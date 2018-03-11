namespace Leetcode
{
    internal class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    internal class RemoveNthNodeFromEnd
    {
        internal static ListNode Execute(ListNode head, int n)
        {
            var nthNodeRemoved = false;
            var currentNode = head;

            while(!nthNodeRemoved)
            {
                var nodeIndex = 0;
                var countNode = currentNode.next;
                while (nodeIndex < n - 1 && countNode != null)
                {
                    countNode = countNode.next;
                    nodeIndex++;
                }

                if(countNode != null)
                {
                    if (countNode.next == null)
                    {
                        currentNode.next = currentNode.next.next;
                        nthNodeRemoved = true;
                    }
                    else
                    {
                        currentNode = currentNode.next;
                    }   
                }
                else
                {
                    return head.next;
                }

            }

            return head;
        }
    }
}