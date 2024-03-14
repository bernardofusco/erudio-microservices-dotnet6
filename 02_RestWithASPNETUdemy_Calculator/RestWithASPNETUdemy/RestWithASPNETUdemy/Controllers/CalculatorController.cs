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

	// SOMA
	[HttpGet ("soma/{firstNumber}/{secondNumber}")]
	public IActionResult Soma(string firstNumber, string secondNumber)
	{
		if ( isNumeric(firstNumber) && isNumeric(secondNumber) ) { 

			var sum = Convert.ToDecimal (firstNumber) + Convert.ToDecimal(secondNumber);

			return Ok("Soma = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	// SUBTRAÇÃO
	[HttpGet("sub/{firstNumber}/{secondNumber}")]
	public IActionResult Subtracao(string firstNumber, string secondNumber)
	{
		if (isNumeric(firstNumber) && isNumeric(secondNumber))
		{

			var sum = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);

			return Ok("Subtração = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	// MULTIPLICAÇÃO
	[HttpGet("mult/{firstNumber}/{secondNumber}")]
	public IActionResult Multiplicacao(string firstNumber, string secondNumber)
	{
		if (isNumeric(firstNumber) && isNumeric(secondNumber))
		{

			var sum = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);

			return Ok("Multiplicação = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	// DIVISÃO
	[HttpGet("div/{firstNumber}/{secondNumber}")]
	public IActionResult Divisao(string firstNumber, string secondNumber)
	{
		if (isNumeric(firstNumber) && isNumeric(secondNumber))
		{

			var sum = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);

			return Ok("Divisão = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	// MÉDIA
	[HttpGet("media/{firstNumber}/{secondNumber}")]
	public IActionResult Media(string firstNumber, string secondNumber)
	{
		if (isNumeric(firstNumber) && isNumeric(secondNumber))
		{

			var sum = ( Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber) ) / 2 ;

			return Ok("Média = " + sum.ToString());
		}
		return BadRequest("Número Inválido!");
	}

	// RAIZ QUADRADA
	[HttpGet("raiz/{firstNumber}/{secondNumber}")]
	public IActionResult RaizQuadrada(string firstNumber, string secondNumber)
	{
		if (isNumeric(firstNumber) && isNumeric(secondNumber))
		{
			var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);

			var raiz = Math.Sqrt( Convert.ToDouble(sum));

			return Ok("Raiz Quadrada = " + raiz.ToString());
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