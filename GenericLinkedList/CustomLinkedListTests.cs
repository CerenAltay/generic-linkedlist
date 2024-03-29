﻿using System;
using Xunit;

namespace GenericLinkedList
{
    public class CustomLinkedListTests
    {
        private CustomLinkedList<string> _customLinkedList = new CustomLinkedList<string>();

        [Theory]
        [InlineData("X", 3, "A->B->X->C->D->E->")]
        [InlineData("X", 1, "X->A->B->C->D->E->")]
        [InlineData("X", 6, "A->B->C->D->E->X->")]
        public void Insert_GivenItemAndPosition_InsertsNode(string item, int position, string expected)
        {
            string[] items = { "A", "B", "C", "D", "E" };
            _customLinkedList.InitializeData(items);

            _customLinkedList.Insert(item, position);
            var result = _customLinkedList.PrintList();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("X", -1, "Index is out of range")]
        [InlineData("X", 0, "Index is out of range")]
        [InlineData("X", 35, "Index is out of range")]
        public void Insert_PositionOutOfRange_ThrowsExceptionWithMessage(string item, int position, string expectedMessage)
        {
            string[] items = { "A", "B", "C", "D", "E" };
            _customLinkedList.InitializeData(items);

            var exception = Assert.Throws<IndexOutOfRangeException>(() => _customLinkedList.Insert(item, position));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData(5, "A->B->C->D->")]
        [InlineData(1, "B->C->D->E->")]
        [InlineData(3, "A->B->D->E->")]
        public void Delete_GivenPosition_DeletesNode(int position, string expected)
        {
            string[] items = { "A", "B", "C", "D", "E" };
            _customLinkedList.InitializeData(items);

            _customLinkedList.Delete(position);
            var result = _customLinkedList.PrintList();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, "Index is out of range")]
        [InlineData(0, "Index is out of range")]
        [InlineData(35, "Index is out of range")]
        public void Delete_PositionOutOfRange_ThrowsExceptionWithMessage(int position, string expectedMessage)
        {
            string[] items = { "A", "B", "C", "D", "E" };
            _customLinkedList.InitializeData(items);

            var exception = Assert.Throws<IndexOutOfRangeException>(() => _customLinkedList.Delete(position));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData("A->B->C->D->E->")]
        public void PrintList_LinkedListWithNodes_PrintsNodesAsString(string expected)
        {
            string[] items = { "A", "B", "C", "D", "E" };
            _customLinkedList.InitializeData(items);

            var result = _customLinkedList.PrintList();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("List is Empty")]
        public void PrintList_EmptyLinkedList_PrintsListIsEmptyMessage(string expected)
        {
            string[] items = { };
            _customLinkedList.InitializeData(items);

            var result = _customLinkedList.PrintList();

            Assert.Equal(expected, result);
        }
    }
}
