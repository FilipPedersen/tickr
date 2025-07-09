using Microsoft.AspNetCore.Mvc;

namespace TickrAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinancialController(FinancialDataService financialService) : ControllerBase
{
    private readonly FinancialDataService _financialService = financialService;

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetFinancialData(string symbol)
    {
        var data = await _financialService.GetFinancialDataAsync(symbol);
        return Ok(data);
    }
}