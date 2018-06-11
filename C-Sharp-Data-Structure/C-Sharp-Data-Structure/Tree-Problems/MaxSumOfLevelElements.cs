﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure.Tree_Problems
{
    public class MaxSumOfLevelElements
    {
        BSTNode rootNode;
        Queue head;
        public MaxSumOfLevelElements()
        {
            head = new Queue();
        }

        #region Queue operations
        public bool IsEmptyQueue()
        {
            return head.frontNode == null;
        }

        private QueueNode CreateNewNode(BSTNode node)
        {
            return new QueueNode(node);
        }

        private void EnQueue(BSTNode node)
        {
            QueueNode newNode = CreateNewNode(node);
            if (IsEmptyQueue())
            {
                head.rearNode = newNode;
                head.frontNode = head.rearNode;
                return;
            }
            head.rearNode.nextNode = newNode;
            head.rearNode = head.rearNode.nextNode;
        }

        private BSTNode DeQueue()
        {
            if (IsEmptyQueue())
                throw new Exception("Queue is underflow");
            BSTNode temp = head.frontNode.data;
            head.frontNode = head.frontNode.nextNode;
            return temp;
        }
        #endregion Queue operations

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }

        #region BST
        private class BSTNode
        {
            public int data;
            public BSTNode leftNode;
            public BSTNode rightNode;

            public BSTNode(int data)
            {
                this.data = data;
                leftNode = null;
                rightNode = null;
            }
        }
        #endregion BST

        #region Queue
        private class QueueNode
        {
            public BSTNode data;
            public QueueNode nextNode;

            public QueueNode(BSTNode data)
            {
                this.data = data;
                nextNode = null;
            }
        }

        private class Queue
        {
            public QueueNode frontNode = null;
            public QueueNode rearNode = null;
        }
        #endregion Queue
    }
}