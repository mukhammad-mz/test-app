string path = "C:/Users/I_Kodirov/Desktop/ip adres list.txt";
string path2 = "C:/Users/I_Kodirov/Desktop/json.txt";


// асинхронное чтение
using (StreamReader reader = new StreamReader(path))
{
    string? line;

    while ((line = await reader.ReadLineAsync()) != null)
    {
        if (line != null)
        {
            var lineLisr = line.Split("-", StringSplitOptions.None);
            var ipList = lineLisr[0].Split(".", StringSplitOptions.None);
            var ipList2 = lineLisr[1].Split(".", StringSplitOptions.None);

            using (StreamWriter writer = new StreamWriter(path2, true))
            {
                 await writer.WriteLineAsync($" {{ \"start\":\"{lineLisr[0]}\",\"end\":\"{lineLisr[1]}\" }},");
                writer.Close();
            }
        }
    }
    reader.Close();
    Console.WriteLine("<_< Complate >_>");
}
