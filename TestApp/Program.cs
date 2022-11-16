// See https://aka.ms/new-console-template for more information

for (int i = 0; i <= 100; i++)
{
    Console.WriteLine("<------------>");
    Console.WriteLine($"my {i} {TestYear.GetExpirationFormatYear(i)}");
    Console.WriteLine($"offer {i} {TestYear.GetOfferExpFormat(i)}");
    Console.WriteLine("<------------>");
}
class  TestYear
{
    public static string GetExpirationFormatYear(int expirationDate)
    {
        int expiration = expirationDate % 10;

        if (expirationDate > 10 && expirationDate < 20 ||
            expiration >= 5 && expiration <= 9 || expiration == 0)
            return "лет";
        if (expiration >= 2 && expiration <= 4)
            return "года";
        else
            return "год";
    }
    public static string GetOfferExpFormat(int offerExpiration)
    {
        

        int offerExp = offerExpiration / 12 % 10;

        int offerExpDec = offerExpiration / 12 % 100 / 10;

        if (offerExp == 1)
            return "год";

        string year = offerExp > 0 && offerExp < 5 && offerExpDec != 1 ? "года" : "лет";

        return year;
    }
}
