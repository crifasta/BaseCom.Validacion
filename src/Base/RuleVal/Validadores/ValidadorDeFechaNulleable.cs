using System;

namespace BaseCom.Validacion
{
 
   public class ValidadorDeFechaNulleable : ValidadorBase<ValidadorDeFechaNulleable, DateTime?>
   {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="valor"></param>
       /// <param name="nombreDelCampo"></param>
       /// <param name="validatorObj"></param>
       public ValidadorDeFechaNulleable(DateTime? valor, string nombreDelCampo, Validador validatorObj)
           : base(valor, nombreDelCampo, validatorObj)
       {
       }
        public static ValidadorDeFechaNulleable Create(DateTime? valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorDeFechaNulleable(valor, nombreDelCampo, validatorObj);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
        public ValidadorDeFechaNulleable ValorAsignado(string mensajeDeError ="Fecha No Asignada")
        {
            bool resultado = Valor.HasValue;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNull);

            return this;
        }


        /// <summary>
        /// Comprueba que la fecha provista no está en el futuro
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
        public ValidadorDeFechaNulleable NoDebeSerUnaFechaFutura(string mensajeDeError)
       {
            bool resultado = false;
            if (Valor.HasValue)
            {
                resultado = Valor.Value > DateTime.Now;
                AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNotAFutureDate);
            }
            else
            {
                resultado = Valor.HasValue;
                AsignarResultado(resultado, "Fecha no asignada", CodigosDeError.DateIsNull);
            }        

           return this;
       }

       /// <summary>
       /// Comprueba que la fecha prevista no está en el futuro
       /// </summary>
       /// <returns>DateValidator</returns>
       public ValidadorDeFechaNulleable NoDebeSerUnaFechaFutura()
       {
           NoDebeSerUnaFechaFutura("La fecha del campo {0} no puede ser posterior a la fecha actual");
           return this;
       }


        /// <summary>
       /// Comprueba que la fecha provista no está en el pasado 
        /// </summary>
        /// <param name="mensajeDeError"></param>
        /// <returns></returns>
       public ValidadorDeFechaNulleable NoEsUnaFechaPasada(string mensajeDeError)
        {
            bool resultado = false;

            if (Valor.HasValue)
            {
                resultado = Valor.Value < DateTime.Now;
                AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.DateIsNotAPastDate);
            }
            else
            {
                resultado = Valor.HasValue;
                AsignarResultado(resultado, "Fecha no asignada", CodigosDeError.DateIsNull);
            }

          
           return this;
       }

       /// <summary>
       ///Comprueba que la fecha prevista no está en el pasado
       /// </summary>
       /// <returns>DateValidator</returns>
       public ValidadorDeFechaNulleable NoEsUnaFechaPasada()
       {
           NoEsUnaFechaPasada(string.Format("La fecha del campo {0} no puede ser anterior a la fecha actual",this.NombreDelCampo));
           return this;
       }

     

       /// <summary>
       /// Comprueba si la fecha es anterior
       /// </summary>
        public ValidadorDeFechaNulleable DebeSerAnteriorA(DateTime fechaATestear, string mensajeDeError)
       {

            bool resultado = false;

            if (Valor.HasValue)
            {
                resultado = Valor.Value >= fechaATestear;

                AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, fechaATestear), CodigosDeError.DateIsEarlierThan);
            }
            else
            {
                resultado = Valor.HasValue;
                AsignarResultado(resultado, "Fecha no asignada", CodigosDeError.DateIsNull);
            }

            return this;
        }

       /// <summary>
       /// Comprueba si la fecha es anterior
       /// </summary>
        public ValidadorDeFechaNulleable DebeSerAnteriorA(DateTime fechaATestear)
       {
           DebeSerAnteriorA(fechaATestear, "La fecha del campo '{0}' debe  ser anterior a {1}");
           return this;
       }



       public ValidadorDeFechaNulleable DebeSerEsteAnio()
       {
           DebeSerEsteAnio(DateTime.Now.Year);
           return this;
       }


       public ValidadorDeFechaNulleable DebeSerEsteAnio(int anio, string mensajeDeError ="La fecha no corresponde al año actual")
       {
            bool resultado = false;

            if (Valor.HasValue)
            {
                resultado   = this.Valor.Value.Year == anio;

                AsignarResultado(resultado, mensajeDeError, CodigosDeError.DateIsEarlierThan);
            }
            else
            {
                resultado = Valor.HasValue;
                AsignarResultado(resultado, "Fecha no asignada", CodigosDeError.DateIsNull);
            }

            return this;

        }

        
        
   }
}
