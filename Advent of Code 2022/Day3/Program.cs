// See https://aka.ms/new-console-template for more information
using Day3;


//Global
string fileName = new("input.txt");


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

int CalculatePrioritySums(string itemList)
{
    int prioritySum = 0;
    foreach (char itemToPrioritize in itemList)
    {
        if (itemToPrioritize > 96)
            prioritySum += itemToPrioritize - 96;
        else
            prioritySum += itemToPrioritize - 64 + 26;
    }
    return prioritySum;
}

Console.WriteLine("Sum priority = " + CalculatePrioritySums(repeatedItemList));
 
string badgeList = "";
for (int groupOfThree = 0; groupOfThree < (MyAccessor.NumberOfBackpacks - 2); groupOfThree += 3)
{
    foreach(char itemToCheck in MyAccessor.EntireBackPacksContents(groupOfThree))
    {
        if (MyAccessor.EntireBackPacksContents(groupOfThree + 1).Contains(itemToCheck) && MyAccessor.EntireBackPacksContents(groupOfThree + 2).Contains(itemToCheck))
        {
            badgeList += itemToCheck; break;
        }
    }
}


Console.WriteLine("Badges: " + badgeList);
Console.WriteLine("Sum of badge priorities: "+ CalculatePrioritySums(badgeList));
Console.WriteLine("Sum of badge priorities: " + CalculatePrioritySums(badgeList));


//File.ReadLines().ElementAt(0);

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




