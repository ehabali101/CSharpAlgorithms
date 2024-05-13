using csharpCoding;
using System;
using System.Linq;

class Test
{
    static void Main()
    {
        Console.WriteLine(BinaryReversal("4567"));

        Console.WriteLine("1, 3, 4, 7, 13", "1, 2, 4, 13, 15");
        Console.WriteLine(FindIntersection(new string[] { "1, 3, 4, 7, 13", "1, 2, 4, 13, 15" }));

        int[] array = new int[] { 10, 17, 25, 35, 52, 55, 62, 77, 90, 95 };
        int index = BinarySearchDisplay(array, 77);
        Console.WriteLine("Index: {0}, Value: {1}",index, array[index]);

        string words = WordSplit(new string[] { "baseball", "a,all,b,ball,bas,base,cat,code,d,e,quit,z" });
        Console.WriteLine("Words: {0}",words);

        int[] profit = maxProfit(new int[] { 5, 11, 3, 50, 60, 90 });
        Console.WriteLine("Buy: {0}, Sell: {1}, Profit: {2}", profit[0], profit[1], profit[2]);

        int[] A1 = new int[] { 1, 3, 6, 4, 1, 2 };
        int[] A2 = new int[] { 1,2,3};
        int[] A3 = new int[] { -3,0,1 };
        int result1  = solution(A1);
        int result2 = solution(A2);
        int result3 = solution(A3);

        Console.WriteLine("result is: {0}, {1}, {2}", result1, result2, result3);

        FindElement();

        int[] A5 = new int[] { 20,-1, 10, 5, 1, 9, -89 , 159};
        int in1 = solution1(A5);
        Console.WriteLine("solution1: {0}", in1);

        int[] A6 = new int[] { -3, -1, 10, 3, 1, 9, -89, 159 };
        int in2 = solution2(A6);
        Console.WriteLine("solution2: {0}", in2);

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("--------------------------------------------");

        BinaryGap binaryGap = new BinaryGap();
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(9));
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(529));
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(20));
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(15));
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(32));
        Console.WriteLine("binaryGap: {0}", binaryGap.solution(561892)); 

        Console.ReadKey();
    }

    public static int solution2(int[] A)
    {
        //Array.Sort(A);
        //for (int i = A.Length - 1; i >= 0; i--)
        //{
        //    int opp = Array.Find(A, e => e.Equals(A[i] * -1));
        //    if (opp != 0)
        //        return A[i];
        //}

        int result = 0;
        for (int i = 0; i < A.Length - 1; i++)
        {
            int opp = Array.Find(A, e => e.Equals(A[i] * -1));
            if (A[i] > result && opp != 0)
                result = A[i];
        }

        return result;
    }

    public static int solution1(int[] A)
    {
        //Array.Sort(A);
        //for(int i = A.Length -1; i>= 0;i--)
        //{
        //    if (A[i].ToString().Length == 1)
        //        return A[i];
        //}

        int result = 0;
        for (int i = 0; i < A.Length - 1; i++)
        { 
            if(A[i]> result && A[i].ToString().Length == 1)
            {
                result = A[i];
            }
        }
        
        return result;
    }
    public static void FindElement()
    {

        int[] A = new int[] { 0, 1, 2, 3 };
        int? notFind = Array.Find(A,e => e.Equals(4));
        int? find = Array.Find(A, e => e.Equals(3));

        Console.WriteLine("notFind: {0}, find: {1}", notFind, find);
    }

    public static string BinaryReversal(string str)
    {
        int number;
        if (!int.TryParse(str, out number))
            return "Invalid Number";

        string binaryStr = Convert.ToString(number, 2);
        int length = binaryStr.Length / 8;
        int remainder = binaryStr.Length % 8;
        if (remainder != 0)
            length++;

        binaryStr = binaryStr.PadLeft(8*length, '0');
        char[] charArray = binaryStr.ToCharArray();
        Array.Reverse(charArray);

        return Convert.ToInt32(new string(charArray),2).ToString();
    }

    public static string FindIntersection(string[] strArr)
    { 
        string[] strArr1 = strArr[0].Split(',');
        string[] strArr2 = strArr[1].Split(',');

        string result = "";

        foreach(string elment in strArr1)
        {
            var res = Array.FindAll(strArr2, s => s.Equals(elment));
            if (res.Length != 0)
                result += elment + ", ";
        }

        if (string.IsNullOrEmpty(result))
            return "";

        return result.Remove(result.Length-2, 2);
    }

    public static string LongestWord(string sen)
    {
        string[] words = sen.Split(' ');
        return words.OrderByDescending(s => s.Length).First(); ;
    }

    public static int BinarySearchDisplay(int[] arr, int key)
    {
        int minNum = 0;
        int maxNum = arr.Length - 1;

        while (minNum <= maxNum)
        {
            int mid = (minNum + maxNum) / 2;
            if (key == arr[mid])
            {
                return mid;
            }
            else if (key < arr[mid])
            {
                maxNum = mid - 1;
            }
            else
            {
                minNum = mid + 1;
            }
        }
        return -1;
    }

    private int Factorial(int num)
    {
        if (num == 1)
            return 1;
        
        return num * Factorial(num - 1);
    }



    public static string WordSplit(string[] strArr)
    {
        string result = "not found";
        string str = strArr[0];
        string[] dicArr = strArr[1].Split(',');

        string remain;
        for (int i = 1; i<str.Length;i++)
        {
            string  subWord = str.Substring(0, i);
            var res1 = Array.FindAll(dicArr, s => s.Equals(subWord));
            if (res1.Length > 0) { 
                remain = str.Substring(i, str.Length- subWord.Length);
                var res2 = Array.FindAll(dicArr, s => s.Equals(remain));
                if (res2.Length > 0)
                {
                    result = res1[0] + "," + res2[0];
                    break;
                }
            }

        }

        return result;
    }

    public static int[] maxProfit(int[] prices)
    {
        var maxProfit = 0;
        var minPrice = int.MaxValue;
        int buy = 0, sell = 0;
        foreach (int price in prices)
        {
            //minPrice = Math.Min(minPrice, price);
            if (price < minPrice)
            {
                minPrice = price;
                buy = price;
            }

            //maxProfit = Math.Max(maxProfit, price - minPrice);
            if (price - minPrice > maxProfit)
            {
                maxProfit = price - minPrice;
                sell = price;
            }
        }

        return new int[] { buy, sell, maxProfit};
    }

    public int MaxProfit(int[] prices)
    {
        var maxprofit_so_far = 0;
        var maxprofit_ending_here = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            maxprofit_ending_here = Math.Max(0, maxprofit_ending_here + prices[i] - prices[i - 1]);
            maxprofit_so_far = Math.Max(maxprofit_ending_here, maxprofit_so_far);
        }

        return maxprofit_so_far;
    }


    public static int solution(int[] A)
    {
        Array.Sort(A);
        int start = A[0];
        int end = A[A.Length - 1];
        if (end < 0)
            return 1;
        for (int num = start; num < end; num++)
        {
            int n = Array.Find(A, elemnt => elemnt.Equals(num));
            if (n == 0 && num > 0)
                return num;
        }
        return end + 1;
    }

}