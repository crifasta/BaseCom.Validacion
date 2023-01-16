using BaseCom.Validacion.Recursos;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseCom.Validacion
{
    

    public partial class Validador
    {
        
        private readonly IList<ResultadoValidacionReglaDeNegocio> resultadosDeValidacion = new List<ResultadoValidacionReglaDeNegocio>();
    

        public LenguaValidacionEnum lenguaValidacion { get; set; }

        internal string LookupLanguageString(string KeyName, bool Negated)
        {
            return MensajesValidacionSC.obtenerMensaje(KeyName, Negated);
        }

        /// <summary>
        /// 
        /// </summary>
        public Validador()
        {
            Modo = ModoDeValidacion.UnErrorPorCampo;
            lenguaValidacion = LenguaValidacionEnum.Espaniol;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modo"></param>
        public Validador(ModoDeValidacion modo)
        {
               Modo = modo;
            lenguaValidacion = LenguaValidacionEnum.Espaniol;
        }


        /// <summary>
        /// Devuelve una lista de los resultados de la validación .
        /// </summary>
        public IList<ResultadoValidacionReglaDeNegocio> ResultadosDeValidacion
        {
            get { return resultadosDeValidacion; }
        }

        /// <summary>
        /// Indica si solo debemos recoger un error por cada nombre de campo o todos los errores.
        /// </summary>
        public ModoDeValidacion Modo { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public void BorrarErrores()
        {
            resultadosDeValidacion.Clear();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public int CantidadDeErrores()
        {
            return ResultadosDeValidacion.Where(x => x.Nivel == NivelDeValidacion.Error).Count();
        }

        /// <summary>
        ///  .
        /// </summary>
        /// <returns></returns>
        public int CantidadDeAdvertencias()
        {
            return ResultadosDeValidacion.Where(x => x.Nivel == NivelDeValidacion.Advertencia).Count();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HayErrores()
        {
            return CantidadDeErrores() != 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HayAdvertencias()
        {
            return CantidadDeAdvertencias() != 0;
        }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="mensaje"></param>
         /// <param name="campo"></param>
         /// <param name="codigoDeError"></param>
        public void AgregarErrorDeValidacion(string mensaje, string campo, int codigoDeError)
        {
            AgregarErrorDeValidacion(mensaje, campo, NivelDeValidacion.Error, codigoDeError);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="campo"></param>
        /// <param name="nivel"></param>
        /// <param name="codigoDeError"></param>
        public void AgregarErrorDeValidacion(string mensaje, string campo, NivelDeValidacion nivel, int codigoDeError, string datos="")
        {
            // ¿Debemos permitir sólo un error por cada nombre de campo ?
            if (Modo == ModoDeValidacion.UnErrorPorCampo)
            {
                // Compruebe si ya existe un error de este nombre de campo
                foreach (var Error in resultadosDeValidacion)
                    if (Error.CampoValidado == campo)
                        return;
            }

            // Si hemos llegado hasta aquí , agregar el nuevo elemento .
            resultadosDeValidacion.Add(new ResultadoValidacionReglaDeNegocio(mensaje, campo, nivel, codigoDeError, datos));
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObtenerListaDeMensajesDeErrores()
        {
            StringBuilder sb = new StringBuilder();

            IList<ResultadoValidacionReglaDeNegocio> Results = resultadosDeValidacion;

            foreach (ResultadoValidacionReglaDeNegocio vr in Results)
            {
                sb.AppendLine(vr.Mensaje);

            }
            return sb.ToString();

        }

       
        

    }
}
