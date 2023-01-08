var sorok = File.ReadAllLines("input.txt");

//var szamok = new List<int>();
/*foreach (var sor in sorok)
{
    if (sor.Length == 0)
    {
        continue;
    }
    int szam = int.Parse(sor);
    szamok.Add(szam);
}*/

var dverger = new List<int>();
//int AntallDverger = 0;
int AktuellDvergMat = 0;

foreach (var sor in sorok)
{
    if (sor.Length == 0)
    {
        //AntallDverger++;
        dverger.Add(AktuellDvergMat);
        AktuellDvergMat = 0;
        continue;
    }
    int Mat = int.Parse(sor);
    //AktuellDvergMat = AktuellDvergMat + Mat;

}
if (AktuellDvergMat != 0)
{
    dverger.Add(AktuellDvergMat);
}

var StorDverg = new List<int>();
StorDverg.Add(0);
StorDverg.Add(0);
StorDverg.Add(0);
int DvergNummer = 0;
int n = 0;
int n2 = 0;
int n3 = 0;

foreach (int dverg in dverger)
{
    n++;
    if (dverg > StorDverg[0])
    {
        StorDverg[0] = dverg;
        DvergNummer = n;
        n2 = n;
    }

}


n = 0;
foreach (int Dverg in dverger)
{
    n++;
    if (Dverg > StorDverg[1] && n != n2)
    {
        StorDverg[1] = Dverg;
        DvergNummer = n;
        n3 = n;
    }

}

n = 0;
foreach (int Dverg in dverger)
{
    n++;
    if (Dverg > StorDverg[2] && n != n3 && n != n2)
    {
        StorDverg[2] = Dverg;
        //DvergNummer = n;
    }

}


Console.WriteLine("1st" + StorDverg[0]);
Console.WriteLine("2nd" + StorDverg[1]);
Console.WriteLine("3rd" + StorDverg[2]);
Console.WriteLine("Sum" + (StorDverg[2]+ StorDverg[1]+ StorDverg[0]));



/*
var lista = new List<string>();
lista.Add("Hello");
lista.Add("Jani");

foreach (string elem in lista)
{
    Console.WriteLine(elem);
}

for (int i = 0; i < lista.Count; i++)
{
    Console.WriteLine(lista[i]);
}

while (true)
{
    break;
}
*/