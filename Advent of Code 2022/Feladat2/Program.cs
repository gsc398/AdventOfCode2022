// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Filebol adat
var lines = File.ReadAllLines("input.txt");
var firstMoveOpponentListString = new List<string>();
var firstMoveOpponentListPointValue = new List<int>();
var secondMoveOwnListString = new List<string>();
var secondMoveOwnListPointValue = new List<int>();
foreach (string line in lines)
{
    var charactersInCurrentLine = line.ToCharArray();
    firstMoveOpponentListString.Add(charactersInCurrentLine[0].ToString());
    secondMoveOwnListString.Add(charactersInCurrentLine[2].ToString());
    if (line[0] == 'A') firstMoveOpponentListPointValue.Add(1);
    if (line[0] == 'B') firstMoveOpponentListPointValue.Add(2);
    if (line[0] == 'C') firstMoveOpponentListPointValue.Add(3);
    if (line[2] == 'X') secondMoveOwnListPointValue.Add(1);
    if (line[2] == 'Y') secondMoveOwnListPointValue.Add(2);
    if (line[2] == 'Z') secondMoveOwnListPointValue.Add(3);
}

//Adatbol eredmeny
int myPointsForSymbol=0;
int myPointsForOutcome=0;
int myTotalScore=0;
for (int i = 0; i< firstMoveOpponentListPointValue.Count; i++)
{
    myPointsForSymbol += secondMoveOwnListPointValue[i];
    myPointsForOutcome += MyParse(firstMoveOpponentListPointValue[i], secondMoveOwnListPointValue[i]);
}
myTotalScore = myPointsForOutcome + myPointsForSymbol;

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
    return 99999;
}
