﻿using System;
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
                if (stringPosition == currentLine.Length) { break; }
                numberAsString.Append(currentLine[stringPosition]);
                stringPosition++;
            }
            return (int)Int16.Parse(numberAsString.ToString());
        }

        /*public int NumberToMove(int position)
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
        }*/

        public int NumberToMove(int position) 
        { 
            string currentLine = instructionsInClass[position];
            var numberAsString = new StringBuilder();
            int stringPosition = 5;
            while (true)
            {
                numberAsString.Append(currentLine[stringPosition]);
                stringPosition++;
                if (currentLine[stringPosition] == ' ') { break; }
            }
            return (int)Int16.Parse(numberAsString.ToString());
        }

        public bool DisplayStacks(List<char>[] stackList) //Ez a fuggveny csak arra van, hogy segitsen debugolni, megmutassa egyesevel a lepeseket mozgatas kozben, mert bonyolult maskent latni
        {
            int longestStack = 0;
            foreach(List<char> stack in stackList) 
            {
                if (stack.Count > longestStack) { longestStack = stack.Count; }
            }

            var lineToDisplay = new StringBuilder();
            for (int line = 0; line < longestStack; line++)
            {
                lineToDisplay.Clear();
                foreach(List<char> stack in stackList)
                {
                    if(stack.Count()>line)
                    {
                        lineToDisplay.Append(stack[line].ToString());
                    }
                    else
                    {
                        lineToDisplay.Append(' ');
                    }
                }
                Console.WriteLine(lineToDisplay.ToString());
            }
            Console.WriteLine(" ");
            return true;
        }
    }
}
