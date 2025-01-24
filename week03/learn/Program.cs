using System;

public class Test_Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();
        Console.WriteLine();
        DuplicateCounterSolution.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();
        Console.WriteLine();
        TranslatorSolution.Run();
    }
}