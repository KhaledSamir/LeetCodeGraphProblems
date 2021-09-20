using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphProblems.LeetcodeProblems
{
    public class OptimizeWaterDistributioninaVillage
    {
        public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
        {

            List<int[]> edges = new List<int[]>();
            int totalCost = 0;

            for (int i = 0; i < wells.Length; i++)
            {
                edges.Add(new int[] { 0, i + 1, wells[i] });
            }

            foreach (var pipe in pipes)
            {
                edges.Add(pipe);
            }

            var orderedEdges = edges.OrderBy(item => item[2]);

            PathCompressionByRank uf = new PathCompressionByRank(n);
            foreach (var edge in orderedEdges)
            {
                if (!uf.Connected(edge[0], edge[1]))
                {
                    uf.Union(edge[0], edge[1]);
                    totalCost += edge[2];
                }
            }

            return totalCost;
        }
    }
}
