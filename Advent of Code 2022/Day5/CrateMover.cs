using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class CrateMover
    {
        private readonly List<string> instructionsInClass = new List<string>();
        public CrateMover(List<string> instr) 
        { 
            foreach(string line in instr) 
            {
                instructionsInClass.Add(line);
            }
        }

        public int Count()
        { return instructionsInClass.Count; }

        public int NextSourceStack(int position)
        {
            string currentLine = instructionsInClass[position];
            var numberAsString = new StringBuilder();
            int stringPosition = 5; //Set the position in the string (current line of instruction) to 5, where the first digit of the first data is located
            stringPosition = stringPosition + this.NumberToMove(position).ToString().Length; //...es most hozzaadom hany jegyu az elso adat mezo
            stringPosition = stringPosition + 6; //...es ez eljuttat a masodik adatmezo kezdeteig. Azert irtam ki 3 sorban, hogy jobban ertheto/olvashato legyen
            while (true)
            {
                numberAsString.Append(currentLine[stringPosition]);
                stringPosition++;
                if (currentLine[stringPosition] == ' ') { break; }
            }
            return (int)Int16.Parse(numberAsString.ToString());
        }

        public int NextDestinationStack(int position)
        {
            string currentLine = instructionsInClass[position];
            var numberAsString = new StringBuilder();
            int stringPosition = 5; //Set the position in the string (current line of instruction) to 5, where the first digit of the first data is located
            stringPosition = stringPosition + this.NumberToMove(position).ToString().Length; //...es most hozzaadom hany jegyu az elso adat mezo
            stringPosition = stringPosition + 6; //...es ez eljuttat a masodik adatmezo kezdeteig. Azert irtam ki 3 sorban, hogy jobban ertheto/olvashato legyen
            stringPosition = stringPosition + this.NextSourceStack(position).ToString().Length + 4; //...es ez az elozo alapjan eljuttat at utolso adatmezohoz
            while (true)
            {
                numberAsString.Append(currentLine[stringPosition]);
                stringPosition++;
                if (stringPosition == currentLine.Length - 1) { break; }
            }
            return (int)Int16.Parse(numberAsString.ToString());
        }

        public int NumberToMove(int position)
        {
            string currentLine = instructionsInClass[position];
            var numberAsString = new StringBuilder();
            int stringPosition = 5; //Set the position in the string (current line of instruction) to 5, where the first digit of the data in question is located
            while (true)
            {
                numberAsString.Append(currentLine[stringPosition]);
                stringPosition++;
                if (currentLine[stringPosition] == ' ')
                { break; }

            } 
,           return (int)Int16.Parse(numberAsString.ToString());
        }
    }
}
