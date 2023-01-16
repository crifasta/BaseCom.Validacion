using System;

namespace BaseCom.Validacion
{
 
   public class ValidadorDeFecha : ValidadorBase<ValidadorDeFecha, DateTime>
   {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="valor"></param>
       /// <param name="nombreDelCampo"></param>
       /// <param name="validatorObj"></param>
       public ValidadorDeFecha(DateTime valor, string nombreDelCampo, Validador validatorObj)
           : base(valor, nombreDelCampo, validatorObj)
       {
       }
        public static ValidadorDeFecha Create(DateTime valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDeFecha(valor, nombreDelCampo, validatorObj);
        }


        /// <summary>
        /// Comprueba que la fecha provista no está en el futuro
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
        public ValidadorDeFecha NoDebeSerUnaFechaFutura(string mensajeDeError)
       {
           bool resultado = Valor > DateTime.Now;

           AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNotAFutureDate);

           return this;
       }

       /// <summary>
       /// Comprueba que la fecha prevista no está en el futuro
       /// </summary>
       /// <returns>DateValidator</returns>
       public ValidadorDeFecha NoDebeSerUnaFechaFutura()
       {
           NoDebeSerUnaFechaFutura("La fecha del campo {0} no puede ser posterior a la fecha actual");
           return this;
       }


        /// <summary>
       /// Comprueba que la fecha provista no está en el pasado 
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
       public ValidadorDeFecha NoEsUnaFechaPasada(string mensajeDeError)
       {
           bool resultado = Valor < DateTime.Now;
           AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNotAPastDate);
           return this;
       }

       /// <summary>
       ///Comprueba que la fecha prevista no está en el pasado
       /// </summary>
       /// <returns>DateValidator</returns>
       public ValidadorDeFecha NoEsUnaFechaPasada()
       {
           NoEsUnaFechaPasada(string.Format("La fecha del campo {0} no puede ser anterior a la fecha actual",this.NombreDelCampo));
           return this;
       }

     

       /// <summary>
       /// Comprueba si la fecha es anterior
       /// </summary>
        public ValidadorDeFecha DebeSerAnteriorA(DateTime fechaATestear, string mensajeDeError)
       {
           bool resultado = Valor >= fechaATestear;

           AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, fechaATestear), CodigosDeError.DateIsEarlierThan);

           return this;
       }

       /// <summary>
       /// Comprueba si la fecha es anterior
       /// </summary>
        public ValidadorDeFecha DebeSerAnteriorA(DateTime fechaATestear)
       {
           DebeSerAnteriorA(fechaATestear, "La fecha del campo '{0}' debe  ser anterior a {1}");
           return this;
       }



       public ValidadorDeFecha DebeSerEsteAnio()
       {
           DebeSerEsteAnio(DateTime.Now.Year);
           return this;
       }


       public ValidadorDeFecha DebeSerEsteAnio(int anio)
       {
           bool valida = this.Valor.Year == anio;
           //EsAnteriorA(fechaATestear, "La fecha del campo {0} no puede ser anterior a {1}");
           return this;
       }

        
        
   }
}
