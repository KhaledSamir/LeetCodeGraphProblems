using System.Collections.Generic;

namespace GraphProblems.LeetcodeProblems
{
    /// <summary>
    /// <see cref="https://leetcode.com/problems/find-if-path-exists-in-graph/"/>
    /// </summary>
    public class FindIfPathExistsInGraph
    {
        bool found = false;
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(i, new List<int>());

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var seen = new HashSet<int>();

            DFS(start, end, graph, seen);

            return found;
        }

        public void DFS(int start, int end, Dictionary<int, List<int>> graph, HashSet<int> seen)
        {
            if (start == end)
            {
                found = true;
                return;
            }

            seen.Add(start);
            foreach (var nei in graph[start])
            {
                if (!seen.Contains(nei))
                    DFS(nei, end, graph, seen);
            }
        }


        /// Solution 2
        /// public bool ValidPath(int n, int[][] edges, int start, int end) {
        public bool ValidPathBFS(int n, int[][] edges, int start, int end)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(i, new List<int>());

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            Queue<int> q = new Queue<int>();
            var seen = new HashSet<int>();
            q.Enqueue(start);
            seen.Add(start);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current == end) return true;
                foreach (var child in graph[current])
                {
                    if (!seen.Contains(child))
                    {
                        seen.Add(child);
                        q.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}
