using NUnit.Framework;

namespace Summator.Tests
{
    public class Tests
    {
      

        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            int actual = Summator.Sum(new int[] { 2, 6 });
            int expected = 8;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test_SumTwoNegativeNumbers()
        {
            int actual = Summator.Sum(new int[] { -2, -9 });
            int expected = -11;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_SumPositiveAndNegativeNumbers()
        {
            int actual = Summator.Sum(new int[] { 2, -6 });
            int expected = -4;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_SumEmptyArray()
        {
            int actual = Summator.Sum(new int[] { });
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

   
    }
}