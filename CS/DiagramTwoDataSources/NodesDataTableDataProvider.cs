using DevExpress.Web.ASPxDiagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace DiagramTwoDataSources
{

    public static class NodesDataTableDataProvider
    {
        private static DataTable Nodes
        {
            get
            {
                var dataTable = HttpContext.Current.Session["DiagramDataTableNodes"] as DataTable;
                if (dataTable == null)
                {
                    dataTable = new DataTable();

                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Type", typeof(string));
                    dataTable.Columns.Add("Text", typeof(string));
                    dataTable.Columns.Add("Width", typeof(int));
                    dataTable.Columns.Add("Height", typeof(int));
                    dataTable.Columns.Add("Style", typeof(string));
                    dataTable.Columns.Add("TextStyle", typeof(string));

                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

                    dataTable.Rows.Add(1, DiagramShapeType.Terminator.ToString(), "A new ticket", 96, 48);
                    dataTable.Rows.Add(2, DiagramShapeType.Process.ToString(), "Analyze the issue", 168, 72);
                    dataTable.Rows.Add(3, DiagramShapeType.Diamond.ToString(), "Do we have all \ninformation \nto work with?", 168, 96, "stroke: red");
                    dataTable.Rows.Add(4, DiagramShapeType.Terminator.ToString(), "Answered", 96, 48, null, "fill: darkgreen; font - weight: bold");
                    dataTable.Rows.Add(5, DiagramShapeType.Rectangle.ToString(), "Request additional information or clarify the scenario", 144, 72);
                    dataTable.Rows.Add(6, DiagramShapeType.Rectangle.ToString(), "Prepare an example in Code Central", 168, 72);
                    dataTable.Rows.Add(7, DiagramShapeType.Rectangle.ToString(), "Update the documentation", 168, 72);
                    dataTable.Rows.Add(8, DiagramShapeType.Rectangle.ToString(), "Process the ticket", 168, 72);
                    dataTable.Rows.Add(9, DiagramShapeType.Rectangle.ToString(), "Work with the R&D team", 144, 72);
                
                    HttpContext.Current.Session["DiagramDataTableNodes"] = dataTable;
                }
                return dataTable;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DataTable GetNodes()
        {
            return Nodes;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertNode(string type, string text, int width, int height, string style, string textStyle)
        {
            int newId = (int)Nodes.Compute("max([ID])", string.Empty) + 1;
            Nodes.Rows.Add(newId, type, text, width, height, style, textStyle);
            return newId;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateNode(int id, string type, string text, int width, int height, string style, string textStyle)
        {
            var nodeToUpdate = Nodes.Rows.Find(id);
            nodeToUpdate["Type"] = type;
            nodeToUpdate["Text"] = text;
            nodeToUpdate["Width"] = width;
            nodeToUpdate["Height"] = height;
            nodeToUpdate["Style"] = style;
            nodeToUpdate["TextStyle"] = textStyle;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteNode(int id)
        {
            DataRow dr = Nodes.Rows.Find(id);
            Nodes.Rows.Remove(dr);
        }
    }
}
