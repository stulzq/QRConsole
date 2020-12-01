using System;

namespace QRConsole.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var qr= new QRConsole();
            qr.Output("aaaa");
            Console.WriteLine("Hello World!");
        }
    }
}
