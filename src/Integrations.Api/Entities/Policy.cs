namespace Integrations.Api.Entities;

public class Policy
{
    public int Id { get; set; }

    public string PolicyNumber { get; set; } = string.Empty;

    public string HolderName { get; set; } = string.Empty;

    public decimal Premium { get; set; }

    public DateOnly EffectiveDate { get; set; }
}
