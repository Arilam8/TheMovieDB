using GenerateDB.Data;
using NUnit.Framework;
using System;

namespace NUnitTestGenerateDB
{
    public class NUnitTestGenerateDB
    {
        private Parser _parser;
        [SetUp]
        public void Setup()
        {
            _parser = new Parser();
        }

        [Test]
        public void TestInsert50Movies()
        {
            Console.WriteLine("Inserting movies");
            bool working = false;
            if (working == false)
            {
                _parser.LoadMovies(50);
                working = true;
            }
            Console.WriteLine("Finished\n");
            if (working) Assert.Pass();
            Assert.Fail();
        }


        [Test]
        public void TestInsert100Movies()
        {
            Console.WriteLine("Inserting movies");
            bool working = false;
            if (working == false)
            {
                _parser.LoadMovies(100);
                working = true;
            }
            Console.WriteLine("Finished\n");
            if (working) Assert.Pass();
            Assert.Fail();
        }

        [TestCase(13)]
        [TestCase(35)]
        [TestCase(497)]
        [TestCase(28)]
        [TestCase(486847)]
        [TestCase(19551)]
        [TestCase(77625)]
        [TestCase(676)]
        [TestCase(46876)]
        [TestCase(142227)]
        [TestCase(144351)]
        [TestCase(60858)]
        [TestCase(9063)]
        [TestCase(75621)]
        [TestCase(11)]
        [TestCase(140607)]
        [TestCase(181808)]
        [TestCase(12180)]
        [TestCase(15969)]
        [TestCase(2249)]
        [TestCase(788)]
        [TestCase(288148)]
        [TestCase(568)]
        [TestCase(634649)]
        [TestCase(453395)]
        [TestCase(585511)]
        [TestCase(766507)]
        [TestCase(299534)]
        [TestCase(299536)]
        [TestCase(24428)]
        [TestCase(99861)]
        [TestCase(8736)]
        [TestCase(262391)]
        [TestCase(714869)]
        [TestCase(505436)]
        [TestCase(616037)]
        [TestCase(920)]
        [TestCase(594328)]
        [TestCase(297762)]
        [TestCase(464052)]
        [TestCase(102899)]
        [TestCase(363088)]
        [TestCase(1726)]
        [TestCase(10138)]
        [TestCase(68721)]
        [TestCase(271110)]
        [TestCase(1771)]
        [TestCase(100402)]
        [TestCase(299537)]
        [TestCase(524434)]
        [TestCase(284052)]
        [TestCase(384018)]
        [TestCase(343668)]
        [TestCase(207703)]
        [TestCase(476669)]
        [TestCase(557)]
        [TestCase(315635)]
        [TestCase(559)]
        [TestCase(1930)]
        [TestCase(429617)]
        [TestCase(102382)]
        [TestCase(324857)]
        [TestCase(558)]
        [TestCase(508442)]
        [TestCase(284052)]
        public void TestInsertMovie(int idMovie)
        {
            Console.WriteLine("Inserting movies");
            bool working = false;
            if (working == false)
            {
                _parser.LoadMovie(idMovie);
                working = true;
            }
            Console.WriteLine("Finished\n");
            if (working) Assert.Pass();
            Assert.Fail();
        }
    }
}