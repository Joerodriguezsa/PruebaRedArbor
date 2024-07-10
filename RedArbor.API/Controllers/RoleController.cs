using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService RoleService, IMapper mapper)
        {
            _RoleService = RoleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<RoleConsultarDTO>> Create(RoleCrearDTO RoleDTO)
        {
            var Role = _mapper.Map<Role>(RoleDTO);
            await _RoleService.CreateAsync(Role);
            var RoleConsultarDTO = _mapper.Map<RoleConsultarDTO>(Role);
            return CreatedAtAction(nameof(GetById), new { id = RoleConsultarDTO.Id }, RoleConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleConsultarDTO>> Update(int id, RoleActualizarDTO RoleDTO)
        {
            var Role = _mapper.Map<Role>(RoleDTO);
            Role.Id = id;

            var updatedRole = await _RoleService.UpdateAsync(Role);
            if (updatedRole != null)
            {
                var RoleConsultarDTO = _mapper.Map<RoleConsultarDTO>(updatedRole);
                return Ok(RoleConsultarDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _RoleService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleConsultarDTO>> GetById(int id)
        {
            var Role = await _RoleService.GetByIdAsync(id);
            if (Role == null)
            {
                return NotFound();
            }
            var RoleConsultarDTO = _mapper.Map<RoleConsultarDTO>(Role);
            return Ok(RoleConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleConsultarDTO>>> GetAll()
        {
            var Rolees = await _RoleService.GetAllAsync();
            var RoleConsultarDTOs = _mapper.Map<List<RoleConsultarDTO>>(Rolees);
            return Ok(RoleConsultarDTOs);
        }
    }
}
