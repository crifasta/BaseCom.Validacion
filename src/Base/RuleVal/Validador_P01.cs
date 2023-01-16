using System;

namespace BaseCom.Validacion
{

    public partial class Validador
    {
        /// <summary>
        /// validar un tipo string
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <returns></returns>
        public ValidadorString Validar(string valor, string nombreDelCampo)
        {
            return new ValidadorString(valor, nombreDelCampo, this);
        }


        /// <summary>
        /// validar un tipo boolean 
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <returns></returns>
        public ValidadorBooleano Validar(bool valor, string nombreDelCampo)
        {
            return new ValidadorBooleano(valor, nombreDelCampo, this);
        }

        /// <summary>
        /// validar un tipo Decimal
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <returns></returns>
        public ValidadorDecimal Validar(decimal valor, string nombreDelCampo)
        {
            return new ValidadorDecimal(valor, nombreDelCampo, this);
        }
        public ValidadorDecimalNulleable Validar(decimal? valor, string nombreDelCampo)
        {
            return new ValidadorDecimalNulleable(valor, nombreDelCampo, this);
        }
        /// <summary>
        /// validar un tipo Entero
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <returns></returns>
        public ValidadorDeEntero Validar(int valor, string nombreDelCampo)
        {
            return new ValidadorDeEntero(valor, nombreDelCampo, this);
        }

        public ValidadorDeEnteroNulleable Validar(int? valor, string nombreDelCampo)
        {
            return new ValidadorDeEnteroNulleable(valor, nombreDelCampo, this);
        }

        /// <summary>
        ///  validar un objeto DateTime.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <returns></returns>
        public ValidadorDeFecha Validar(DateTime valor, string nombreDelCampo)
        {
            return new ValidadorDeFecha(valor, nombreDelCampo, this);
        }


        public ValidadorDeFechaNulleable Validar(DateTime? valor, string nombreDelCampo)
        {
            return new ValidadorDeFechaNulleable(valor, nombreDelCampo, this);
        }

         

        
    }
}
