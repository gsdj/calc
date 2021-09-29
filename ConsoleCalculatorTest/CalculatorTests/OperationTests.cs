using ConsoleCalculatorTest;
using System.Collections.Generic;
using Xunit;

namespace CalculatorTests
{
   public class OperationTests
   {
      [Fact]
      public void CalcAddSubtractTest ()
      {
         CalculatorV2 c = new CalculatorV2();
         string mes = "2+5+16-5+3-17";
         ParserV2 p = new ParserV2(mes);
         string exp = p.ExtractExpression().Trim(new char[] { '(', ')' });
         var expP = p.ParseExpression(exp);

         foreach (var item in expP)
         {
            var resexp = p.ParseMinExpression(item);
            foreach (var item1 in resexp)
            {
               var res = p.ParseNumberOp(item1);
               c.Calc(res[0], double.Parse(res[1]));
            }
         }
         double result = c.GetResult();
         Assert.Equal(4, result);
      }

      [Fact]
      public void CalcMultiplyDivideTest ()
      {
         CalculatorV2 c = new CalculatorV2();
         string mes = "2*4*3/2";
         ParserV2 p = new ParserV2(mes);
         string exp = p.ExtractExpression().Trim(new char[] { '(', ')' });
         var expP = p.ParseExpression(exp);

         foreach (var item in expP)
         {
            var resexp = p.ParseMinExpression(item);
            foreach (var item1 in resexp)
            {
               var res = p.ParseNumberOp(item1);
               c.Calc(res[0], double.Parse(res[1]));
            }
         }
         double result = c.GetResult();
         Assert.Equal(12, result);
      }

      [Fact]
      public void CalcMultiplyDivideAddSubtractTest ()
      {
         List<double> results2 = new List<double>();
         CalculatorV2 c = new CalculatorV2();
         string mes = "2-3+2*4*3/2-1+3+2*4";
         ParserV2 p = new ParserV2(mes);
         string exp = p.ExtractExpression().Trim(new char[] { '(', ')' });
         var expP = p.ParseExpression(exp);

         foreach (var item in expP)
         {
            var resexp = p.ParseMinExpression(item);
            foreach (var item1 in resexp)
            {
               var res = p.ParseNumberOp(item1);
               c.Calc(res[0], double.Parse(res[1]));
            }
            results2.Add(c.GetResult());
            c.Clear();
         }
         foreach (var item in results2)
         {
            c.Calc(item);
         }
         double result = c.GetResult();
         Assert.Equal(21, result);
      }

      [Fact]
      public void CalcMultiplyDivideAddSubtractTest2 ()
      {
         List<double> results2 = new List<double>();
         CalculatorV2 c = new CalculatorV2();
         string mes = "2-3+2*-4*3/2-1+3+2*4";
         ParserV2 p = new ParserV2(mes);
         string exp = p.ExtractExpression().Trim(new char[] { '(', ')' });
         var expP = p.ParseExpression(exp);

         foreach (var item in expP)
         {
            var resexp = p.ParseMinExpression(item);
            foreach (var item1 in resexp)
            {
               var res = p.ParseNumberOp(item1);
               c.Calc(res[0], double.Parse(res[1]));
            }
            results2.Add(c.GetResult());
            c.Clear();
         }
         foreach (var item in results2)
         {
            c.Calc(item);
         }
         double result = c.GetResult();
         Assert.Equal(-3, result);
      }
   }
}
