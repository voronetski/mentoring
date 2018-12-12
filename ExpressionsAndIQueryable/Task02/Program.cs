using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;

namespace Task02
{
    public class Mapper<TSource, TDestination>
    {
        Func<TSource, TDestination> mapFunction;
        internal Mapper(Func<TSource, TDestination> func) { mapFunction = func; }
        public TDestination Map(TSource source) { return mapFunction(source); }
    }

    public class MappingGenerator
    {
        public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var sourceParam = Expression.Parameter(typeof(TSource));
            var mapFunction = Expression.Lambda<Func<TSource, TDestination>>(Expression.New(typeof(TDestination)), sourceParam);
            return new Mapper<TSource, TDestination>(mapFunction.Compile());
        }
    }

    public class Foo {
        public int Field1 = 12;
    }
    public class Bar { }

    public class TestClass
    {
        [TestMethod]
        public void TestMethod3()
        {
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();
            var foo = new Foo();

            var res = mapper.Map(foo);
            Assert.IsTrue(res.Equals(foo));
        }
    }
}
