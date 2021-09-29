using ConsoleCalculatorTest;
using System.Collections.Generic;
using Xunit;

namespace ParserTests
{
   public class ParseExpressionTests
   {
      [Fact]
      public void ParseExpressionTest ()
      {
         string mes = "2+3+(2-1)+4+(34-2+(-1*2-11+15*1*5-7+3*2/2))+22-11";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s); ;
         List<string> expected = new List<string> { "-1*2", "+15*1*5", "+3*2/2", "-11", "-7" };
         Assert.Equal(expected, result);
      }

      [Fact]
      public void ParseExpressionTest2 ()
      {
         string mes = "34-2+(1*2+3+7*2-2+4/2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "1*2", "+7*2", "+4/2", "+3", "-2" };
         Assert.Equal(expected, result);
      }

      [Fact]
      public void ParseExpressionTest3 ()
      {
         string mes = "-1+2-11+15-1+5-7+3+2-2";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "-1", "+2", "-11", "+15", "-1", "+5", "-7", "+3", "+2", "-2" };
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseExpressionTest4 ()
      {
         string mes = "2+3+(2-1)+4+(8-2)+(34-2+(2*3-14+2*5*5/3-7+3*2/2))+15-13-(5*3-4+2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "2*3", "+2*5*5/3", "+3*2/2", "-14", "-7" };
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseExpressionTest5 ()
      {
         string mes = "2+3+1+4+6+(34-2+4,666666666666668)+15-13-(5*3-4+2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "34", "-2", "+4,666666666666668" };
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseExpressionTest6 ()
      {
         string mes = "2+3+1+4+6+(34-2+5*-4,666666666666668+3-2)+15-13-(5*3-4+2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "+5*-4,666666666666668", "34", "-2", "+3", "-2" };
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseExpressionTest7 ()
      {
         string mes = "2+3+1+4+6+(34-2+5*-4,666666666666668*3-2)+15-13-(5*3-4+2)";
         ParserV2 p = new ParserV2(mes);
         string s = p.ExtractExpression().Trim(new char[] { '(', ')' });
         List<string> result = p.ParseExpression(s);
         List<string> expected = new List<string> { "+5*-4,666666666666668*3", "34", "-2", "-2" };
         Assert.Equal(expected, result);
      }
   }
}
