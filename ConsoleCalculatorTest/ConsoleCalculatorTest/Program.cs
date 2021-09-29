using System;
using System.Collections.Generic;

namespace ConsoleCalculatorTest
{
   class Program
   {
      static void Main (string[] args)
      {
         bool endApp = false;

         while (!endApp)
         {
            string str = Console.ReadLine();
            CalculatorV2 c2 = new CalculatorV2();
            ParserV2 p2 = new ParserV2(str);
            if (p2.VerifyString())
            {
               while (p2.IsMatch())
               {
                  List<double> results2 = new List<double>();
                  string exp = p2.ExtractExpression().Trim(new char[] { '(', ')' });
                  var res11 = p2.ParseExpression(exp);
                  foreach (var item in res11)
                  {
                     var resexp = p2.ParseMinExpression(item);
                     foreach (var item1 in resexp)
                     {
                        var res = p2.ParseNumberOp(item1);
                        c2.Calc(res[0], double.Parse(res[1]));
                     }
                     results2.Add(c2.GetResult());
                     c2.Clear();
                  }
                  foreach (var item in results2)
                  {
                     c2.Calc(item);
                  }
                  Console.WriteLine($"String = {p2.GetStr()}, Expression = {p2.ExtractExpression()}, Result = {c2.GetResult()}");
                  p2.RewriteExpression(p2.ExtractExpression(), c2.GetResult().ToString());
                  c2.Clear();
               }
               Console.WriteLine(p2.GetStr());
            }
            else
            {
               Console.WriteLine("expression error");
            }
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
         }

      }
   }
}
