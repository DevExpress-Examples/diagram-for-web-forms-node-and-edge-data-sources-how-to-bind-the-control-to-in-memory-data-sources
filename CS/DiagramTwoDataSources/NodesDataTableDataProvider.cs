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
                    dataTable.Columns.Add("Type", typeof(int));
                    dataTable.Columns.Add("Text", typeof(string));
                    dataTable.Columns.Add("Width", typeof(int));
                    dataTable.Columns.Add("Height", typeof(int));

                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

                    dataTable.Rows.Add(1, (int)DiagramShapeType.Terminator, "A new ticket", 96, 48);
                    dataTable.Rows.Add(2, (int)DiagramShapeType.Process, "Analyze the issue", 168, 72);
                    dataTable.Rows.Add(3, (int)DiagramShapeType.Diamond, "Do we have all information to work with?", 168, 96);
                    dataTable.Rows.Add(4, (int)DiagramShapeType.Terminator, "Answered", 96, 48);
                    dataTable.Rows.Add(5, (int)DiagramShapeType.Rectangle, "Request additional information or clarify the scenario", 144, 72);
                    dataTable.Rows.Add(6, (int)DiagramShapeType.Rectangle, "Prepare an example in Code Central", 168, 72);
                    dataTable.Rows.Add(7, (int)DiagramShapeType.Rectangle, "Update the documentation", 168, 72);
                    dataTable.Rows.Add(8, (int)DiagramShapeType.Rectangle, "Process the ticket", 168, 72);
                    dataTable.Rows.Add(9, (int)DiagramShapeType.Rectangle, "Work with the R&D team", 144, 72);
                
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
        public static int InsertNode(int type, string text, int width, int height)
        {
            int newId = (int)Nodes.Compute("max([ID])", string.Empty) + 1;
            Nodes.Rows.Add(newId, type, text, width, height);
            return newId;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateNode(int id, int type, string text, int width, int height)
        {
            var nodeToUpdate = Nodes.Rows.Find(id);
            nodeToUpdate["Type"] = type;
            nodeToUpdate["Text"] = text;
            nodeToUpdate["Width"] = width;
            nodeToUpdate["Height"] = height;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteNode(int id)
        {
            DataRow dr = Nodes.Rows.Find(id);
            Nodes.Rows.Remove(dr);
        }
    }
}
