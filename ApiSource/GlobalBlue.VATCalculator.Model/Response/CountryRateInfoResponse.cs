
namespace GlobalBlue.VATCalculator.Model.Response;

public class CountryRateInfoResponse
{
    public int Id { get; set; }

    public string RateTitle { get; set; }

    public decimal Rate { get; set; }

    public int CountryId { get; set; }
}