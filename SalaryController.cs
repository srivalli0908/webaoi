using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM_SAMPLE.ORM_MODELS;

namespace ORM_SAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private OrmsContext _ormsContext;
        public SalaryController(OrmsContext ormsContext)
        {
            _ormsContext = ormsContext;
        }

        [HttpPost]
        [Route("AddSalary")]
        public async Task<Salary> AddSalary([FromBody] Salary salary)
        {
            _ormsContext.Add(salary);
            _ormsContext.SaveChanges();
            return salary;
        }

        [HttpGet]
        [Route("Detsalart")]
        public async Task<List<Salary>> GetSalary()
        {
            var getsalary = _ormsContext.Salaries.AsEnumerable().ToList();
            return getsalary;

        }

        [HttpDelete]
        [Route("Deletesalary")]
        public async Task<bool> Deletesalary(string id)
        {
            try
            {
                var _salary = _ormsContext.Salaries.AsEnumerable().Where(empi => empi.EmpId == id).FirstOrDefault();
                _salary.IsActive = false;
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
