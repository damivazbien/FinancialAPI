using System.Collections.Generic;

namespace FinancialTimes.API.Models
{
    public class Expense
    {
        public IEnumerable<Item> ListItemsExpense { get; set; }
    }
  
}