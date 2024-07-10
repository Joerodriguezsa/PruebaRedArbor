namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Crear Role
    /// </summary>
    public class RoleCrearDTO
    {
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
