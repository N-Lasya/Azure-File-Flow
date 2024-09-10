using Database6.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Database6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDataController : ControllerBase
    {
        private readonly IMongoCollection<Employee> _collection;

      public EmployeeDataController(EmployeeContext employeeContext)
        {
            _collection = employeeContext.Drivers;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var result = await _collection.Find(d => true).ToListAsync();
            return Ok(result);
        }
        
    }
}