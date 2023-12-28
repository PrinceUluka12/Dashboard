using Dashboard.Server.Models;
using Dashboard.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _service;
        public OrdersController(IOrdersService service)
        {
            _service = service;  
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersData()
        {

            var employees = await _service.GetAll();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> PostToDb([FromBody] List<Order> data)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

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
