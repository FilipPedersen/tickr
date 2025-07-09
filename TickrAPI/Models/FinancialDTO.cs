using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TickrAPI.Models;

public class FinancialData
{
    public List<IncomeStatement?> YearlyIncomeStatements { get; set; } = [];
    public List<IncomeStatement?> QuarterlyIncomeStatements { get; set; } = [];
}

public class IncomeStatement
{
    public string Date { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string ReportedCurrency { get; set; } = string.Empty;
    public string Cik { get; set; } = string.Empty;
    public string FilingDate { get; set; } = string.Empty;
    public string AcceptedDate { get; set; } = string.Empty;
    public string FiscalYear { get; set; } = string.Empty;
    public string Period { get; set; } = string.Empty;
    public double Revenue { get; set; }
    public double CostOfRevenue { get; set; }
    public double GrossProfit { get; set; }
    public double ResearchAndDevelopmentExpenses { get; set; }
    public double GeneralAndAdministrativeExpenses { get; set; }
    public double SellingAndMarketingExpenses { get; set; }
    public double SellingGeneralAndAdministrativeExpenses { get; set; }
    public double OtherExpenses { get; set; }
    public double OperatingExpenses { get; set; }
    public double CostAndExpenses { get; set; }
    public double NetInterestIncome { get; set; }
    public double InterestIncome { get; set; }
    public double InterestExpense { get; set; }
    public double DepreciationAndAmortization { get; set; }
    public double Ebitda { get; set; }
    public double Ebit { get; set; }
    public double NonOperatingIncomeExcludingInterest { get; set; }
    public double OperatingIncome { get; set; }
    public double TotalOtherIncomeExpensesNet { get; set; }
    public double IncomeBeforeTax { get; set; }
    public double IncomeTaxExpense { get; set; }
    public double NetIncomeFromContinuingOperations { get; set; }
    public double NetIncomeFromDiscontinuedOperations { get; set; }
    public double OtherAdjustmentsToNetIncome { get; set; }
    public double NetIncome { get; set; }
    public double NetIncomeDeductions { get; set; }
    public double BottomLineNetIncome { get; set; }
    public double Eps { get; set; }
    public double EpsDiluted { get; set; }
    public double WeightedAverageShsOut { get; set; }
    public double WeightedAverageShsOutDil { get; set; }
}

