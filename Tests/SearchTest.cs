using Knapsack;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class SearchTest
    {
        [Test]
        public void SimpleTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            var res = searcher.Solve(6, new int[] { 3, 2, 4 }, new int[] { 5, 6, 5 });
            Assert.AreEqual(res, new bool[] { false, true, true });
        }

        [Test]
        public void SimpleTest2()
        {
            ISolver searcher = new ExhaustiveSearch();
            var res = searcher.Solve(6, new int[] { 4, 2, 4 }, new int[] { 5, 6, 4 });
            Assert.AreEqual(res, new bool[] { true, true, false });
        }

        [Test]
        public void NegativeValuesTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            var res = searcher.Solve(6, new int[] { -3, 2, 2 }, new int[] { 5, 6, 5 });
        }

        [Test]
        public void NullListsTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            Assert.Throws<ArgumentNullException>(() => searcher.Solve(0, null, null));
        }

        [Test]
        public void EmptyListsTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            Assert.AreEqual(searcher.Solve(6, new List<int>().ToArray(), new List<int>().ToArray()), new bool[0]);
        }

        [Test]
        public void DifferentListLengthsTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            Assert.Throws<ArgumentException>(() => searcher.Solve(4, new int[] { 3, 2 }, new int[] { 5, 6, 5 }));
        }

        [Test]
        public void CapasityLessThanZeroTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            Assert.Throws<ArgumentException>(() => searcher.Solve(-4, new int[] { 3, 2, 4 }, new int[] { 5, 6, 5 }));
        }

        [Test]
        public void CapasityIsZeroTest()
        {
            ISolver searcher = new ExhaustiveSearch();
            var res = searcher.Solve(0, new int[] { 3, 2, 4 }, new int[] { 5, 6, 5 });
            Assert.AreEqual(res, new bool[] { false, false, false });
        }
    }
}