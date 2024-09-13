using Microsoft.VisualStudio.TestTools.UnitTesting;
using TareaListas;

namespace DoublyLinkedListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MergeSortedTest()
        {
            DoublyLinkedList list1 = new DoublyLinkedList();
            DoublyLinkedList list2 = new DoublyLinkedList();

            DoublyLinkedList checkList = new DoublyLinkedList();

            checkList.InsertInOrder(1);
            checkList.InsertInOrder(2);
            checkList.InsertInOrder(3);
            checkList.InsertInOrder(4);
            checkList.InsertInOrder(5);
            checkList.InsertInOrder(6);
            checkList.InsertInOrder(7);

            list1.InsertInOrder(4);
            list1.InsertInOrder(2);
            list1.InsertInOrder(7);

            list2.InsertInOrder(3);
            list2.InsertInOrder(1);
            list2.InsertInOrder(5);
            list2.InsertInOrder(6);

            list1.MergeSorted(list1, list2, SortDirection.Ascending);

            for (int i = 0; i < checkList.Length(); i++)
            {
                Assert.AreEqual(checkList.IndexValue(i), list1.IndexValue(i));
            }

        }

        [TestMethod]
        public void GetMiddleTest()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.InsertInOrder(3);
            list.InsertInOrder(4);
            list.InsertInOrder(2);
            list.InsertInOrder(5);
            list.InsertInOrder(1);

            int middle = list.GetMiddle();

            Assert.AreEqual(middle, 3);

        }

        [TestMethod]
        public void InvertListTest()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.InsertInOrder(3);
            list.InsertInOrder(4);
            list.InsertInOrder(2);
            list.InsertInOrder(5);
            list.InsertInOrder(1);

            // list should be equal to [1, 2, 3, 4, 5]

            list.InvertList();

            // should now be [5, 4, 3, 2, 1]

            int num = 5;

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(num, list.IndexValue(i));
                num--;
            }
        }
    }
}