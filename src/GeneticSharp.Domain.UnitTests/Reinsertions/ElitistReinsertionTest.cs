using System;
using NUnit.Framework;
using GeneticSharp.Domain.Reinsertions;
using Rhino.Mocks;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using System.Collections.Generic;
using GeneticSharp.Domain.Randomizations;

namespace GeneticSharp.Domain.UnitTests.Reinsertions
{
	[TestFixture()]
	public class ElitistReinsertionTest
	{
		
		[Test()]
		public void SelectChromosomes_OffspringsSizeLowerThanMinSize_SelectOffsprings ()
		{
			var target = new ElitistReinsertion ();

			var population = new Population (6, 8, MockRepository.GenerateStub<ChromosomeBase> (1));
			var offsprings = new List<IChromosome> () { 
				MockRepository.GenerateStub<ChromosomeBase> (1), 
				MockRepository.GenerateStub<ChromosomeBase> (2), 
				MockRepository.GenerateStub<ChromosomeBase> (3), 
				MockRepository.GenerateStub<ChromosomeBase> (4)
			};

			var parents = new List<IChromosome> () { 
				MockRepository.GenerateStub<ChromosomeBase> (5), 
				MockRepository.GenerateStub<ChromosomeBase> (6), 
				MockRepository.GenerateStub<ChromosomeBase> (7), 
				MockRepository.GenerateStub<ChromosomeBase> (8)
			};

			parents [0].Fitness = 0.2;
			parents [1].Fitness = 0.3;
			parents [2].Fitness = 0.5;
			parents [3].Fitness = 0.7;

			var selected = target.SelectChromosomes (population, offsprings, parents);
			Assert.AreEqual (6, selected.Count);
			Assert.AreEqual (1, selected [0].Length);
			Assert.AreEqual (2, selected [1].Length);
			Assert.AreEqual (3, selected [2].Length);
			Assert.AreEqual (4, selected [3].Length);
			Assert.AreEqual (8, selected [4].Length);
			Assert.AreEqual (7, selected [5].Length);
		}
	}
}

