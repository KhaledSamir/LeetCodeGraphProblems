
namespace GraphProblems
{
    /// <summary>
    /// Disjoint Set implementation which stores parent Vertex as value for specific index.
    /// Define arr length when initializing the object.
    /// </summary>
    public class DisjoinSet
    {
        private readonly int[] arr;
        public DisjoinSet(int arrLength)
        {
            // [0, 0, 3, 4, 6, 7, 7]
            arr = new int[arrLength];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;
        }

        public void Union(int node1, int node2)
        {
            arr[node2] = node1;
        }

        public bool Connected(int node1, int node2)
        {
            int head1 = Find(node1);
            int head2 = Find(node2);

            return head1 == head2;
        }
        
        public int Find(int node)
        {
            int root = arr[node];
            int i = node;

            while(arr[root] != i)
            {
                root = arr[root];
                i = root;
            }


            return root;
        }
    }
}
