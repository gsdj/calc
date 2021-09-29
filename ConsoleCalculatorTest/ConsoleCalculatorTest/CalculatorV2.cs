using System;

namespace ConsoleCalculatorTest
{
   public class CalculatorV2
   {
      private double Result;
      public void Calc (double a)
      {
         Result += a;
      }

      public void Calc (string action, double a)
      {
         switch (action)
         {
            case "":
               Add(a);
               break;
            case "-":
               Subtract(a);
               break;
            case "/":
               Divide(a);
               break;
            case "*":
               Multiply(a);
               break;
         }

      }

      public void Clear()
      {
         Result = 0;
      }

      public double GetResult()
      {
         return Result;
      }
      private void Add(double a)
      {
         Result += a;
      }
      private void Subtract (double a)
      {
         Result -= a;
      }
      private void Multiply (double a)
      {
         Result *= a;
      }
      private void Divide (double a)
      {
         if (a == 0)
         {
            throw new DivideByZeroException();
         }
         Result /= a;
      }
   }
}
