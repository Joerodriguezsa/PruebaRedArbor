using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<StatusConsultarDTO>> Create(StatusCrearDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            await _statusService.CreateAsync(status);
            var statusConsultarDTO = _mapper.Map<StatusConsultarDTO>(status);
            return CreatedAtAction(nameof(GetById), new { id = statusConsultarDTO.Id }, statusConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StatusActualizarDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            status.Id = id;

            if (await _statusService.UpdateAsync(status))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _statusService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusConsultarDTO>> GetById(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            var statusConsultarDTO = _mapper.Map<StatusConsultarDTO>(status);
            return Ok(statusConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusConsultarDTO>>> GetAll()
        {
            var statuses = await _statusService.GetAllAsync();
            var statusConsultarDTOs = _mapper.Map<List<StatusConsultarDTO>>(statuses);
            return Ok(statusConsultarDTOs);
        }
    }
}
