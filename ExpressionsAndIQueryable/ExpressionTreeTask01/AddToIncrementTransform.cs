using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeTask01
{
    public class BinaryToUnaryTransform : ExpressionVisitor
    {
        private delegate UnaryExpression Operation(ParameterExpression param);

        private static UnaryExpression Increment(ParameterExpression param)
        {
            return Expression.Increment(param);
        }

        private static UnaryExpression Decrement(ParameterExpression param)
        {
            return Expression.Decrement(param);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            ParameterExpression param = null;
            ConstantExpression constant = null;
            Operation operation = null;

            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    switch (node.Left.NodeType)
                    {
                        case ExpressionType.Parameter:
                            param = (ParameterExpression)node.Left;
                            break;
                        case ExpressionType.Constant:
                            constant = (ConstantExpression)node.Left;
                            break;
                    }

                    switch (node.Right.NodeType)
                    {
                        case ExpressionType.Parameter:
                            param = (ParameterExpression)node.Right;
                            break;
                        case ExpressionType.Constant:
                            constant = (ConstantExpression)node.Right;
                            break;
                    }

                    operation = Increment;
                    break;

                case ExpressionType.Subtract:
                    if (node.Left.NodeType == ExpressionType.Parameter)
                    {
                        param = (ParameterExpression)node.Left;
                    }

                    if (node.Right.NodeType == ExpressionType.Constant)
                    {
                        constant = (ConstantExpression)node.Right;
                    }
                    operation = Decrement;
                    break;
            }

            if (param != null && constant != null && constant.Type == typeof(int) && (int)constant.Value == 1)
            {
                return operation(param);
            }


            return base.VisitBinary(node);

        }
    }
}
