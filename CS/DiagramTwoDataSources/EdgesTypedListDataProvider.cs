using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiagramTwoDataSources
{
    public class Edge
    {
        public int ID { set; get; }
        public string Text { set; get; }
        public int FromID { set; get; }
        public int ToID { set; get; }

        public Edge(int id, string text, int fromId, int toId)
        {
            ID = id;
            Text = text;
            FromID = fromId;
            ToID = toId;
        }

        public Edge() { }
    }

    public static class EdgesTypedListDataProvider
    {
        private static List<Edge> Edges
        {
            get
            {
                var data = HttpContext.Current.Session["DiagramTypedListEdges"] as List<Edge>;
                if (data == null)
                {
                    data = new List<Edge>
                {
                    new Edge(1, null, 1, 2),
                    new Edge(2, null, 2, 3),
                    new Edge(3, "No", 3, 5),
                    new Edge(4, null, 5, 2),
                    new Edge(5, null, 8, 4),
                    new Edge(6, string.Empty, 4, 6),
                    new Edge(9, string.Empty, 4, 7),
                    new Edge(10, "Yes", 3, 8),
                    new Edge(11, "Need developer assistance?", 8, 9),
                    new Edge(12, null, 9, 4)
                };
                    HttpContext.Current.Session["DiagramTypedListEdges"] = data;
                }
                return data;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Edge> GetEdges()
        {
            return Edges;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertEdge(Edge edge)
        {
            List<Edge> edges = Edges;
            edge.ID = Edges.Count == 0 ? 1 : Edges.Max(i => i.ID) + 1;
            edges.Add(edge);
            return edge.ID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateEdge(Edge edge)
        {
            List<Edge> edges = Edges;
            var edgeToUpdate = edges.Find(i => i.ID == edge.ID);
            edgeToUpdate.Text = edge.Text;
            edgeToUpdate.FromID = edge.FromID;
            edgeToUpdate.ToID = edge.ToID;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteEdge(Edge edge)
        {
            List<Edge> edges = Edges;
            edges.RemoveAll(x => x.ID == edge.ID);
        }
    }
}