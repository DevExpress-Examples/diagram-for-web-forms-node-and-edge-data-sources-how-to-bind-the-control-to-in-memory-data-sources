using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace DiagramTwoDataSources
{
    public static class EdgesDataTableDataProvider
    {
        private static DataTable Edges
        {
            get
            {
                var dataTable = HttpContext.Current.Session["DiagramDataTableEdges"] as DataTable;
                if (dataTable == null)
                {
                    dataTable = new DataTable();

                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Text", typeof(string));
                    dataTable.Columns.Add("FromID", typeof(int));
                    dataTable.Columns.Add("ToID", typeof(int));

                    dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

                    dataTable.Rows.Add(1, null, 1, 2);
                    dataTable.Rows.Add(2, null, 2, 3);
                    dataTable.Rows.Add(3, "No", 3, 5);
                    dataTable.Rows.Add(4, null, 5, 2);
                    dataTable.Rows.Add(5, null, 8, 4);
                    dataTable.Rows.Add(6, string.Empty, 4, 6);
                    dataTable.Rows.Add(9, string.Empty, 4, 7);
                    dataTable.Rows.Add(10, "Yes", 3, 8);
                    dataTable.Rows.Add(11, "Need developer assistance?", 8, 9);
                    dataTable.Rows.Add(12, null, 9, 4);

                    HttpContext.Current.Session["DiagramDataTableEdges"] = dataTable;
                }
                return dataTable;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DataTable GetEdges()
        {
            return Edges;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertEdge(string text, int fromId, int toId)
        {
            int newId = (int)Edges.Compute("max([ID])", string.Empty) + 1;
            Edges.Rows.Add(newId, text, fromId, toId);
            return newId;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void UpdateEdge(int id, string text, int fromId, int toId)
        {
            var edgeToUpdate = Edges.Rows.Find(id);
            edgeToUpdate["Text"] = text;
            edgeToUpdate["FromID"] = fromId;
            edgeToUpdate["ToID"] = toId;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static void DeleteEdge(int id)
        {
            DataRow dr = Edges.Rows.Find(id);
            Edges.Rows.Remove(dr);
        }
    }
}