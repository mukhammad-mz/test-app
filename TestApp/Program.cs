using System.Text.Json;
using System.Text.Json.Serialization;

string path2 = "json.txt";

string UserIP = "177.113.143.255";
bool found = false;

using (FileStream fileStream = new FileStream(path2, FileMode.OpenOrCreate))
{
    var ipAddressRangeList = await JsonSerializer.DeserializeAsync<List<IPRange>>(fileStream);

    if (ipAddressRangeList == null || ipAddressRangeList.Count <= 0)
    {
        Console.WriteLine("Not Found");

        return;
    }

    foreach (var range in ipAddressRangeList)
    {
        if (IpFind.Find(UserIP, range))
        {
            found = true;
            break;
        }
    }
    
}

if (found)
    Console.WriteLine("Found");
else
    Console.WriteLine("Not Found");


public class IpFind
{
    public static bool CheckUserIPInRange(string IpAdress, IPRange data)
    {
        var userIPSplit = IpAdress.Split(".", StringSplitOptions.None);
        var startSplit = data.Start.Split(".", StringSplitOptions.None);
        var endSplit = data.End.Split(".", StringSplitOptions.None);

        for (int i = 0; i < 4; i++)
        {
            if (!CheckSplitedRange(Convert.ToInt32(userIPSplit[i]), Convert.ToInt32(startSplit[i]), Convert.ToInt32(endSplit[i])))
            {
                return false;
            }
        }

        return true;
      
    }

    private static bool CheckSplitedRange(int userSplitedRange, int startSplitedRange, int endSplitedRange)
    {
        if (userSplitedRange >= startSplitedRange && userSplitedRange <= endSplitedRange)
        {
            return true;
        }

        return false;
    }
}

public partial class IPRange
{
    [JsonPropertyName("start")]
    public string Start { get; set; }

    [JsonPropertyName("end")]
    public string End { get; set; }
}