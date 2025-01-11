namespace FLT.Kernel.Infrastructure.Extensions;

public static class DateTimeExtensions
{
   
    public static int YearsSince(this DateTime dateTime)
    {
        var now = DateTime.Now;
        int years = now.Year - dateTime.Year;

        if (now < dateTime.AddYears(years))
        {
            years--;
        }

        return years;
    }

}