using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace WindowsFormsApplication2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitTokenEdit();
            InitGrid();
        }
        void InitTokenEdit() {
            foreach(KeyValuePair<int, string> item in TokenRegistry.GetTokens()) {
                repositoryItemMyTokenEdit1.Tokens.AddToken(item.Value, new ObjectWrapper(item.Key));
            }
        }
        void InitGrid() {
            gridControl1.DataSource = GetDataSource();
        }
        BindingList<Employee> GetDataSource() {
            BindingList<Employee> list = new BindingList<Employee>();
            list.Add(new Employee("John"));
            list.Add(new Employee("Carl"));
            list.Add(new Employee("Mike"));
            list.Add(new Employee("Kate"));
            return list;
        }
        
        void OnCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
            Employee emp = e.Row as Employee;
            if(emp == null) return;
            if(e.IsGetData) {
                BindingList<ObjectWrapper> col = new BindingList<ObjectWrapper>();
                foreach(string tok in emp.Tokens) {
                    int id = TokenRegistry.GetId(tok);
                    col.Add(new ObjectWrapper(id));
                }                
                e.Value = col;
            }
        }
        bool update = false;
        void OnSelectedItemsChanged(object sender, ListChangedEventArgs e) {
            if(update) return;
            TokenEdit edit = sender as TokenEdit;
            if(edit == null) return;
            Employee emp = (Employee)gridView1.GetFocusedRow();
            UpdateTokens(edit, emp);
        }
        void UpdateTokens(TokenEdit edit, Employee emp) {
            if(update) return;
            this.update = true;
            try {
                emp.Tokens.Clear();
                foreach(ObjectWrapper wr in (IList)edit.EditValue) {
                    string tok = TokenRegistry.GetToken(wr.Obj);
                    emp.Tokens.Add(tok);
                }
                gridView1.UpdateCurrentRow();
            }
            finally {
                this.update = false;
            }
        }

        private void OnValidateToken(object sender, TokenEditValidateTokenEventArgs e) {
            int id;
            if(int.TryParse(e.Description, out id)) {
                string tok = TokenRegistry.GetToken(id);
                e.Description = tok;
                e.Value = new ObjectWrapper(id);
                e.IsValid = true;
            }
        }
    }

   

    public class Employee : INotifyPropertyChanged {
        string name;
        IList tokens;
        public Employee(string item) {
            this.name = item;
            this.tokens = new List<string>();
        }
        public string Name {
            get { return name; }
            set {
                if(Name == value)
                    return;
                name = value;
                OnPropertyChanged("Name");
            }
        }
        [Browsable(false)]
        internal IList Tokens {
            get { return tokens; }
            set { tokens = value; }
        }

        public override string ToString() {
            return Name;
        }
        protected virtual void OnPropertyChanged(string propertyName) {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TokenRegistry {
        Dictionary<int, string> tasks;
        protected TokenRegistry() {
            this.tasks = LoadTokens();
        }
        protected Dictionary<int, string> LoadTokens() {
            Dictionary<int, string> t = new Dictionary<int, string>();
            t.Add(0, "One");
            t.Add(1, "Two");
            t.Add(2, "Three");
            t.Add(3, "Four");
            return t;
        }
        static TokenRegistry instance = new TokenRegistry();
        public static Dictionary<int, string> GetTokens() {
            return instance.tasks;
        }
        public static string GetToken(int id) {
            return instance.tasks[id];
        }
        public static int GetId(string token) {
            foreach(KeyValuePair<int, string> item in instance.tasks) {
                if(item.Value == token) return item.Key;
            }
            return -1;
        }
    }
}
