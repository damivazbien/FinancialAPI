// using System;
// using FinancialTimes.API.Configurations;
// using FinancialTimes.API.Interfaces;
// using FinancialTimes.API.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using Newtonsoft.Json;

// namespace FinancialTimes.API
// {
//     public class FinancialServicesMock : IFinancialTimes
//     {
//         private string mySettings { get; set; }

//         public FinancialServicesMock(string settings)
//         {            
//             mySettings = settings;
//         }

//         //devuelvo un json
//         public MonthFinance Get(string name)
//         {
//             //if(mySettings != null)
//             //{
//                 return JsonConvert.DeserializeObject<MonthFinance>("{name:'Sep2016'}");
//             //}
//             //return null;
//         }

//         public bool Save()
//         {
//             throw new NotImplementedException();
//         }

//         public bool Update()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
