using ConsoleCalculatorTest;
using Xunit;

namespace ParserTests
{
   public class ExtractExpressionTests
   {
      [Fact]
      public void ExtractExpressionTest ()
      {
         string mes = "2+3+(2-1)+4+(34-2+(-1*2-11+15*1*5-7+3*2/2))+22-11";
         ParserV2 p = new ParserV2(mes);
         string expected = "(-1*2-11+15*1*5-7+3*2/2)";
         var result = p.ExtractExpression();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ExtractExpressionTest2 ()
      {
         string mes = "34-2+(1*2+3+7*2-2+4/2)";
         ParserV2 p = new ParserV2(mes);
         string expected = "(1*2+3+7*2-2+4/2)";
         var result = p.ExtractExpression();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ExtractExpressionTest3 ()
      {
         string mes = "2+3+(2-1)+4";
         ParserV2 p = new ParserV2(mes);
         string expected = "(2-1)";
         var result = p.ExtractExpression();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ExtractExpressionTest4 ()
      {
         string mes = "-1+2-11+15-1+5-7+3+2-2";
         ParserV2 p = new ParserV2(mes);
         string expected = "-1+2-11+15-1+5-7+3+2-2";
         var result = p.ExtractExpression();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ExtractExpressionTest5 ()
      {
         string mes = "(-1+2-11+15-1+5-7+3+2-2)";
         ParserV2 p = new ParserV2(mes);
         string expected = "(-1+2-11+15-1+5-7+3+2-2)";
         var result = p.ExtractExpression();
         Assert.Equal(expected, result);
      }
   }
}
