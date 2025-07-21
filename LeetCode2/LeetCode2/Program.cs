
//using System.Xml.Linq;

//ListNode x = new ListNode();
//x.Add(ref x, 2);
//x.Add(ref x, 4);
//x.Add(ref x, 3);
//ListNode y = new ListNode();
//y.Add(ref y, 2);
//y.Add(ref y, 4);
//y.Add(ref y, 3);

//ListNode z =Solution.AddTwoNumbers(x, y);
//while (z != null)
//{
//    Console.WriteLine(z.val + " ");
//    z = z.next;
//}
////Definition for singly-linked list.
//public class ListNode
//{
//    public int val;
//    public ListNode next;
//    public ListNode(int val = 0, ListNode next = null)
//    {
//        this.val = val;
//        this.next = next;
//    }
//    public void Add(ref ListNode head, int data)
//    {
//        ListNode toAdd = new ListNode();
//        toAdd.val = data;
//        ListNode current = head;
//        // traverse all nodes (see the print all nodes method for an example)
//        current.next = toAdd;
//    }
//}

//public static class Solution
//{
//    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
//    {
//        ListNode result = new ListNode();
//        ListNode ptr = result;
//        int carry = 0;
//        while (l1 != null || l2 != null)
//        {
//            int sum = 0 + carry;
//            if (l1 != null)
//            {
//                sum += l1.val;
//                l1 = l1.next;
//            }
//            if (l2 != null)
//            {
//                sum += l2.val;
//                l2 = l2.next;
//            }
//            carry = sum / 10;
//            sum = sum % 10;
//            ptr.next = new ListNode(sum);
//            ptr = ptr.next;
//        }
//        if (carry != 0)
//        {
//            ptr.next = new ListNode(carry);
//        }
//        return result.next;
//    }
//}


using System;

// Definition for singly-linked list (provided by LeetCode)
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int val1 = l1?.val ?? 0;
            int val2 = l2?.val ?? 0;

            int sum = val1 + val2 + carry;
            carry = sum / 10;
            int digit = sum % 10;

            current.next = new ListNode(digit);
            current = current.next;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummyHead.next;
    }
}

// Test class to demonstrate the solution
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Test case: 342 + 465 = 807
        // Input: l1 = [2,4,3], l2 = [5,6,4]
        // Output: [7,0,8]

        // Create first number: 342 -> [2,4,3]
        ListNode l1 = new ListNode(2);
        l1.next = new ListNode(4);
        l1.next.next = new ListNode(3);

        // Create second number: 465 -> [5,6,4]
        ListNode l2 = new ListNode(5);
        l2.next = new ListNode(6);
        l2.next.next = new ListNode(4);

        // Add the numbers
        ListNode result = solution.AddTwoNumbers(l1, l2);

        // Print the result
        Console.WriteLine("Result:");
        PrintList(result);

        // Test case 2: 0 + 0 = 0
        ListNode l3 = new ListNode(0);
        ListNode l4 = new ListNode(0);
        ListNode result2 = solution.AddTwoNumbers(l3, l4);
        Console.WriteLine("\nTest case 2 (0 + 0):");
        PrintList(result2);

        // Test case 3: 999 + 9999 = 10998
        // Input: l1 = [9,9,9], l2 = [9,9,9,9]
        ListNode l5 = new ListNode(9);
        l5.next = new ListNode(9);
        l5.next.next = new ListNode(9);

        ListNode l6 = new ListNode(9);
        l6.next = new ListNode(9);
        l6.next.next = new ListNode(9);
        l6.next.next.next = new ListNode(9);

        ListNode result3 = solution.AddTwoNumbers(l5, l6);
        Console.WriteLine("\nTest case 3 (999 + 9999):");
        PrintList(result3);
        Console.ReadKey();
    }

    // Helper method to print linked list
    public static void PrintList(ListNode head)
    {
        ListNode current = head;
        Console.Write("[");
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
            {
                Console.Write(",");
            }
            current = current.next;
        }
        Console.WriteLine("]");
    }
}