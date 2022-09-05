using System.Text.Json;
using System.Text.Json.Serialization;

string path = "C:/Users/I_Kodirov/Desktop/ip adres list.txt";
string path2 = "C:/Users/I_Kodirov/Desktop/json.txt";

string UserIP = "176.113.143.255";
bool found = false;

using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
{
    IpAddress? person = await JsonSerializer.DeserializeAsync<IpAddress>(fs);

    foreach (var item in person.IpAdresList)
    {
        if (IpFind.Find(UserIP, item))
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
    public static bool Find(string IpAdress, IpAdresList data)
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
                    var ip3 = int.Parse(userIPSplit[2]);

                    //step 3
                    if (start <= ip3 && end >= ip3)
                    {
                        start = int.Parse(data.Start.Substring(data.Start.LastIndexOf('.') + 1));
                        end = int.Parse(data.End.Substring(data.End.LastIndexOf('.') + 1));
                        ip3 = int.Parse(userIPSplit[3]);

                        //step 4 
                        if (start <= ip3 && end >= ip3)
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

public partial class IpAddress
{
    [JsonPropertyName("ip-adres-list")]
    public List<IpAdresList> IpAdresList { get; set; }
}

public partial class IpAdresList
{
    [JsonPropertyName("start")]
    public string Start { get; set; }

    [JsonPropertyName("end")]
    public string End { get; set; }
}
