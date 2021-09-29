using ConsoleCalculatorTest;
using Xunit;

namespace ParserTests
{
   public class MatchTests
   {
      [Fact]
      public void IsMatchTest ()
      {
         string mes = "2+3+(2-1)+4+(34-2+(-1*2-11+15*1*5-7+3*2/2))+22-11";
         ParserV2 p = new ParserV2(mes);
         bool expected = true;
         var result = p.IsMatch();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void IsMatchTest2 ()
      {
         string mes = "34-2+(1*2+3+7*2-2+4/2)";
         ParserV2 p = new ParserV2(mes);
         bool expected = true;
         var result = p.IsMatch();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void IsMatchTest3 ()
      {
         string mes = "2+3+(2-1)+4";
         ParserV2 p = new ParserV2(mes);
         bool expected = true;
         var result = p.IsMatch();
         Assert.Equal(expected, result);
      }
      [Fact]
      public void IsMatchTest4 ()
      {
         string mes = "-1+2-11+15-1+5-7+3+2-2";
         ParserV2 p = new ParserV2(mes);
         bool expected = true;
         var result = p.IsMatch();
         Assert.Equal(expected, result);
      }
   }
}
