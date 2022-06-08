using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var N = int.Parse(input.Split(' ')[0]);
            var K = int.Parse(input.Split(' ')[1]);

            //K=1とはバブルソートを指す
            if (K == 1)
            {
                Console.WriteLine("Yes");
                return;
            }

            var array = Console.ReadLine().Split(' ').Select(m => int.Parse(m)).ToList();

            //配列を、K-1間隔の要素ごとにまとまった配列とする
            //仮にK=2の場合、1つ置きの要素はこの操作によって昇順に並び替えることができる
            //a b c d e f gという配列があるとする
            //このswap操作は、acegという配列をバブルソートで並び替えることと同じこと
            //acegとbdfをそれぞれ昇順に並び替えた後、全体が昇順になっているか確認する

            //配列のグループリスト
            var allList = new List<List<int>>();

            for(int i = 0; i < K; i++)
            {
                var tmpList = array.Select((v, i) => new { Val = v, Idx = i }).Where(m => m.Idx % K == i).Select(m => m.Val).ToList();
                allList.Add(tmpList);
            }

            //それぞれのリストを昇順にする
            var allOrderedList = allList.Select(m =>
            {
                return m.OrderBy(n => n).ToList();
            }).ToList();

            //それぞれの配列を元に戻す
            var orderedList = new List<int>();
            for (var i = 0; i < allOrderedList[0].Count; i++)
            {
                for (var j = 0; j < allOrderedList.Count; j++)
                {
                    if(allOrderedList[j].Count <= i)
                    {
                        break;
                    }
                    orderedList.Add(allOrderedList[j][i]);
                }
            }
            var orderedArray = orderedList.ToArray();
            if (IsAsc(orderedArray))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static bool IsAsc(int[] args)
        {
            var previous = args[0];
            for(var i = 1; i < args.Length; i++)
            {
                if(args[i] < previous)
                {
                    return false;
                }
                previous = args[i];
            }
            return true;
        }
    }
}
