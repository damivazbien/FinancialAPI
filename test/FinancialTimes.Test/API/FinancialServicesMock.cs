using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialTimes.API.Configurations;
using FinancialTimes.API.Interfaces;
using FinancialTimes.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FinancialTimes.Test
{
    //Mock Services, for test route controller.
    public class FinancialServicesMock : IFinancialTimes
    {
        private string mySettings { get; set; }

        public FinancialServicesMock(string settings)
        {            
            mySettings = settings;
        }
 
        public async Task<MonthFinance[]> Get()
		{
            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MonthFinance[]>(@"[{'Name':'Sep2016'}, {'Name':'Oct2016'}]"));
            return await task;
        }

        public async Task Persist(MonthFinance dashboard)
        {
            if(dashboard == null)
            {
                throw new NotImplementedException();    
            }
            IEnumerable<MonthFinance> listMonthFinance = new List<MonthFinance>();
            await Persist(listMonthFinance);

        }

        public async Task Persist(IEnumerable<MonthFinance> monthFinances)
		{
			await Task.Delay(1000);
		}


        public Task<MonthFinance[]> Remove(Guid dashboardId)
        {
            throw new NotImplementedException();
        }

        string IFinancialTimes.GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
