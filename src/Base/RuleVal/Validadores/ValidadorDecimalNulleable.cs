namespace BaseCom.Validacion
{

    public class ValidadorDecimalNulleable : ValidadorBase<ValidadorDecimalNulleable, decimal?>
    {
        public static ValidadorDecimalNulleable Create(decimal? valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDecimalNulleable(valor, nombreDelCampo, validatorObj);
        }

        public ValidadorDecimalNulleable(decimal? valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
        public ValidadorDecimalNulleable ValorAsignado(string mensajeDeError = "El valor de {0} no puede ser nulo")
        {
            bool resultado = !Valor.HasValue;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.intIsNull);

            return this;
        }

        public ValidadorDecimalNulleable ValorMayorA(string mensajeDeError = "El valor de {0} debe ser mayor a {1}", decimal? valorComparacion = 0)
        {
            bool resultado = !Valor.HasValue && !valorComparacion.HasValue;

            if(resultado)
            {
                resultado = !(Valor > valorComparacion.Value);
            }

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorComparacion.Value.ToString()), CodigosDeError.NumericIsGreaterThanOrEqual);

            return this;
        }


    }
}
