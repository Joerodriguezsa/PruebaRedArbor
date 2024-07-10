namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Actualizar Company
    /// </summary>
    public class CompanyActualizarDTO
    {
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
