// See https://aka.ms/new-console-template for more information


var dateTime = CustomDateTime.Now();
var now = CustomDateTime.Now();
var diffSeconds = (dateTime - now).TotalSeconds;

Console.WriteLine($"hour {dateTime}, Now {now} , diff {diffSeconds}");

public class TEst
{
    public void IsExpiredDateHumanizeByDate(DateTime dateTime, string message)
    {
        var now = CustomDateTime.Now();

        if (dateTime > now)
        {
            var diffSeconds = (dateTime - now).TotalDays;
             
        }
    }
}