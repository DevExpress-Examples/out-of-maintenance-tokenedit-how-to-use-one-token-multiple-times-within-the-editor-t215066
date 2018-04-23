Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsFormsApplication2
    <UserRepositoryItem("RegisterMyTokenEdit")> _
    Public Class RepositoryItemMyTokenEdit
        Inherits RepositoryItemTokenEdit

        Shared Sub New()
            RegisterMyTokenEdit()
        End Sub
        Public Const CustomEditName As String = "MyTokenEdit"

        Public Sub New()
        End Sub
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return CustomEditName
            End Get
        End Property
        Public Shared Sub RegisterMyTokenEdit()
            Dim img As Image = Nothing
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(MyTokenEdit), GetType(RepositoryItemMyTokenEdit), GetType(TokenEditViewInfo), New TokenEditPainter(), True, img))
        End Sub
    End Class

    <ToolboxItem(True)> _
    Public Class MyTokenEdit
        Inherits TokenEdit

        Shared Sub New()
            RepositoryItemMyTokenEdit.RegisterMyTokenEdit()
        End Sub
        Protected Overrides Function CreatePopupForm() As TokenEditPopupForm
            Return New MyTokenEditPopupForm(Me)
        End Function
        Protected Overrides Function CanAddNewToken() As Boolean
            Return True
        End Function
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Shadows ReadOnly Property Properties() As RepositoryItemMyTokenEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemMyTokenEdit)
            End Get
        End Property
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return RepositoryItemMyTokenEdit.CustomEditName
            End Get
        End Property
    End Class

    Public Class MyTokenEditPopupForm
        Inherits TokenEditPopupForm

        Public Sub New(ByVal tokenEdit As TokenEdit)
            MyBase.New(tokenEdit)
        End Sub
        Protected Overrides Function GetDataSource() As IList
            Dim tokCol As TokenEditTokenCollection = Properties.Tokens
            Dim selCol As TokenEditSelectedItemCollection = Properties.SelectedItems
            Dim list As New List(Of TokenEditToken)(Properties.Tokens.Count)
            For i As Integer = 0 To tokCol.Count - 1
                Dim tok As TokenEditToken = tokCol(i)
                If IsSelected(tok) Then
                    Dim wr As ObjectWrapper = CType(tok.Value, ObjectWrapper)
                    tok = New TokenEditToken(tok.Description, wr.Clone())
                End If
                list.Add(tok)
            Next i
            Return list
        End Function
        Protected Function IsSelected(ByVal tok As TokenEditToken) As Boolean
            For Each item As TokenEditToken In Properties.SelectedItems
                If Object.ReferenceEquals(tok, item) Then
                    Return True
                End If
            Next item
            Return False
        End Function
    End Class

    Public Class ObjectWrapper
        Implements ICloneable


        Private obj_Renamed As Integer
        Public Sub New(ByVal obj As Integer)
            Me.obj_Renamed = obj
        End Sub
        Public Overrides Function ToString() As String
            Return Obj.ToString()
        End Function
        Public ReadOnly Property Obj() As Integer
            Get
                Return obj_Renamed
            End Get
        End Property

        Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
            Return Clone()
        End Function
        Public Function Clone() As ObjectWrapper
            Return New ObjectWrapper(Obj)
        End Function
    End Class
End Namespace
