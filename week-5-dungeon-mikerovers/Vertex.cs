using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace week_5_dungeon_mikerovers
{
    public class Vertex
    {
        public Edge NorthernEdge { get; set; }
        public Edge SouthernEdge { get; set; }
        public Edge EasternEdge { get; set; }
        public Edge WesternEdge { get; set; }
        public char Label { get; set; }
        
        public Vertex(char label)
        {
            Label = label;
        }

        public Edge GetEdgeWith(Vertex vertex)
        {
            foreach (Edge edge in Edges)
            {
                if (edge.Other(this) == vertex)
                {
                    return edge;
                }
            }

            return null;
        }

        public override string ToString()
        {
            return Label.ToString();
        }

        public HashSet<Edge> Edges
        {
            get
            {
                HashSet<Edge> temp = new HashSet<Edge>();
                if (NorthernEdge != null && NorthernEdge.Walkable)
                {
                    temp.Add(NorthernEdge);
                }

                if (SouthernEdge != null && SouthernEdge.Walkable)
                {
                    temp.Add(SouthernEdge);
                }

                if (EasternEdge != null && EasternEdge.Walkable)
                {
                    temp.Add(EasternEdge);
                }

                if (WesternEdge != null && WesternEdge.Walkable)
                {
                    temp.Add(WesternEdge);
                }

                return temp; 
            }
        }

        public HashSet<Vertex> Neightbors
        {
            get
            {
                HashSet<Vertex> temp = new HashSet<Vertex>();
                if (NorthernEdge != null)
                {
                    temp.Add(NorthernEdge.Other(this));
                }

                if (SouthernEdge != null)
                {
                    temp.Add(SouthernEdge.Other(this));
                }

                if (EasternEdge != null)
                {
                    temp.Add(EasternEdge.Other(this));
                }

                if (WesternEdge != null)
                {
                    temp.Add(WesternEdge.Other(this));
                }

                return temp;
            }
        }

        public string GetDirectionInString(Edge e)
        {
            if (e == NorthernEdge)
            {
                return "Zuid";
            } else if (e == EasternEdge)
            {
                return "West";
            } else if (e == SouthernEdge)
            {
                return "Noord";
            } else if (e == WesternEdge)
            {
                return "Oost";
            }

            return "";
        }

        public void Draw()    
        {
            System.Console.Write(ToString());
            if (EasternEdge != null)
            {
                EasternEdge.Draw(this);
            } 
        }
    }
}