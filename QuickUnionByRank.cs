

namespace GraphProblems
{
    /// <summary>
    /// This class has QuickUnion implementation by rank where the time complexity of
    /// all functions is O(log n).
    /// Note: rank is the length of each tree.
    /// </summary>
    public class QuickUnionByRank
    {
        int[] root;
        int[] rank;
        public QuickUnionByRank(int size)
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

            if(rank[x] > rank[y])
            {
                root[rootY] = rootX;
            } else if(rank[y] > rank[x])
            {
                root[rootX] = rootY;
            } else
            {
                root[rootY] = rootX;
                rank[rootX]++;
            }
        }

        public bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
