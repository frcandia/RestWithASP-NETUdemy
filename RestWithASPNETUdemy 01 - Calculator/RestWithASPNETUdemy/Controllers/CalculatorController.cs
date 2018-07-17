using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/calculator/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString(CultureInfo.InvariantCulture));
            }

            return BadRequest("Invalid input");
        }

        // GET api/calculator/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString(CultureInfo.InvariantCulture));
            }

            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
                return decimalValue;

            return 0;
        }

        private bool IsNumeric(string number)
        {
            double numberValue;

            var isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numberValue);

            return isNumber;
        }
    }
}
