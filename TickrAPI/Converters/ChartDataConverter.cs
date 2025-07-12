using TickrAPI.Models;

namespace TickrAPI.Converters;

public class ChartDataConverter
{
    public ChartData ConvertToChartData(FinancialData financialData, string symbol)
    {
        const int yearlyLimit = 10;
        const int quarterlyLimit = 20;

        var yearlyStatements = financialData.YearlyIncomeStatements
            .Where(x => x != null)
            .OrderByDescending(x => x!.Date)
            .Take(yearlyLimit)
            .ToList();

        var chartData = new ChartData
        {
            Symbol = symbol,
            Yearly = new MetricChartView
            {
                Metrics = new List<Metric>
                {
                    new Metric
                    {
                        Name = "Revenue",
                        ChartView = new ChartView
                        {
                            Labels = yearlyStatements.Select(x => x!.FiscalYear).ToList(),
                            Data = yearlyStatements.Select(x => x!.Revenue).ToList()
                        }
                    },
                    new Metric
                    {
                        Name = "NetIncome",
                        ChartView = new ChartView
                        {
                            Labels = yearlyStatements.Select(x => x!.FiscalYear).ToList(),
                            Data = yearlyStatements.Select(x => x!.NetIncome).ToList()
                        }
                    },
                    new Metric
                    {
                        Name = "OperatingExpenses",
                        ChartView = new ChartView
                        {
                            Labels = yearlyStatements.Select(x => x!.FiscalYear).ToList(),
                            Data = yearlyStatements.Select(x => x!.OperatingExpenses).ToList()
                        }
                    },
                    new Metric
                    {
                        Name = "GrossProfit",
                        ChartView = new ChartView
                        {
                            Labels = yearlyStatements.Select(x => x!.FiscalYear).ToList(),
                            Data = yearlyStatements.Select(x => x!.GrossProfit).ToList()
                        }
                    }
                }
            }
        };

        var quarterlyStatements = financialData.QuarterlyIncomeStatements
            .Where(x => x != null)
            .OrderByDescending(x => x!.Date)
            .Take(quarterlyLimit)
            .ToList();

        chartData.Quarterly = new MetricChartView
        {
            Metrics = new List<Metric>
            {
                new Metric
                {
                    Name = "Revenue",
                    ChartView = new ChartView
                    {
                        Labels = quarterlyStatements.Select(x => $"{x!.FiscalYear}-{x.Period}").ToList(),
                        Data = quarterlyStatements.Select(x => x!.Revenue).ToList()
                    }
                },
                new Metric
                {
                    Name = "NetIncome",
                    ChartView = new ChartView
                    {
                        Labels = quarterlyStatements.Select(x => $"{x!.FiscalYear}-{x.Period}").ToList(),
                        Data = quarterlyStatements.Select(x => x!.NetIncome).ToList()
                    }
                },
                new Metric
                {
                    Name = "OperatingExpenses",
                    ChartView = new ChartView
                    {
                        Labels = quarterlyStatements.Select(x => $"{x!.FiscalYear}-{x.Period}").ToList(),
                        Data = quarterlyStatements.Select(x => x!.OperatingExpenses).ToList()
                    }
                },
                new Metric
                {
                    Name = "GrossProfit",
                    ChartView = new ChartView
                    {
                        Labels = quarterlyStatements.Select(x => $"{x!.FiscalYear}-{x.Period}").ToList(),
                        Data = quarterlyStatements.Select(x => x!.GrossProfit).ToList()
                    }
                }
            }
        };

        return chartData;
    }
}