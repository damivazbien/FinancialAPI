using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialTimes.API.DAO;
using FinancialTimes.API.Interfaces;
using FinancialTimes.API.Models;
using FinancialTimes.API.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;

namespace FinancialTimes.API
{
    public class FinancialServices : IFinancialTimes
    {
        private IConfiguration Configuration { get; set; }
        private readonly MonthFinanceStore store;
        public string UserId {get;set;}
        public string ConnString {get;set;}

        public FinancialServices(IConfiguration configuration)
        {            
            Configuration = configuration;
            UserId = Configuration.GetValue<string>("MySettings:UserId");
            ConnString =Configuration.GetValue<string>("MySettings:Configuration");
            var account = CloudStorageAccount.Parse(ConnString);
            new BlobStorageInitializer(account, Configuration.GetValue<string>("MySettings:ConteinerName")).Initialize();
			store = new MonthFinanceStore(account, Configuration.GetValue<string>("MySettings:ConteinerName"));
        }

        private string GetDocumentName()
		{
			return UserId.ToString().ToLowerInvariant() + "/" + "config.json";
		}

        public async Task<MonthFinance[]> Get()
		{
            var documentName = GetDocumentName();
			return (await store.Get(documentName))?.ToArray() ?? new MonthFinance[0];
		}

        public string GetConfiguration()
        {
            return Configuration.GetValue<string>("MySettings:Configuration");
        }

        public async Task Persist(IEnumerable<MonthFinance> monthFinances)
        {
            if (monthFinances == null)
			{
				monthFinances = Enumerable.Empty<MonthFinance>();
			}
			var dblist = monthFinances.ToArray();
			foreach (var monthFin in dblist)
			{
				if (Guid.Empty.Equals(monthFin.Id))
				{
					monthFin.Id = Guid.NewGuid();
				}
			}
			if (dblist.Length > 0 && !dblist.Any(x => x.IsDefault))
			{
				dblist[0].IsDefault = true;
			}
			await store.Persist(GetDocumentName(), dblist);
        }

        public async Task Persist(MonthFinance monthFinance)
        {
            if (monthFinance == null)
			{
				return;
			}
			var stored = await store.Get(GetDocumentName());
			List<MonthFinance> monthFinanceList = new List<MonthFinance>();
			if (stored == null)
			{
				monthFinanceList = new List<MonthFinance>{ monthFinance };
			}
			else
			{
				monthFinanceList = stored.ToList();
				if (monthFinance.IsDefault)
				{
				 	foreach (var monthFInanceConfig in monthFinanceList)
				 	{
				 		monthFInanceConfig.IsDefault = false;
				 	}
				}
				var existent = monthFinanceList.FirstOrDefault(x => x.Id == monthFinance.Id);
				if (existent != null)
				{
					monthFinanceList.Remove(existent);
				}
				monthFinanceList.Add(monthFinance);
				if (monthFinanceList.Count == 1)
				{
					monthFinance.IsDefault = true;
				}
			}
			await Persist(monthFinanceList);
        }

        public async Task<MonthFinance[]> Remove(Guid monthFinanceId)
        {
            var stored = await store.Get(GetDocumentName());
			if (stored == null)
			{
				return new MonthFinance[0];
			}
			var monthFinance = stored.Where(x => x.Id != monthFinanceId).ToArray();
			await Persist(monthFinance);
			return monthFinance;
        }
    }
}
