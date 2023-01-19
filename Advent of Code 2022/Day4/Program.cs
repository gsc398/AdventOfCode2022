// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Collections.Immutable;

var fileContents = File.ReadAllLines("input.txt");

int lineCount = fileContents.Length; 

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
for (int line = 0; line < lineCount; line++) 
{
    if (thirdNumberInLine(line) >= firstNumberInLine(line) && fourthNumberInLine(line) <= secondNumberInLine(line)) pairsWithCompleteOverlap++;
    else if (firstNumberInLine(line) >= thirdNumberInLine(line) && secondNumberInLine(line) <= fourthNumberInLine(line)) pairsWithCompleteOverlap++; 
}

Console.WriteLine("Complete overlaps:"+pairsWithCompleteOverlap);

int pairsWithAnyOverlap = 0;
for (int line = 0; line < lineCount; line++) 
{
    if (thirdNumberInLine(line) >= firstNumberInLine(line) && thirdNumberInLine(line) <= secondNumberInLine(line)) pairsWithAnyOverlap++;
    else if (fourthNumberInLine(line) >= firstNumberInLine(line) && fourthNumberInLine(line) <= secondNumberInLine(line)) pairsWithAnyOverlap++;
    else if (fourthNumberInLine(line) >= firstNumberInLine(line) && thirdNumberInLine(line) <= secondNumberInLine(line)) pairsWithAnyOverlap++;

    //Na, először rossz eredmény lett (csak 2 sor if volt, nem 3. Pedig azt a kettőt is vért izzadva számpárokat papírra írkálva és fejben végigküzdve, hogy mi mekkora írtam,
    //s persze nem értettem, hogy miért nem találja meg az összes átfedést. Szerintem egy órát biztos ültem rajta és írtam fel mindenféle számpárokat, mire találtam egyet, amire egyik
    //sem teljesült és akkor arra külön írtam egy harmadik sort. Így jó lett, de ez full trial and error, valószínű csak véletlen, hogy épp ez a 3 sor magában foglalja az összes 
    //átfedést. Semmiféle empirikus módszert nem tudok kitalálni, hogy miképpen írhatnék egy tesztet, ami felszedi az összeset és be is tudom mutatni, hogy miért fogja mindet megtalálni.
    //Persze, úgy lehetett volna még kőbunkóbb módon csinálni, hogy fizikailag kiírom az összes elemét a számpároknak és egyenként végigmegyek rajtuk, hogy van-e köztük egyforma. 
    //Azonban azt tanítottad, hogy ne pazaroljam az erőforrásokat, márpedig az nagyon sokszor ennyi munka lett volna (minden számpárhoz, nem is csak elfpárhoz) létre kellett volna hozni
    //egy új tömböt, egy ciklussan feltölteni, aztán egy másik ciklussal végigmenni az elsőn és belső ciklussal a másodikon. Azt látom, hogy az nagyságrendekkel tovább tartana. 
    //Viszont, akkor tudnám garantálni, hogy a megoldás jó, és minden esetben megtalálminden átfedést. A jelen megoldás valószínű jól működik, de nem lehetek benne biztos, hogy ez minden
    //esetben igaz, és csak a véletlen műve, hogy ha egyáltalán működik. ....ráadásul ezt megírni... ...szó szerint fájt már a fejem és csillagokat láttam a számpoárokat írva és 
    //összehasonlítva. Nagyon sokáig tartott. ...még a sokkal lassabb megoldást össze lehetett volna rakni kb gondolkodás nélkül és el is készül töredék ennyi idő alatt annak ellenére,
    //hogy az nem 3 sor, hanem sokkal több. 

    //Console.WriteLine(line + "   " + pairsWithAnyOverlap);
}

Console.WriteLine("Any overlaps:" + pairsWithAnyOverlap);

