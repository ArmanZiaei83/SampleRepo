using System;
using System.Linq;
using System.Linq.Expressions;
using Sample.Infrastructure.Shared;

namespace Test.Specifications.Infrastructures.Attributes
{
    public static class Runner
    {
        public static void RunScenario(
            params Expression<Action<object>>[] steps)
        {
            var textContext = new
            {
            };

            steps.Select(_ => _.Compile()).ForEach(_ => _.Invoke(textContext));
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Scenario : Attribute
    {
        public string Title { get; set; }

        public Scenario(string title)
        {
            Title = title;
        }
    }
    
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Given : Attribute
    {
        private string Title { get; set; }

        public Given(string title)
        {
            Title = title;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class When : Attribute
    {
        private string Title { get; set; }

        public When(string title)
        {
            Title = title;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Then : Attribute
    {
        private string Title { get; set; }

        public Then(string title)
        {
            Title = title;
        }
    }
}