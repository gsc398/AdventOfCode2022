using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class MyStringAccessor 
    {
        public string FileName;

        public MyStringAccessor(string fileNameLocal)
        {
            FileName= fileNameLocal;
        }

        public int NumberOfBackpacks
        {
            get
            {
                return File.ReadLines(FileName).Count();
            }
            set { }
        }

        public string FirstCompartment (int index)
        {
            string backPackContents = File.ReadLines(FileName).Skip(index).First();
            string toReturn = new string(backPackContents.Chunk(backPackContents.Length / 2).First());
            return toReturn;
        }

        public string SecondCompartment(int index)
        {
            string backPackContents = File.ReadLines(FileName).Skip(index).First();
            string toReturn = new string(backPackContents.Chunk(backPackContents.Length / 2).Last());
            return toReturn;
        }

    }
}
