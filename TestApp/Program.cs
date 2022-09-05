
using System.Text.Json;
using System.Text.Json.Serialization;

string path = "C:/Users/I_Kodirov/Desktop/ip adres list.txt";
string path2 = "C:/Users/I_Kodirov/Desktop/json.txt";


// асинхронное чтение
//using (StreamReader reader = new StreamReader(path))
//{
//    string? line;

//    while ((line = await reader.ReadLineAsync()) != null)
//    {
//        if (line != null)
//        {
//            var lineLisr = line.Split("-", StringSplitOptions.None);
//            var ipList = lineLisr[0].Split(".", StringSplitOptions.None);
//            var ipList2 = lineLisr[1].Split(".", StringSplitOptions.None);

//            using (StreamWriter writer = new StreamWriter(path2, true))
//            {
//                 await writer.WriteLineAsync($" {{ \"start\":\"{lineLisr[0]}\",\"end\":\"{lineLisr[1]}\" }},");
//                writer.Close();
//            }
//        }
//    }
//    reader.Close();
//    Console.WriteLine("<_< Complate >_>");
//}

using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
{
    IpAddress? person = await JsonSerializer.DeserializeAsync<IpAddress>(fs);

    Console.WriteLine(person.IpAdresList.Count);
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