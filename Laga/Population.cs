﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laga.GeneticAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Population<T> : IEnumerable
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SizePopulation"></param>
        public Population(int SizePopulation)
        {
            population = new List<Chromosome<T>>(SizePopulation);
        }

        /// <summary>
        ///
        /// </summary>
        public Population()
        {
            population = new List<Chromosome<T>>();
        }

        private List<Chromosome<T>> population;

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return population.Count;
            }
        }

        /// <summary>
        /// Return the Higher Ranked Chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome<T> Higher()
        {
            return population.OrderBy(chr => chr.Fitness).Last();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type for chromosome</typeparam>
        /// <param name="chromosome2"></param>
        public void Add(Chromosome<T> chromosome2)
        {
            population.Add(chromosome2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            population.RemoveAt(index);
        }
        /// <summary>
        /// Return the Lower ranked chromosome based on the fitness evaluation
        /// </summary>
        /// <returns></returns>
        public Chromosome<T> Lower()
        {
            return population.OrderBy(chr => chr.Fitness).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Chromosome<T> GetChromosome(int index)
        {
            return population[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public double FitnessAverage()
        {
            double fltAverage = 0;
            for (int i = 0; i < population.Count; i++)
            {
                fltAverage += population[i].Fitness;
            }

            return fltAverage / population.Count;
        }


        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return population.GetEnumerator();
        }

    }
}