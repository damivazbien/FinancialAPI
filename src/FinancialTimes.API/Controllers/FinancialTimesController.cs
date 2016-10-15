using System.Linq;
using System.Threading.Tasks;
using FinancialTimes.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FinancialTimes.API.Models;

namespace FinancialTimes.API.Controllers
{
    [Route("api/[controller]")]
    public class FinancialTimesController : Controller
    {
        private readonly IFinancialTimes _financialTimes;
        public FinancialTimesController(IFinancialTimes financialTimes)
        {
            _financialTimes = financialTimes;
        }

        public async Task<IActionResult> Get([FromQuery] string name)
        {

            if (name != null)
            {
                var monthFinance = (await _financialTimes.Get()).Where(x=>x.Name == name).FirstOrDefault();

                if (monthFinance != null)
                    return Ok(new
                    {
                        Name = monthFinance.Name
                    });
            }

            return NotFound();
        }

        public async Task<IActionResult> SaveNewMonthFinance([FromQuery] string name)
        {
            if(name != null)
            {
                var entity = new MonthFinance{
                    Name = name 
                };
                var documents = (await _financialTimes.Get()).Last();

                if(documents != null)
                {
                    entity.MonthEarning = documents.MonthEarning;
                    entity.MonthExpense = documents.MonthExpense;
                    entity.MonthInvestment = documents.MonthInvestment;
                }
                
                await _financialTimes.Persist(entity);

                return Ok(entity);
            }
            return BadRequest();;
        }

        



        
        
    }
}
