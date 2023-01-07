var sorok = File.ReadAllLines("example.txt");

var szamok = new List<int>();
foreach (var sor in sorok)
{
    if (sor.Length == 0)
    {
        continue;
    }
    int szam = int.Parse(sor);
    szamok.Add(szam);
}


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
*/