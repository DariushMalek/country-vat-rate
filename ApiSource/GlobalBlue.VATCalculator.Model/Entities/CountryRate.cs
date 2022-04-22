
namespace GlobalBlue.VATCalculator.Model.Entities;

public class CountryRate : EntityBase
{
    public string RateTitle { get; set; }

    public decimal Rate { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public Country Country { get; set; }
}