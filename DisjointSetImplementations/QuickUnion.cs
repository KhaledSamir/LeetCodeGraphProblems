

namespace GraphProblems
{
    /// <summary>
    /// This class has QuickUnion implementation where the time complexity of
    /// all functions is O(H), where H is height of the tree.
    /// </summary>
    public class QuickUnion
    {
        int[] root;
        public QuickUnion(int size)
        {
            root = new int[size];
            for (int i = 0; i < size; i++)
            {
                root[i] = i;
            }
        }

        public int Find(int x)
        {
            while (x != root[x])
            {
                x = root[x];
            }
            return x;
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
