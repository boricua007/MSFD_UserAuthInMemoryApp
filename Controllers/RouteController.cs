using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MSFD_UserAuthInMemoryApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("route")]
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET:  This endpoint is protected by the "HR" role, meaning only users with this role can access it.
        [HttpGet("employee-records")]
        [Authorize(Roles = "HR")]
        public IActionResult GetAll()
        {
            return Ok("All employee records retrieved successfully.");
        }

        // POST: This endpoint is protected by the "ManageEmployeeRecords" policy (claims-based authorization).
        [HttpPost("employee-records")]
        [Authorize(Policy = "ManageEmployeeRecords")]
        public IActionResult AddEmployee()
        {
            return Ok("New employee record added successfully.");
        }

        // DELETE: This endpoint is protected by the "ManageEmployeeRecords" policy (claims-based authorization).
        [HttpDelete("employee-records/{id}")]
        [Authorize(Policy = "ManageEmployeeRecords")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok($"Employee record with ID {id} deleted successfully.");   
        }

    }
}