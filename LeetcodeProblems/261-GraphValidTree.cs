
namespace GraphProblems
{
    public class GraphValidTree
    {
        public bool ValidTree(int n, int[][] edges)
        {
            PathCompressionByRank uf = new PathCompressionByRank(n);
            int count = n;
            foreach (var edge in edges)
            {
                if (!uf.Connected(edge[0], edge[1]))
                {
                    uf.Union(edge[0], edge[1]);
                    count--;
                }
                else
                    return false;
            }

            return count == 1;
        }
    }
}
