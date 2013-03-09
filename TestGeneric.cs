using System;
using System.Collections.Generic;

class TestGeneric
{
    static void Main()
    {
        GenericList<int> elementList = new GenericList<int>(7);
        elementList.AddElement(15);
        elementList.AddElement(5);
        elementList.AddElement(7);
        elementList.AddElement(12);
        elementList.AddElement(15);
        elementList.AddElement(15);
        elementList.AddElement(15);

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(elementList.AccessElement(i));
        }
        Console.WriteLine();      

        elementList.AddElement(15); // make doubleSize

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(elementList.AccessElement(i));
        }
        Console.WriteLine();

        Console.WriteLine(elementList.AccessElement(2)); 
        Console.WriteLine();


        elementList.RemoveElement(3);
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(elementList.AccessElement(i));
        }
        Console.WriteLine();

        elementList.InsertElement(2, 14);
        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine(elementList.AccessElement(i));
        }
        Console.WriteLine();

        Console.WriteLine(elementList.FindElement(7));

        elementList.ClearElements();
    }
    
}
