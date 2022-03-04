using System;
using System.Collections.Generic;
using System.Text;


namespace Data_algorithms_and_structures
{
    class Merge_Sort
    {
        private List<int> res;
       
        public void Merge_Sorting(List<int> get_queue,  ref ulong N_op)
        {
            res = Sort(get_queue, ref N_op); N_op += 2;
        }

        public List<int> GetRes()
        {
            return res; 
        }
        private List<int> Sort(List<int> get_queue, ref ulong N_op)
        {
            //создаем очередь
            Queue tmp = new Queue( ref N_op); N_op += 3;

            N_op += 3;
            for (int i = 0; i < get_queue.Count; i++)
            {
                N_op += 3;
                tmp.Push(get_queue[i], ref N_op); N_op += 3;
            }

            //последние деления очереди
            N_op += 5;
            if (tmp.Count(ref N_op) == 1 || tmp.Count(ref N_op) == 0)
            {
                N_op++;
                return get_queue ;
            }
            
            //делим полученную очередь на 2 очереди L- начало первой очереди , R - второй
            int L = tmp.Count(ref N_op) / 2-1; N_op+=4;
            int R = tmp.Count(ref N_op) / 2; N_op += 3;
            Queue queue_Left = new Queue(ref N_op); N_op += 3;
            Queue queue_Right = new Queue(ref N_op) ; N_op += 3;
            //создаем 2 очереди которые в 2 раза меньше полученной
            N_op += 2;
            for (int i = 0; i <= L; i++)
            {
                N_op += 2;
                // Console.WriteLine("Push " + get_queue[i]);
                queue_Left.Push(get_queue[i], ref N_op); N_op += 2;
            }

            N_op += 3;
            for (int i = R; i < tmp.Count( ref N_op); i++)
            {
                N_op += 3;
                queue_Right.Push(get_queue[i], ref N_op); N_op += 2;
            }

            //создаем массив для неотсортированной очереди, чтобы ее потом передать в сортировку рекурсивно
            List<int> arr_queue = new List<int>(); N_op += 2;
            int iteration = queue_Left.Count(ref N_op); N_op += 2;
            N_op += 2;
            while (queue_Left.Count(ref N_op) !=0)
            {
                arr_queue.Add(queue_Left.Pop(ref N_op)); N_op += 3;
            }

            //добавление обратно в очередь ее элементов
            N_op ++;
            while (iteration != 0)
            {
                queue_Left.Push(arr_queue[iteration-1],ref N_op); N_op += 4;
                iteration--; N_op ++;
            }
            //рекурсивно вызываем сортировку и добавляем в новые отсортированные очереди
            List<int> sorted_left_list = Sort(arr_queue, ref N_op); N_op += 3;
            Queue sorted_left_queue = new Queue(ref N_op); N_op += 3;
            N_op += 3;
            for (int i = 0; i < sorted_left_list.Count; i++)
            {
                N_op += 3;
                sorted_left_queue.Push(sorted_left_list[i], ref N_op); N_op += 3;

            }
            //очищаем за собой лист, для дальнейших вычислений с правой частью.
            arr_queue.Clear(); N_op ++;



            //----------------------------------------------------------------------------------------------------------------------
            iteration = queue_Right.Count(ref N_op); N_op += 2;
            N_op += 2;
            while (queue_Right.Count(ref N_op) != 0)
            {
                N_op += 2;
                arr_queue.Add(queue_Right.Pop(ref N_op)); N_op += 3;
            }
            //добавление обратно в очередь ее элементов
            N_op ++;
            while (iteration != 0)
            {
                N_op++;
                queue_Right.Push(arr_queue[iteration - 1], ref N_op); N_op+=4;
                iteration--; N_op++;
            }

            List<int> sorted_right_list = Sort(arr_queue, ref N_op); N_op+=3;
            Queue sorted_right_queue = new Queue(ref N_op); N_op += 3;
            N_op += 3;
            for (int i = 0; i < sorted_right_list.Count; i++)
            {
                N_op += 3;
                sorted_right_queue.Push(sorted_right_list[i], ref N_op); N_op += 3;
            }
            arr_queue.Clear(); N_op ++;

            //Sorting
            //переменные циклов
            int n = 0; N_op++;
            int m = 0; N_op++;
            int k = 0; N_op++;
            Queue sorted_queue = new Queue(ref N_op); N_op+=3;
            N_op += 5;
            while (n < sorted_left_queue.Count(ref N_op) && m< sorted_right_queue.Count(ref N_op))
            {
                N_op += 5;
                N_op += 5;
                if (sorted_left_queue.Get(n, ref N_op) <= sorted_right_queue.Get(m, ref N_op))
                {                   
                    sorted_queue.Push(sorted_left_queue.Get(n, ref N_op), ref N_op); N_op += 4;
                    n += 1; N_op ++;
                }
                else
                {
                    sorted_queue.Push(sorted_right_queue.Get(m, ref N_op), ref N_op); N_op += 4;
                    m += 1; N_op++;
                }
                k += 1; N_op++;
            }
            //сортируем остатки которые не вошли
            N_op+=2;
            while (n < sorted_left_queue.Count(ref N_op))
            {
                sorted_queue.Push(sorted_left_queue.Get(n, ref N_op), ref N_op); N_op += 4;
                n += 1; N_op++;
                k += 1; N_op++;
            }
            while (m < sorted_right_queue.Count(ref N_op))
            {
                sorted_queue.Push(sorted_right_queue.Get(m, ref N_op), ref N_op); N_op += 4;
                m += 1; N_op++;
                k += 1; N_op++;
            }

            //возвращение отсортированного листа
            iteration = sorted_queue.Count(ref N_op); N_op +=2;
            N_op += 2;
            while (sorted_queue.Count(ref N_op) != 0)
            {
                N_op += 2;
                arr_queue.Add(sorted_queue.Pop(ref N_op)); N_op += 3;
            }
            //добавление обратно в очередь ее элементов
            int it = 0; N_op ++;
            N_op++;
            while (it < iteration )
            {
                N_op++;
                sorted_queue.Push(arr_queue[it], ref N_op); N_op+=3;
                it++; N_op++;
            }
            N_op++;
            return arr_queue;
        }
    }
}



