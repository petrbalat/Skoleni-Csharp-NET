using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace TestLanguage
{
    class Person
    {
        public string Name { get; set; } 

        public int Length { get; set; } 
    }

    [TestFixture]
    public class TestExpression
    {
        [Test]
        public void Test()
        {
            Expression<Func<Person, bool>> expression = p => p.Name == "Jan";

            BinaryExpression binaryExpression = (BinaryExpression)expression.Body;
            Expression left = binaryExpression.Left;
            Expression right = binaryExpression.Right;
            MethodInfo methodInfo = binaryExpression.Method;

            Func<Person, bool> compile = expression.Compile();

            Console.WriteLine(compile(new Person { Name = "Jan" }));
            Console.WriteLine(compile(new Person { Name = "Petr" }));
        }
    }
}