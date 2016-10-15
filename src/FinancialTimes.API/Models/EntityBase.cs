using System;

namespace FinancialTimes.API.Models
{
    
    // Here i need inject the depency with dbcontext, for can apply any
    // configuration database.
    public abstract class EntityBase 
    {
        public Guid Id { get; set; }
    }    
}
