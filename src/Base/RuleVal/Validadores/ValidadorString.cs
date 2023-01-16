using BaseCom.Validacion.Extensores;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BaseCom.Validacion
{
    public class ValidadorString : ValidadorBase<ValidadorString, string>
    {
        public ValidadorString(string valor, string nombreDelCampo, Validador validatorObj)
            : base(valor, nombreDelCampo, validatorObj)
        {
        }

        public static ValidadorString Create(string valor, string nombreDelCampo, Validador validatorObj)
        {
            return new ValidadorString(valor, nombreDelCampo, validatorObj);
        }

        private ValidadorString MatchRegex(string RegularExpression, string mensajeDeError)
        {
            Regex Reg = new Regex(RegularExpression);
            AsignarResultado(!Reg.IsMatch(Valor), mensajeDeError, CodigosDeError.StringMatchRegex);
            return this;
        }


        private ValidadorString MatchRegex(string RegularExpression, RegexOptions regexOptions, string mensajeDeError)
        {
            Regex Reg = new Regex(RegularExpression, regexOptions);
            AsignarResultado(!Reg.IsMatch(Valor), mensajeDeError, CodigosDeError.StringMatchRegex);
            return this;
        }

        #region nulos


        public ValidadorString NoPuedeSerVacio(string mensajeDeError, string nombreDelCampo)
        {
            bool resultado = (Valor ?? string.Empty).Length == 0;
            AsignarResultado(resultado, string.Format(mensajeDeError, nombreDelCampo));
            return this;
        }

        public ValidadorString NoPuedeSerVacio(string mensajeDeError)
        {
            bool resultado = (Valor ?? string.Empty).Length == 0;
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo));
            return this;
        }
        
        public ValidadorString NoPuedeSerVacio()
        {
            NoPuedeSerVacio("El campo '{0}' no puede estar vacio");

            return this;
        }



        public ValidadorString NoDebeSerNulo(string mensajeDeError, string nombreDelCampo)
        {
            bool resultado = Valor == null;
            AsignarResultado(resultado, string.Format(mensajeDeError, nombreDelCampo), CodigosDeError.StringIsNull);
            return this;
        }

        public ValidadorString NoDebeSerNulo(string mensajeDeError)
        {
            bool resultado = Valor == null;
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.StringIsNull);
            return this;
        }


        public ValidadorString NoDebeSerNulo()
        {
            NoDebeSerNulo("El campo '{0}' no debe ser nulo");
            return this;
        }


        public ValidadorString NoPuedeSerNuloOVacio(string mensajeDeError)
        {
            bool resultado = string.IsNullOrEmpty(Valor) == true;
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo), CodigosDeError.StringIsNullOrEmpty);
            return this;
        }


        public ValidadorString NoPuedeSerNuloOVacio()
        {
            NoPuedeSerNuloOVacio("El campo '{0}' no puede ser nulo o vacio");
           // NoPuedeSerNuloOVacio(ObjValidador.LookupLanguageString("string_IsNullOrEmpty", NegarSiguienteValidacionResultado));
            return this;
        }

        #endregion


        #region longitud


        public ValidadorString DebeTenerLaLongitudRequerida(int longitudRequerida, string mensajeDeError)
        {
            bool resultado = Valor.Length != longitudRequerida;
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, longitudRequerida.ToString()));
            return this;
        }


        public ValidadorString DebeTenerLaLongitudRequerida(int longitudRequerida)
        {
            DebeTenerLaLongitudRequerida(longitudRequerida, "el campo {0} debe tener una longitud de {1} carácteres");
            return this;
        }


        public ValidadorString LaLongitudDebeSerMayorA(int menorLongitudPermitida, string mensajeDeError)
        {
            bool resultado = Valor.Length <= menorLongitudPermitida;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, menorLongitudPermitida.ToString()), CodigosDeError.StringIsLongerThan);
            
            return this;
        }


        public ValidadorString LaLongitudDebeSerMayorA(int menorLongitudPermitida)
        {
            LaLongitudDebeSerMayorA(menorLongitudPermitida,"La longitud del campo '{0}' debe ser mayor a '{1}' carácteres");
           // LaLongitudDebeSerMayorA(menorLongitudPermitida, ObjValidador.LookupLanguageString("string_IsLongerThan", NegarSiguienteValidacionResultado));
            return this;
        }


        public ValidadorString LaLongitudDebeSerMenorA(int maximaLongitud, string mensajeDeError)
        {
            bool resultado = Valor.Length >= maximaLongitud;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, maximaLongitud.ToString()), CodigosDeError.StringIsShorterThan);
         
            return this;
        }


        public ValidadorString LaLongitudDebeSerMenorA(int maximaLongitud)
        {
            LaLongitudDebeSerMenorA(maximaLongitud, "La longitud del campo '{0}' debe ser menor a '{1}' carácteres");
            //LaLongitudDebeSerMenorA(maximaLongitud, ObjValidador.LookupLanguageString("string_IsShorterThan", NegarSiguienteValidacionResultado));
            return this;
        }

        public ValidadorString LaLongitudDebeEstarEntre(int menorLongitud, int mayorLongitud, string mensajeDeError)
        {
            bool resultado = Valor.Length < menorLongitud || Valor.Length > mayorLongitud;

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, menorLongitud, mayorLongitud), CodigosDeError.StringHasALengthBetween);
            
            return this;
        }

        public ValidadorString LaLongitudDebeEstarEntre(int menorLongitud, int mayorLongitud)
        {
            LaLongitudDebeEstarEntre(menorLongitud, mayorLongitud, "La longitud del campo '{0}' debe estra entre {1} y {2}");
            //LaLongitudDebeEstarEntre(menorLongitud, mayorLongitud, ObjValidador.LookupLanguageString("string_HasALengthBetween", NegarSiguienteValidacionResultado));
            return this;
        }

        #endregion

        #region tipos de datos o formatos

        public ValidadorString DebeSerUnCUITValido()
        {
            return DebeSerUnCUITValido(String.Format("El texto ingresado en '{0}' no es un CUIT/CUIL válido", NombreDelCampo));

        }
        public ValidadorString DebeSerUnCUITValido(string mensajeDeError)
        {
            bool resultado = !Valor.CUITValido();
            AsignarResultado(resultado, mensajeDeError);
            return this;

        }
        public ValidadorString DebeSerUnaURL(string mensajeDeError)
        {
            Regex Reg = new Regex(@"^\w+://(?:[\w-]+(?:\:[\w-]+)?\@)?(?:[\w-]+\.)+[\w-]+(?:\:\d+)?[\w- ./?%&=\+]*$", RegexOptions.IgnoreCase);

            bool resultado = !Reg.IsMatch(Valor);
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsURL);
            return this;
        }
      

        public ValidadorString DebeSerUnaURL()
        {
            DebeSerUnaURL("El texto ingresado en '{0}' debe ser una URL");
            return this;
        }


         

        public ValidadorString DebeSerUnEmail(string mensajeDeError = "El valor de '{0}' debe ser un Email (Dirección DE Correo Electrónico)")
        {

           bool isEmail = ExtValString.IsEmail(Valor); ;
            
            bool resultado = !isEmail;
            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsURL);
            return this;
        }



        public ValidadorString DebeSerUnaFecha(string mensajeDeError)
        {
            DateTime Date;
       
            AsignarResultado(!DateTime.TryParse(Valor, out Date), string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsDate);
            return this;
        }


        public ValidadorString DebeSerUnaFecha()
        {
            DebeSerUnaFecha("El texto ingresado en '{0}' debe ser una fecha válida");
            return this;
        }

      
        public ValidadorString DebeSerUnEntero(string mensajeDeError)
        {
            int tmp;
            AsignarResultado(!int.TryParse(Valor, out tmp), string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsInteger);
            return this;
        }

        public ValidadorString DebeSerUnEntero()
        {
            DebeSerUnEntero("El texto ingresado en '{0}' debe ser un numero entero");
            return this;
        }


        public ValidadorString DebeSerUnEnteroLargo(string mensajeDeError)
        {
            long tmp;
            AsignarResultado(!long.TryParse(Valor, out tmp), string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsLong);
            return this;
        }


        public ValidadorString DebeSerUnEnteroLargo()
        {
            DebeSerUnEnteroLargo("El texto ingresado en '{0}' debe un entero largo");
            return this;
        }


      
        public ValidadorString DebeSerEsUnDecimal(string mensajeDeError)
        {
            decimal tmp;
            AsignarResultado(!decimal.TryParse(Valor, out tmp), string.Format(mensajeDeError, NombreDelCampo, Valor.ToString()), CodigosDeError.StringIsDecimal);
            return this;
        }


        public ValidadorString DebeSerEsUnDecimal()
        {
            DebeSerEsUnDecimal("El texto ingresado en '{0}' debe ser un décimal");
            return this;
        }


        #endregion

        #region contenido


        public ValidadorString DebeComnezarCon(string valorDeInicio, string mensajeDeError)
        {
            bool resultado = !Valor.StartsWith(valorDeInicio);

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorDeInicio), CodigosDeError.StringStartsWith);
            
            return this;
        }


        public ValidadorString DebeComnezarCon(string valorDeInicio)
        {
            DebeComnezarCon(valorDeInicio, "El texto ingresado en '{0}' debe comenzar con {1}");
            return this;
        }

   
        public ValidadorString DebeTerminarCon(string valorDeFin, string mensajeDeError)
        {
            bool resultado = !Valor.EndsWith(valorDeFin);

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorDeFin), CodigosDeError.StringEndsWith);
            
            return this;
        }


        public ValidadorString DebeTerminarCon(string valorFinal)
        {

            DebeTerminarCon(valorFinal, "El texto ingresado en '{0}' debe terminar con {1}");
            //DebeTerminarCon(valorFinal, ObjValidador.LookupLanguageString("string_EndsWith", NegarSiguienteValidacionResultado));
            return this;
        }

        public ValidadorString NoDebeContenerA(string valorDeComparacion, string mensajeDeError)
        {
            bool resultado = Valor.Contains(valorDeComparacion);

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorDeComparacion), CodigosDeError.StringContains);
            return this;
        }
        public ValidadorString NoDebeContenerA(List<string> listaDeValores)
        {
            foreach (string val in listaDeValores)
            {
                NoDebeContenerA(val, "El texto ingresado en '{0}' no debe contener a {1}");    
            }
            
            return this;
        }

        public ValidadorString NoDebeContenerA(string valorDeComparacion)
        {
            NoDebeContenerA(valorDeComparacion, "El texto ingresado en '{0}' no debe contener a {1}");    
            return this;
        }

        public ValidadorString DebeContenerA(string valorDeComparacion, string mensajeDeError)
        {
            bool resultado = !Valor.Contains(valorDeComparacion);

            AsignarResultado(resultado, string.Format(mensajeDeError, NombreDelCampo, valorDeComparacion), CodigosDeError.StringContains);
            
            return this;
        }


        public ValidadorString DebeContenerA(string valorDeComparacion)
        {
            DebeContenerA(valorDeComparacion, "El texto ingresado en '{0}'  debe contener a {1}");
            return this;
        }
        #endregion

       
       

    }
}
