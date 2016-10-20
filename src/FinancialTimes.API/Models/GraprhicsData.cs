using System.Collections.Generic;

namespace FinancialTimes.API.Models
{
  public class GraprhicsData
  {
    public List<string> NameMonth { get; set; } = new List<string>();
    public List<List<double>> Data { get; set; } = new List<List<double>>();
          
  }  
}
