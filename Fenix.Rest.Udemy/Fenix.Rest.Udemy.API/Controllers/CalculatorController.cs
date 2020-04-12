using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fenix.Rest.Udemy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public CalculatorController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{firstNumeric}/{secondNumeric}")]
        public IActionResult Sum(string firstNumeric, string secondNumeric)
        {
            if (IsNumeric(firstNumeric) && IsNumeric(secondNumeric))
            {
                var sum = ConvertToDecimal(firstNumeric) + ConvertToDecimal(secondNumeric);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string numeric)
        {
            decimal decimalValue;
            if(decimal.TryParse(numeric, out decimalValue))
                return decimalValue;

            return 0;
        }

        private bool IsNumeric(string numeric)
        {
            double number;

            bool isNumber = double.TryParse(numeric, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
