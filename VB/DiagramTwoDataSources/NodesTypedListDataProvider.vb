Imports DevExpress.Web.ASPxDiagram
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

Namespace DiagramTwoDataSources
	Public Class Node
		Public Property ID() As Integer
		Public Property Type() As Integer
		Public Property Text() As String
		Public Property Width() As Integer
		Public Property Height() As Integer

		Public Sub New(ByVal id As Integer, ByVal type As Integer, ByVal text As String, ByVal width As Integer, ByVal height As Integer)
			Me.ID = id
			Me.Type = type
			Me.Text = text
			Me.Width = width
			Me.Height = height
		End Sub

		Public Sub New()
		End Sub
	End Class
	Public Module NodesTypedListDataProvider
		Private ReadOnly Property Nodes() As List(Of Node)
			Get
				Dim data = TryCast(HttpContext.Current.Session("DiagramNodes"), List(Of Node))
				If data Is Nothing Then
					data = New List(Of Node) From {
						New Node(1, CInt(DiagramShapeType.Terminator), "A new ticket", 96, 48),
						New Node(2, CInt(DiagramShapeType.Process), "Analyze the issue", 168, 72),
						New Node(3, CInt(DiagramShapeType.Diamond), "Do we have all information to work with?", 168, 96),
						New Node(4, CInt(DiagramShapeType.Terminator), "Answered", 96, 48),
						New Node(5, CInt(DiagramShapeType.Rectangle), "Request additional information or clarify the scenario", 144, 72),
						New Node(6, CInt(DiagramShapeType.Rectangle), "Prepare an example in Code Central", 168, 72),
						New Node(7, CInt(DiagramShapeType.Rectangle), "Update the documentation", 168, 72),
						New Node(8, CInt(DiagramShapeType.Rectangle), "Process the ticket", 168, 72),
						New Node(9, CInt(DiagramShapeType.Rectangle), "Work with the R&D team", 144, 72)
					}
					HttpContext.Current.Session("DiagramNodes") = data
				End If
				Return data
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetNodes() As List(Of Node)
			Return Nodes
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertNode(ByVal node As Node) As Integer
'INSTANT VB NOTE: The variable nodes was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim nodes_Renamed As List(Of Node) = Nodes
			node.ID = If(Nodes.Count = 0, 1, Nodes.Max(Function(i) i.ID) + 1)
			nodes_Renamed.Add(node)
			Return node.ID
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateNode(ByVal node As Node)
'INSTANT VB NOTE: The variable nodes was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim nodes_Renamed As List(Of Node) = Nodes
			Dim nodeToUpdate = nodes_Renamed.Find(Function(i) i.ID = node.ID)
			nodeToUpdate.Type = node.Type
			nodeToUpdate.Text = node.Text
			nodeToUpdate.Width = node.Width
			nodeToUpdate.Height = node.Height
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteNode(ByVal node As Node)
'INSTANT VB NOTE: The variable nodes was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim nodes_Renamed As List(Of Node) = Nodes
			nodes_Renamed.RemoveAll(Function(x) x.ID = node.ID)
		End Sub
	End Module
End Namespace
