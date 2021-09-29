using ConsoleCalculatorTest;
using System.Collections.Generic;
using Xunit;

namespace ParserTests
{
   public class ParseMinExpressionTests
   {
      [Fact]
      public void ParseMinExpressionTest ()
      {
         string mes = "2+3+(2-1)+4+(34-2+(-1*2-11+15*1*5-7+3*2/2))+22-11";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> expression = p.ParseExpression(s);
         List<string> result = p.ParseMinExpression(expression[1]);
         List<string> expected = new List<string>() { "+15", "*1", "*5" };
         Assert.Equal(expected, result);
      }

      [Fact]
      public void ParseMinExpressionTest2 ()
      {
         ParserV2 p = new ParserV2();
         string mes = "+15*1*5";
         List<string> expected = new List<string>() { "+15", "*1", "*5" };
         var result = p.ParseMinExpression(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseMinExpressionTest3 ()
      {
         string mes = "2+3+(2-1)+4+(8-2)+(34-2+(2*3-14+2*5*5/3-7+3*2/2))+15-13-(5*3-4+2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> expression = p.ParseExpression(s);
         List<string> result = new List<string>();
         foreach (var item in expression)
         {
            var res1 = p.ParseMinExpression(item);
            foreach (var item1 in res1)
            {
               result.Add(item1);
            }

         }

         string res = "";
         foreach (var item in result)
         {
            res += item;
         }
         string expected = "2*3+2*5*5/3+3*2/2-14-7";
         Assert.Equal(expected, res);
      }
      [Fact]
      public void ParseMinExpressionTest4 ()
      {
         string mes = "-4*2+34-2+8+5,86*-4,666666666666668*3/2*4-2*2/3-9+13";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> expression = p.ParseExpression(s);
         List<string> result = new List<string>();
         foreach (var item in expression)
         {
            var res1 = p.ParseMinExpression(item);
            foreach (var item1 in res1)
            {
               result.Add(item1);
            }

         }

         string res = "";
         foreach (var item in result)
         {
            res += item;
         }
         string expected = "-4*2+5,86*-4,666666666666668*3/2*4-2*2/3+34-2+8-9+13";
         Assert.Equal(expected, res);
      }
      [Fact]
      public void ParseMinExpressionTest5 ()
      {
         string mes = "2-3+2*4*3/2-1+3+2*4";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> expression = p.ParseExpression(s);
         List<string> result = new List<string>();
         foreach (var item in expression)
         {
            var res1 = p.ParseMinExpression(item);
            foreach (var item1 in res1)
            {
               result.Add(item1);
            }

         }

         string res = "";
         foreach (var item in result)
         {
            res += item;
         }
         string expected = "+2*4*3/2+2*42-3-1+3";
         Assert.Equal(expected, res);
      }
   }
}
