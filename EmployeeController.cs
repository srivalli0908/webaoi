using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM_SAMPLE.ORM_MODELS;
using System.ComponentModel;

namespace ORM_SAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private OrmsContext _ormsContext;
        public EmployeeController(OrmsContext ormsContext)
        {
            _ormsContext = ormsContext;
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<Employee> AddEmployeeToDb([FromBody] Employee employee)
        {
            _ormsContext.Add(employee);
            _ormsContext.SaveChanges();

            return employee;
        }


        [HttpGet]
        [Route("GetEmployee")]
        public async Task<List<Employee>> GetAllEmployeeFromDb()
        {
            var _emp = _ormsContext.Employees.AsEnumerable().ToList();

            return _emp;
        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<bool> DeleteEmpFromDb(string id)
        {
            try
            {
                var _emptodelete = _ormsContext.Employees.AsEnumerable().Where(emp => emp.EmployeId == id).FirstOrDefault();
                _emptodelete.IsActive = false;

                var _salary = _ormsContext.Salaries.AsEnumerable().Where(empi => empi.EmpId == id).FirstOrDefault();
                _salary.IsActive = false;
                
                _ormsContext.Employees.Update(_emptodelete);
                _ormsContext.Salaries.Update(_salary);
                _ormsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
