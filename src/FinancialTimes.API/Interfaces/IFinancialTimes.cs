using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialTimes.API.Models;

namespace FinancialTimes.API.Interfaces
{
  public interface IFinancialTimes 
  { 
      Task<MonthFinance[]> Get();
	    Task Persist(IEnumerable<MonthFinance> dashboards);
		  Task Persist(MonthFinance dashboard);
		  Task<MonthFinance[]> Remove(Guid dashboardId);
  } 
}