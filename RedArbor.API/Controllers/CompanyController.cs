using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Interface.IService;
using RedArbor.Domain.DTO;
using RedArbor.Domain.Entities;

namespace RedArbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _CompanyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService CompanyService, IMapper mapper)
        {
            _CompanyService = CompanyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyConsultarDTO>> Create(CompanyCrearDTO CompanyDTO)
        {
            var Company = _mapper.Map<Company>(CompanyDTO);
            await _CompanyService.CreateAsync(Company);
            var CompanyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(Company);
            return CreatedAtAction(nameof(GetById), new { id = CompanyConsultarDTO.Id }, CompanyConsultarDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyConsultarDTO>> Update(int id, CompanyActualizarDTO CompanyDTO)
        {
            var Company = _mapper.Map<Company>(CompanyDTO);
            Company.Id = id;

            var updatedCompany = await _CompanyService.UpdateAsync(Company);
            if (updatedCompany != null)
            {
                var CompanyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(updatedCompany);
                return Ok(CompanyConsultarDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _CompanyService.DeleteAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyConsultarDTO>> GetById(int id)
        {
            var Company = await _CompanyService.GetByIdAsync(id);
            if (Company == null)
            {
                return NotFound();
            }
            var CompanyConsultarDTO = _mapper.Map<CompanyConsultarDTO>(Company);
            return Ok(CompanyConsultarDTO);
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyConsultarDTO>>> GetAll()
        {
            var Companyes = await _CompanyService.GetAllAsync();
            var CompanyConsultarDTOs = _mapper.Map<List<CompanyConsultarDTO>>(Companyes);
            return Ok(CompanyConsultarDTOs);
        }
    }
}
