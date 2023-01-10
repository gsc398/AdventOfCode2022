// See https://aka.ms/new-console-template for more information
using Day3;


//Global
string fileName = new("ex.txt");


MyStringAccessor MyAccessor = new MyStringAccessor(fileName);

Console.WriteLine("Number of backpacks: "+MyAccessor.NumberOfBackpacks);

string repeatedItemList = "";
for (int currentBackPack = 0; currentBackPack < MyAccessor.NumberOfBackpacks; currentBackPack++)
{
    foreach (char itemToTest in MyAccessor.FirstCompartment(currentBackPack))
    {
        if (MyAccessor.SecondCompartment(currentBackPack).Contains(itemToTest)) { repeatedItemList += itemToTest; break; }
    }
}

int prioritySum = 0;
foreach(char itemToPrioritize in repeatedItemList)
{
    if (itemToPrioritize > 96)
        prioritySum += itemToPrioritize - 96;
    else
        prioritySum += itemToPrioritize - 64 + 26;
}

Console.WriteLine("Sum priority = " + prioritySum);

//Test section
/*while(true)
{
    Console.WriteLine("Which backpack? ");
    var inputNumber = Console.ReadLine();
    Console.WriteLine("Contents in backpack " + inputNumber + " are: " + MyAccessor.FirstCompartment(Convert.ToInt32(inputNumber)));
    Console.WriteLine("Contents in backpack " + inputNumber + " are: " + MyAccessor.SecondCompartment(Convert.ToInt32(inputNumber)));
}*/

//Console.WriteLine("Repeated Items List: "+repeatedItemList);

/*for (int n = 97; n < (97+26); n++)
{
    char temp = (char)n;
    Console.WriteLine(temp);
}*/




