using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCom.Validacion.Extensores
{
    public static class CUITExt
    {
        /// <summary>
        /// Verifica que s sea un CUIT Válido.
        /// Pueden pasarse con o sin Guión.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CUITValido(this string s)
        {
            string sCUIT = s.Replace("-", "");
            string aMult = "5432765432";

            char[] charArrayaMult = aMult.ToCharArray();

            if (!string.IsNullOrEmpty(sCUIT) && sCUIT.Length == 11)
            {
                char[] charArrayCUIT = sCUIT.ToCharArray();
                int iResult = 0;

                for (int i = 0; i <= 9; i++)
                {
                    int x = Convert.ToInt32(charArrayCUIT[i].ToString());
                    int y = Convert.ToInt32(charArrayaMult[i].ToString());
                    iResult += x * y;
                }

                iResult = (iResult % 11);
                iResult = 11 - iResult;

                if (iResult == 11) iResult = 0;
                if (iResult == 10) iResult = 9;

                if (iResult == Convert.ToInt32(Convert.ToString(charArrayCUIT[10]))) return true;

            }

            return false;
        }

        //  Si ya cuentas con CUIL,
        //  el número se consolida y será entonces asignado el mismo número.
        //  Los dígitos que indican el tipo suelen ser: 20 para hombres, 27 para mujeres,
        //  23, 24, 25 o 26 para ambos(en caso de que ya exista un CUIT idéntico)
        //  y 30 para empresas.
        /// <summary>
        ///0    no identificado 
        ///1	Humana
        ///2	Jurídica
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static int TipoDePersona(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return 0;
            }
            if (valor.Substring(0, 2) == "30")
            {
                return 2;
            }

            return 1;
        }

        public static int CalcularDigitoCuit(this string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }

        public static bool ValidaCuit(this string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;

            }
        }
    }
}
