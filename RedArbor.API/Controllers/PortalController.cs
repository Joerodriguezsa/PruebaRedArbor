using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalController : ControllerBase
    {
        private readonly IPortalService _PortalService;
        private readonly IMapper _mapper;

        public PortalController(IPortalService PortalService, IMapper mapper)
        {
            _PortalService = PortalService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PortalConsultarDTO>> Create(PortalCrearDTO PortalDTO)
        {
            var Portal = _mapper.Map<Portal>(PortalDTO);
            await _PortalService.CreateAsync(Portal);
            var PortalConsultarDTO = _mapper.Map<PortalConsultarDTO>(Portal);
            return CreatedAtAction(nameof(GetById), new { id = PortalConsultarDTO.Id }, PortalConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PortalConsultarDTO>> Update(int id, PortalActualizarDTO PortalDTO)
        {
            var Portal = _mapper.Map<Portal>(PortalDTO);
            Portal.Id = id;

            var updatedPortal = await _PortalService.UpdateAsync(Portal);
            if (updatedPortal != null)
            {
                var PortalConsultarDTO = _mapper.Map<PortalConsultarDTO>(updatedPortal);
                return Ok(PortalConsultarDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _PortalService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortalConsultarDTO>> GetById(int id)
        {
            var Portal = await _PortalService.GetByIdAsync(id);
            if (Portal == null)
            {
                return NotFound();
            }
            var PortalConsultarDTO = _mapper.Map<PortalConsultarDTO>(Portal);
            return Ok(PortalConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<PortalConsultarDTO>>> GetAll()
        {
            var Portales = await _PortalService.GetAllAsync();
            var PortalConsultarDTOs = _mapper.Map<List<PortalConsultarDTO>>(Portales);
            return Ok(PortalConsultarDTOs);
        }
    }
}
