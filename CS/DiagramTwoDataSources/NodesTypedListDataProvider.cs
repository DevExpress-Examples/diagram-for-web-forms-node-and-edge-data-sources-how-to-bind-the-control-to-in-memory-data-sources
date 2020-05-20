using DevExpress.Web.ASPxDiagram;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DiagramTwoDataSources
{
    public class Node
    {
        public int ID { set; get; }
        public string Type { set; get; }
        public string Text { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public string Style { set; get; }
        public string TextStyle { set; get; }

        public Node(int id, string type, string text, int width, int height, string style = null, string textStyle = null)
        {
            ID = id;
            Type = type;
            Text = text;
            Width = width;
            Height = height;
            Style = style;
            TextStyle = textStyle;
        }

        public Node() { }
    }
    public static class NodesTypedListDataProvider
    {
        private static List<Node> Nodes
        {
            get
            {
                var data = HttpContext.Current.Session["DiagramNodes"] as List<Node>;
                if (data == null)
                {
                    data = new List<Node>
                {
                    new Node(1, DiagramShapeType.Terminator.ToString(), "A new ticket", 96, 48),
                    new Node(2, DiagramShapeType.Process.ToString(), "Analyze the issue", 168, 72),
                    new Node(3, DiagramShapeType.Diamond.ToString(), "Do we have all \ninformation \nto work with?", 168, 96, "stroke: red"),
                    new Node(4, DiagramShapeType.Terminator.ToString(), "Answered", 96, 48, textStyle:"fill: darkgreen; font-weight: bold"),
                    new Node(5, DiagramShapeType.Rectangle.ToString(), "Request additional information or clarify the scenario", 144, 72),
                    new Node(6, DiagramShapeType.Rectangle.ToString(), "Prepare an example in Code Central", 168, 72),
                    new Node(7, DiagramShapeType.Rectangle.ToString(), "Update the documentation", 168, 72),
                    new Node(8, DiagramShapeType.Rectangle.ToString(), "Process the ticket", 168, 72),
                    new Node(9, DiagramShapeType.Rectangle.ToString(), "Work with the R&D team", 144, 72)
                };
                    HttpContext.Current.Session["DiagramNodes"] = data;
                }
                return data;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Node> GetNodes()
        {
            return Nodes;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertNode(Node node)
        {
            List<Node> nodes = Nodes;
            node.ID = Nodes.Count == 0 ? 1 : Nodes.Max(i => i.ID) + 1;
            nodes.Add(node);
            return node.ID;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateNode(Node node)
        {
            List<Node> nodes = Nodes;
            var nodeToUpdate = nodes.Find(i => i.ID == node.ID);
            nodeToUpdate.Type = node.Type;
            nodeToUpdate.Text = node.Text;
            nodeToUpdate.Width = node.Width;
            nodeToUpdate.Height = node.Height;
            nodeToUpdate.Style = node.Style;
            nodeToUpdate.TextStyle = node.TextStyle;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteNode(Node node)
        {
            List<Node> nodes = Nodes;
            nodes.RemoveAll(x => x.ID == node.ID);
        }
    }
}
