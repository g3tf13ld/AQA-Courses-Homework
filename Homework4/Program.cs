﻿using Homework4.Tasks;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Из двух заданных стеков, хранящих цифры, создать новый стек из тех цифр,
             *      которые есть и в первом и во втором стеке.
             * 
             * 2. Дана последовательность из N различных целых чисел, занесённых в очередь.
             * Найти сумму её членов расположенных между максимальным и минимальным значениями
             *      (в сумму включить и оба этих числа).
             * 
             * 3. В кругу стоят N человек, пронумерованных от 1 до N.
             * При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один.
             * Составить программу, моделирующую процесс.
             * 
             * 4. Реализовать любые две сортировки из списка в лекции.
             */
            
            var task1 = new Task1();
            task1.Start();

            var task2 = new Task2();
            task2.Start();
        
            var task3 = new Task3();
            task3.Start();
            
            var task4 = new Task4();
            task4.Start();
        }
    }
}