using Dashboard.Server.Models;
using Dashboard.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Dashboard.Server.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class EmployeesDataController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesDataController(IEmployeeService service)
        {
                _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeesData()
        {

            var employees = await _service.GetAll();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> PostToDb([FromBody] List<EmployeeDataDto> data)
        {
            if(!ModelState.IsValid) { return BadRequest(); }

            try
            {
                var result = await _service.PostToDb(data);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
    }
}

