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
            var lineLisr = line.Split("-", StringSplitOptions.None);
            var ipList = lineLisr[0].Split(".", StringSplitOptions.None);
            var ipList2 = lineLisr[1].Split(".", StringSplitOptions.None);

            int ip1_3 = Convert.ToInt16(ipList[2 + i]);
            int ip1_4 = Convert.ToInt16(ipList[3]);

            int ip2_3 = Convert.ToInt16(ipList2[2 + i]);
            int ip2_4 = Convert.ToInt16(ipList2[3]);

            using (StreamWriter writer = new StreamWriter(path2, true))
            {
                for (; ip2_3 >= ip1_3; ip1_3++)
                {
                    if (ip2_3 == ip1_3 && ip2_4 > 0)
                        for (int j = ip1_4; j <= ip2_4; j++)
                        {
                            await writer.WriteLineAsync($"{ipList[0]}.{ipList[1]}.{ip1_3}.{j}");
                            count++;

                        }
                    else
                        for (int j = 0; j <= 255; j++)
                        {
                            await writer.WriteLineAsync($"{ipList[0]}.{ipList[1]}.{ip1_3}.{j}");
                            count++;
                        }
                }
                writer.Close();
            }
            Console.WriteLine(count);
            count = 0;
        }
    }
    reader.Close();
}
