Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Linq
Imports System.Web

Namespace DiagramTwoDataSources
	Public Module EdgesDataTableDataProvider
		Private ReadOnly Property Edges() As DataTable
			Get
				Dim dataTable = TryCast(HttpContext.Current.Session("DiagramDataTableEdges"), DataTable)
				If dataTable Is Nothing Then
					dataTable = New DataTable()

					dataTable.Columns.Add("ID", GetType(Integer))
					dataTable.Columns.Add("Text", GetType(String))
					dataTable.Columns.Add("FromID", GetType(Integer))
					dataTable.Columns.Add("ToID", GetType(Integer))

					dataTable.PrimaryKey = New DataColumn() { dataTable.Columns("ID") }

					dataTable.Rows.Add(1, Nothing, 1, 2)
					dataTable.Rows.Add(2, Nothing, 2, 3)
					dataTable.Rows.Add(3, "No", 3, 5)
					dataTable.Rows.Add(4, Nothing, 5, 2)
					dataTable.Rows.Add(5, Nothing, 8, 4)
					dataTable.Rows.Add(6, String.Empty, 4, 6)
					dataTable.Rows.Add(9, String.Empty, 4, 7)
					dataTable.Rows.Add(10, "Yes", 3, 8)
					dataTable.Rows.Add(11, "Need developer assistance?", 8, 9)
					dataTable.Rows.Add(12, Nothing, 9, 4)

					HttpContext.Current.Session("DiagramDataTableEdges") = dataTable
				End If
				Return dataTable
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetEdges() As DataTable
			Return Edges
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertEdge(ByVal text As String, ByVal fromId As Integer, ByVal toId As Integer) As Integer
			Dim newId As Integer = DirectCast(Edges.Compute("max([ID])", String.Empty), Integer) + 1
			Edges.Rows.Add(newId, text, fromId, toId)
			Return newId
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateEdge(ByVal id As Integer, ByVal text As String, ByVal fromId As Integer, ByVal toId As Integer)
			Dim edgeToUpdate = Edges.Rows.Find(id)
			edgeToUpdate("Text") = text
			edgeToUpdate("FromID") = fromId
			edgeToUpdate("ToID") = toId
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteEdge(ByVal id As Integer)
			Dim dr As DataRow = Edges.Rows.Find(id)
			Edges.Rows.Remove(dr)
		End Sub
	End Module
End Namespace