using System.Collections.Generic;

namespace BaseCom.Validacion
{

    public class ValidadorDeEntero : ValidadorBase<ValidadorDeEntero, int>
    {
        public static ValidadorDeEntero Create(int valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDeEntero(valor, nombreDelCampo, validatorObj);
        }

        public ValidadorDeEntero(int valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        public ValidadorDeEntero ElValorNoPuedeSerMayorA(int comparador)
        {
            return ElValorNoPuedeSerMayorA("El valor de '{0}' no puede ser mayor a {1}", comparador);
        }

        public ValidadorDeEntero ElValorNoPuedeSerMayorA(string mensajeDeError, int comparador)
        {
            AsignarResultado(Valor > comparador, string.Format(mensajeDeError, NombreDelCampo, comparador.ToString()), CodigosDeError.DateIsNotAFutureDate);
            return this;
        }


        public ValidadorDeEntero ElValorNoPuedeSerMenorA(int comparador)
        {
            return ElValorNoPuedeSerMenorA("El valor de {0} no puede ser menor a {1}",comparador);
        }

        public ValidadorDeEntero ElValorNoPuedeSerMenorA(string mensajeDeError, int comparador)
        {
            AsignarResultado(Valor < comparador, string.Format(mensajeDeError, NombreDelCampo, comparador.ToString()));
            return this;
        }

        public ValidadorDeEntero ElValorDebeEstarDentroDe(string mensajeDeError, int inicio, int fin)
        {
            AsignarResultado(Valor >= inicio && Valor <= fin, 
                
                string.Format("El valor de {0} debe estar entre {1} y {2}", NombreDelCampo, inicio.ToString(), fin.ToString())
                , CodigosDeError.GenericErrror);
            return this;
        }


        public ValidadorDeEntero LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, int sumaDeValores)
        {
            AsignarResultado(this.Valor == sumaDeValores, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.GenericErrror);
            return this;
        }

        public ValidadorDeEntero LaSumaDeLosValoresDebenSerIgualesAlValorDelCampo(string mensajeDeError, List<int> comparadores)
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
