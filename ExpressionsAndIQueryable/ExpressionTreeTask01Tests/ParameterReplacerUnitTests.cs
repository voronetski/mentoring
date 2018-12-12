using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionTreeTask01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTreeTask01Tests
{
    [TestClass]
    public class ParameterReplacerUnitTests
    {
        [TestMethod]
        public void ParameterReplacerTest()
        {
            Expression<Func<int, int>> exp1 = (a) => 1 + a;
            var exp2 = ParameterReplacer.Replace<Func<int, int>, Expression<Func<int, int>>>(exp1, new Dictionary<string, object>() {{"a", 5}});
            exp2.Compile();
        }
    }
}
