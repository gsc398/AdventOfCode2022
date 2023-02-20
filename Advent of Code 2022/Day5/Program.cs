// See https://aka.ms/new-console-template for more information

//Split the input file into 2 sets of lines with the logically different content (stacks and instructions)
using Day5;
using System.Security.Cryptography.X509Certificates;

var fileContents = File.ReadAllLines("input.txt");
List<string> stacks = new List<string>();
List<string> instructions = new List<string>();
bool emptyLineReached =false;
foreach(string line in fileContents)
{
    if (line == "") emptyLineReached = true;

    if (!emptyLineReached)
    {
        stacks.Add(line);
    }
    else if (line != "")
    {
        instructions.Add(line); 
    }
}

//Testing if it worked
/*foreach (string line in stacks)
{
    Console.WriteLine(line);
}
Console.WriteLine(" Next Set ");
foreach(string line in instructions)
{
    Console.WriteLine(line);
}*/
//Mukodott. :) (Na, nem elsore...)

//Most a kupacokkal foglalkozok, levagom az also sort, mert azok csak szamok, es megallapitom hany kupac van
//Probalom ugy megirni a programot, hogy univerzalis legyen (pl a feladatban nincs 2 jegyu szamu kupac, de lehetne..)
char[] nrOfStacksTemporaryChar = new char[100];
string lastLineOfStacks = stacks.Last().Trim();
for (int n=lastLineOfStacks.Length; n > 0; n--)
{
    //Console.WriteLine(lastLineOfStacks[n - 1].ToString());
    if (lastLineOfStacks[n-1] != ' ')
    {
        nrOfStacksTemporaryChar[99 - (lastLineOfStacks.Length - n)] = lastLineOfStacks[n-1];
    }
    else break;
}
string nrOfStacksTemporaryString = new string(nrOfStacksTemporaryChar);
//Console.WriteLine("Number of Stacks:" +nrOfStacksTemporaryString);
nrOfStacksTemporaryString = nrOfStacksTemporaryString.Replace((char)0, ' ');
nrOfStacksTemporaryString = nrOfStacksTemporaryString.Trim();
int nrOfStacks = (int) Int64.Parse(nrOfStacksTemporaryString);
Console.WriteLine("Number of Stacks:" + nrOfStacks.ToString());
//Hogy ezzel a par sorral mennyit szivtam!? 

stacks.RemoveAt(stacks.Count - 1); //Kivettem a listabol az utolso sort, ami nem stack-ot abrazol

//A Stack abrazolasaban fix karakterpoziciokban van a crate neve, tehat csak ezeket a karakterpoziciokat kell nezni. 
//Ami megbonyolitja, hogy nem minden sor feltetlenul ugyanolyan hosszu, tehat nem minden pozicio letezik.

//List<char>[] stackList = new List<char>[nrOfStacks]; //Ez a sor eddig a legeslegnehezebb felfogni meg a Te segitsegeddel is! Brutal ez a c# logika! Nem embernek valo!
//Tovabbra is teljesen bizonytalan vagyok, hiaba irtad le, mert azt sem igazan ertem, hogy ez most tulajdonkeppen mit is hoz letre?? Te azt mondod tombot. De akkor milyen tipusu 
//tombot? ...es ha egyszer az van ott, hogy List, akkor miert nem listat hoz letre? :o 

//Javaslod itt ezt a StringBuildert, dehat hogy kell azt hasznali????? En nem merem. Maradok a listaknal, igazabol azt sem tudom meg hasznalni. 

List<char>[] stackList = new List<char>[nrOfStacks];
for (int n=0; n < nrOfStacks; n++)
{ stackList[n] = new List<char>(); }

foreach (string line in stacks)
{
    for (int selectedStack = 0; selectedStack < nrOfStacks; selectedStack++)
    {
        if ((1 + (4 * selectedStack)) <= (line.Length - 1))
        {
            if (line[1 + (4 * selectedStack)] != ' ') //Megadja (remelem) a kovetkezo poziciot olvasasra
            {
                stackList[selectedStack].Add(line[1 + (4 * selectedStack)]);
            }
        }
        
    }
}

//Ellenorzes
//Megnéztem a debuggerben a változók tartalmár és jó.

//Akkor most johet maga a feladat, a dobozok mozgatasa.... El kell olvasnom ujra a feladatot, mar nem emlekszem. 

var DataProcessor = new CrateMover(instructions);

//int nextSourceStack;
//int nextDestinationStack;
//int numberToMove;

for (int position = 0; position < DataProcessor.Count(); position++)
{
    for (int moveCounter = 0; moveCounter < DataProcessor.NumberToMove(position); moveCounter++)
    {
        //nextDestinationStack = DataProcessor.NextDestinationStack(position);
        //nextSourceStack = DataProcessor.NextSourceStack(position);
        Console.WriteLine(DataProcessor.NumberToMove(position).ToString() + " " + DataProcessor.NextSourceStack(position).ToString() + " " + DataProcessor.NextDestinationStack(position).ToString());
    }
    // Ellenorzes: Passed // Console.WriteLine(DataProcessor.NumberToMove(position).ToString() ...... ilyesmi.
    

}

