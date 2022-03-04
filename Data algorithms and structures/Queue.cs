using System.Collections.Generic;
using System.IO;
using System;
using Data_algorithms_and_structures;


class Queue
{
    // объявление массива очереди
    private List<int> queue;

    //создание очереди
    public Queue( ref ulong  N_op)
    {
        queue = new List<int>(); N_op+=2;
    }

    //возвращение количества элементов
    public int Count(ref ulong N_op)
    {
        return queue.Count; N_op++;
    }

    // Добавляем в конец
    public void Push(int newValue, ref ulong N_op)
    {
        queue.Add(newValue); N_op++;
    }

    // Извлекаем из начала
    public int Pop(ref ulong N_op)
    {
        int result = queue[0]; N_op+=2;
        queue.RemoveAt(0); N_op++;

        N_op++; return result; 
    }

    // Показываем значение первого элемента
    public int Show( ref ulong  N_op)
    {
        N_op++; 
        return queue[0];
    }

    // Получение элемента очереди по i-ой (указанной) позиции
    public int Get(int pos, ref ulong N_op)
    {
        N_op+=2;
        for (int i = 0; i < pos; ++i)
        {
            N_op+=2;
            Push(Pop(ref N_op), ref N_op); N_op++;
        }

        int result = Show(ref N_op); N_op+=2;

        N_op += 2; 
        for (int i = pos; i < queue.Count; ++i)
        {
            N_op += 2;
            Push(Pop(ref N_op), ref N_op); N_op++;
        }

        N_op++; 
        return result;
    }
    
   

    // Установка нового элемента на (i-ую) указанную позицию
    public void Set(int pos, int newValue, ref ulong N_op)
    {
        N_op+=2;
        for (int i = 0; i < pos; ++i)
        {
            N_op += 2;
            N_op += 2;
            Push(Pop(ref N_op), ref N_op);

        }

        queue.Insert(0, newValue); N_op += 3;
        N_op += 3;
        for (int i = pos; i < queue.Count; ++i)
        {
            N_op += 3;
            N_op += 2;
            Push(Pop(ref N_op), ref N_op);
        }
    }

    // Отображение очереди в консоли
    public void Print()
    {
        foreach (int item in queue)
            Console.WriteLine(item);
        Console.WriteLine("---------");
    }
}
