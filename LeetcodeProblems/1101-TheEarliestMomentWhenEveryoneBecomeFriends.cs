using System;
using System.Linq;

namespace GraphProblems.LeetcodeProblems
{
    public class TheEarliestMomentWhenEveryoneBecomeFriends
    {
        public int EarliestAcq(int[][] logs, int n)
        {
            int earliest = -1;

            PathCompressionByRank uf = new PathCompressionByRank(n);

            int components = n;

            var ordered = logs.OrderBy(log => log[0]).ToList();

            foreach (var log in ordered)
            {

                if (!uf.Connected(log[1], log[2]))
                {
                    components--;
                    uf.Union(log[1], log[2]);
                }
                if (components == 1)
                    return log[0];
            }

            return earliest;
        }
    }
}
