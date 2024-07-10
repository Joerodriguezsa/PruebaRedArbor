namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Actualizar Status
    /// </summary>
    public class StatusActualizarDTO
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
