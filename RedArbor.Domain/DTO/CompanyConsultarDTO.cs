namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Consultar Company
    /// </summary>
    public class CompanyConsultarDTO
    {
        /// <summary>
        /// Id Company
        /// </summary>
        public int Id { get; set; }

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
