namespace TickrAPI.Models;

public class ChartData
{
    public string Symbol { get; set; } = string.Empty;
    public MetricChartView Yearly { get; set; } = new MetricChartView();
    public MetricChartView Quarterly { get; set; } = new MetricChartView();
}

public class MetricChartView
{
    public List<Metric> Metrics { get; set; } = [];
}

public class Metric
{
    public string Name { get; set; } = string.Empty; // e.g., "Revenue", "NetIncome"
    public ChartView ChartView { get; set; } = new ChartView();
}

public class ChartView
{
    public List<string> Labels { get; set; } = []; // e.g., ["2023", "2022"] or ["2023-Q4", "2023-Q3"]
    public List<double> Data { get; set; } = []; // e.g., [394328000000, 365817000000]
}