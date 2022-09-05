using System.Text.Json;
using System.Text.Json.Serialization;

string path2 = "json.txt";

string UserIP = "176.113.143.255";
bool found = false;

using (FileStream fileStream = new FileStream(path2, FileMode.OpenOrCreate))
{
    var ipAddressList = await JsonSerializer.DeserializeAsync<IpAddressList>(fileStream);

    if (ipAddressList != null)
        foreach (var ipAddress in ipAddressList.IpAdress)
        {
            if (IpFind.Find(UserIP, ipAddress))
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
    public static bool Find(string IpAdress, IpAdress data)
    {
        var userIPSplit = IpAdress.Split(".", StringSplitOptions.None);
        //step 1
        if (data.Start.StartsWith(userIPSplit[0]))
        {
            try
            {
                //step 2
                if (String.Equals(data.Start.Substring(userIPSplit[0].Length + 1, userIPSplit[1].Length), userIPSplit[1]))
                {
                    var start = int.Parse(data.Start.Substring(userIPSplit[0].Length + userIPSplit[1].Length + 2, userIPSplit[2].Length));
                    var end = int.Parse(data.End.Substring(userIPSplit[0].Length + userIPSplit[1].Length + 2, userIPSplit[2].Length));
                    var userIp = int.Parse(userIPSplit[2]);

                    //step 3
                    if (start <= userIp && end >= userIp)
                    {
                        start = int.Parse(data.Start.Substring(data.Start.LastIndexOf('.') + 1));
                        end = int.Parse(data.End.Substring(data.End.LastIndexOf('.') + 1));
                        userIp = int.Parse(userIPSplit[3]);

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

public partial class IpAddressList
{
    [JsonPropertyName("ip-adress-list")]
    public List<IpAdress> IpAdress { get; set; }
}

public partial class IpAdress
{
    [JsonPropertyName("start")]
    public string Start { get; set; }

    [JsonPropertyName("end")]
    public string End { get; set; }
}