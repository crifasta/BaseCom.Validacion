using System.Collections.Generic;

namespace BaseCom.Validacion.Recursos
{
    public  class MensajesValidacionSC
    {
        private static MensajesValidacion mmv = null;

        public static string obtenerMensaje(string KeyName, bool Negated)
        {
            if (mmv == null) mmv = new MensajesValidacion();

            return mmv.ObtenerMensaje(KeyName, Negated);

        }

    
    }

   public class MensajesValidacion
    {
       public Dictionary<string, string> ListaDeMensajes { get; internal set; }

       public string ObtenerMensaje(string clave)
       {
           return ObtenerMensaje(clave, false);
       }


       public string ObtenerMensaje(string clave, bool negado)
       {
           string nombre = negado ? "not_" + clave : clave;

           foreach (KeyValuePair<string, string> pair in ListaDeMensajes)
           {
               if (pair.Key == clave) return pair.Value;
           }
           //return ListaDeMensajes.First() .Find((x => x.Nombre.Equals(nombre))).Valor;
           return string.Empty;
       }


       public MensajesValidacion()
       { 
       
            ObtenerListaDeMensajes();
       
       }
      

       private void ObtenerListaDeMensajes()
       {
           ListaDeMensajes = new Dictionary<string, string>();
           ListaDeMensajes.Add("int_IsLessThanOrEqual", "{0} debe ser menor que o igual a{1}");
           ListaDeMensajes.Add("int_IsLessThan",  "{0} debe ser inferior a {1}");
           ListaDeMensajes.Add("int_IsGreaterThanOrEqual",  "{0} debe ser mayor o igual que {1}");
           ListaDeMensajes.Add("int_IsGreaterThan",  "{0} debe ser mayor que{1}");
           ListaDeMensajes.Add("int_Equals",  "{0} debe ser {1}");
           ListaDeMensajes.Add("int_Between",  "{0} debe estar entre { 1 } y { 2 }");
           ListaDeMensajes.Add("int_IsZero",  "{0} debe ser cero");
           ListaDeMensajes.Add("string_IsEmpty",  "{0} Dębe Estar Vacío");
           ListaDeMensajes.Add("string_IsNull",  "{0} debe ser nulo");
           ListaDeMensajes.Add("string_IsNullOrEmpty",  "{0} must be null or empty");
           ListaDeMensajes.Add("string_IsLongerThan",  "{0} is too short (min {1} characters)");
           ListaDeMensajes.Add("string_IsShorterThan",  "{0} is too long (max {1} characters)");
           ListaDeMensajes.Add("string_IsEmail",  "'{0}' is not a valid email address");
           ListaDeMensajes.Add("string_IsURL",  "'{0}' is not a valid URL");
           ListaDeMensajes.Add("string_IsDate",  "'{0}' is not a valid date");
           ListaDeMensajes.Add("string_IsInteger",  "'{0}' is not a valid integer value");
           ListaDeMensajes.Add("string_IsLong",  "'{0}' is not a valid integer value");
           ListaDeMensajes.Add("string_IsDecimal",  "'{0}' is not a valid decimal value");
           ListaDeMensajes.Add("string_HasALengthBetween",  "'{0}' must have a length between {1} and {2} characters");
           ListaDeMensajes.Add("string_StartsWith",  "'{0}' must start with '{1}'");
           ListaDeMensajes.Add("string_EndsWith",  "'{0}' must end with '{1}'");
           ListaDeMensajes.Add("string_Contains",  "'{0}' debe contener '{1}'");
           ListaDeMensajes.Add("string_IsLength",  "'{0}' must consist of '{1}' characters");
           ListaDeMensajes.Add("date_IsNotAFutureDate",  "'{0}' must not be in the future");
           ListaDeMensajes.Add("date_IsNotAPastDate",  "'{0}' must not beller je in the past");
           ListaDeMensajes.Add("date_IsNotMinMaxValue",  "'{0}' must not be a minimum or maximum value");
           ListaDeMensajes.Add("date_IsLaterThan",  "'{0}' must be later than {1}");
           ListaDeMensajes.Add("date_IsEarlierThan",  "'{0}' must be earlier than {1}");
           ListaDeMensajes.Add("bool_IsTrue",  "'{0}' must be true");
           ListaDeMensajes.Add("bool_IsFalse",  "'{0}' must be false");
           ListaDeMensajes.Add("not_int_IsLessThanOrEqual",  "{0} must not be less than or equal to {1}");
           ListaDeMensajes.Add("not_int_IsLessThan",  "{0} must not be less than {1}");
           ListaDeMensajes.Add("not_int_IsGreaterThanOrEqual",  "{0} must not be greater than or equal to {1}");
           ListaDeMensajes.Add("not_int_IsGreaterThan",  "{0} must not be greater than {1}");
           ListaDeMensajes.Add("not_int_Equals",  "{0} must not be {1}");
           ListaDeMensajes.Add("not_int_Between",  "{0} must not be between {1} and {2}");
           ListaDeMensajes.Add("not_int_IsZero",  "{0} must not be zero");
           ListaDeMensajes.Add("not_string_IsEmpty",  "{0} must not be empty");
           ListaDeMensajes.Add("not_string_IsNull",  "{0} must not be null");
           ListaDeMensajes.Add("not_string_IsNullOrEmpty",  "{0} must not be null or empty");
           ListaDeMensajes.Add("not_string_IsLongerThan",  "{0} is too long (max {1} characters)");
           ListaDeMensajes.Add("not_string_IsShorterThan",  "{0} is too short (min {1} characters)");
           ListaDeMensajes.Add("not_string_IsEmail",  "'{0}' can not be an email address");
           ListaDeMensajes.Add("not_string_IsURL",  "'{0}' can not be an URL");
           ListaDeMensajes.Add("not_string_IsDate",  "'{0}' can not be a date");
           ListaDeMensajes.Add("not_string_IsInteger",  "'{0}' can not be an integer value");
           ListaDeMensajes.Add("not_string_IsLong",  "'{0}' can not be an integer value");
           ListaDeMensajes.Add("not_string_IsDecimal",  "'{0}' can not be a decimal value");
           ListaDeMensajes.Add("not_string_HasALengthBetween",  "'{0}' cannot have a length between {1} and {2} characters");
           ListaDeMensajes.Add("not_string_StartsWith",  "'{0}' must not start with '{1}'");
           ListaDeMensajes.Add("not_string_EndsWith",  "'{0}' must not end with '{1}'");
           ListaDeMensajes.Add("not_string_Contains",  "'{0}' must not contain '{1}'");
           ListaDeMensajes.Add("not_string_IsLength",  "'{0}' must not consist of '{1}' characters");
           ListaDeMensajes.Add("not_date_IsNotAFutureDate",  "'{0}' must be in the future");
           ListaDeMensajes.Add("not_date_IsNotAPastDate",  "'{0}' must be in the past");
           ListaDeMensajes.Add("not_date_IsNotMinMaxValue",  "'{0}' must be either a minimum or maximum value");
           ListaDeMensajes.Add("not_date_IsLaterThan",  "'{0}' must not be later than {1}");
           ListaDeMensajes.Add("not_date_IsEarlierThan",  "'{0}' must not be earlier than {1}");
           ListaDeMensajes.Add("not_bool_IsTrue",  "'{0}' must not be true");
           ListaDeMensajes.Add("not_bool_IsFalse", "'{0}' must not be false");
       }
        
    }
}
