Imports DevExpress.Web.ASPxDiagram
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Linq
Imports System.Web

Namespace DiagramTwoDataSources

	Public Module NodesDataTableDataProvider
		Private ReadOnly Property Nodes() As DataTable
			Get
				Dim dataTable = TryCast(HttpContext.Current.Session("DiagramDataTableNodes"), DataTable)
				If dataTable Is Nothing Then
					dataTable = New DataTable()

					dataTable.Columns.Add("ID", GetType(Integer))
					dataTable.Columns.Add("Type", GetType(String))
					dataTable.Columns.Add("Text", GetType(String))
					dataTable.Columns.Add("Width", GetType(Integer))
					dataTable.Columns.Add("Height", GetType(Integer))
					dataTable.Columns.Add("Style", GetType(String))
					dataTable.Columns.Add("TextStyle", GetType(String))

					dataTable.PrimaryKey = New DataColumn() {dataTable.Columns("ID")}

					dataTable.Rows.Add(1, DiagramShapeType.Terminator.ToString(), "A new ticket", 96, 48)
					dataTable.Rows.Add(2, DiagramShapeType.Process.ToString(), "Analyze the issue", 168, 72)
					dataTable.Rows.Add(3, DiagramShapeType.Diamond.ToString(), "Do we have all" + vbCrLf + "information" + vbCrLf + "to work with?", 168, 96, "stroke: red")
					dataTable.Rows.Add(4, DiagramShapeType.Terminator.ToString(), "Answered", 96, 48, Nothing, "fill: darkgreen; font-weight: bold")
					dataTable.Rows.Add(5, DiagramShapeType.Rectangle.ToString(), "Request additional information or clarify the scenario", 144, 72)
					dataTable.Rows.Add(6, DiagramShapeType.Rectangle.ToString(), "Prepare an example in Code Central", 168, 72)
					dataTable.Rows.Add(7, DiagramShapeType.Rectangle.ToString(), "Update the documentation", 168, 72)
					dataTable.Rows.Add(8, DiagramShapeType.Rectangle.ToString(), "Process the ticket", 168, 72)
					dataTable.Rows.Add(9, DiagramShapeType.Rectangle.ToString(), "Work with the R&D team", 144, 72)

					HttpContext.Current.Session("DiagramDataTableNodes") = dataTable
				End If
				Return dataTable
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetNodes() As DataTable
			Return Nodes
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertNode(ByVal type As String, ByVal text As String, ByVal width As Integer, ByVal height As Integer, Optional ByVal style As String = Nothing, Optional ByVal textStyle As String = Nothing) As Integer
			Dim newId As Integer = DirectCast(Nodes.Compute("max([ID])", String.Empty), Integer) + 1
			Nodes.Rows.Add(newId, type, text, width, height, style, textStyle)
			Return newId
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateNode(ByVal id As Integer, ByVal type As String, ByVal text As String, ByVal width As Integer, ByVal height As Integer, Optional ByVal style As String = Nothing, Optional ByVal textStyle As String = Nothing)
			Dim nodeToUpdate = Nodes.Rows.Find(id)
			nodeToUpdate("Type") = type
			nodeToUpdate("Text") = text
			nodeToUpdate("Width") = width
			nodeToUpdate("Height") = height
			nodeToUpdate("Style") = style
			nodeToUpdate("TextStyle") = textStyle
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteNode(ByVal id As Integer)
			Dim dr As DataRow = Nodes.Rows.Find(id)
			Nodes.Rows.Remove(dr)
		End Sub
	End Module
End Namespace
