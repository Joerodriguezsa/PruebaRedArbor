namespace RedArbor.Domain.Entities
{
    /// <summary>
    /// Clase Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Id Role
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
