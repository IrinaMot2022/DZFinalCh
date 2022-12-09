void PrintArray(Array varr, string v_f)
{
    int[] vidxArr = new int[varr.Rank];
    for (int i = 0; i < vidxArr.Length; i++) vidxArr[i] = 0;

    while (vidxArr[0] < varr.GetLength(0))
    {
        for (int i = 0; i < varr.Rank - 1; i++)
        {
            Console.Write($"({vidxArr[i],3})");
            if (i < varr.Rank - 2) Console.Write(",");
        }
        Console.Write("[");
        for (int i = 0; i < varr.GetLength(varr.Rank - 1); i++)
        {
            vidxArr[vidxArr.Length - 1] = i;
            string v_str = String.Format(v_f, varr.GetValue(vidxArr));
            Console.Write(v_str);
            if (vidxArr[vidxArr.Length - 1] < varr.GetLength(vidxArr.Length - 1) - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
        int vcurRank = varr.Rank - 2;
        if (vcurRank >= 0)
        {
            while (vidxArr[vcurRank] >= varr.GetLength(vcurRank)) vcurRank--;

            if (vidxArr[vcurRank] < varr.GetLength(vcurRank) - 1) vidxArr[vcurRank]++;
            else
            {
                for (int i = vcurRank; i < varr.Rank - 1; i++) vidxArr[i] = 0;
                vcurRank--;
                if (vcurRank >= 0) vidxArr[vcurRank]++; else break;
            }
        }
        else break;
    }
}

string[] FilterArray(string[] varr, int vFilterLength)
{
    int vLen = varr.Length;
    int i = 0;
    while ((i < vLen) && (vLen > 0))
    {
        if (varr[i].Length > vFilterLength)
        {
            (varr[i], varr[vLen - 1]) = (varr[vLen - 1], varr[i]);
            vLen--;
        }
        else i++;
    }
    string[] vRes = new string[vLen];
    for (i = 0; i < vLen; i++) vRes[i] = varr[i];
    return vRes;
}

//string[] vArr = { "hello", "2", "world", ":-)" };
//string[] vArr = { "Russia", "Denmark", "Kazan" };
string[] vArr = { "1234", "1567", "-2", "computer science" };
Console.WriteLine("Исходный массив");
PrintArray(vArr, "{0}");
string[] vFilteredArr = FilterArray(vArr, 3);
Console.WriteLine("Фильтрованный (темный) массив");
if (vFilteredArr.Length == 0) Console.WriteLine("[]"); else PrintArray(vFilteredArr, "{0}");