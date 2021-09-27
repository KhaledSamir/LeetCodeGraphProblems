using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphProblems.LeetcodeProblems
{
    public class AllPathsFromSourceToTarget
    {
        /// <summary>
        /// DFS solution
        /// </summary>
        /// <param name="graph"></param>
        /// <see cref="https://leetcode.com/problems/all-paths-from-source-to-target/"/>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int n = graph.Length;
            var g = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                g.Add(i, new List<int>());
                foreach (var nei in graph[i])
                {
                    g[i].Add(nei);
                }
            }

            var ans = new List<IList<int>>();
            var current = new List<int>();
            current.Add(0);
            GeneratePaths(ans, current, g, 0, n);

            return ans;

        }

        public void GeneratePaths(List<IList<int>> ans, List<int> current, Dictionary<int, List<int>> graph, int node, int n)
        {

            if (node == n - 1)
            {
                ans.Add(new List<int>(current));
            }
            else
            {
                foreach (var nei in graph[node])
                {
                    current.Add(nei);
                    GeneratePaths(ans, current, graph, nei, n);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }


        /// <summary>
        /// BFS Solution
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTargetBFS(int[][] graph)
        {
            int n = graph.Length;
            var g = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                g.Add(i, new List<int>());
                foreach (var nei in graph[i])
                {
                    g[i].Add(nei);
                }
            }

            var ans = new List<IList<int>>();

            int start = 0;
            int destination = n - 1;

            var q = new Queue<(int node, List<int> path)>();

            q.Enqueue((start, new List<int>() { 0 }));

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.node == destination)
                {
                    ans.Add(current.path);
                    continue;
                }
                foreach (var nei in g[current.node])
                {
                    if (nei != current.path.Last())
                    {
                        var currentPath = new List<int>(current.path);
                        currentPath.Add(nei);
                        q.Enqueue((nei, currentPath));
                    }
                }
            }

            return ans;
        }
    }
}
