using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConvertNFO
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: make this callable from commandline :-{}
            //var path = @"F:\ftp.scene.org\mirrors\hornet\graphics\images\1998\x\x_dragon\TOUR1998.NFO";
            var path = @"C:\Users\johnc\Downloads\nfo2png\file.nfo";
         var xx = File.ReadAllLines(path, Encoding.GetEncoding(437));

            var font = new Font("Courier New", 20);
            var image = DrawText(xx, font, Color.White, Color.Black);
            image.Save(@"c:\git\foo2.bmp");
        }


        private static Image DrawText(String[] text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            var eighty = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(eighty, font);
            var lineHeight = textSize.Height - 4;
            textSize.Height = lineHeight * text.Length;

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            var y = 0;
            for (int i = 0; i < text.Length; i++)
            {
                drawing.DrawString(text[i], font, textBrush, 0, i * lineHeight);
            }

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
    }
}
