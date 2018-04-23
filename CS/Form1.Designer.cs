namespace WindowsFormsApplication2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTokens = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMyTokenEdit1 = new WindowsFormsApplication2.RepositoryItemMyTokenEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMyTokenEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMyTokenEdit1});
            this.gridControl1.Size = new System.Drawing.Size(782, 439);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname,
            this.colTokens});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.OnCustomUnboundColumnData);
            // 
            // colname
            // 
            this.colname.Caption = "Name";
            this.colname.FieldName = "Name";
            this.colname.Name = "colname";
            this.colname.OptionsColumn.AllowEdit = false;
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            // 
            // colTokens
            // 
            this.colTokens.Caption = "Tokens";
            this.colTokens.ColumnEdit = this.repositoryItemMyTokenEdit1;
            this.colTokens.FieldName = "(none)";
            this.colTokens.Name = "colTokens";
            this.colTokens.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colTokens.Visible = true;
            this.colTokens.VisibleIndex = 1;
            // 
            // repositoryItemMyTokenEdit1
            // 
            this.repositoryItemMyTokenEdit1.AutoHeightMode = DevExpress.XtraEditors.TokenEditAutoHeightMode.RestrictedExpand;
            this.repositoryItemMyTokenEdit1.EditMode = DevExpress.XtraEditors.TokenEditMode.Manual;
            this.repositoryItemMyTokenEdit1.EditValueType = DevExpress.XtraEditors.TokenEditValueType.List;
            this.repositoryItemMyTokenEdit1.MaxExpandLines = 1;
            this.repositoryItemMyTokenEdit1.Name = "repositoryItemMyTokenEdit1";
            this.repositoryItemMyTokenEdit1.Separators.AddRange(new string[] {
            ","});
            this.repositoryItemMyTokenEdit1.TokenPopulateMode = DevExpress.XtraEditors.TokenEditTokenPopupateMode.DisableAutoPopulate;
            this.repositoryItemMyTokenEdit1.ValidateToken += new DevExpress.XtraEditors.TokenEditValidateTokenEventHandler(this.OnValidateToken);
            this.repositoryItemMyTokenEdit1.SelectedItemsChanged += new System.ComponentModel.ListChangedEventHandler(this.OnSelectedItemsChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 439);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMyTokenEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTokens;
        private RepositoryItemMyTokenEdit repositoryItemMyTokenEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colname;

    }
}

