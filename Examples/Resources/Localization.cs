﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace Examples.Resources
{
    public class Localization
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("Examples.Resources.Resource1",
                              Assembly.GetExecutingAssembly());
            CultureInfo cultureInfo = new CultureInfo("es-ar");
            Thread.CurrentThread.CurrentCulture = cultureInfo; //including dates and numbers
            Thread.CurrentThread.CurrentUICulture = cultureInfo; //resources
#pragma warning disable CS8604 // Possible null reference argument.
            string? greeting = String.Format(rm.GetString("greet"));
#pragma warning restore CS8604 // Possible null reference argument.
            Console.WriteLine($"{greeting}, {DateTime.Now.ToLongDateString()} {1e6:n}");
        }
    }
}
