//using BaseCom.Models;

//namespace BaseCom.Validacion
//{
//    public static class ValidadorExt
//    {
//        public static ResultadoDeAccion AsginarValidacion(this Validador validador)
//        {
//            ResultadoDeAccion res = new ResultadoDeAccion();
//            if (validador.HayErrores())
//            {
        
//                res.AsignarResultado(false, CodigoResultadoEnum.Cancelado,CodigoResultadoEnum.Cancelado.ToString(), validador.ObtenerListaDeMensajesDeErrores());
//                res.MostrarMensaje = true;
//                res.ContinuarEjecucion = false;
//            }
//            return res;
//        }
//    }
//}
