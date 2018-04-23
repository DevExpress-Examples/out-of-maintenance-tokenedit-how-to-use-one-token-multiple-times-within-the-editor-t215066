Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base

Namespace WindowsFormsApplication2
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            InitTokenEdit()
            InitGrid()
        End Sub
        Private Sub InitTokenEdit()
            For Each item As KeyValuePair(Of Integer, String) In TokenRegistry.GetTokens()
                repositoryItemMyTokenEdit1.Tokens.AddToken(item.Value, New ObjectWrapper(item.Key))
            Next item
        End Sub
        Private Sub InitGrid()
            gridControl1.DataSource = GetDataSource()
        End Sub
        Private Function GetDataSource() As BindingList(Of Employee)
            Dim list As New BindingList(Of Employee)()
            list.Add(New Employee("John"))
            list.Add(New Employee("Carl"))
            list.Add(New Employee("Mike"))
            list.Add(New Employee("Kate"))
            Return list
        End Function

        Private Sub OnCustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
            Dim emp As Employee = TryCast(e.Row, Employee)
            If emp Is Nothing Then
                Return
            End If
            If e.IsGetData Then
                Dim col As New BindingList(Of ObjectWrapper)()
                For Each tok As String In emp.Tokens
                    Dim id As Integer = TokenRegistry.GetId(tok)
                    col.Add(New ObjectWrapper(id))
                Next tok
                e.Value = col
            End If
        End Sub

        Private update_Renamed As Boolean = False
        Private Sub OnSelectedItemsChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs) Handles repositoryItemMyTokenEdit1.SelectedItemsChanged
            If update_Renamed Then
                Return
            End If
            Dim edit As TokenEdit = TryCast(sender, TokenEdit)
            If edit Is Nothing Then
                Return
            End If
            Dim emp As Employee = CType(gridView1.GetFocusedRow(), Employee)
            UpdateTokens(edit, emp)
        End Sub
        Private Sub UpdateTokens(ByVal edit As TokenEdit, ByVal emp As Employee)
            If update_Renamed Then
                Return
            End If
            Me.update_Renamed = True
            Try
                emp.Tokens.Clear()
                For Each wr As ObjectWrapper In DirectCast(edit.EditValue, IList)
                    Dim tok As String = TokenRegistry.GetToken(wr.Obj)
                    emp.Tokens.Add(tok)
                Next wr
                gridView1.UpdateCurrentRow()
            Finally
                Me.update_Renamed = False
            End Try
        End Sub

        Private Sub OnValidateToken(ByVal sender As Object, ByVal e As TokenEditValidateTokenEventArgs) Handles repositoryItemMyTokenEdit1.ValidateToken
            Dim id As Integer = Nothing
            If Integer.TryParse(e.Description, id) Then
                Dim tok As String = TokenRegistry.GetToken(id)
                e.Description = tok
                e.Value = New ObjectWrapper(id)
                e.IsValid = True
            End If
        End Sub
    End Class



    Public Class Employee
        Implements INotifyPropertyChanged


        Private name_Renamed As String

        Private tokens_Renamed As IList
        Public Sub New(ByVal item As String)
            Me.name_Renamed = item
            Me.tokens_Renamed = New List(Of String)()
        End Sub
        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                If Name = value Then
                    Return
                End If
                name_Renamed = value
                OnPropertyChanged("Name")
            End Set
        End Property
        <Browsable(False)> _
        Friend Property Tokens() As IList
            Get
                Return tokens_Renamed
            End Get
            Set(ByVal value As IList)
                tokens_Renamed = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Name
        End Function
        Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

    Public Class TokenRegistry
        Private tasks As Dictionary(Of Integer, String)
        Protected Sub New()
            Me.tasks = LoadTokens()
        End Sub
        Protected Function LoadTokens() As Dictionary(Of Integer, String)
            Dim t As New Dictionary(Of Integer, String)()
            t.Add(0, "One")
            t.Add(1, "Two")
            t.Add(2, "Three")
            t.Add(3, "Four")
            Return t
        End Function
        Private Shared instance As New TokenRegistry()
        Public Shared Function GetTokens() As Dictionary(Of Integer, String)
            Return instance.tasks
        End Function
        Public Shared Function GetToken(ByVal id As Integer) As String
            Return instance.tasks(id)
        End Function
        Public Shared Function GetId(ByVal token As String) As Integer
            For Each item As KeyValuePair(Of Integer, String) In instance.tasks
                If item.Value = token Then
                    Return item.Key
                End If
            Next item
            Return -1
        End Function
    End Class
End Namespace
