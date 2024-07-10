namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Crear Portal
    /// </summary>
    public class PortalCrearDTO
    {
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
