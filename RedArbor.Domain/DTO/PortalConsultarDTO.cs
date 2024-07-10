namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Consultar Portal
    /// </summary>
    public class PortalConsultarDTO
    {
        /// <summary>
        /// Id Portal
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Portal Name
        /// </summary>
        public string PortalName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
