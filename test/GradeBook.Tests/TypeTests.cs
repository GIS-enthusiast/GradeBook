using System;
using Xunit;

namespace GradeBook.Tests
{
    //proper abstractions require good names. Unit tests for the Book class by convention are called BookTests.
    public class BookTests
    {
        //Fact is an attribute, a little bit of data attached to the method Test1() in class UnitTest1. We decorate the methods that are unit tests with this attribute
        //because xunit will go looking for them when testing.
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            //create an instance of my Book class with an empty string for the explicit constructor parameter. Tell the compiler to look in another project for the Book() class.
            
            var book = new Book("");
            //is it legal for a book to have an empty name? This may become a test.
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            

        }
    }
}
//Unit Testing Module - many benefits.
//Tests 'happydays' but also when things go wrong, ie., a user forgets to enter a value.
//test folder dotnet new xunit. xunit is not part of dotnet core, it is available from NuGet. NuGet is a package manager for dotnet and dot core. nuget.org.
//we use an API provided by a class called Assert, it is an xunit namespace.
//Usually divided into three sections (arrange, act, assert).
//When making a reference to a NuGet or a project in a project, you will also have to add a using statement. We didnt need to for Book() here because it is under
//the GradeBook namespace.
//We ended up simplifying ShowStatistics because orginally it was caluculating AND showing the results, two vastly different things. So testing can help you
//to write smarter code with smaller pieces that are easier to understand in the future by oneself or another developer that comes along.Strive to write smaller 
//methods and smaller classes.
//Your unit test forces you to redesign your code, so you go through and refactor it, ie, make the updated changes.