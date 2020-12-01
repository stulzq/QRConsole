using System;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace QRConsole
{
    public class QRConsole
    {
        public static void Output(string text)
        {
            const int threshold = 180;

            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData); 
            var bitmapBytes = qrCode.GetGraphic(1);

            var image = Image.Load<Rgba32>(bitmapBytes);
            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    //获取该像素点的RGB的颜色
                    var color = image[i, j];
                    if (color.B <= threshold)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.Write("\n");
            }
        }

    }
}
