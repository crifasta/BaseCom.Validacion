namespace BaseCom.Validacion
{
    /// <summary>
    /// Enumeration of the built-in supported languages.
    /// </summary>
    public enum LenguaValidacionEnum
    {

        [ArchivoDeRecursosDeLengua("Recursos.Lenguas-en.xml")]
        Ingles = 0,

        [ArchivoDeRecursosDeLengua("Recursos.Lenguas-es.xml")]
        Espaniol = 1,


    }

    /// <summary>
    /// Enumeración para establecer si queremos recogerlos errores de uno o varios
    /// </summary>
    public enum ModoDeValidacion
    {
        /// <summary>
        /// Un error por campo
        /// </summary>
        UnErrorPorCampo,

        /// <summary>
        /// Devolver todos los errores encontrados para cada campo.
        /// </summary>
        TodosLosErrores
    }
 
    /// <summary>
    /// Los diferentes niveles de error de validación que podemos tener.
    /// </summary>
    public enum NivelDeValidacion
    {
        Error,
        Advertencia
    }



}
