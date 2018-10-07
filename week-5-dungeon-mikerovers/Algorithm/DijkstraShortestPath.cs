using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace week_5_dungeon_mikerovers
{
    public class DijkstraShortestPath
    {
        public Dictionary<Vertex, Vertex> Execute(Graph graph)
        {
            Dictionary<Vertex, int> distances = new Dictionary<Vertex, int>();
            Dictionary<Vertex, bool> shortestPathSet = new Dictionary<Vertex, bool>();
            Dictionary<Vertex, Vertex> parents = new Dictionary<Vertex, Vertex>();
            
            foreach (Vertex vertex in graph.Vertices)
            {
                distances.Add(vertex, int.MaxValue);
                shortestPathSet.Add(vertex, false);
                parents.Add(vertex, null);
            }

            parents[graph.StartPoint] = null;
            distances[graph.StartPoint] = 0;

            foreach (Vertex vertex in graph.Vertices)
            {
                Vertex minVertex = MinDistance(distances, shortestPathSet, graph.Vertices);
                shortestPathSet[minVertex] = true;
                
                foreach (Edge edge in minVertex.Edges)
                {
                    Vertex other = edge.Other(minVertex);
                    if (!shortestPathSet[other]
                        
                        && distances[minVertex] != int.MaxValue
                        && (distances[minVertex] + edge.Weight) < distances[other])
                    {
                        parents[other] = minVertex;
                        distances[other] = (distances[minVertex] + edge.Weight);
                    }
                }
                
                if (minVertex == graph.EndPoint)
                {
                    break;
                }
            }

            return parents;
        }

        private Vertex MinDistance(Dictionary<Vertex, int> distances, Dictionary<Vertex, bool> tree,
            HashSet<Vertex> vertices)
        {
            int min = int.MaxValue;
            Vertex minVertex = null;

            foreach (var vertex in vertices)
            {
                if (tree[vertex] == false && distances[vertex] <= min)
                {
                    min = distances[vertex];
                    minVertex = vertex;
                }
            }

            return minVertex;
        }
    }
}