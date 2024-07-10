namespace RedArbor.Domain.DTO
{
    /// <summary>
    /// DTO Actualizar Role
    /// </summary>
    public class RoleActualizarDTO
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
