using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_Core_CRUD_API.DataAccess;

namespace NET_Core_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryContext context;

        public InventoryController(InventoryContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee() {
            var data = await context.Employees.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var data = await context.Employees.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee emp)
        {
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllEmployee), new { id = emp.EmployeeId }, new { Message = "Employee created successfully.", CreatedEmployee = emp });

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id ,Employee emp)
        {
           //if(id != emp.EmployeeId)
           // {
           //     return BadRequest();
           // }
            //else
            {
                context.Entry(emp).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { Message = "Employee updated successfully.", UpdatedEmployee = emp });

            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id)
        {
            var data = await context.Employees.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            context.Employees.Remove(data);
            await context.SaveChangesAsync();
            return Ok(new {Message = "Employee deleted Succesfully" , DeletedEmployee = data});
        }


    }
}
