using System.Collections.Generic;

namespace BaseCom.Validacion
{
    public class ValidadorDecimal : ValidadorBase<ValidadorDecimal, decimal>
    {
        
        public ValidadorDecimal(decimal valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }
        public static ValidadorDecimal Create(decimal valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDecimal(valor, nombreDelCampo, validatorObj);
        }



        public ValidadorDecimal ElValorNoPuedeSerMayorA(int comparador)
        {
            return ElValorNoPuedeSerMayorA("El valor de '{0}' no puede ser mayor a {1}", comparador);
        }

        public ValidadorDecimal ElValorNoPuedeSerMayorA(string mensajeDeError, decimal comparador)
        {
            AsignarResultado(Valor > comparador, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNotAFutureDate);
            return this;
        }


        public ValidadorDecimal ElValorNoPuedeSerMenorA(int comparador)
        {
            return ElValorNoPuedeSerMenorA("El valor de {0} no puede ser menor a {1}", comparador);
        }

        public ValidadorDecimal ElValorNoPuedeSerMenorA(string mensajeDeError, decimal comparador)
        {
            AsignarResultado(Valor < comparador, string.Format(mensajeDeError, NombreDelCampo, comparador), CodigosDeError.DateIsNotAFutureDate);
            return this;
        }

        public ValidadorDecimal ElValorDebeEstarDentroDe(string mensajeDeError, decimal inicio, decimal fin)
        {
            AsignarResultado(Valor >= inicio && Valor <= fin,

               string.Format("El valor de {0} debe estar entre {1} y {2}", NombreDelCampo, inicio.ToString(), fin.ToString()), CodigosDeError.GenericErrror);
            return this;
        }


        public ValidadorDecimal LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, int sumaDeValores)
        {
            AsignarResultado(this.Valor == sumaDeValores, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.GenericErrror);
            return this;
        }

        public ValidadorDecimal LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, List<decimal> comparadores)
        {
            int suma = 0;
            foreach (int item in comparadores)
            {
                suma += item;
            }
            AsignarResultado(this.Valor == suma, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.GenericErrror);
            return this;
        }
    }
}
