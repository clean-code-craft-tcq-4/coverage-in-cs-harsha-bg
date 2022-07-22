using System;

namespace TypewiseAlert
{
    static class ExtensionMethods
    {
        public static void PrintMessage(this string message)
        {
            Console.WriteLine(message);
        }
    }
}
