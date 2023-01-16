using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace BaseCom.Validacion
{

    internal class ArchivoDeRecursosDeLengua : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resourceFile"></param>
        public ArchivoDeRecursosDeLengua(string resourceFile)
        {
            ResourceFile = resourceFile;
        }

        /// <summary>
        /// The name of the langauge resource file
        /// </summary>
        public string ResourceFile { get; private set; }
    }

 

    internal class LangCache
    {
        /// <summary>
        /// A cache that contains all the words in the system
        /// </summary>
        private static Dictionary<string, string> WordCache = new Dictionary<string, string>();

        /// <summary>
        /// A cache that keeps track of what languages that we have loaded into our static cache.
        /// </summary>
        private static Dictionary<LenguaValidacionEnum, bool> LoadedLanguagesCache = new Dictionary<LenguaValidacionEnum, bool>();

        /// <summary>
        /// Our lock that we use to make this class thread safe
        /// </summary>
        private static ReaderWriterLock RWLock = new ReaderWriterLock();

        /// ******************************************************************
        /// <summary>
        /// Fetch an item from the language defintion XML files.
        /// 
        /// Also caches the result
        /// </summary>
        /// <param name="ValidationLanguage">The desired language to retrieve from</param>
        /// <param name="StringKey">The string identifier</param>
        /// <returns>Returns "" if not found</returns>
        public static string FetchItem(LenguaValidacionEnum ValidationLanguage, string StringKey)
        {
            string CacheKey = ValidationLanguage.ToString() + ":" + StringKey;
            string CacheEntry;

            // First, see if the item already exists in the cache
            RWLock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                if (LoadedLanguagesCache.Keys.Contains(ValidationLanguage))
                {
                    // The requested language has been loaded, lets get it from the words cache
                    WordCache.TryGetValue(CacheKey, out CacheEntry);
                    return CacheEntry;
                }
            }
            finally
            {
                RWLock.ReleaseReaderLock();
            }

            // Not found in the cache; parse the XML document and insert the records into
            // the cache
            RWLock.UpgradeToWriterLock(Timeout.Infinite);
            try
            {
                // Extra check to avoid threading issues.
                if (LoadedLanguagesCache.Keys.Contains(ValidationLanguage))
                {
                    //The requested language has been loaded, lets get it from the word cache
                    WordCache.TryGetValue(CacheKey, out CacheEntry);
                    return CacheEntry;
                }

                //Populate the WordCache with the words from the XML document
                LoadLanguageDefinition(ValidationLanguage);

                //Now try to get the desired word. 
                WordCache.TryGetValue(CacheKey, out CacheEntry);
                return CacheEntry;
            }
            finally
            {
                RWLock.ReleaseLock();
            }
        }

        /// *****************************************************************
        /// <summary>
        /// Load the entire language definition XML file into the LanguageDict 
        /// dictionary. LanguageDict acts like a cache/lookup-table for all the 
        /// language strings.
        /// </summary>
        /// <param name="ValidationLanguage"></param>
        private static void LoadLanguageDefinition(LenguaValidacionEnum ValidationLanguage)
        {
            // Grab value of resource file name attribute.
            var Type = ValidationLanguage.GetType();
            var FieldInfo = Type.GetField(ValidationLanguage.ToString());
            var Attribs = FieldInfo.GetCustomAttributes(typeof(ArchivoDeRecursosDeLengua), false) as ArchivoDeRecursosDeLengua[];
            if (Attribs.Length != 1)
                throw new Exception("No language specified for Validation Language " + ValidationLanguage.ToString());
            var ResourceFileName = Attribs[0].ResourceFile;

            // Load the language defintion file into an XML document
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream LanguageStream = a.GetManifestResourceStream(ResourceFileName))
            {
                if (LanguageStream != null)
                {
                    StreamReader sr = new StreamReader(LanguageStream);
                    XDocument LangDefXMLDoc = XDocument.Load(sr);

                    //Populate the LanguageDict with all the language definitions found in the XML file
                    var Entries = (from E in LangDefXMLDoc.Elements().Elements()
                                   select E).ToList();

                    foreach (var entry in Entries)
                    {
                        string EntryName = entry.Attribute("name").Value.ToString().Trim();
                        string CacheKey = ValidationLanguage.ToString() + ":" + EntryName;
                        if (!WordCache.Keys.Contains(CacheKey))
                            WordCache.Add(CacheKey, entry.Value.Trim());
                        else
                            throw new ApplicationException("Duplicate '" + EntryName +
                                                           "' entry in the language definition xml file '" +
                                                           ResourceFileName + "'");
                    }

                    //Mark this language as loaded
                    LoadedLanguagesCache.Add(ValidationLanguage, true);
                }
            }
        }
    }
}
