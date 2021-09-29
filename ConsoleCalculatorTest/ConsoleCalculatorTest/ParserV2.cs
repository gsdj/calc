using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleCalculatorTest
{
   public class ParserV2
   {
      public ParserV2()
      {
      }

      public ParserV2 (string s)
      {
         _str = s;
      }

      public string GetStr()
      {
         return _str;
      }

      private string _str;


      private static readonly string digits = @"\d+(?:[\,\.]\d+)?";
      private static readonly string op = @"[\/\*\-\+]";
      private static readonly string op2 = @"[\/\*]";
      private static readonly string pattern1 = $"({digits}{op}{digits})+";
      private static readonly string pattern2 = @$"\((({digits})*{op}({digits})*)+\)";
      private static readonly string pattern3 = @$"\(((({digits})*{op})*\((({digits})*{op}({digits})*)+\)({op}({digits})*)*)*\)";

      Regex Reg1 = new Regex(pattern3); // самые вложенные скобки
      Regex Reg2 = new Regex(pattern2); // скобка цифра знак цифра скобка
      Regex Reg21 = new Regex(pattern1); //  цифра знак цифра 
      //проверка введенного выражения
      Regex Ver1 = new Regex(@"\(\)");
      Regex Ver2 = new Regex(@"\(");
      Regex Ver3 = new Regex(@"\)");
      Regex Ver4 = new Regex(@"\+\+|\-\-|\*\*|\/\/|\+\-|\-\+|\-\*|\-\/|\*\/|\/\*|\+\*|\+\/");
      Regex Ver5 = new Regex(@"\d+(?:[\,\.]\d+)?\(");

      Regex MD4 = new Regex(@"[\/\*]?[\-\+]?(\d+(?:[\,\.]\d+)?([\/\*](\-)?\d+(?:[\,\.]\d+)?)*)+");

      public bool VerifyString (string str)
      {
         bool res = false;
         if (!Ver1.IsMatch(str) && !Ver4.IsMatch(str) && !Ver5.IsMatch(str) && (Ver2.Matches(str).Count == Ver3.Matches(str).Count))
         {
            res = true;
         }

         return res;
      }

      public bool VerifyString ()
      {
         bool res = false;
         if (!Ver1.IsMatch(_str) && !Ver4.IsMatch(_str) && !Ver5.IsMatch(_str) && (Ver2.Matches(_str).Count == Ver3.Matches(_str).Count))
         {
            res = true;
         }

         return res;
      }

      public List<string> ParseExpression (string str)
      {
         List<string> lst1 = new List<string>();
         foreach (var item in MD4.Matches(str))
         {
            if (item.ToString().Contains("*") || item.ToString().Contains("/"))
            {
               lst1.Add(item.ToString());
            }
         }
         foreach (var item in MD4.Matches(str))
         {
            if (!item.ToString().Contains("*") && !item.ToString().Contains("/"))
            {
               lst1.Add(item.ToString());
            }
         }
         return lst1;
      }

      public List<string> ParseMinExpression (string s)
      {
         Regex useCalc3 = new Regex($@"({op})*{digits}");
         var matches = useCalc3.Matches(s);
         List<string> list = new List<string>();
         foreach (var item in matches)
         {
            list.Add(item.ToString());
         }
         return list;
      }

      public string[] ParseNumberOp (string s)
      {
         Regex useCalc1 = new Regex(op2);
         Regex useCalc2 = new Regex($@"[\-]*{digits}");
         string[] res = new string[2];
         res[0] = useCalc1.Match(s).Value;
         res[1] = useCalc2.Match(s).Value;
         return res;
      }

      public string ExtractExpression () 
      {
         string result = "";
         var matchesStr = Reg1.Matches(_str); 
         if (Reg1.IsMatch(_str))
         {
            result = Reg1.Match(_str).Value;
            result = Reg2.Match(result).Value;
         }
         else if (Reg2.IsMatch(_str))
         {
            result = Reg2.Match(_str).Value;
         }
         else if (Reg21.IsMatch(_str))
         {
            result = _str;
         }
         return result;
      }
      
      public bool IsMatch()
      {
         if (Reg1.IsMatch(_str))
         {
            return true;
         }
         else if (Reg2.IsMatch(_str))
         {
            return true;
         }
         else if (Reg21.IsMatch(_str))
         {
            return true;
         }
         return false;
      }

      public void RewriteExpression(string oldStr,string newStr)
      {
         if (_str.Contains(oldStr))
         {
            _str = _str.Replace(oldStr, newStr);
         }

      }
   }
}
