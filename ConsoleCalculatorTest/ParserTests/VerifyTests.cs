using ConsoleCalculatorTest;
using Xunit;

namespace ParserTests
{
   public class VerifyTests
   {
      [Fact]
      public void VerifyStringTest1 ()
      {
         string mes = "(2+4)";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.True(result);
      }
      [Fact]
      public void VerifyStringTest2 ()
      {
         string mes = "(2+4)()";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.False(result);
      }
      [Fact]
      public void VerifyStringTest3 ()
      {
         string mes = "2-4+2+4";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.True(result);
      }
      [Fact]
      public void VerifyStringTest4 ()
      {
         string mes = "(2-4)+2+-52+4";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.False(result);
      }
      [Fact]
      public void VerifyStringTest5 ()
      {
         string mes = "(2-4)+2+/52+4";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.False(result);
      }
      [Fact]
      public void VerifyStringTest6 ()
      {
         string mes = "2(5-5)";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.False(result);
      }
      [Fact]
      public void VerifyStringTest7 ()
      {
         string mes = "2+5+@";
         ParserV2 p = new ParserV2(mes);
         var result = p.VerifyString();
         Assert.False(result);
      }
   }
}
