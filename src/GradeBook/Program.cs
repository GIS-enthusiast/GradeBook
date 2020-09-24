using System;
using System.Collections.Generic;

//if no namespace is used then you are running globally, which can lead to compilation corruption if someone else also adds a Program class to the global namespace.
namespace GradeBook
{
    //a class or type. Used to encapsulate and abstract objects. Contains a data type for storage and functionalites for the stored data.
    class Program
    {
        static void Main(string[] args)
        {
            /*
            notes can be made using hte /* or //. // is equiv. to # in python
            */
            var book = new Book("Shane's Grade Book");
            //name type string is an explicit constructor parameter so a string must be passed, "Shane's Grade Book".
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"The average score is {stats.Average:N1}");
            Console.WriteLine($"The highest score is {stats.High:N1}");
            Console.WriteLine($"The lowest score is {stats.Low:N1}");

            
        }
    }
}
//GENERAL NOTES
//The keyword Null in C# means that the defined variable does not refer to an object. If you try to use an operater, ie. .AddGrade to a Book object, eg. book2 and
//it is Null defined, then you will recieve a Null reference exception and the program will crash. You might see for example in C#
//if(book2 == Null)
//{
//    do something else.
//}
// Instance methods and instance fields are associated with objects (this opposite of static)
//Ctrl KC and Ctrl KU will turn a highlighted block of sourcecode into this green text. 
//Anything static is not associated with an object, it negates object oriented programming. Console for example is static. You dont have to intansiate 
//an instance of WriteLine, you can walk up to the Console class and do a .rightline, ie. Console.WriteLine()

