
namespace GraphProblems.LeetCode
{
    public class NumberOfProvinces
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            PathCompressionByRank uf = new PathCompressionByRank(n);
            int count = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < isConnected[i].Length; j++)
                {
                    if (isConnected[i][j] == 1 && !uf.Connected(i, j))
                    {
                        uf.Union(i, j);
                        count--;
                    }
                }
            }

            // Another way to solve it is by return the entire root array.
            // Then, loop through it and count where the index == value as follows:
            // int [] root = uf.GetRoot();
            // return root.Select((value, index) => new {value, index}).Count(el => el.value == el.index);

            return count;
        }
    }
}
