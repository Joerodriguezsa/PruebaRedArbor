namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Crear Company
    /// </summary>
    public class CompanyCrearDTO
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
