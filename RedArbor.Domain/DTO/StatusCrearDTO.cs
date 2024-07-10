namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Crear Status
    /// </summary>
    public class StatusCrearDTO
    {
        /// <summary>
        /// Status Name
        /// </summary>
        public string StatusName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
