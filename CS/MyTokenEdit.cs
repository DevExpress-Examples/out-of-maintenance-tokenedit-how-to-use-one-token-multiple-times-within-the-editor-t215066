using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace WindowsFormsApplication2 {
    [UserRepositoryItem("RegisterMyTokenEdit")]
    public class RepositoryItemMyTokenEdit : RepositoryItemTokenEdit {
        static RepositoryItemMyTokenEdit() {
            RegisterMyTokenEdit();
        }
        public const string CustomEditName = "MyTokenEdit";

        public RepositoryItemMyTokenEdit() {
        }
        public override string EditorTypeName {
            get { return CustomEditName; }
        }
        public static void RegisterMyTokenEdit() {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(MyTokenEdit), typeof(RepositoryItemMyTokenEdit), typeof(TokenEditViewInfo), new TokenEditPainter(), true, img));
        }
    }

    [ToolboxItem(true)]
    public class MyTokenEdit : TokenEdit {
        static MyTokenEdit() {
            RepositoryItemMyTokenEdit.RegisterMyTokenEdit();
        }
        protected override TokenEditPopupForm CreatePopupForm() {
            return new MyTokenEditPopupForm(this);
        }
        protected override bool CanAddNewToken() {
            return true;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyTokenEdit Properties {
            get { return base.Properties as RepositoryItemMyTokenEdit; }
        }
        public override string EditorTypeName {
            get { return RepositoryItemMyTokenEdit.CustomEditName; }
        }
    }

    public class MyTokenEditPopupForm : TokenEditPopupForm {
        public MyTokenEditPopupForm(TokenEdit tokenEdit)
            : base(tokenEdit) {
        }
        protected override IList GetDataSource() {
            TokenEditTokenCollection tokCol = Properties.Tokens;
            TokenEditSelectedItemCollection selCol = Properties.SelectedItems;
            List<TokenEditToken> list = new List<TokenEditToken>(Properties.Tokens.Count);
            for(int i = 0; i < tokCol.Count; i++) {
                TokenEditToken tok = tokCol[i];
                if(IsSelected(tok)) {
                    ObjectWrapper wr = (ObjectWrapper)tok.Value;
                    tok = new TokenEditToken(tok.Description, wr.Clone());
                }
                list.Add(tok);
            }
            return list;
        }
        protected bool IsSelected(TokenEditToken tok) {
            foreach(TokenEditToken item in Properties.SelectedItems) {
                if(object.ReferenceEquals(tok, item)) return true;
            }
            return false;
        }
    }

    public class ObjectWrapper : ICloneable {
        int obj;
        public ObjectWrapper(int obj) {
            this.obj = obj;
        }
        public override string ToString() {
            return Obj.ToString();
        }
        public int Obj { get { return obj; } }

        object ICloneable.Clone() {
            return Clone();
        }
        public ObjectWrapper Clone() {
            return new ObjectWrapper(Obj);
        }
    }
}
