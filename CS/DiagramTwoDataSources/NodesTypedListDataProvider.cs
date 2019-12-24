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
        public int Type { set; get; }
        public string Text { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }

        public Node(int id, int type, string text, int width, int height)
        {
            ID = id;
            Type = type;
            Text = text;
            Width = width;
            Height = height;
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
                    new Node(1, (int)DiagramShapeType.Terminator, "A new ticket", 96, 48),
                    new Node(2, (int)DiagramShapeType.Process, "Analyze\nthe issue", 168, 72),
                    new Node(3, (int)DiagramShapeType.Diamond, "Do we have all\ninformation to\nwork with?", 168, 96),
                    new Node(4, (int)DiagramShapeType.Terminator, "Answered\n", 96, 48),
                    new Node(5, (int)DiagramShapeType.Rectangle, "Request additional\ninformation or clarify\nthe scenario", 144, 72),
                    new Node(6, (int)DiagramShapeType.Rectangle, "Prepare an example in\nCode Central", 168, 72),
                    new Node(7, (int)DiagramShapeType.Rectangle, "Update the\ndocumentation", 168, 72),
                    new Node(8, (int)DiagramShapeType.Rectangle, "Process the\nticket", 168, 72),
                    new Node(9, (int)DiagramShapeType.Rectangle, "Work with the\nR&D team", 144, 72)
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
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteNode(Node node)
        {
            List<Node> nodes = Nodes;
            nodes.RemoveAll(x => x.ID == node.ID);
        }
    }
}