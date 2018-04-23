Namespace WindowsFormsApplication2
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colname = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colTokens = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repositoryItemMyTokenEdit1 = New WindowsFormsApplication2.RepositoryItemMyTokenEdit()
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.repositoryItemMyTokenEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemMyTokenEdit1})
            Me.gridControl1.Size = New System.Drawing.Size(782, 439)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colname, Me.colTokens})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            ' 
            ' colname
            ' 
            Me.colname.Caption = "Name"
            Me.colname.FieldName = "Name"
            Me.colname.Name = "colname"
            Me.colname.OptionsColumn.AllowEdit = False
            Me.colname.Visible = True
            Me.colname.VisibleIndex = 0
            ' 
            ' colTokens
            ' 
            Me.colTokens.Caption = "Tokens"
            Me.colTokens.ColumnEdit = Me.repositoryItemMyTokenEdit1
            Me.colTokens.FieldName = "(none)"
            Me.colTokens.Name = "colTokens"
            Me.colTokens.UnboundType = DevExpress.Data.UnboundColumnType.Object
            Me.colTokens.Visible = True
            Me.colTokens.VisibleIndex = 1
            ' 
            ' repositoryItemMyTokenEdit1
            ' 
            Me.repositoryItemMyTokenEdit1.AutoHeightMode = DevExpress.XtraEditors.TokenEditAutoHeightMode.RestrictedExpand
            Me.repositoryItemMyTokenEdit1.EditMode = DevExpress.XtraEditors.TokenEditMode.Manual
            Me.repositoryItemMyTokenEdit1.EditValueType = DevExpress.XtraEditors.TokenEditValueType.List
            Me.repositoryItemMyTokenEdit1.MaxExpandLines = 1
            Me.repositoryItemMyTokenEdit1.Name = "repositoryItemMyTokenEdit1"
            Me.repositoryItemMyTokenEdit1.Separators.AddRange(New String() { ","})
            Me.repositoryItemMyTokenEdit1.TokenPopulateMode = DevExpress.XtraEditors.TokenEditTokenPopupateMode.DisableAutoPopulate
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(782, 439)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.repositoryItemMyTokenEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private gridControl1 As DevExpress.XtraGrid.GridControl
        Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Private colTokens As DevExpress.XtraGrid.Columns.GridColumn
        Private WithEvents repositoryItemMyTokenEdit1 As RepositoryItemMyTokenEdit
        Private colname As DevExpress.XtraGrid.Columns.GridColumn

    End Class
End Namespace

