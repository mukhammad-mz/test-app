string path = "C:/Users/I_Kodirov/Desktop/ip adres list.txt";
string path2 = "C:/Users/I_Kodirov/Desktop/ip list all.txt";


// асинхронное чтение
using (StreamReader reader = new StreamReader(path))
{
    string? line;
    int count = 0;

    while ((line = await reader.ReadLineAsync()) != null)
    {
        if (line != null)
        {
            int i = 0;
            bool temp = false;
            var lineLisr = line.Split("-", StringSplitOptions.None);
            var ipList = lineLisr[0].Split(".", StringSplitOptions.None);
            var ipList2 = lineLisr[1].Split(".", StringSplitOptions.None);

            int ip1_3 = Convert.ToInt16(ipList[2 + i]);
            int ip1_4 = Convert.ToInt16(ipList[3]);

            int ip2_3 = Convert.ToInt16(ipList2[2 + i]);
            int ip2_4 = Convert.ToInt16(ipList2[3]);

            using (StreamWriter writer = new StreamWriter(path2, true))
            {
                for (; ip2_3 >= ip1_3; ip1_3++, temp = true)
                {
                    if (ip1_4 > 0 && ip2_3 > ip1_3 && !temp )
                    {
                        await writer.WriteLineAsync($"{ipList[0]}.{ipList[1]}.{ip1_3}.{ip1_4}/255");
                    }
                    else if (ip1_3 == ip2_3 && ip1_4 > 0 && temp)
                    {
                        await writer.WriteLineAsync($"{ipList[0]}.{ipList[1]}.{ip1_3}.0/{ip2_4}");
                    }
                    else
                        await writer.WriteLineAsync($"{ipList[0]}.{ipList[1]}.{ip1_3}.0/255");
                }
                writer.Close();
            }
        }
    }
    reader.Close();
    Console.WriteLine("Ok");
}
