﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{

    /// <summary>
    /// A collection of tools to operate on populations and chromosomes.
    /// </summary>
    public static class LagaTools
    {

        /// <summary>
        /// Convert a binary chromosome to an integer, base of 2.
        /// </summary>
        /// <typeparam name="T">chromosome type</typeparam>
        /// <param name="chromosome">your chromosome</param>
        /// <returns>the integer.</returns>
        public static int BinaryChromosomeToInteger<T>(this T[] chromosome)
        {
            string s = String.Join<T>("", chromosome);
            if(s == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(s, 2);
            }
        }
        /// <summary>
        /// Extract part of the DNA from a chromosome. 
        /// </summary>
        /// <typeparam name="T">any chromosome type</typeparam>
        /// <param name="chromosome">the chromosome</param>
        /// <param name="index">start the extraction</param>
        /// <param name="length">length of the extraction</param>
        /// <returns>a piece of the DNA from the original chromosome</returns>
        public static T[] ExtractDNA<T>(this T[] chromosome, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(chromosome, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charPop"></param>
        public static void ReversePopulation(char[][] charPop)
        {
            char[] arrTempInd;
            for (int i = 0; i < charPop.Length / 2; i++)
            {
                arrTempInd = new char[charPop[i].Length];
                arrTempInd = charPop[i];
                charPop[i] = charPop[charPop.Length - i - 1];
                charPop[charPop.Length - i - 1] = arrTempInd;
            }
        }

        /// <summary>
        /// Generate prefixs.
        /// </summary>
        /// <param name="prefix">string prefix</param>
        /// <param name="size">the length of prefix to generate</param>
        /// <returns>Array of strings</returns>
        public static string[] Prefix(string prefix, int size)
        {
            string[] arrS = new string[size];
            for(int i = 0; i < size; i++)
            {
                arrS[i] = prefix + i.ToString();
            }

            return arrS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="any"></param>
        /// <param name="round"></param>
        /// <returns></returns>
        public static string[] Parse(point[] any, int round)
        {
            string[] arrPtsChromosome = new string[any.Length];
            double[] arrdblCoords;
            int i = 0;

            foreach (point p in any)
            {
                arrdblCoords = new double[] {Math.Round(p.X, round), Math.Round(p.Y, round), Math.Round(p.Z, round)};
                string[] arrString = Array.ConvertAll(arrdblCoords, new Converter<double, string>(Convert.ToString));
                arrPtsChromosome[i] = string.Join(", ", arrString);
                i++;
            }
            return arrPtsChromosome;
        }

        /// <summary>
        /// Parse any Chromosome type to string Array
        /// </summary>
        /// <param name="any">Array</param>
        /// <returns>Array of strings</returns>
        public static string[] Parse(double[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<double, string>(Convert.ToString));
            return arrString;
        }

        public static string[] Parse(int[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<int, string>(Convert.ToString));
            return arrString;
        }

        public static string[] Parse(float[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<float, string>(Convert.ToString));
            return arrString;
        }

        public static string[] Parse(char[] any)
        {
            string[] arrString = Array.ConvertAll(any, new Converter<char, string>(Convert.ToString));
            return arrString;
        }


        public static void Reverse(float[] arrFloat)
        {
            float temp;
            for (int i = 0; i < arrFloat.Length / 2; i++)
            {
                temp = arrFloat[i];
                arrFloat[i] = arrFloat[arrFloat.Length - i - 1];
                arrFloat[arrFloat.Length - i - 1] = temp;
            }
        }

        public static void Reverse(int[] arrInt)
        {
            int temp;
            for (int i = 0; i < arrInt.Length / 2; i++)
            {
                temp = arrInt[i];
                arrInt[i] = arrInt[arrInt.Length - i - 1];
                arrInt[arrInt.Length - i - 1] = temp;
            }
        }
        public static void Reverse(double[] arrDbl)
        {
            double temp;
            for (int i = 0; i < arrDbl.Length / 2; i++)
            {
                temp = arrDbl[i];
                arrDbl[i] = arrDbl[arrDbl.Length - i - 1];
                arrDbl[arrDbl.Length - i - 1] = temp;
            }
        }

        public static void ReversePopulation(int[][] intPop) { }
        public static void ReversePopulation(double[][] dblPop) { }
        public static void ReversePopulation(float[][] flPop) { }
        public static void ReversePopulation(object[][] objPop) { }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of integers.
        /// </summary>
        /// <param name="arrInt"> the array of integers to shuffle</param>
        /// <returns></returns>
        public static int[] Fisher_Yates(int[] arrInt)
        {
            int cant = arrInt.Length;

            int[] arrMut = new int[cant];
            Array.Copy(arrInt, arrMut, cant);
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(GetRandomNumber() * (cant - i));
                int temp = arrMut[index];
                arrMut[index] = arrMut[i];
                arrMut[i] = temp;
            }
            return arrMut;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <returns></returns>
        public static object[] Fisher_Yates(object[] arrObj)
        {
            int cant = arrObj.Length;
            object[] arrObjMuts = (object[])arrObj.Clone();

            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < cant; i++)
            {
                int index = i + (int)(r.NextDouble() * (cant - i));
                
                //swap
                object temp = arrObjMuts[index];
                arrObjMuts[index] = arrObjMuts[i];
                arrObjMuts[i] = temp;
            }

            return arrObjMuts;
        }

        /// <summary>
        /// Fisher-Yates Shuffle Algorithm for an array of objects.
        /// </summary>
        /// <param name="arrObj">the array of objects to shuffle</param>
        /// <param name="percent">the percent to shuffle</param>
        /// <returns></returns>
        public static object[] Fisher_YatesPercent(object[] arrObj, float percent)
        {
            int l = arrObj.Length;
            object[] arrObjMuts = (object[])arrObj.Clone();

            int cant = (int)(l * percent);
            cant = (cant <= 0) ? cant = 2 : cant;

            //Random r = new Random(DateTime.Now.Millisecond);
            int index;

            for (int i = 0; i < cant; i++)
            {
                //index = i + (int)(r.NextDouble() * (cant - i));
                index = GetRandomNumber(i, cant);
                //swap
                object temp = arrObjMuts[index];
                arrObjMuts[index] = arrObjMuts[i];
                arrObjMuts[i] = temp;
            }
            return arrObjMuts;
        }

        //Function to get random number
        private static readonly Random getrandom = new Random(DateTime.Now.Millisecond);

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        public static double GetRandomNumber()
        {
            lock(getrandom)
            {
                return getrandom.NextDouble();
            }
        }

        /// <summary>
        /// Returns a Char in the format 0 or 1
        /// </summary>
        /// <param name="thershold">thershold parameter. 0.5 = 50%</param>
        /// <returns></returns>
        public static char RandomCharBinary(float thershold)
        {
            char t;

            if (GetRandomNumber() < thershold)
            {
                t = '1';
            }
            else
            {
                t = '0';
            }
            return t;
        }

        /// <summary>
        /// Generate a random char.
        /// based on this link: http://www.asciitable.com/
        /// </summary>
        /// <param name="start">the start number for the table, inclusive</param>
        /// <param name="end">the end number for the table, inclusive</param>
        /// <returns>char</returns>
        public static char RandomChar(int start, int end)
        {
            return (char)GetRandomNumber(start, end + 1);
        }

        /// <summary>
        /// Experimental Fisher_Yates
        /// </summary>
        /// <typeparam name="T">the type of data</typeparam>
        /// <param name="arrData">the array of data</param>
        public static void Fishe_Yates<T>(T[] arrData)
        {
            int n = arrData.Length;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                int ri = i + (int)(r.NextDouble() * (n - i));
                T t = arrData[ri];
                arrData[ri] = arrData[i];
                arrData[i] = t;
            }
        }

        /// <summary>
        /// Return non repetead integers between a min max and percent.
        /// </summary>
        /// <param name="min">the minimum value</param>
        /// <param name="max">the maximum value</param>
        /// <param name="percent">the percent of return, if 1f will return all the numbers.</param>
        /// <returns>array of integers if wrong array of 0</returns>
        public static int[] RandomInt(int min, int max, float percent)
        {
            if(min > max) { return new int[] { 0 }; }

            int size = (int)(percent * ((max - min) + 1));
            size = (size < 1) ? 1 : size;
            int[] arrIndexSelected = new int[size];

            int[] arrIndex = Enumerable.Range(min, max).ToArray();
            arrIndex = Fisher_Yates(arrIndex);

            for (int i = 0; i < size; i++)
            {
                arrIndexSelected[i] = arrIndex[i];
            }
            return arrIndexSelected;
        }

        /// <summary>
        /// Non repeated indexs.
        /// </summary>
        /// <param name="lengthPop">the length of the population</param>
        /// <param name="percent">the percent of mutation</param>
        /// <returns>array of indexs</returns>
        public static int[] Mom_Dad(int lengthPop, float percent)
        {
            //numbers and utilities..
            int size = (int)(percent * lengthPop);

            if (size % 2 != 0) { size--; } //check if is even...
            size = (size <= 1) ? 2 : size; //check if is too small...
            

            int[] arrIndex = Enumerable.Range(0, lengthPop).ToArray();
            arrIndex = Fisher_Yates(arrIndex);

            int[] arrIndexSelected = new int[size];
            for (int i = 0; i < size; i++)
            {
                arrIndexSelected[i] = arrIndex[i];
            }

            return arrIndexSelected;
        }


    }
}
