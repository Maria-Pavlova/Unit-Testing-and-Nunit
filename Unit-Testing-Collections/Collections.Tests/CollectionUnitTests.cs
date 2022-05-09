using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class Tests
    {
        private Collection<int> collection;

        [SetUp]
        public void Setup()
        {
            this.collection = new Collection<int>(new int[] {10,20,30,40});
        }

        [Test]
        public void Test_Collecyion_Add()
        {
            collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            Assert.AreEqual(2, collection.Count);
            Assert.That(collection.ToString, Is.EqualTo("[1, 2]"));
        }

        [Test]
        public void Test_Collection_InsertWithGrow()
        {
            Collection<int> collection1 = new Collection<int>();
            collection1.AddRange(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            int oldCapacity = collection.Capacity;
            collection1.InsertAt(0, 1);
            collection1.InsertAt(1, 2);
            collection1.InsertAt(2, 3);
            collection1.InsertAt(3, 4);
            collection1.InsertAt(4, 5);
            collection1.InsertAt(5, 6);
            collection1.InsertAt(6, 7);
            collection1.InsertAt(7, 8);
            Assert.That(collection1.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8]"));
            Assert.That(collection1.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(collection1.Capacity, Is.GreaterThanOrEqualTo(collection1.Count));
        }

        [Test]
        public void Test_AddRange()
        {
            collection = new Collection<int>();
            collection.AddRange(new int[] { 1, 2 ,3, 4, 5});      
            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var collection = new Collection<int>();
            int oldCapacity = collection.Capacity;
            var newNums = Enumerable.Range(100, 200).ToArray();
            collection.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(collection.ToString(), Is.EqualTo(expectedNums));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(collection.Count));
        }



        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });
            Assert.That(collection.Count, Is.EqualTo(5));
            Assert.That(collection.Capacity, Is.EqualTo(16));
        }


        [Test]
        public void Test_Collection_ResizeOfCapacityWhenAdd16Items()
        {
            collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});
            Assert.That(collection.Count, Is.EqualTo(16));
            Assert.That(collection.Capacity, Is.EqualTo(32));
        }


        [Test]
        public void Test_Collections_Clear()
        {
            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void Test_Collections_ConstructorSingleItem()
        {
            Collection<int> collection1 = new Collection<int>(new int[] {50});
             Assert.That(collection1.Count, Is.EqualTo(1));
             Assert.That(collection1[0], Is.EqualTo(50));
        }

        [Test]
        public void Test_Collections_ConstructorMultipleItems()
        {
            Collection<int> collection1 = new Collection<int>(new int[] { 50, 100, 150, 200 });
            Assert.That(collection1.Count, Is.EqualTo(4));
            Assert.That(collection1.ToString, Is.EqualTo("[50, 100, 150, 200]"));
            
        }

        [Test]
        public void Test_Collections_EmptyConstructor()
        {
            Collection<int> collection1 = new Collection<int>();
             Assert.That(collection1.Count, Is.EqualTo(0));
             Assert.That(collection1.ToString, Is.EqualTo("[]"));
           
        }

        [Test]
        public void Test_Collections_ExchangeFirstLast()
        {
            collection.Exchange(0, 3);
            Assert.That(collection[0].Equals(40), Is.True);
            Assert.That(collection[3].Equals(10), Is.True);
        }

        [Test]
        public void Test_Collections_ExchangeMidäle()
        {
            collection.Exchange(1, 2);
            Assert.That(collection[1].Equals(30), Is.True);
            Assert.That(collection[2].Equals(20), Is.True);
        }

        [Test]
        public void Test_Collections_ExchangeIndavidIndexes()
        {
         Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(1,6));
        }

        [Test]
        public void Test_Collections_GetIntByIndex()
        {
            var item1 = collection[0];
            var item2 = collection[1];
            Assert.AreEqual(10, item1);
            Assert.AreEqual(20, item2);
        }

        [Test]
        public void Test_Collections_GetStringByIndex()
        {
            Collection<string> stringCollection = new Collection<string>("First", "Second");
            var item1 = stringCollection[0];
            var item2 = stringCollection[1];
            Assert.That( item1, Is.EqualTo("First"));
            Assert.That( item2, Is.EqualTo("Second"));
        }

        [Test]
        public void Test_Collections_GetByInvalidIndex()
        {
            Assert.That(() => { var num = collection[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var num = collection[4]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var num = collection[20]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void Test_Collections_SetByInvalidIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => collection[10]=200);
        }

        [Test]
        public void Test_Collections_SetByIndex()
        {
            collection[1] = 15;
            Assert.AreEqual(collection[1], 15);
        }


        [Test]
        public void Test_Collections_InsertAtStart()
        {
            collection.InsertAt(0, 1);
           Assert.That((int)collection[0], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collections_InsertAtEnd()
        {
            collection.InsertAt(4, 50);
            Assert.That (collection[4], Is.EqualTo(50));
        }

        [Test]
        public void Test_Collections_InsertAtMiddle()
        {
            collection.InsertAt(2, 35);
            Assert.That(collection[2], Is.EqualTo(35));
        }

        [Test]
        public void Test_Collections_InsertAtInvalidIndex()
        {
          Assert.Throws<ArgumentOutOfRangeException>(() => collection.InsertAt(50, 1));
        }


        [Test]
        public void Test_Collections_RemoveAtStart()
        {
           collection.RemoveAt(0);
            Assert.That((int)collection[0], Is.EqualTo(20));
            Assert.That(collection.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Collections_RemoveAtEnd()
        {
            collection.RemoveAt(3);
            Assert.That((int)collection[2], Is.EqualTo(30));
            Assert.That(collection.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Collections_RemoveAtMiddle()
        {
            collection.RemoveAt(1);
            Assert.That((int)collection[1], Is.EqualTo(30));
            Assert.That(collection.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_Collections_RemoveAtInvalidIndex()
        {
          Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(50));
        }

        [Test]
        public void Test_Collections_ToStringMultiple()
        {
            StringAssert.AreEqualIgnoringCase(collection.ToString(), "[10, 20, 30, 40]");
        
        }

        [Test]
        public void Test_Collections_ToStringSingle()
        {
            Collection<int> collectionTest = new Collection<int>(new int[] {1}) ;
            StringAssert.AreEqualIgnoringCase(collectionTest.ToString(), "[1]");
        }

        [Test]
        public void Test_Collections_ToStringEmpty()
        {
            Collection<int> collectionTest = new Collection<int>();
            StringAssert.AreEqualIgnoringCase(collectionTest.ToString(), "[]");
        }


        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Geoge", "Merry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Geoge, Merry], [10, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }


    }
}