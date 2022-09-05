using System.Text.Json;
using System.Text.Json.Serialization;

string path2 = "json.txt";

string UserIP = "176.113.143.255";
bool found = false;

using (FileStream fileStream = new FileStream(path2, FileMode.OpenOrCreate))
{
    var ipAddressRangeList = await JsonSerializer.DeserializeAsync<IPRangeList>(fileStream);

    if (ipAddressRangeList != null)
        foreach (var range in ipAddressRangeList.Range)
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
    public static bool Find(string IpAdress, Range data)
    {
        var userIpSplit = IpAdress.Split(".", StringSplitOptions.None);
        //step 1
        if (data.Start.StartsWith(userIpSplit[0]))
        {
            try
            {
                //step 2
                if (String.Equals(data.Start.Substring(userIpSplit[0].Length + 1, userIpSplit[1].Length), userIpSplit[1]))
                {
                    var start = int.Parse(data.Start.Substring(userIpSplit[0].Length + userIpSplit[1].Length + 2, userIpSplit[2].Length));
                    var end = int.Parse(data.End.Substring(userIpSplit[0].Length + userIpSplit[1].Length + 2, userIpSplit[2].Length));
                    var userIp = int.Parse(userIpSplit[2]);

                    //step 3
                    if (start <= userIp && end >= userIp)
                    {
                        start = int.Parse(data.Start.Substring(data.Start.LastIndexOf('.') + 1));
                        end = int.Parse(data.End.Substring(data.End.LastIndexOf('.') + 1));
                        userIp = int.Parse(userIpSplit[3]);

                        //step 4 
                        if (start <= userIp && end >= userIp)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        return false;
    }
}

public partial class IPRangeList
{
    [JsonPropertyName("ip-range-list")]
    public List<Range> Range { get; set; }
}

public partial class Range
{
    [JsonPropertyName("start")]
    public string Start { get; set; }

    [JsonPropertyName("end")]
    public string End { get; set; }
}