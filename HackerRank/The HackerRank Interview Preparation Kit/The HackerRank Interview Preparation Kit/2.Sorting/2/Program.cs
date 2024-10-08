using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

/*class Result
{

    *//*
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     *//*

    private static int sortAndFindMedianTimes2(List<int> history)
    {
        if (history.Count() % 2 == 1)
        {
            return history[history.Count()/2]*2;
        }
        else
        {
            return (history[history.Count() / 2-1]+ history[history.Count() / 2]);
        }
    }

    public static int activityNotifications(List<int> expenditure, int d)
    {
        int noOfNotification = 0;
        if (d >= expenditure.Count())
        {
            return noOfNotification;
        }

        int currentIndex = 0;
        while (d + currentIndex < expenditure.Count())
        {
            List<int> currentHistory = new List<int>();
            for (int i = currentIndex; i < currentIndex+d; i++)
            {
                currentHistory.Add(expenditure[i]);
            }

            int times2Median = sortAndFindMedianTimes2(currentHistory);
            if (expenditure[d] >= times2Median)
            {
                noOfNotification++;
            }
            currentIndex++;
        }

        return noOfNotification;
    }

}*/

class Result
{


    /** Complete the 'activityNotifications' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY expenditure
    *  2. INTEGER d*/
    public static Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
    public static int find(int idx) {
        int start = 0;
        for(int i = 0; i <= 200; i++)
        {
            int frec = 0;
            if (keyValuePairs.ContainsKey(i))
            {
                frec= keyValuePairs[i];
            }
            start = start + frec;
            if (start >= idx)
            {
                return i;
            }
        }
        return 0;
    }

    public static int activityNotifications(List<int> expenditure, int d)
    {
        int noOfNotification = 0;
        for(int i = 0; i < expenditure.Count(); i++)
        {
            int val = expenditure[i];

            if (i >= d)
            {
                float med = find(d / 2 + d % 2);

                if (d % 2 == 0)
                {
                    int ret = find(d / 2 + 1);
                    if(val>=med+ret) { noOfNotification++; }
                }
                else
                {
                    if(val>=med*2) { noOfNotification++; }
                }
            }
            if (!keyValuePairs.ContainsKey(val)) keyValuePairs[val] = 0;
            keyValuePairs[val]++;
            if (i >= d)
            {
                int prev = expenditure[i - d];
                keyValuePairs[prev] = keyValuePairs[prev] - 1;
            }
        }

        return noOfNotification;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
