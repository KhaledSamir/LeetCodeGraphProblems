
namespace GraphProblems.LeetcodeProblems
{
    public class NumberofConnectedComponents
    {
        public int CountComponents(int n, int[][] edges)
        {
            int count = n;
            PathCompressionByRank uf = new PathCompressionByRank(n);
            foreach (var edge in edges)
            {
                if (!uf.Connected(edge[0], edge[1]))
                {
                    uf.Union(edge[0], edge[1]);
                    count--;
                }
            }

            return count;
        }
    }
}
