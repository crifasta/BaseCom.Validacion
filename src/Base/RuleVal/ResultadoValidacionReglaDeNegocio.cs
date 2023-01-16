namespace BaseCom.Validacion
{
   public  class ResultadoValidacionReglaDeNegocio
    {
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="campoValidado"></param>
        /// <param name="nivelDeValidacion"></param>
        /// <param name="codigoDeError"></param>
        public ResultadoValidacionReglaDeNegocio(string mensaje, string campoValidado, NivelDeValidacion nivelDeValidacion, int codigoDeError, string datos)
        {
            Mensaje = mensaje;
            CampoValidado = campoValidado;
            Nivel = nivelDeValidacion;
            CodigoDeError = codigoDeError;
            Datos = datos;
        }

        /// <summary>
        /// el mensaje de error
        /// </summary>
        public string Mensaje { get; private set; }

        /// <summary>
        /// El nombre del campo que provocó el error
        /// </summary>
        public string CampoValidado { get; private set; }

        /// <summary>
        ///  
        /// </summary>
        public NivelDeValidacion Nivel { get; private set; }

        /// <summary>
        ///  
        /// </summary>
        public int CodigoDeError { get; private set; }


        public string Datos { get; set; }
    }
}
