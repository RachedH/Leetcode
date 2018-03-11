using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    internal class MergeKLists
    {
        internal static ListNode Execute(ListNode[] lists)
        {
            var returnVal = lists.SelectMany(x => { var list = new List<int>(); while (x != null) { list.Add(x.val); x = x.next; }; return list; }).
                        OrderBy(x => x);

            ListNode head = null;
            ListNode prevEntry = null;
            ListNode currentEntry = null;

            foreach(var val in returnVal)
            {
                currentEntry = new ListNode(val);
                if (prevEntry != null)
                    prevEntry.next = currentEntry;
                prevEntry = currentEntry;
                if(head == null)
                {
                    head = currentEntry;
                }
            }

            return head;
        }
    }
}