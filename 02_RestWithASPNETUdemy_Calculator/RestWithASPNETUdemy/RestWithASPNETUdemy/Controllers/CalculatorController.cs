using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
	
	private readonly ILogger<CalculatorController> _logger;

	public CalculatorController(ILogger<CalculatorController> logger)
	{
		_logger = logger;
	}

	[HttpGet ("sum/{firstNumber}/{secondNumber}")]
	public IActionResult Get(string firstNumber, string secondNumber)
	{
		if ( isNumeric(firstNumber) && isNumeric(secondNumber) ) { 

			var sum = Convert.ToDecimal (firstNumber) + Convert.ToDecimal(secondNumber);

			return Ok("Resultado = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	private bool isNumeric(string strNumber)
	{
		double number;
		
		bool isNumber = double.TryParse(
			strNumber,
			System.Globalization.NumberStyles.Any,
			System.Globalization.NumberFormatInfo.InvariantInfo,
			out number);

		return isNumber;
	}
}