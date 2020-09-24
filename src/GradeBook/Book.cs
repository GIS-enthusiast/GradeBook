using System;
using System.Collections.Generic;

namespace GradeBook
{
    //public mean the class can be used in other projects. The default is internal, ie., only this project.
    public class Book
    {
        //This is an explicit constuctor method, where you take complete control of how Book() will initialise an object (alternatively we could have initialised grades
        //below with private List<double> grades = new List<double>();. If we let C# compile the constuctor its called an implicit constructor.
        //The constuctor method must have the same name as the class.
        public Book(string name)
        // name is a constructor parameter. name is a field created at bottom in private.
        {
            //If you receive a null reference exception its because you have not initiatised anything, ie., something = new Xxx< etc.
            grades = new List<double>();
            Name = name;
            //this. is used so C# knows that you mean the field named name and the parameter named name.
        }
        //Create a method AddGrade. To do this, first think how you'd like to use it and how it looks before trying to build it. For example book.AddGrade(89.1)
        //would be how it could be used.
        public void AddGrade(double grade)
        //void means that it does not return a value. 
        //When defining a method, eg AddGrade, we pass the data type and the parameters, ie, double grade.
        //often you will validate that input, ie. make sure the user inputs correct data, in this case a grade between 0-100.
        {
            //add 'state' to a class definition.
            grades.Add(grade);
        }
        //In C# if you create a method that has not been invoked yet you can right click and choose generate!
        public Statistics GetStatistics()
        {
            //instead of void it will now return an object of type Statistics. Could retuen an int or a List<double> etc. 
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
                //+= means result = result + number
            }
            result.Average /= grades.Count;
            // is the same as result = result/grades.Count
            return result;
        }

        //add 'state' to a class definition. grades in not a variable here but a field definition, or field, it can be called outside of the AddGrade method. It should be created
        //outside of methods. With a field you can not use implicit typing, ie. var. Basically, any methods inside Book class now have access to this field.
        private List<double> grades;
        //creating the above field has not initiasied grades though. 
        //public is an access modifier.They control access to this part of the class. Public means code outside of this class can have acess to this particular member. Often though,
        //we are very protected in object based programming. If this field was public, then external code for example to add a grade using book.grades.Add(102), 
        //which we otherwise validated by saying it has to be between 0 and 100, also a security threat. By dorcing through book.AddGrade() you are also hiding
        //that the data is stored in a memory list, and later could change this to a database or file. So private means that I only want the grades field to be
        //available inside this class definition Book.
        public string Name;
        //you could add a method for constructing the name, ie., SetName(), or, as we have done, you could require a name when you invoke the explicit constructor.

        
    }
}

    