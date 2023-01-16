using System;

namespace BaseCom.Validacion
{
 
    public abstract class ValidadorBase<TValidator, TValue> where TValidator : ValidadorBase<TValidator, TValue>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nombreDelCampo"></param>
        /// <param name="objValidador"></param>
        protected ValidadorBase(TValue valor, string nombreDelCampo, Validador objValidador)
        {
            Valor = valor;
            NombreDelCampo = nombreDelCampo;
            ObjValidador = objValidador;
        }


        /// <summary>
        /// devolver el valor de la propiedad
        /// </summary>
        public TValue Valor { get; set; }

        /// <summary>
        /// El nombre del campo probado
        /// </summary>
        public string NombreDelCampo { get; private set; }

        /// <summary>
        /// La referencia a nuestra clase validadora
        /// </summary>
        protected Validador ObjValidador { get; set; }

        /// <summary>
        /// Verdadero  si la siguiente operación de validación debe ser negada
        /// </summary>
        protected bool NegarSiguienteValidacionResultado  { get; set; }

        /// <summary>
        ///El nivel de la siguiente validación con fracaso
        /// </summary>
        protected NivelDeValidacion NextFailureResultLevel = NivelDeValidacion.Error;

        /// <summary>
        ///
        /// </summary>
        protected int? SiguienteCodigoDeError = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="MensajeDeError"></param>
        public void AsignarResultado(bool Resultado, string MensajeDeError)
        {
            AsignarResultado(Resultado, MensajeDeError, 0);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="MensajeDeError"></param>
        /// <param name="CodigoDeError"></param>
        public void AsignarResultado(bool Resultado, string MensajeDeError, int CodigoDeError, string datos="")
        {
            if (Resultado ^ NegarSiguienteValidacionResultado)
                ObjValidador.AgregarErrorDeValidacion(MensajeDeError, NombreDelCampo, NextFailureResultLevel,SiguienteCodigoDeError ?? CodigoDeError,datos);

            NegarSiguienteValidacionResultado = false;
            NextFailureResultLevel = NivelDeValidacion.Error;
            SiguienteCodigoDeError = null;
        }


        /// <summary>
        /// Permite una validación personalizada que se realiza en el valor. Llamar utilizando un
        /// expresión lambda. se debe suministrar  un mensaje de error .
        /// </summary>
        /// <param name="Predicado">Función de predicado que debe devolver true si la prueba de validación es continuar , y falso si no</param>
        /// <param name="MensajeDeError"></param>
        /// <returns></returns>
        public TValidator Is(Predicate<TValue> Predicado, string MensajeDeError)
        {
            AsignarResultado(!Predicado(Valor), MensajeDeError);
            return (TValidator)this;
        }


        /// <summary>
        /// Niega la siguiente comprobación de validación
        /// </summary>
        /// <returns></returns>
        public TValidator Not()
        {
            NegarSiguienteValidacionResultado = true;
            return (TValidator)this;
        }


        /// <summary>
        /// Establece el nivel del siguiente resultado de la validación a ser sólo de advertencia , en lugar de error.
        /// </summary>
        /// <returns></returns>
        public TValidator AdvertirAMenosQue()
        {
            NextFailureResultLevel = NivelDeValidacion.Advertencia;
            return (TValidator)this;
        }


        /// <summary>
        /// Establece el código del siguiente resultado de la validación .
        /// </summary>
        /// <returns></returns>
        public TValidator ConElCodigoDeError(int codigo)
        {
            SiguienteCodigoDeError = codigo;
            return (TValidator)this;
        }
    }
}
