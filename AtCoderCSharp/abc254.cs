using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderCSharp
{
    class abc254
    {
        /// <summary>
        /// https://atcoder.jp/contests/abc254/tasks/abc254_a
        /// </summary>
        private void A()
        {
            var input = Console.ReadLine();
            var output = "";
            output = input[input.Length - 1] + output;
            output = input[input.Length - 2] + output;
            Console.WriteLine(output);
        }

        /// <summary>
        /// https://atcoder.jp/contests/abc254/tasks/abc254_b
        /// </summary>
        private void B()
        {
            //整数列の数
            var rowCount = int.Parse(Console.ReadLine());
            //全体の結果格納用
            var allResult = new int[rowCount, rowCount];
            //1ループにつき1整数列を作成
            for (var i = 0; i < rowCount; i++)
            {
                var output = "";
                for (var j = 0; j <= i; j++)
                {
                    int result;
                    if (j == 0 || j == i)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = allResult[i - 1, j - 1] + allResult[i - 1, j];
                    }
                    allResult[i, j] = result;
                    output += $" {result}";
                }
                output = output.Trim(' ');
                Console.WriteLine(output);
            }
        }
    }
}
