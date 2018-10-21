using System.Collections.Generic;
using System.Linq;

namespace week_5_dungeon_mikerovers_wouterbouwman.Algorithm
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
            }

            return result;
        }
        
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