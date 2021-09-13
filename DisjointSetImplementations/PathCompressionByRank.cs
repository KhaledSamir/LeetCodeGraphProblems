
namespace GraphProblems
{
    /// <summary>
    /// This implementation of disjoint set improves Find & Union fuctions.
    /// The idea is connecting all the verticies to it's root node so that
    /// when we want to retrive their root node, Find function moves only 1 step to find the root node.
    /// This implemntation almost O(1) for all functions.
    /// </summary>
    public class PathCompressionByRank
    {
        int[] root;
        int[] rank;

        public PathCompressionByRank(int size)
        {
            root = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                root[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (root[x] == x)
                return x;
            return root[x] = Find(root[x]);
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[x] > rank[y])
                {
                    root[rootY] = rootX;
                }
                else if (rank[y] > rank[x])
                {
                    root[rootX] = rootY;
                }
                else
                {
                    root[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }

        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
