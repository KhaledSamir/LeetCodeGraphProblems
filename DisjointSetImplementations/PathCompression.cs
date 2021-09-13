
namespace GraphProblems
{
    /// <summary>
    /// This implementation of disjoint set improves the find fuctions.
    /// The idea is connecting all the verticies to it's root node so that
    /// when we want to retrive their root node, Find function moves only 1 step to find the root node.
    /// </summary>
    public class PathCompression
    {
        int[] root;
        public PathCompression(int size)
        {
            root = new int[size];
            for (int i = 0; i < size; i++)
            {
                root[i] = i;
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
                root[rootY] = rootX;
            }
        }

        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
