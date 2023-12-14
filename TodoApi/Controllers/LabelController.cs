using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelRepository _labelRepository;
        public LabelController(ILabelRepository labelRepository)
        {
            this._labelRepository= labelRepository;
        }

        [HttpGet("")]
        public IActionResult Get ()
        {
            var response = _labelRepository.GetLabels();
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _labelRepository.GetLabelById(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(LabelDto label)
        {
            var response = await _labelRepository.CreateLabel(label);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LabelDto label)
        {
            var response = await _labelRepository.UpdateLabel(id, label);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _labelRepository.DeleteLabel(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
