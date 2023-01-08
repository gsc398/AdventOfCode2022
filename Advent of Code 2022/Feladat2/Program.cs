// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Filebol adat
var lines = File.ReadAllLines("input.txt");
var opponentListPointValue = new List<int>();
var ownListPointValue = new List<int>();
foreach (string line in lines)
{
    var charactersInCurrentLine = line.ToCharArray();
    if (line[0] == 'A') opponentListPointValue.Add(1);
    if (line[0] == 'B') opponentListPointValue.Add(2);
    if (line[0] == 'C') opponentListPointValue.Add(3);
    if (line[2] == 'X') ownListPointValue.Add(1);
    if (line[2] == 'Y') ownListPointValue.Add(2);
    if (line[2] == 'Z') ownListPointValue.Add(3);
}

//Adatbol eredmeny
int myPointsForSymbol=0;
int myPointsForOutcome=0;
for (int i = 0; i< opponentListPointValue.Count; i++)
{
    myPointsForSymbol += ownListPointValue[i];
    myPointsForOutcome += MyParse(opponentListPointValue[i], ownListPointValue[i]);
}
int myTotalScore = myPointsForOutcome + myPointsForSymbol;

Console.WriteLine("MyTotalScore " + myTotalScore);

int MyParse(int opponentMove, int ownMove)
{
    if (opponentMove == ownMove) return 3;
    if (opponentMove == 1 && ownMove == 2) return 6;
    if (opponentMove == 1 && ownMove == 3) return 0;
    if (opponentMove == 2 && ownMove == 1) return 0;
    if (opponentMove == 2 && ownMove == 3) return 6;
    if (opponentMove == 3 && ownMove == 1) return 6;
    if (opponentMove == 3 && ownMove == 2) return 0;
    throw new ArgumentException();
}

//Masodik feladat
for (int i = 0; i < opponentListPointValue.Count; i++)
{
    int winDrawLooseSelector = ownListPointValue[i];
    if (winDrawLooseSelector == 2) ownListPointValue[i] = opponentListPointValue[i];
    if (winDrawLooseSelector == 1)
    {
        if (opponentListPointValue[i] == 1) ownListPointValue[i] = 3;
        if (opponentListPointValue[i] == 2) ownListPointValue[i] = 1;
        if (opponentListPointValue[i] == 3) ownListPointValue[i] = 2;
    }
    if (winDrawLooseSelector == 3)
    {
        if (opponentListPointValue[i] == 1) ownListPointValue[i] = 2;
        if (opponentListPointValue[i] == 2) ownListPointValue[i] = 3;
        if (opponentListPointValue[i] == 3) ownListPointValue[i] = 1;
    }

}

myPointsForSymbol = 0;
myPointsForOutcome = 0;
for (int i = 0; i < opponentListPointValue.Count; i++)
{
    myPointsForSymbol += ownListPointValue[i];
    myPointsForOutcome += MyParse(opponentListPointValue[i], ownListPointValue[i]);
}
myTotalScore = myPointsForOutcome + myPointsForSymbol;

Console.WriteLine("MyTotalScore New" + myTotalScore);