using ConsoleCalculatorTest;
using Xunit;

namespace ParserTests
{
   public class ParseNumberOpTests
   {

      [Fact]
      public void ParseNumberOpTest ()
      {
         string mes = "-1";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "", "-1" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }

      [Fact]
      public void ParseNumberOpTest2 ()
      {
         ParserV2 p = new ParserV2();
         string mes = "7";
         string[] expected = new string[] { "", "7" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest3 ()
      {
         string mes = "*1";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "*", "1" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest4 ()
      {
         string mes = "+1";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "", "1" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest5 ()
      {
         string mes = "/1";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "/", "1" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest6 ()
      {
         string mes = "+2,534314234";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "", "2,534314234" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest7 ()
      {
         string mes = "-2,534314234";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "", "-2,534314234" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest8 ()
      {
         string mes = "*2,534314234";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "*", "2,534314234" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest9 ()
      {
         string mes = "*-2,534314234";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "*", "-2,534314234" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
      [Fact]
      public void ParseNumberOpTest10 ()
      {
         string mes = "/-2.534314234";
         ParserV2 p = new ParserV2();
         string[] expected = new string[] { "/", "-2.534314234" };
         var result = p.ParseNumberOp(mes);
         Assert.Equal(expected, result);
      }
   }
}
