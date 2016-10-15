using System.Collections.Generic;
using System.Linq;

namespace FinancialTimes.API.Models
{
    public class Investment
    {
        public IEnumerable<Item> ListItemsInvestment { get; set; }
    }
    
    
    // public static class InvestmentModelExtensions
    // {
    //     public static Investment ToModelToEntity(this InvestmentModel model)
    //     {
    //         var investment = new Investment{
    //            ListItemsInvestment = model.ListItemsInvestmentModel.Select(x=>x.ModelToEntity()).ToList()
    //         };
     
    //         return investment;
    //     }
        
    //     public static double SumInvestment(this InvestmentModel model)
    //     {
    //         double sumInvestment = 0;
            
    //         foreach (ItemModel item in model.ListItemsInvestmentModel)
    //         {
    //             sumInvestment += item.HowMuch;
    //         }
            
    //         return sumInvestment;
    //     } 
    // }
}