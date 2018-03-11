using System;

namespace Leetcode
{
    internal class ReverseKGroup
    {
        internal static ListNode Execute(ListNode head, int k)
        {
            if (head == null)
                return null;
            
            var count = 1;
            ListNode nodeCursor = head;

            while(count < k && nodeCursor != null)
            {
                nodeCursor = nodeCursor.next;
                ++count;
            }

            if(nodeCursor == null)
            {
                return head;
            }

            var underlyingList = Execute(nodeCursor.next, k);

            var frontNode = underlyingList;
            var middleNode = head;
            var tailNode = head.next;
            middleNode.next = frontNode;

            for (int i = 1; i < k; ++i)
            {
                frontNode = middleNode;
                middleNode = tailNode;
                tailNode = tailNode.next;
                middleNode.next = frontNode;
            }

            return middleNode;
        }
    }
}