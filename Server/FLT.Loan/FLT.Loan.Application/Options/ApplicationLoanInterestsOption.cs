namespace FLT.Loan.Application.Options;

public class ApplicationLoanInterestsOption
{
    public decimal PrimeRate { get; set; }
    public int MinPeriodInMonth { get; set; }
    public decimal AbnormalInterestRate { get; set; }
}
