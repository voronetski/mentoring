using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionTreeTask01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTreeTask01Tests
{
    [TestClass]
    public class AddToIncrementTransformTests
    {
        static Expression<Func<int, int>> constPlusParameter = (a) => 1 + a;
        static Expression<Func<int, int>> parameterPlusConst = (a) => a + 1;
        static Expression<Func<int, int>> ConstMinusparameter = (a) => a - 1;
        static Expression<Func<int, int>> parameterMinusConst = (a) => a - 1;
        static Expression<Func<int, int>> constPlusParameterPlusConst = (a) => 1 + a + 1;
        static Expression<Func<int, int>> parameterPlusConstPlusParameter = (a) => a + 1 + a;
        
        readonly List<Expression<Func<int, int>>> expList = new List<Expression<Func<int, int>>>()
        { constPlusParameter, 
            parameterPlusConst,
            ConstMinusparameter,
            parameterMinusConst, 
            constPlusParameterPlusConst, 
            parameterPlusConstPlusParameter
        };


        [TestMethod]
        public void TestMethod1()
        {
            const int ConstantExpression = 3;
            foreach (var exp in expList)
            {
                var initResult = exp.Compile().Invoke(ConstantExpression);
                Console.WriteLine("{0} : {1}", exp, initResult);

                var newExp = (Expression<Func<int, int>>)new BinaryToUnaryTransform().Visit(exp);
                var newResult = newExp.Compile().Invoke(ConstantExpression);
                Console.WriteLine("{0} : {1}", newExp, newResult);
                Assert.IsTrue(initResult == newResult);
            }

/*
            Expression<Func<int, int>> exp1 = (a) => 1 + a;
            Console.WriteLine("{0} : {1}", exp1, exp1.Compile().Invoke(3));

            var exp3 = (Expression<Func<int, int>>) new BinaryToUnaryTransform().Visit(exp1);
            Console.WriteLine("{0} : {1}", exp3, exp3.Compile().Invoke(3));

            Expression<Action<int>> exp2 = (a) => Console.WriteLine(a);
            Console.WriteLine("{0} : ", exp2);
            exp2.Compile().Invoke(3);
            */
        }
    }
}
