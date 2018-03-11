using System;

namespace Leetcode
{
    internal class SwapPairs
    {
        internal static ListNode Execute(ListNode head)
        {
            if (head == null)
                return null;

            if (head.next == null)
                return head;

            if (head.next.next == null)
            {
                var newHead = head.next;
                newHead.next = head;
                newHead.next.next = null;

                return newHead;
            }
            else
            {
                var underlyingHead = Execute(head.next.next);
                var newHead = head.next;
                newHead.next = head;
                newHead.next.next = underlyingHead;

                return newHead;
            }
        }
    }
}