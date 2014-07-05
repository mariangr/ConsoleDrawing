using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleImage
{
    class ProgramConsoleImage
    {
        static void Main(string[] args)
        {
            String PictureOutput = "";
            Console.WriteLine("Put the picture in the same folder as the exe and write picture name with the extention:");
            String NAME = Console.ReadLine();
            Image Picture = Image.FromFile(NAME);
            Console.WriteLine("Write height:");
            String StringDefaultSize = Console.ReadLine();
            int DefaultSize;
            int Divider;
            int.TryParse(StringDefaultSize, out DefaultSize);
            if (DefaultSize < Picture.Height)
            {
                Divider = Picture.Height / DefaultSize;
            }
            else
            {
                Divider = 1;
            }
            Console.SetBufferSize(((Picture.Width * 2)), ((Picture.Height * 2)));
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', ',','.', ' '};
            for (int i = (Divider/2); i < Picture.Height; i+= Divider + 1)
            {
                for (int j = (Divider/2); j < Picture.Width; j += Divider + 1)
                {
                    int Gray = 0;
                    int Index = 0;
                    int br = 0;
                    for (int k = i - (Divider / 2); k <= i + (Divider / 2) && k < Picture.Height; k++)
                    {
                        for (int l = j - (Divider / 2); l <= j + (Divider / 2) && l< Picture.Width; l++)
                        {
                            Color Color = ((Bitmap)Picture).GetPixel(l, k);
                            Gray += (Color.R + Color.G + Color.B) / 3;
                            br++;
                        }
                    }
                    Gray = Gray / br;
                    Index = (Gray * (Chars.Length - 1)) / 256;
                    PictureOutput = PictureOutput + Chars[Index];
                    Console.Write(Chars[Index]);

                }
                PictureOutput = PictureOutput + "\n";
                Console.Write('\n');
                
            }
            System.IO.File.WriteAllText(@"path.txt", PictureOutput);
            Console.Read();
        }
    }
}