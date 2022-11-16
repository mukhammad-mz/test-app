// See https://aka.ms/new-console-template for more information

for (int i = 0; i < 200; i++)
{
    Console.WriteLine($"{i} {TestYear.GetExpirationFormatYear(i)}");
}
class  TestYear
{
    public static string GetExpirationFormatYear(int expirationDate)
    {
        int expiration = expirationDate % 10;

        if (expiration == 1)
            return "год";

        if (expiration >= 2 && expiration <= 4)
            return "года";

        if (expiration >= 5 && expiration <= 9 || expiration == 0)
            return "лет";

        return "";
    }
}
