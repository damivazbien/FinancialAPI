using System.Collections.Generic;
using System.Linq;


namespace FinancialTimes.API.Models
{
    public class MonthFinance : EntityBase
    {
        public MonthFinance()
        {
        }

        internal bool IsDefault = false;
        public string Name { get; set; }
        public Expense MonthExpense { get; set; }
        public Earning MonthEarning { get; set; }
        public Investment MonthInvestment { get; set; }
        public double Saving { get; }
        public double SubTotalExpense  { get; } 
        public double SubTotalEarning { get; }
        public double Total { get; set; }
        
        public MonthFinance(string name, Expense monthExpensiveLast, double saving)
        {
            this.Name = name;
            this.MonthExpense = monthExpensiveLast;
            this.Saving = saving;
        }
    }
    
    
    // public static class MonthFinanceModelExtensions
    // {
    //     public static MonthFinance ToModelToEntity(this MonthFinanceModel model)
    //     {
    //         if(model == null)
    //             return null;
                
    //         var monthFinance = new MonthFinance(
    //            model.Name,
    //            model.Expense.ToModelToEntity(),
    //            model.Saving
    //         );
            
    //         monthFinance.MonthEarning.ListItemsEarning = model.Earning.ToModelToEntity().ListItemsEarning;
    //         monthFinance.Total = monthFinance.SubTotalEarning + monthFinance.SubTotalExpense; 
            
    //         return monthFinance;
    //     }
    // }
}