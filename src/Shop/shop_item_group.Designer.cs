//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Shop {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("shop_item_group")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class shop_item_group : System.Data.DataSet {
        
        private shop_item_groupDataTable tableshop_item_group;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public shop_item_group() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected shop_item_group(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["shop_item_group"] != null)) {
                    base.Tables.Add(new shop_item_groupDataTable(ds.Tables["shop_item_group"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public shop_item_groupDataTable _shop_item_group {
            get {
                return this.tableshop_item_group;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override System.Data.DataSet Clone() {
            shop_item_group cln = ((shop_item_group)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["shop_item_group"] != null)) {
                    base.Tables.Add(new shop_item_groupDataTable(ds.Tables["shop_item_group"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableshop_item_group = ((shop_item_groupDataTable)(base.Tables["shop_item_group"]));
            if ((initTable == true)) {
                if ((this.tableshop_item_group != null)) {
                    this.tableshop_item_group.InitVars();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "shop_item_group";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/shop_item_group.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableshop_item_group = new shop_item_groupDataTable();
            base.Tables.Add(this.tableshop_item_group);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerialize_shop_item_group() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            shop_item_group ds = new shop_item_group();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void shop_item_groupRowChangeEventHandler(object sender, shop_item_groupRowChangeEvent e);
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class shop_item_groupDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnidx;
            
            private System.Data.DataColumn columnname;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupDataTable() {
                this.TableName = "shop_item_group";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal shop_item_groupDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected shop_item_groupDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn idxColumn {
                get {
                    return this.columnidx;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn nameColumn {
                get {
                    return this.columnname;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRow this[int index] {
                get {
                    return ((shop_item_groupRow)(this.Rows[index]));
                }
            }
            
            public event shop_item_groupRowChangeEventHandler shop_item_groupRowChanging;
            
            public event shop_item_groupRowChangeEventHandler shop_item_groupRowChanged;
            
            public event shop_item_groupRowChangeEventHandler shop_item_groupRowDeleting;
            
            public event shop_item_groupRowChangeEventHandler shop_item_groupRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Addshop_item_groupRow(shop_item_groupRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRow Addshop_item_groupRow(string name) {
                shop_item_groupRow rowshop_item_groupRow = ((shop_item_groupRow)(this.NewRow()));
                rowshop_item_groupRow.ItemArray = new object[] {
                        null,
                        name};
                this.Rows.Add(rowshop_item_groupRow);
                return rowshop_item_groupRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRow FindByidx(int idx) {
                return ((shop_item_groupRow)(this.Rows.Find(new object[] {
                            idx})));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                shop_item_groupDataTable cln = ((shop_item_groupDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new shop_item_groupDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnidx = base.Columns["idx"];
                this.columnname = base.Columns["name"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnidx = new System.Data.DataColumn("idx", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnidx);
                this.columnname = new System.Data.DataColumn("name", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnname);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnidx}, true));
                this.columnidx.AutoIncrement = true;
                this.columnidx.AllowDBNull = false;
                this.columnidx.ReadOnly = true;
                this.columnidx.Unique = true;
                this.columnname.MaxLength = 50;
                this.ExtendedProperties.Add("Generator_TablePropName", "_shop_item_group");
                this.ExtendedProperties.Add("Generator_UserTableName", "shop_item_group");
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRow Newshop_item_groupRow() {
                return ((shop_item_groupRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new shop_item_groupRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(shop_item_groupRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.shop_item_groupRowChanged != null)) {
                    this.shop_item_groupRowChanged(this, new shop_item_groupRowChangeEvent(((shop_item_groupRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.shop_item_groupRowChanging != null)) {
                    this.shop_item_groupRowChanging(this, new shop_item_groupRowChangeEvent(((shop_item_groupRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.shop_item_groupRowDeleted != null)) {
                    this.shop_item_groupRowDeleted(this, new shop_item_groupRowChangeEvent(((shop_item_groupRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.shop_item_groupRowDeleting != null)) {
                    this.shop_item_groupRowDeleting(this, new shop_item_groupRowChangeEvent(((shop_item_groupRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Removeshop_item_groupRow(shop_item_groupRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                shop_item_group ds = new shop_item_group();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "shop_item_groupDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class shop_item_groupRow : System.Data.DataRow {
            
            private shop_item_groupDataTable tableshop_item_group;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal shop_item_groupRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableshop_item_group = ((shop_item_groupDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int idx {
                get {
                    return ((int)(this[this.tableshop_item_group.idxColumn]));
                }
                set {
                    this[this.tableshop_item_group.idxColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string name {
                get {
                    try {
                        return ((string)(this[this.tableshop_item_group.nameColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'name\' in table \'shop_item_group\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableshop_item_group.nameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsnameNull() {
                return this.IsNull(this.tableshop_item_group.nameColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetnameNull() {
                this[this.tableshop_item_group.nameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class shop_item_groupRowChangeEvent : System.EventArgs {
            
            private shop_item_groupRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRowChangeEvent(shop_item_groupRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public shop_item_groupRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
namespace Shop.shop_item_groupTableAdapters {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.ComponentModel.DataObjectAttribute(true)]
    [System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" +
        ", Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
    public partial class shop_item_groupTableAdapter : System.ComponentModel.Component {
        
        private System.Data.SqlClient.SqlDataAdapter _adapter;
        
        private System.Data.SqlClient.SqlConnection _connection;
        
        private System.Data.SqlClient.SqlCommand[] _commandCollection;
        
        private bool _clearBeforeFill;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public shop_item_groupTableAdapter() {
            this.ClearBeforeFill = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private System.Data.SqlClient.SqlDataAdapter Adapter {
            get {
                if ((this._adapter == null)) {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal System.Data.SqlClient.SqlConnection Connection {
            get {
                if ((this._connection == null)) {
                    this.InitConnection();
                }
                return this._connection;
            }
            set {
                this._connection = value;
                if ((this.Adapter.InsertCommand != null)) {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if ((this.Adapter.DeleteCommand != null)) {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if ((this.Adapter.UpdateCommand != null)) {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; (i < this.CommandCollection.Length); i = (i + 1)) {
                    if ((this.CommandCollection[i] != null)) {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).Connection = value;
                    }
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected System.Data.SqlClient.SqlCommand[] CommandCollection {
            get {
                if ((this._commandCollection == null)) {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public bool ClearBeforeFill {
            get {
                return this._clearBeforeFill;
            }
            set {
                this._clearBeforeFill = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitAdapter() {
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "shop_item_group";
            tableMapping.ColumnMappings.Add("idx", "idx");
            tableMapping.ColumnMappings.Add("name", "name");
            this._adapter.TableMappings.Add(tableMapping);
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[shop_item_group] ([name]) VALUES (@name);\r\nSELECT idx, name FR" +
                "OM shop_item_group WHERE (idx = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitConnection() {
            this._connection = new System.Data.SqlClient.SqlConnection();
            this._connection.ConnectionString = global::Shop.Properties.Settings.Default.GCString;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitCommandCollection() {
            this._commandCollection = new System.Data.SqlClient.SqlCommand[3];
            this._commandCollection[0] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT     idx, name\r\nFROM         shop_item_group";
            this._commandCollection[0].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "DELETE FROM [dbo].[shop_item_group] WHERE ([idx] = @Original_idx);";
            this._commandCollection[1].CommandType = System.Data.CommandType.Text;
            this._commandCollection[1].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_idx", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "idx", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._commandCollection[2] = new System.Data.SqlClient.SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "UPDATE    shop_item_group\r\nSET              name = @name\r\nWHERE     idx = @Origin" +
                "al_idx; \r\n";
            this._commandCollection[2].CommandType = System.Data.CommandType.Text;
            this._commandCollection[2].Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_idx", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "idx", System.Data.DataRowVersion.Original, false, null, "", "", ""));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Fill, true)]
        public virtual int Fill(shop_item_group.shop_item_groupDataTable dataTable) {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if ((this.ClearBeforeFill == true)) {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public virtual shop_item_group.shop_item_groupDataTable GetData() {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            shop_item_group.shop_item_groupDataTable dataTable = new shop_item_group.shop_item_groupDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(shop_item_group.shop_item_groupDataTable dataTable) {
            return this.Adapter.Update(dataTable);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(shop_item_group dataSet) {
            return this.Adapter.Update(dataSet, "shop_item_group");
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow dataRow) {
            return this.Adapter.Update(new System.Data.DataRow[] {
                        dataRow});
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        public virtual int Update(System.Data.DataRow[] dataRows) {
            return this.Adapter.Update(dataRows);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public virtual int Insert(string name) {
            if ((name == null)) {
                this.Adapter.InsertCommand.Parameters[0].Value = System.DBNull.Value;
            }
            else {
                this.Adapter.InsertCommand.Parameters[0].Value = ((string)(name));
            }
            System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
            if (((this.Adapter.InsertCommand.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try {
                int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
                return returnValue;
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public virtual int DeleteGroup(int Original_idx) {
            System.Data.SqlClient.SqlCommand command = this.CommandCollection[1];
            command.Parameters[0].Value = ((int)(Original_idx));
            System.Data.ConnectionState previousConnectionState = command.Connection.State;
            if (((command.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                command.Connection.Open();
            }
            int returnValue;
            try {
                returnValue = command.ExecuteNonQuery();
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    command.Connection.Close();
                }
            }
            return returnValue;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public virtual int UpdateGroup(string name, int Original_idx) {
            System.Data.SqlClient.SqlCommand command = this.CommandCollection[2];
            if ((name == null)) {
                command.Parameters[0].Value = System.DBNull.Value;
            }
            else {
                command.Parameters[0].Value = ((string)(name));
            }
            command.Parameters[1].Value = ((int)(Original_idx));
            System.Data.ConnectionState previousConnectionState = command.Connection.State;
            if (((command.Connection.State & System.Data.ConnectionState.Open) 
                        != System.Data.ConnectionState.Open)) {
                command.Connection.Open();
            }
            int returnValue;
            try {
                returnValue = command.ExecuteNonQuery();
            }
            finally {
                if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
                    command.Connection.Close();
                }
            }
            return returnValue;
        }
    }
}

#pragma warning restore 1591