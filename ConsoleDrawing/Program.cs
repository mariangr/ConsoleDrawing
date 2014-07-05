using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleImage
{
    class ProgramConsoleImage
    {
        static void Main(string[] args)
        {
            Image Picture = Image.FromFile(@"96px-Core_Image_icon.png");
            Console.Write("Write height:");
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
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
                
            }
            Console.Read();
        }
    }
}