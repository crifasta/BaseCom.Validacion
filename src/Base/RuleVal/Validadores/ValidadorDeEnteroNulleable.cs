namespace BaseCom.Validacion
{

    public class ValidadorDeEnteroNulleable : ValidadorBase<ValidadorDeEnteroNulleable, int?>
    {
        public static ValidadorDeEnteroNulleable Create(int? valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDeEnteroNulleable(valor, nombreDelCampo, validatorObj);
        }

        public ValidadorDeEnteroNulleable(int? valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
        public ValidadorDeEnteroNulleable ValorAsignado(string mensajeDeError = "Debe seleccionar un valor para el campo {0}")
        {
            bool resultado = !Valor.HasValue;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.intIsNull);

            return this;
        }

        public ValidadorDeEnteroNulleable ValorMayorA(string mensajeDeError = "El valor de {0} debe ser mayor a {1}", int? valorComparacion = 0)
        {
            bool resultado = Valor.HasValue && valorComparacion.HasValue;

            if (resultado)
            {
                resultado = !(Valor > valorComparacion.Value);
            }

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorComparacion.Value.ToString()), CodigosDeError.NumericIsGreaterThanOrEqual);

            return this;
        }

        //public ValidadorDeEnteroNulleable ElValorNoPuedeSerMayorA(int comparador)
        //{
        //    return ElValorNoPuedeSerMayorA("El valor de '{0}' no puede ser mayor a {1}", comparador);
        //}

        //public ValidadorDeEnteroNulleable ElValorNoPuedeSerMayorA(string mensajeDeError, int comparador)
        //{

        //    AsignarResultado(Valor > comparador, string.Format(mensajeDeError, NombreDelCampo, comparador.ToString()), CodigosDeError.DateIsNotAFutureDate);
        //    return this;
        //}


        //public ValidadorDeEnteroNulleable ElValorNoPuedeSerMenorA(int comparador)
        //{
        //    return ElValorNoPuedeSerMenorA("El valor de {0} no puede ser menor a {1}",comparador);
        //}

        //public ValidadorDeEnteroNulleable ElValorNoPuedeSerMenorA(string mensajeDeError, int comparador)
        //{
        //    AsignarResultado(Valor.Value < comparador, string.Format(mensajeDeError, NombreDelCampo, comparador.ToString()));
        //    return this;
        //}

        //public ValidadorDeEnteroNulleable ElValorDebeEstarDentroDe(string mensajeDeError, int inicio, int fin)
        //{
        //    AsignarResultado(Valor >= inicio && Valor <= fin, 

        //        string.Format("El valor de {0} debe estar entre {1} y {2}", NombreDelCampo, inicio.ToString(), fin.ToString())
        //        , CodigosDeError.GenericErrror);
        //    return this;
        //}


        //public ValidadorDeEnteroNulleable LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, int sumaDeValores)
        //{
        //    AsignarResultado(this.Valor == sumaDeValores, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.GenericErrror);
        //    return this;
        //}

        //public ValidadorDeEnteroNulleable LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, List<int> comparadores)
        //{
        //    int suma = 0;
        //    foreach (int item in comparadores)
        //    {
        //        suma += item;
        //    }
        //    AsignarResultado(this.Valor == suma, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.GenericErrror);
        //    return this;
        //}






    }
}
