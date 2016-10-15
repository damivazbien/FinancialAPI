using System.Collections.Generic;
using System.Linq;

namespace FinancialTimes.API.Models
{
    public class Expense
    {
        public IEnumerable<Item> ListItemsExpense { get; set; }
    }
    
    // public static class ExpenseModelExtensions
    // {
    //     public static Expense ToModelToEntity(this ExpensesModel model)
    //     {
    //         var expense = new Expense{
    //            ListItemsExpense = model.ListItemsExpenseModel.Select(x=>x.ModelToEntity()).ToList()
    //         };
     
    //         return expense;
    //     }
        
    //     public static double SumExpense(this ExpensesModel model)
    //     {
    //         double sumExpense = 0;
            
    //         foreach (ItemModel item in model.ListItemsExpenseModel)
    //         {
    //             sumExpense += item.HowMuch;
    //         }
            
    //         return sumExpense;
    //     } 
    // }
}