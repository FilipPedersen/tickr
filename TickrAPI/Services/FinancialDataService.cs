using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Supabase;
using Supabase.Interfaces;
using TickrAPI.Converters;
using TickrAPI.Models;

public class FinancialDataService
{
    private readonly HttpClient _httpClient;
    private readonly Client _supabaseClient;
    private readonly ChartDataConverter _converter;

    private readonly string _baseUrl;
    private readonly string _apiKey;

    public FinancialDataService(HttpClient httpClient, Client supabaseClient, IOptions<FinancialModelingPrepSettings> settings, ChartDataConverter converter)
    {
        _httpClient = httpClient;
        _supabaseClient = supabaseClient;
        _baseUrl = settings.Value.BaseUrl;
        _apiKey = settings.Value.ApiKey;
        _converter = converter;
    }

    public async Task<ChartData> GetChartDataAsync(string symbol)
    {
        var financialData = await GetFinancialDataAsync(symbol); 
        return _converter.ConvertToChartData(financialData, symbol);
    }
    
    public async Task<FinancialData> GetFinancialDataAsync(string symbol)
    {
        try
        {
            var existing = await _supabaseClient
                .From<StoredIncomeStatement>()
                .Where(x => x.Symbol == symbol)
                .Get();

            var yearlyData = existing.Models
                .Where(x => x.Period == "FY")
                .Select(x => JsonSerializer.Deserialize<IncomeStatement>(x.Data))
                .ToList();

            var quarterlyData = existing.Models
                .Where(x => x.Period != "FY")
                .Select(x => JsonSerializer.Deserialize<IncomeStatement>(x.Data))
                .ToList();


            if (yearlyData.Count == 0)
            {
                try
                {
                    yearlyData = await _httpClient.GetFromJsonAsync<List<IncomeStatement?>>(
                        $"https://financialmodelingprep.com/stable/income-statement?symbol=${symbol}&apikey=${_apiKey}") ?? [];

                    foreach (var item in yearlyData)
                    {
                        if (item == null) continue;
                        await _supabaseClient.From<StoredIncomeStatement>().Insert(new StoredIncomeStatement
                        {
                            Symbol = symbol,
                            Period = item.Period,
                            FiscalYear = item.FiscalYear,
                            Date = item.Date,
                            Data = JsonSerializer.Serialize(item)
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            // if (quarterlyData.Count == 0)
            // {
            //     _logger.LogInformation("No quarterly data in Supabase, fetching from FMP for {Symbol}", symbol);
            //     try
            //     {
            //         quarterlyData = await _httpClient.GetFromJsonAsync<List<IncomeStatement?>>(
            //             $"{_baseUrl}/income-statement/{symbol}&apikey={_apiKey}") ?? [];
            //         _logger.LogInformation("Fetched {Count} quarterly records from FMP", quarterlyData.Count);
            //         foreach (var item in quarterlyData)
            //         {
            //             await _supabaseClient.From<StoredIncomeStatement>().Insert(new StoredIncomeStatement
            //             {
            //                 Symbol = symbol,
            //                 Period = item.Period,
            //                 FiscalYear = item.FiscalYear,
            //                 Date = item.Date,
            //                 Data = JsonSerializer.Serialize(item)
            //             });
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         _logger.LogError(ex, "Failed to fetch quarterly data from FMP for {Symbol}", symbol);
            //         throw;
            //     }
            // }

           return new FinancialData
            {
                YearlyIncomeStatements = yearlyData,
                QuarterlyIncomeStatements = quarterlyData
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
 
