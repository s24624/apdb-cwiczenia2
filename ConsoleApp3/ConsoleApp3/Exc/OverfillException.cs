using System;

namespace ConsoleApp3
{
    public class OverfillException : Exception
    {
        public OverfillException() : base("Przekroczono pojemność kontera, ładunek za ciężki")
        {
        }
    }
}