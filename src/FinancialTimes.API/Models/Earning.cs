using System.Collections.Generic;
using System.Linq;

namespace FinancialTimes.API.Models
{
    public class Earning
    {
        public IEnumerable<Item> ListItemsEarning { get; set; }
    }
    // public static class EarningModelExtensions
    // {
    //     public static Earning ToModelToEntity(this EarningModel model)
    //     {
    //         var earning = new Earning{
    //            ListItemsEarning = model.ListItemsEarningModel.Select(x => x.ModelToEntity())
    //         };
     
    //         return earning;
    //     }
        
    //     public static double SumEarning(this EarningModel model)
    //     {
    //         double sumEarning = 0;

    //         foreach (ItemModel item in model.ListItemsEarningModel)
    //             sumEarning += item.HowMuch;

    //         return sumEarning;
    //     }
    // }
}