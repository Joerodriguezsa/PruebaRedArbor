namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Actualizar Portal
    /// </summary>
    public class PortalActualizarDTO
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
