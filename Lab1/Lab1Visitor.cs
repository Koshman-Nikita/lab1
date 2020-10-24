using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Lab1Visitor : Lab1BaseVisitor<double>
    {
        public override double VisitCompileUnit(Lab1Parser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(Lab1Parser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }
    

        public override double VisitIdentifierExpr(Lab1Parser.IdentifierExprContext context)
        {

            var result = context.GetText();
            if (Form1.cellNameToCellObject.ContainsKey(result))
                return Double.Parse(Form1.cellNameToCellObject[result].Value.ToString());
            else
            
                return Double.Parse("NOT A DOUBLE");                                                                                                                                                                                                                                                                                
        }

        public override double VisitParenthesizedExpr(Lab1Parser.ParenthesizedExprContext context)
        {


            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(Lab1Parser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(Lab1Parser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == Lab1Lexer.ADD)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else 
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(Lab1Parser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == Lab1Lexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            else //Lab1Lexer.DIVIDE
            {
                Debug.WriteLine("{0} / {1}", left, right);
                if (right == 0)
                    return (int)left / (int)right; //визове DivideByZeroException
                return left / right;
            }
        }
        public override double VisitMax(Lab1Parser.MaxContext context)
        {
            return Math.Max(Visit(context.left), Visit(context.right));
        }
        public override double VisitMin(Lab1Parser.MinContext context)
        {
            return Math.Min(Visit(context.left), Visit(context.right));
        }
        private double WalkLeft(Lab1Parser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<Lab1Parser.ExpressionContext>(0));
        }

        private double WalkRight(Lab1Parser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<Lab1Parser.ExpressionContext>(1));
        }
    }
}

