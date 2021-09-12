
namespace GraphProblems
{
    /// <summary>
    /// Disjoint Set implementation which stores root Vertex as value for specific index.
    /// Define arr length when initializing the object.
    /// </summary>
    public class QuickFind
    {
        private readonly int[] arr;
        public QuickFind(int size)
        {
            arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i;
        }

        /// <summary>
        /// Find roots for each vertices and change all the root value for y by x; 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if(rootX != rootY)
            {
                for(int i = 0; i < arr.Length;i++)
                {
                    if (arr[i] == rootY)
                        arr[i] = rootX;
                }
            }
        }

        public bool Connected(int node1, int node2)
        {
            return Find(node1) == Find(node2);
        }
        
        public int Find(int node)
        {
            return arr[node];
        }
    }
}
