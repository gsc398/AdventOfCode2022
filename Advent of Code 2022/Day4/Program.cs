// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Collections.Immutable;

//IReadOnlyList<string> fileContents = new List<string>();
//fileContents = (IReadOnlyList<string>)File.ReadLines("ex.txt");

//var fileContents = new List<string>();
//fileContents = (List<string>)File.ReadLines("ex.txt");

var fileContents = File.ReadAllLines("input.txt");
//Kozben megtalaltam a neten, hogy hogy lehet belole listat csinalni, es persze en vagyok a hulye, primitiv egyszeru. ...de valoszinu sosem jottem volna most ra.
//Viszont ugye rajottem kozben, hogy mar nem is emlekszem, hogy miert mondtad, hogy hasznaljak listat, szoval mostmar mindegy, mert ugysem arra hasznalnam amire kellene. Jo lesz a tomb is. 
//Probaltam a var ele-utan irni readonly-t de sehol nem volt neki jo. Gondoltam 'szepen' csinalom, de ez is mindegy. 

//Na, most azon gondolkodom, hogy a feneben tudom szetszedni a sort 2 stringre, ahol mind a kettore kulon szuksegem van. Megintcsak emlekszem, hogy tanitottal valamit
//a ket visszatereses valamikrol, de semmi nincs mar meg belole, hogy hogy volt. (Meg errol eszembe jutott, hogy volt valami 'out' is, de mar azt sem tudom, mire volt jo. 

//Oke, vicces, ugyanugy kell csinalni, mint ahogy listat kellett volna, illetve meg egyszerubben. ...de hogy ezekre magamtol ma miert nem jovok ra....?

int lineCount = fileContents.Length; //Lehet, hogy kicsit felesleges (nagyon), de igy majd nem azon gondolkodom minden alkalommal amikor kell, hogy hogy is kell megtudnom az elemszamot.



//Most kivadaszom a sorokbol a 4 szamot
string lineFirstPart(int lineID)
{
    var lineParts = fileContents[lineID].Split(',');
    return lineParts[0];
}

string lineSecondPart(int lineID)
{
    var lineParts = fileContents[lineID].Split(','); 
    return lineParts[1];
}

int firstNumberInLine(int lineID)
{
    var numbersInPart = lineFirstPart(lineID).Split('-');
    return (int)Int64.Parse(numbersInPart[0]);
}

int secondNumberInLine(int lineID)
{
    var numbersInPart = lineFirstPart(lineID).Split('-');
    return (int) Int64.Parse(numbersInPart[1]);
}

int thirdNumberInLine(int lineID)
{
    var numbersInPart = lineSecondPart(lineID).Split('-');
    return (int) Int64.Parse(numbersInPart[0]);
}

int fourthNumberInLine(int lineID)
{
    var numbersInPart = lineSecondPart(lineID).Split('-');
    return (int)Int64.Parse(numbersInPart[1]);
}

//Itt meg kiszamolom a 2 range-et es megszamolom az atfedeseket
int pairsWithCompleteOverlap = 0;
for (int line = 0; line < lineCount; line++) //Persze nem emlekeztem a lineCount nevere igy igazan sokat nem ert..
{
    /*bool markerOfFind = false;
    for (int itemInFirstRangeOfLine = firstNumberInLine(line); itemInFirstRangeOfLine < secondNumberInLine(line) + 1; itemInFirstRangeOfLine++) //Na, itt nem volt igaz, amit mondtal, hogy mindig siman kisebbet kell irni. Itt kellett +1, de probalmtam elobb != meg !>, ha egyaltalan van ilyen jel...
    {
        //Nagyon szarul sikerult az elnevezes, vegtelen hosszuak a sorok, olvashatatlan, es nem is tudom, mi micsoda. De hogy lehet jobban???
        //Console.WriteLine(itemInFirstRangeOfLine);
        for (int itemInSecondRangeOfLine = thirdNumberInLine(line); itemInSecondRangeOfLine < fourthNumberInLine(line) + 1; itemInSecondRangeOfLine++)
        {
            if (itemInFirstRangeOfLine)
        }

    }*/

    if (thirdNumberInLine(line) >= firstNumberInLine(line) && fourthNumberInLine(line) <= secondNumberInLine(line)) pairsWithCompleteOverlap++;
    else if (firstNumberInLine(line) >= thirdNumberInLine(line) && secondNumberInLine(line) <= fourthNumberInLine(line)) pairsWithCompleteOverlap++; //Ezt istentelen nehez volt osszesakkozni fejben (illetve papir segedlettel)

    Console.WriteLine(line + "   " + pairsWithCompleteOverlap);
}

Console.WriteLine("Overlaps:"+pairsWithCompleteOverlap);
