using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Text_to_ASCII_Art_Converter
{
    using System.Linq;

    class Translator
    {
        public List<Letter> Art = new List<Letter>();

        public bool LoadAlphabet(string filename)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines.ElementAt(i).StartsWith("Let: "))
                    {
                        string[] letterData = lines.ElementAt(i).Split(' ');

                        char letter = letterData[1][0];

                        if(this.Art.Where(a => a._Letter == letter).Count() == 1)
                            continue;

                        int width = (int)letterData[2][0] - '0';
                        int height = (int)letterData[3][0] - '0';

                        Art.Add(new Letter(letter, width, height, lines.GetRange(i + 1, height)));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Something went wrong: " + e.Message);
                return false;
            }
        }

        public void WriteMessage(string message)
        {
            if (this.Art.Count == 0)
                return;
            
            int height = this.Art.First().Height;

            for (int i = 0; i < height; i++)
            {
                string line = "";
                foreach (char letter in message.ToUpper())
                {
                    if (letter == ' ')
                        line += "   ";
                    else
                        line += this.Art.Where(a => a._Letter == letter).Single().Art.ElementAt(i) + " ";
                }

                Console.WriteLine(line);
            }
        }
    }

    class Letter
    {
        public char _Letter;

        public int Width;

        public int Height;

        public List<string> Art;

        public Letter(char letter, int width, int height, List<string> _Art)
        {
            this._Letter = letter;

            this.Width = width;

            this.Height = height;

            this.Art = _Art;
        }
    }
}