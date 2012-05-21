using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HandyToolsAndExtensions.SpecFlow
{
    public class StepDefinitions
    {
        protected readonly IDictionary<string, int> _PositionToIndex =
            new Dictionary<string, int>
                {
                    {"first", 0},
                    {"second", 1},
                    {"third", 2},
                    {"fourth", 3},
                    {"fifth", 4},
                    {"sixth", 5},
                    {"seventh", 6},
                    {"fourteenth", 13}
                };

        protected readonly IDictionary<string, int> _QuantityToNumber =
            new Dictionary<string, int>
                {
                    {"no", 0},
                    {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"six", 6},
                    {"twelve", 12},
                    {"seventeen", 17},
                    {"thirty six", 36}
                };

        protected T GetContext<T>(string key = null)
        {
            try
            {
                return (T)ScenarioContext.Current[key ?? typeof(T).AssemblyQualifiedName];
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    return (T)ScenarioContext.Current[key ?? typeof(object).AssemblyQualifiedName];
                }
                catch (KeyNotFoundException)
                {
                    return default(T);
                }
            }
        }

        protected void SetContext<T>(T value, string key = null)
        {
            ScenarioContext.Current[key ?? typeof (T).AssemblyQualifiedName] = value;
        }
    }
}