namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Consultar Status
    /// </summary>
    public class StatusConsultarDTO
    {
        /// <summary>
        /// Id Status
        /// </summary>
        public int Id { get; set; }

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
