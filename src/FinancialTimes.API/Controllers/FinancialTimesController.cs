using System.Linq;
using System.Threading.Tasks;
using FinancialTimes.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FinancialTimes.API.Models;
using System;

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
        
        [HttpGet("get/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            if (name != null)
            {
                var monthFinance = (await _financialTimes.Get()).Where(x=>x.Name == name).FirstOrDefault();

                if (monthFinance != null)
                    return Ok(monthFinance);
            }
            return NotFound();
        }

        //save new document copy data from last document.
        [HttpPost("save/{name}")]
        public async Task<IActionResult> SaveNewMonthFinance(string name)
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

        /*
            Delete document.
        */
        [HttpPost]
        public async Task<bool> DeleteMonthFinance([FromQuery] string name)
        {
            if(name!= null)
            {
                Guid idDocument = (await _financialTimes.Get()).ToArray().Where(x=>x.Name == name).Select(x=>x.Id).FirstOrDefault();
                if(idDocument != null || idDocument != Guid.Empty )
                {
                     var documents = await _financialTimes.Remove(idDocument);
                     return true;
                }
            }
            return false;
        }


        [HttpPost]
        public async Task<MonthFinance> SaveMonthFinance([FromBody] MonthFinance monthFinances)
        {
            var documents = (await _financialTimes.Get()).ToArray();
            var entity = documents.Where(x=> x.Name == monthFinances.Name).FirstOrDefault();
            
            if(entity.Name != null)
            {
                var entityExpense = new Expense {
                    ListItemsExpense = monthFinances.MonthExpense.ListItemsExpense
                };

                var entityEarning = new Earning
                {
                    ListItemsEarning = monthFinances.MonthEarning.ListItemsEarning
                };
                    
                var entityInvestment = new Investment
                {
                    ListItemsInvestment = monthFinances.MonthInvestment.ListItemsInvestment  
                };

                entity.MonthEarning = entityEarning;
                entity.MonthExpense = entityExpense;
                entity.MonthInvestment = entityInvestment;

                await _financialTimes.Persist(entity);
            }    
            return entity;
        }
        
        [HttpGet]
        public async Task<MonthFinance> GetMonthFinanceByParams([FromQuery] string name)
        {
            var model = new MonthFinance();
            var entity = (await _financialTimes.Get()).ToArray();
            
            if(name!=null)
                model = entity.Where(x=> x.Name.Contains(name)).FirstOrDefault();
            
            return model;
        }

        [HttpGet]
        public async Task<MonthFinance> GetDocument()
        {
            var model = new MonthFinance();
            var entity = (await _financialTimes.Get()).ToArray();
            
            //todo: remove guid hardcore
            model = entity.Where(x => x.Id.Equals(Guid.Parse("efede5a3-0b4c-4d41-a054-55d1b97ae35e"))).FirstOrDefault()
									?? entity.Where(x => x.IsDefault).FirstOrDefault();

            model = entity.FirstOrDefault();
            return model;
        }

    }
}
