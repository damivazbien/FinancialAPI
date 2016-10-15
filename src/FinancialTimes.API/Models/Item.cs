using System;

namespace FinancialTimes.API.Models
{
    public class Item
    {
        public string Name {get; set;}
        public double HowMuch { get; set; }
        
    }
    
    // public static class ItemModelExtensions
    // {
    //     public static Item ModelToEntity(this ItemModel model)
    //     {
    //         var item = new Item{
    //             Name = model.Name,
    //             HowMuch = model.HowMuch
    //         };
     
    //         return item;
    //     }
    // }
}