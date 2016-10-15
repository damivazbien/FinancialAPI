using FinancialTimes.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace FinancialTimes.Test
{
    public class ApiTest
    {
        public IConfigurationRoot Configuration { get; }
        
        public ApiTest()
        {
          //TODO: add appsettings from FinancialTimes.API to test  
          var builder = new ConfigurationBuilder().AddJsonFile("setting.json", optional: true, reloadOnChange: true);
          Configuration = builder.Build();
        }

        [Fact]
        public async void WhenSaveDataAndOkThen200()
        {
            var controller = new FinancialTimesController(new FinancialServicesMock(Configuration.GetSection("MySettings:Configuration").Value));

            // Act
            var result = (await controller.Get("Sep2016"));

            // Assert
            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<OkObjectResult>(okRequestResult);
        }

        [Fact]
        public async void WhenSaveNewDataOkAcceptable()
        {
          var controller = new FinancialTimesController(new FinancialServicesMock(Configuration.GetSection("MySettings:Configuration").Value));

            // Act
          var result = (await controller.SaveNewMonthFinance("Sep2016"));

          // Assert
          var okRequestResult = Assert.IsType<OkObjectResult>(result);
          Assert.IsType<OkObjectResult>(okRequestResult);
        }

        [Fact]
        public async void WhenDataNotFound404()
        {
          var controller = new FinancialTimesController(new FinancialServicesMock(Configuration.GetSection("MySettings:Configuration").Value));

          // Act
          var result = (await controller.Get("Nov2025"));

          // Assert
          var notFoundResult = Assert.IsType<NotFoundResult>(result);
          Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
