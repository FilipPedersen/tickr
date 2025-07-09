using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TickrAPI.Models;

[Table("income_statements")]
public class StoredIncomeStatement : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("symbol")]
    public string Symbol { get; set; } = string.Empty;
    [Column("period")]
    public string Period { get; set; } = string.Empty;
    [Column("fiscal_year")]
    public string FiscalYear { get; set; } = string.Empty;
    [Column("date")]
    public string Date { get; set; } = string.Empty;
    [Column("data")]
    public string Data { get; set; } = string.Empty;
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}