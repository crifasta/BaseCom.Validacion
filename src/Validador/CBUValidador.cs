namespace BaseCom.Validation.Validador
{
    public class CBUValidador
    {
        //La CBU debe ser ingresada en 2 bloques:

        //  El 1º bloque contiene:
        //            • Banco(3 dígitos)
        //            • Dígito Verificador 1 (1 dígito)
        //            • Sucursal(3 dígitos)
        //            • Dígito Verificador 2 (1 digito)

        //  El 2º bloque contiene:
        //            • Cuenta(13 dígitos)
        //            • Dígito Verificador(1 dígito)

        //  Validación:

        //  Por ejemplo: CBU 28505909 40090418135201

        //  Debe verificarse el código de banco con una tabla de bancos.

        //  Validación 1º bloque(28505909)

        //            • Banco = 285 (Descomponer en sus dígitos B1 = 2, B2 = 8, B3 = 5)
        //            • DigitoVerificador1 = 0 
        //            • Sucursal = 590 (Descomponer en sus dígitos S1 = 5, S2 = 9, S3 = 0)
        //            • DigitoVerificador2 = 9

        //  Obtener:
        //            • SUMA1 = B1*7 + B2*1 + B3*3 + DigitoVerificador1*9 + S1*7 + S2*1 + S3*3
        //            • SUMA1 = 2*7 + 8*1 + 5*3 + 0*9 + 5*7 + 9*1 + 0*3 = 14 + 8 + 15 + 0 + 35 + 9 + 0 = 81

        //  Obtener:
        //            • DIFERENCIA1 = 10 - ultimo digito de SUMA1 = 10 - 1 = 9
        //            • Si DIFERENCIA1 = DigitoVerificador2 => CBU OK

        //  Validación 2º bloque(40090418135201)

        //            • Cuenta = 4009041813520 (Descomponer en sus dígitos C1 = 4, C2 = 0, C3 = 0, C4 = 9, C5 = 0, C6 = 4, C7 = 1, C8 = 8, C9 = 1, C10 = 3, C11 = 5, C12 = 2, C13 = 0
        //            • Digito = 1

        //  Obtener:
        //            • SUMA2 = C1*3 + C2*9 + C3*7 + C4*1 + C5*3 + C6*9 + C7*7 + C8*1 + C9*3 + C10*9 + C11*7 + C12*1 + C13*3
        //            • SUMA2 = 12 + 0 + 0 + 9 + 0 + 36 + 7 + 8 + 3 + 27 + 35 + 2 + 0
        //            • SUMA2 = 139

        //  Obtener:
        //            • DIFERENCIA2 = 10 - ultimo digito de SUMA2 = 10 - 9 = 1 
        //            • Si DIFERENCIA2 = Digito => CBU OK
    }
}
