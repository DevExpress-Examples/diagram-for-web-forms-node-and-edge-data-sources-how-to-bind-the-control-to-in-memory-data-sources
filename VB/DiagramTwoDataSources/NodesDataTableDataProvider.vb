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
					dataTable.Columns.Add("Type", GetType(Integer))
					dataTable.Columns.Add("Text", GetType(String))
					dataTable.Columns.Add("Width", GetType(Integer))
					dataTable.Columns.Add("Height", GetType(Integer))

					dataTable.PrimaryKey = New DataColumn() { dataTable.Columns("ID") }

					dataTable.Rows.Add(1, CInt(DiagramShapeType.Terminator), "A new ticket", 96, 48)
					dataTable.Rows.Add(2, CInt(DiagramShapeType.Process), "Analyze" & vbLf & "the issue", 168, 72)
					dataTable.Rows.Add(3, CInt(DiagramShapeType.Diamond), "Do we have all" & vbLf & "information to" & vbLf & "work with?", 168, 96)
					dataTable.Rows.Add(4, CInt(DiagramShapeType.Terminator), "Answered" & vbLf, 96, 48)
					dataTable.Rows.Add(5, CInt(DiagramShapeType.Rectangle), "Request additional" & vbLf & "information or clarify" & vbLf & "the scenario", 144, 72)
					dataTable.Rows.Add(6, CInt(DiagramShapeType.Rectangle), "Prepare an example in" & vbLf & "Code Central", 168, 72)
					dataTable.Rows.Add(7, CInt(DiagramShapeType.Rectangle), "Update the" & vbLf & "documentation", 168, 72)
					dataTable.Rows.Add(8, CInt(DiagramShapeType.Rectangle), "Process the" & vbLf & "ticket", 168, 72)
					dataTable.Rows.Add(9, CInt(DiagramShapeType.Rectangle), "Work with the" & vbLf & "R&D team", 144, 72)

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
		Public Function InsertNode(ByVal type As Integer, ByVal text As String, ByVal width As Integer, ByVal height As Integer) As Integer
			Dim newId As Integer = DirectCast(Nodes.Compute("max([ID])", String.Empty), Integer) + 1
			Nodes.Rows.Add(newId, type, text, width, height)
			Return newId
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateNode(ByVal id As Integer, ByVal type As Integer, ByVal text As String, ByVal width As Integer, ByVal height As Integer)
			Dim nodeToUpdate = Nodes.Rows.Find(id)
			nodeToUpdate("Type") = type
			nodeToUpdate("Text") = text
			nodeToUpdate("Width") = width
			nodeToUpdate("Height") = height
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteNode(ByVal id As Integer)
			Dim dr As DataRow = Nodes.Rows.Find(id)
			Nodes.Rows.Remove(dr)
		End Sub
	End Module
End Namespace