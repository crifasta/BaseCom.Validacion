
using System;

namespace BaseCom.Validacion
{
    /// <summary>
    /// Se utiliza para las validaciones simples
    /// </summary>      
    public sealed class Guard
    {

        /// <summary>
        /// Compruebe que la condición es verdadera 
        /// </summary>
        /// <param name="expression"></param>
        public static void IsTrue(bool condition)
        {
            if (condition == false)
            {
                throw new ArgumentException("La condición es falsa suministrada");
            }
        }


        /// <summary>
        /// Compruebe que la condición es verdadero y  retorna  mensaje proporcionado .
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void IsTrue(bool condition, String message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }


        /// <summary>
        ///Compruebe que la condición es falsa .
        /// </summary>
        /// <param name="expression"></param>
        public static void IsFalse(bool condition)
        {
            if (condition)
            {
                throw new ArgumentException("La condición suministrada es verdadera");
            }
        }


        /// <summary>
        /// Compruebe que la condición es falsa y  retorna  mensaje proporcionado .
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void IsFalse(bool condition, String message)
        {
            if (condition)
            {
                throw new ArgumentException(message);
            }
        }


        /// <summary>
        /// Compruebe que el objeto suministrado no es nulo y lanzar una excepción
        /// con el mensaje proporcionado .
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public static void IsNotNull(Object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }


        /// <summary>
        /// Compruebe que el objeto proporcionado no es nulo.
        /// </summary>
        /// <param name="obj"></param>
        public static void IsNotNull(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("El argumento proporcionado no puede ser nulo.");
            }
        }


        /// <summary>
        /// Compruebe que el objeto suministrado es excepción nula y tiro
       ///con el mensaje proporcionado .
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public static void IsNull(Object obj, string message)
        {
            if (obj != null)
            {
                throw new ArgumentNullException(message);
            }
        }


        /// <summary>
        /// Compruebe que el objeto proporcionado es nulo.
        /// </summary>
        /// <param name="obj"></param>
        public static void IsNull(Object obj)
        {
            if (obj != null)
            {
                throw new ArgumentNullException("El argumento proporcionado no puede ser nulo.");
            }
        }
    }
}
