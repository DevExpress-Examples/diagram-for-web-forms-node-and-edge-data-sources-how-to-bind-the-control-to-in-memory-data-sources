Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

Namespace DiagramTwoDataSources
	Public Class Edge
		Public Property ID() As Integer
		Public Property Text() As String
		Public Property FromID() As Integer
		Public Property ToID() As Integer

		Public Sub New(ByVal id As Integer, ByVal text As String, ByVal fromId As Integer, ByVal toId As Integer)
			Me.ID = id
			Me.Text = text
			Me.FromID = fromId
			Me.ToID = toId
		End Sub

		Public Sub New()
		End Sub
	End Class

	Public Module EdgesTypedListDataProvider
		Private ReadOnly Property Edges() As List(Of Edge)
			Get
				Dim data = TryCast(HttpContext.Current.Session("DiagramTypedListEdges"), List(Of Edge))
				If data Is Nothing Then
					data = New List(Of Edge) From {
						New Edge(1, Nothing, 1, 2),
						New Edge(2, Nothing, 2, 3),
						New Edge(3, "No", 3, 5),
						New Edge(4, Nothing, 5, 2),
						New Edge(5, Nothing, 8, 4),
						New Edge(6, String.Empty, 4, 6),
						New Edge(9, String.Empty, 4, 7),
						New Edge(10, "Yes", 3, 8),
						New Edge(11, "Need developer assistance?", 8, 9),
						New Edge(12, Nothing, 9, 4)
					}
					HttpContext.Current.Session("DiagramTypedListEdges") = data
				End If
				Return data
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetEdges() As List(Of Edge)
			Return Edges
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertEdge(ByVal edge As Edge) As Integer
'INSTANT VB NOTE: The variable edges was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim edges_Renamed As List(Of Edge) = Edges
			edge.ID = If(Edges.Count = 0, 1, Edges.Max(Function(i) i.ID) + 1)
			edges_Renamed.Add(edge)
			Return edge.ID
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateEdge(ByVal edge As Edge)
'INSTANT VB NOTE: The variable edges was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim edges_Renamed As List(Of Edge) = Edges
			Dim edgeToUpdate = edges_Renamed.Find(Function(i) i.ID = edge.ID)
			edgeToUpdate.Text = edge.Text
			edgeToUpdate.FromID = edge.FromID
			edgeToUpdate.ToID = edge.ToID
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteEdge(ByVal edge As Edge)
'INSTANT VB NOTE: The variable edges was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim edges_Renamed As List(Of Edge) = Edges
			edges_Renamed.RemoveAll(Function(x) x.ID = edge.ID)
		End Sub
	End Module
End Namespace