using System;
using System.Collections.Generic;
using System.Globalization;
namespace MysticalDreamers.WitchLexicapple
{

    public static class MathExpression
    {
        public static double Evaluate(string expression)
        {
            List<string> output = ToRpn(expression);
            return EvaluateRpn(output);
        }

        private static List<string> ToRpn(string expression)
        {
            List<string> output = new();
            Stack<char> operators = new();

            int i = 0;
            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                // Number
                if (char.IsDigit(c) || c == '.')
                {
                    int start = i;
                    while (i < expression.Length &&
                          (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        i++;
                    }

                    output.Add(expression.Substring(start, i - start));
                    continue;
                }

                // Unary minus
                if (c == '-' &&
                    (i == 0 || "+-*/%(".Contains(expression[i - 1])))
                {
                    int start = i;
                    i++;

                    while (i < expression.Length &&
                          (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        i++;
                    }

                    output.Add(expression.Substring(start, i - start));
                    continue;
                }

                if (IsOperator(c))
                {
                    while (operators.Count > 0 &&
                           IsOperator(operators.Peek()) &&
                           Priority(operators.Peek()) >= Priority(c))
                    {
                        output.Add(operators.Pop().ToString());
                    }

                    operators.Push(c);
                }
                else if (c == '(')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        output.Add(operators.Pop().ToString());
                    }

                    if (operators.Count == 0)
                        throw new Exception("Mismatched parentheses.");

                    operators.Pop();
                }
                else
                {
                    throw new Exception($"Invalid character '{c}'.");
                }

                i++;
            }

            while (operators.Count > 0)
            {
                char op = operators.Pop();

                if (op == '(')
                    throw new Exception("Mismatched parentheses.");

                output.Add(op.ToString());
            }

            return output;
        }

        private static double EvaluateRpn(List<string> rpn)
        {
            Stack<double> stack = new();

            foreach (string token in rpn)
            {
                if (double.TryParse(token, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                    continue;
                }

                double b = stack.Pop();
                double a = stack.Pop();

                stack.Push(token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    "%" => a % b,
                    _ => throw new Exception("Unknown operator.")
                });
            }

            return stack.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '%';
        }

        private static int Priority(char op)
        {
            return op switch
            {
                '+' or '-' => 1,
                '*' or '/' or '%' => 2,
                _ => 0
            };
        }
    }
}