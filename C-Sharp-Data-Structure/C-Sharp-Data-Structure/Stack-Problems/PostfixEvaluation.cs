﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/* Operand : +,*,/,-
 * Operator : 0-9
 * Constraint element need to be space seperated
 */
namespace C_Sharp_Data_Structure.Stack_Problems
{
    public class PostfixEvaluation
    {
        GenericStack<int> stack;

        public PostfixEvaluation()
        {
            stack = new GenericStack<int>();
        }

        public int EvaluateEquation(string equation)
        {
            string[] elements = equation.Split(' ');
            foreach (string element in elements)
            {
                int number = 0;
                if (Int32.TryParse(element, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    int firstNumber = stack.Pop();
                    int secondNumber = stack.Pop();
                    int result = GetResult(firstNumber, secondNumber, Char.Parse(element));
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }

        private int GetResult(int firstElement, int secondElement, char ch)
        {
            switch (ch)
            {
                case '+':
                    return firstElement + secondElement;
                case '-':
                    return firstElement - secondElement;
                case '*':
                    return firstElement * secondElement;
                case '/':
                    return firstElement / secondElement;
                default://Kept + as a default operation
                    return firstElement + secondElement;
            }

        }

        public static void Main(string[] args)
        {
            PostfixEvaluation postFixEval = new PostfixEvaluation();
            string eq = Console.ReadLine();
            Console.WriteLine(postFixEval.EvaluateEquation(eq));
            Console.ReadKey();
        }
    }
}
