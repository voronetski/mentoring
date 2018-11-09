using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeTask01
{
    public static class ParameterReplacer
    {
        public static Expression<TOutput> Replace<TInput, TOutput>(Expression<TInput> expression, Dictionary<string, object> replacementsDict)
        {
            return new ParameterReplacerVisitor<TOutput>(replacementsDict).VisitAndConvert(expression);
        }

        private class ParameterReplacerVisitor<TOutput> : ExpressionVisitor
        {
            private Dictionary<string, object> _replacementsDict;

            public ParameterReplacerVisitor(Dictionary<string, object> replacementsDict)
            {
                _replacementsDict = replacementsDict;
            }

            internal Expression<TOutput> VisitAndConvert<T>(Expression<T> root)
            {
                return (Expression<TOutput>)VisitLambda(root);
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                return Expression.Lambda<TOutput>(Visit(node.Body), node.Parameters);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return _replacementsDict.ContainsKey(node.Name) ? Expression.Constant(_replacementsDict[node.Name]) : base.VisitParameter(node);
            }
        }
    }
}