using System.Collections.Generic;
using System.IO;
using System;
using Data_algorithms_and_structures;
using System.Diagnostics;

class Program
{
    
    //number 93. Массив - Очередь - Фиксированное двухпутевое слияние
    static void Main()
    {
        
        
        //подсчет о-символики
        ulong N_op = 0;
        List<int> res;
        Merge_Sort merge_sort = new Merge_Sort();
        int kolvo = 300;
        Stopwatch stopWatch = new Stopwatch();
        for (int i = 1; i <= 10; i ++)
        {
            stopWatch.Restart();


            merge_sort.Merge_Sorting(Random_Generation(kolvo), ref N_op);
            res = merge_sort.GetRes();

           
            stopWatch.Stop();
            
            long ms = stopWatch.ElapsedMilliseconds;
            
            // Format and display the TimeSpan value.
            //long elapsedTime = ts.Hours*360000+ ts.Minutes*6000+ ts.Seconds*100+ ts.Milliseconds;

            Console.WriteLine("Номер сортировки= "+i+" Колличество отсортированных эл. = "+kolvo+ " Время выполнения ms = "+ ms + " N_op = " + N_op);
            kolvo += 300;
        }
        
        

        /*
        merge_sort.Merge_Sorting(Random_Generation(600));
        res = merge_sort.GetRes();
        Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
        Console.WriteLine("sorted queue = ");
        for (int i = 0; i < res.Count; i++)
        {
            Console.WriteLine(res[i] + " ");
        }
        */
    }

    static List<int> Random_Generation(int num)
    {
        //Создание объекта для генерации чисел
        Random rnd = new Random();
        List<int> nums = new List<int>();
        //Console.WriteLine("Unsorted queue = ");
        for (int i = 0; i < num; i++)
        {
            nums.Add (rnd.Next(0, 1000));
            //Console.WriteLine(nums[i]);
        }

        return nums;
    }
}