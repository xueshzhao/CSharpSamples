using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SampleProgrames.TutorialSample
{
    class TreeSample
    {
    }
    class TreeNode
    {
        public int val;
        public TreeNode left, right;
        public TreeNode(int i) { val = i; }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            t1.val = t1.val + t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
        //BFS
        public IList<double> AverageOfLevels(TreeNode root)
        {
            //if (root == null) return null;
            List<double> result = new List<double>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                int total = size;
                double sumVal = 0;
                while (size > 0)
                {
                    TreeNode node = queue.Dequeue();
                    sumVal += node.val;

                    size--;
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);

                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(sumVal / total);
            }

            return result;

        }
        //level triversal
        public int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode result = root;
            while (queue.Count > 0)
            {
                result = queue.Dequeue();
                if (result.right != null)
                {
                    queue.Enqueue(result.right);
                }
                if (result.left != null)
                {
                    queue.Enqueue(result.left);
                }
            }
            return result.val;
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;
            if (root.left == null && root.right == null) return root;
            TreeNode r = root.right;
            root.right = InvertTree(root.left);
            root.left = InvertTree(r);
            return root;
        }

        int min = int.MaxValue;
        TreeNode pre = null;
        public int GetMinimumDifference(TreeNode root)
        {
            //use inOrder
            if (root == null) return min;
            min= Math.Min(this.GetMinimumDifference(root.left),min);
            if (pre != null)
            {
                min = Math.Min(min, Math.Abs(root.val - pre.val));
            }
            pre = root;
            min = Math.Min(this.GetMinimumDifference(root.right), min);
            return min;
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null) return q == null;
            if (q == null||p.val!=q.val) return false;
            //if (p.val != q.val) return false;
            return this.IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null||nums.Length==0) return null;
            return this.internalSortToBST(nums, 0, nums.Length - 1);

        }
        private TreeNode internalSortToBST(int[] nums, int left, int right)
        {
            if (left > right) return null;
            if (left == right) return new TreeNode(nums[left]);
            int mid = left + (right - left) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = this.internalSortToBST(nums, left, mid - 1);
            root.right = this.internalSortToBST(nums, mid + 1, right);
            return root;
        }

        public bool DetectCapitalUse(string word)
        {
            if (string.IsNullOrEmpty(word)) return true;
            int pre = 0;
            int upper = 0;
            foreach (char ch in word.ToCharArray())
            {
                if (ch >= 'A' && ch <= 'Z') {
                    upper++;
                    if (pre == 2) return false;
                    pre = 1;
                }
                else
                {
                    if (upper > 1) return false;
                    pre = 2;
                }
            }
            return true;
        }
        public int TitleToNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int power = 1;
            int value = 0;
            foreach (char ch in s.Reverse())
            {
                int v = ch - 'A' + 1;
                v *= power;
                power *= 26;
                value += v;
            }
            return value;

        }

    }
    class ListNode
    {
        int val;
        ListNode next;
        public ListNode(int i) { val = i; }
        public ListNode ReverseList(ListNode head)
        {
            //if (head == null || head.next == null) return head;
            ListNode dimmy = new ListNode(-1);
            ListNode next = head;
            while (next != null)
            {
                ListNode nn = next.next;
                head.next = nn;
                next.next = dimmy.next;
                dimmy.next = next;
                next = nn;
            }
            return dimmy.next;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode dimmy = new ListNode(-1);
            ListNode c1 = l1;
            ListNode c2 = l2;
            ListNode pre = dimmy;
            while (c1 != null && c2 != null)
            {
                ListNode t = null;
                if (c1.val <= c2.val)
                {
                    t = new ListNode(c1.val);
                    c1 = c1.next;
                }
                else
                {
                    t = new ListNode(c2.val);
                    c2 = c2.next;
                }
                pre.next = t;
                pre = t;
            }
            while (c1 != null)
            {
                ListNode t = new ListNode(c1.val);
                c1 = c1.next;
                pre.next = t;
                pre = t;
            }
            while (c2 != null)
            {
                ListNode t = new ListNode(c2.val);
                c2 = c2.next;
                pre.next = t;
                pre = t;
            }
            return dimmy.next;
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return head;
            //ListNode pre = head;
            ListNode cur = head;
            ListNode next = head.next;
            while (next != null)
            {
                if (cur.val == next.val)
                {
                    cur.next = next.next;
                }
                else
                {
                    cur = next;
                }
                next = next.next;
            }
            return head;
        }
        /**
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0||target<=nums[0]) return 0;

        }
    */
        public bool IsAnagram(string s, string t)
        {
            if (s == null) return t == null;
            if (t == null) return false;
            if (s.Length != t.Length) return false;
            int[] s1 = buildChs(s);
            int[] s2 = buildChs(t);
            for(int i = 0; i < 26; i++)
            {
                if (s1[i] != s2[i]) return false;
            }
            return true;


        }
        private int[] buildChs(string s)
        {
            int[] result = new int[26];
            foreach(char c in s)
            {
                result[c - 'a'] = result[c - 'a'] + 1;
            }
            return result;
        }
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) return root.val == sum;
            return this.HasPathSum(root.left, sum - root.val) || this.HasPathSum(root.right, sum - root.val);
        }
        public string AddBinary(string a, string b)
        {
            return this.addBInternal(a, b, false);

        }
        private string addBInternal(string a, string b, bool up)
        {
            if (string.IsNullOrEmpty(a)) return up?this.addBInternal("1",b,false):b;
            if (string.IsNullOrEmpty(b)) return up?this.addBInternal(a,"1",false):a;
            char c1 = a.Last();
            char c2 = b.Last();
            int i1 = c1 == '1' ? 1 : 0;
            int i2 = c1 == '1' ? 1 : 0;
            int i = i1 + i2;
            if (up) i++;
            char c='0';
            up = false;
            switch (i)
            {
                case 0:
                    c = '0';
                    break;
                case 1:
                    c = '1';
                    break;
                case 2:
                    up = true;
                    c = '0';
                    break;
                case 3:
                    up = true;
                    c = '1';
                    break;

            }
            return this.addBInternal(a.Substring(0,a.Length-1), b.Substring(0,b.Length-1), up)+c;

        }
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
            if (root.left == null)
            {
                return MinDepth(root.right) + 1;
            }
            if (root.right == null)
            {
                return MinDepth(root.left) + 1;
            }
            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return null;
            string pre = strs[0];
            for(int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(pre) != 0)
                {
                    pre = pre.Substring(0, pre.Length - 1);
                }
            }
            return pre;
        }
    }
    public class Codec
    {
        private Dictionary<long, string> urls = new Dictionary<long, string>();
        long counter = 0;
        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            counter++;
            urls.Add(counter, longUrl);
            return counter + "";
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            string outVal = "";
            urls.TryGetValue(long.Parse(shortUrl),out outVal);
            return outVal;
        }
        public int CompareVersion(string version1, string version2)
        {
            if (string.IsNullOrEmpty(version1)) return string.IsNullOrEmpty(version2)?0:-1;
            if (string.IsNullOrEmpty(version2)) return 1;
            string[] s1 = version1.Split('.');
            string[] s2 = version2.Split('.');
            int cursor = 0;
            while (cursor < s1.Length || cursor < s2.Length)
            {
                int i1 = cursor < s1.Length ? int.Parse(s1[cursor]) : 0;
                int i2 = cursor < s2.Length ? int.Parse(s2[cursor]) : 0;
                if (i1 != i2)
                {
                    return i1 - i2 > 0 ? 1 : -1;
                }
                cursor++;
            }
            return 0;
        }
        /*
         * 1. 判断 r1 的左上角是否在 r2 的右下角的下面或者右面
2. 判断 r2 的左上角是否在 r1 的右下角的下面或者右面
3. 结果求反
*/
        public bool IsRectangleOverlap(int[] rect1, int[] rect2)
        {
            return !(rect1[1] <= rect2[3] || rect1[2] >= rect2[2] || rect2[1] <= rect1[3] || rect2[0] >= rect1[2]);
            
        }
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length < 2) return;
            int zeroCursor = 0;
            foreach(int num in nums)
            {
                if (num != 0)
                {
                    nums[zeroCursor++] = num;
                }
            }
            while (zeroCursor < nums.Length)
            {
                nums[zeroCursor++] = 0;
            }
        }
    }
}
