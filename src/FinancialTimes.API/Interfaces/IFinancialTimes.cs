using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialTimes.API.Models;

namespace FinancialTimes.API.Interfaces
{
  public interface IFinancialTimes 
  { 
      string GetConfiguration();
      Task<MonthFinance[]> Get();
	    Task Persist(IEnumerable<MonthFinance> monthFinance);
		  Task Persist(MonthFinance monthFinance);
		  Task<MonthFinance[]> Remove(Guid monthFinanceId);
  } 
}