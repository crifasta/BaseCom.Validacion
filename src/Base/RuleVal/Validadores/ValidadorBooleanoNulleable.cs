namespace BaseCom.Validacion
{
    public class ValidadorBooleanoNulleable : ValidadorBase<ValidadorBooleanoNulleable, bool?>
    {
      
        public ValidadorBooleanoNulleable(bool valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        /// <summary>
        /// verifica si el valor es verdadero
        /// </summary>
        public ValidadorBooleanoNulleable EsVerdadero(string mensajeDeError)
        {
            AsignarResultado(!Valor.Value, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.BoolIsNotTrue);
            return this;
        }
        

        /// <summary>
        /// verifica si el valor es verdadero
        /// </summary>
        /// <returns></returns>
        public ValidadorBooleanoNulleable EsVerdadero()
        {
            EsVerdadero("El campo debe ser verdadero");
            
            return this;
        }

        /// <summary>
        /// verifica si el valor es  falso
        /// </summary>
        public ValidadorBooleanoNulleable EsFalso(string mensajeDeError)
        {
            AsignarResultado(Valor.Value, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.BoolIsNotFalse);
            return this;
        }

        /// <summary>
        /// verifica si el valor es  falso
        /// </summary>
        public ValidadorBooleanoNulleable EsFalso()
        {
            EsFalso("El campo debe ser falso");
            return this;
        }
    }
}
