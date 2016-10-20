using FinancialTimes.API.Models;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using FinancialTimes.API.DAO;
using Microsoft.Extensions.Configuration;

namespace FinancialTimes.API.Stores
{
    public class MonthFinanceStore: BaseDocumentDao<IEnumerable<MonthFinance>>
		{
				private IConfiguration Configuration { get; set; }

				public MonthFinanceStore(CloudStorageAccount account, string documentsContainerName) : base(account) {}
				protected override void AdjustBlobAttributes(ICloudBlob blobReference)
				{
					var blobProperties = blobReference.Properties;
					blobProperties.ContentType = "application/json";
				}
		}
}
