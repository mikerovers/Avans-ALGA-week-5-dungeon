using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace week_5_dungeon_mikerovers
{
    public class MinimumSpanningTree
    {
        public HashSet<Edge> Execute(Graph graph)
        {
            HashSet<Edge> result = new HashSet<Edge>();
            
            Dictionary<Vertex, Subset> subsets = new Dictionary<Vertex, Subset>();
            foreach (var graphVertex in graph.Vertices)
            {
                subsets.Add(graphVertex, new Subset());
            }

            foreach (var graphVertex in graph.Vertices)
            {
                subsets[graphVertex].parent = graphVertex;
                subsets[graphVertex].rank = 0;
            }
            
//            Dictionary<Vertex, HashSet<Vertex>> membershipMap = new Dictionary<Vertex, HashSet<Vertex>>();
//            
//            
//            foreach (Vertex graphVertex in graph.Vertices)
//            {
//                HashSet<Vertex> set = new HashSet<Vertex>();
//                set.Add(graphVertex);
//                membershipMap.Add(graphVertex, set);
//            }
            
            Queue<Edge> edgeQueue = new Queue<Edge>(graph.Edges.OrderBy(edge => edge.Weight));

            while (edgeQueue.Count > 0)
            {
                Edge edge = edgeQueue.Dequeue();

                Vertex x = Find(subsets, edge.Node1);
                Vertex y = Find(subsets, edge.Node2);

                if (x != y)
                {
                    result.Add(edge);
                    Union(subsets, x, y);
                }

//                if (!IsSamePart(edge.Node1, edge.Node2, membershipMap))
//                {
//                    Union(edge.GetFromVertex(), edge.GetToVertex(), membershipMap);
//                    result.Add(edge);
//                }
            }

            return result;

//            HashSet<Edge> result = new HashSet<Edge>();
//            HashSet<Vertex> notIncluded = new HashSet<Vertex>(graph.Vertices);
//            Queue<Edge> edgesAvailable = new Queue<Edge>();
//
//            notIncluded.Remove(start);        
//            Vertex currentVertex = start;
//
//            while (notIncluded.Count > 0)
//            {
//                
//            }
//            
//            while (notIncluded.Count > 0)
//            {
//                foreach (Edge edge in currentVertex.Edges)
//                {
//                    if (notIncluded.Contains(edge.GetToVertex()))
//                    {
//                        edgesAvailable.Enqueue(edge); 
//                    }
//                }
//
//                edgesAvailable = new Queue<Edge>(edgesAvailable.OrderBy(edge => edge.Weight));
//                Edge min = edgesAvailable.Dequeue();
//                result.Add(min);
//
//                currentVertex = min.GetToVertex();
//                notIncluded.Remove(currentVertex);
//            }
//
//            return result;

//            Queue<Edge> edges = new Queue<Edge>(graph.Edges.OrderBy(edge => edge.Weight));
//            HashSet<Edge> solved = new HashSet<Edge>();
//
//            foreach (Edge edge in edges)
//            {
//                Vertex v1 = edge.Node1;
//                Vertex v2 = edge.Node2;
//
//                if (v1 != v2)
//                {
//                    v1.Join(v2);
//                    solved.Add(edge);
//                }
//            }
//
//            return solved;
        }

//        private bool IsSamePart(Vertex v1, Vertex v2, Dictionary<Vertex, HashSet<Vertex>> membershipMap)
//        {
//            var m1 = membershipMap[v1];
//            var m2 = membershipMap[v2];
//            var res = (m1.Equals(m2));
//
//            return res;
//        }
//
//        private void Union(Vertex v1, Vertex v2, Dictionary<Vertex, HashSet<Vertex>> membershipMap)
//        {
//            HashSet<Vertex> firstSet = membershipMap[v1];
//            HashSet<Vertex> secondSet = membershipMap[v2];
//
//            if (secondSet.Count > firstSet.Count)
//            {
//                HashSet<Vertex> tempSet = firstSet;
//                firstSet = secondSet;
//                secondSet = tempSet;
//            }
//
//            foreach (Vertex vertex in secondSet)
//            {
//                membershipMap[vertex] = secondSet;
//            }
//            
//            firstSet.UnionWith(secondSet);
//        }
        
        internal class Subset
        {
            public Vertex parent;
            public int rank;
        }

        private Vertex Find(Dictionary<Vertex, Subset> subsets, Vertex vertex)
        {
            if (subsets[vertex].parent != vertex)
            {
                subsets[vertex].parent = Find(subsets, subsets[vertex].parent);
            }

            return subsets[vertex].parent;
        }

        private void Union(Dictionary<Vertex, Subset> subsets, Vertex x, Vertex y)
        {
            Vertex xRoot = Find(subsets, x);
            Vertex yRoot = Find(subsets, y);

            if (subsets[xRoot].rank < subsets[yRoot].rank)
            {
                subsets[xRoot].parent = yRoot;
            } else if (subsets[xRoot].rank > subsets[yRoot].rank)
            {
                subsets[yRoot].parent = xRoot;
            }
            else
            {
                subsets[yRoot].parent = xRoot;
                subsets[xRoot].rank++;
            }
        }
    }
    
}