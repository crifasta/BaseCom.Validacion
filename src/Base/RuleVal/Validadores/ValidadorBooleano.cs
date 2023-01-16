namespace BaseCom.Validacion
{
    public class ValidadorBooleano :ValidadorBase<ValidadorBooleano, bool>
    {
      
        public ValidadorBooleano(bool valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        public static ValidadorBooleano Create(bool valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorBooleano(valor, nombreDelCampo, validatorObj);
        }

        /// <summary>
        /// verifica si el valor es verdadero
        /// </summary>
        public ValidadorBooleano EsVerdadero(string mensajeDeError)
        {
            AsignarResultado(!Valor, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.BoolIsNotTrue);
            return this;
        }




        /// <summary>
        /// verifica si el valor es verdadero
        /// </summary>
        /// <returns></returns>
        public ValidadorBooleano EsVerdadero()
        {
            EsVerdadero("El campo debe ser verdadero");
            
            return this;
        }

        /// <summary>
        /// verifica si el valor es  falso
        /// </summary>
        public ValidadorBooleano EsFalso(string mensajeDeError)
        {
            AsignarResultado(Valor, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.BoolIsNotFalse);
            return this;
        }

        /// <summary>
        /// verifica si el valor es  falso
        /// </summary>
        public ValidadorBooleano EsFalso()
        {
            EsFalso("El campo debe ser falso");
            return this;
        }
    }
}
