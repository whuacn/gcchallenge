﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
#pragma warning disable 1591

namespace ImportExport
{
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [DesignerCategory("code")]
    [ToolboxItem(true)]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    [XmlRoot("testById")]
    [HelpKeyword("vs.data.DataSet")]
    public partial class testById : DataSet
    {
        private TestsDataTable tableTests;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [DebuggerNonUserCode()]
        public testById()
        {
            BeginInit();
            InitClass();
            CollectionChangeEventHandler schemaChangedHandler = new CollectionChangeEventHandler(SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            EndInit();
        }

        [DebuggerNonUserCode()]
        protected testById(SerializationInfo info, StreamingContext context) :
            base(info, context, false)
        {
            if ((IsBinarySerialized(info, context) == true))
            {
                InitVars(false);
                CollectionChangeEventHandler schemaChangedHandler1 = new CollectionChangeEventHandler(SchemaChanged);
                Tables.CollectionChanged += schemaChangedHandler1;
                Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string) (info.GetValue("XmlSchema", typeof (string))));
            if ((DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema))
            {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new StringReader(strSchema)));
                if ((ds.Tables["Tests"] != null))
                {
                    base.Tables.Add(new TestsDataTable(ds.Tables["Tests"]));
                }
                DataSetName = ds.DataSetName;
                Prefix = ds.Prefix;
                Namespace = ds.Namespace;
                Locale = ds.Locale;
                CaseSensitive = ds.CaseSensitive;
                EnforceConstraints = ds.EnforceConstraints;
                Merge(ds, false, MissingSchemaAction.Add);
                InitVars();
            }
            else
            {
                ReadXmlSchema(new XmlTextReader(new StringReader(strSchema)));
            }
            GetSerializationData(info, context);
            CollectionChangeEventHandler schemaChangedHandler = new CollectionChangeEventHandler(SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            Relations.CollectionChanged += schemaChangedHandler;
        }

        [DebuggerNonUserCode()]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TestsDataTable Tests
        {
            get { return tableTests; }
        }

        [DebuggerNonUserCode()]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override SchemaSerializationMode SchemaSerializationMode
        {
            get { return _schemaSerializationMode; }
            set { _schemaSerializationMode = value; }
        }

        [DebuggerNonUserCode()]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get { return base.Tables; }
        }

        [DebuggerNonUserCode()]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get { return base.Relations; }
        }

        [DebuggerNonUserCode()]
        protected override void InitializeDerivedDataSet()
        {
            BeginInit();
            InitClass();
            EndInit();
        }

        [DebuggerNonUserCode()]
        public override DataSet Clone()
        {
            testById cln = ((testById) (base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = SchemaSerializationMode;
            return cln;
        }

        [DebuggerNonUserCode()]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode()]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode()]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if ((DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema))
            {
                Reset();
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["Tests"] != null))
                {
                    base.Tables.Add(new TestsDataTable(ds.Tables["Tests"]));
                }
                DataSetName = ds.DataSetName;
                Prefix = ds.Prefix;
                Namespace = ds.Namespace;
                Locale = ds.Locale;
                CaseSensitive = ds.CaseSensitive;
                EnforceConstraints = ds.EnforceConstraints;
                Merge(ds, false, MissingSchemaAction.Add);
                InitVars();
            }
            else
            {
                ReadXml(reader);
                InitVars();
            }
        }

        [DebuggerNonUserCode()]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream stream = new MemoryStream();
            WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return XmlSchema.Read(new XmlTextReader(stream), null);
        }

        [DebuggerNonUserCode()]
        internal void InitVars()
        {
            InitVars(true);
        }

        [DebuggerNonUserCode()]
        internal void InitVars(bool initTable)
        {
            tableTests = ((TestsDataTable) (base.Tables["Tests"]));
            if ((initTable == true))
            {
                if ((tableTests != null))
                {
                    tableTests.InitVars();
                }
            }
        }

        [DebuggerNonUserCode()]
        private void InitClass()
        {
            DataSetName = "testById";
            Prefix = "";
            Namespace = "http://tempuri.org/testById.xsd";
            EnforceConstraints = true;
            SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            tableTests = new TestsDataTable();
            base.Tables.Add(tableTests);
        }

        [DebuggerNonUserCode()]
        private bool ShouldSerializeTests()
        {
            return false;
        }

        [DebuggerNonUserCode()]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if ((e.Action == CollectionChangeAction.Remove))
            {
                InitVars();
            }
        }

        [DebuggerNonUserCode()]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            testById ds = new testById();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            XmlSchemaAny any = new XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }

        public delegate void TestsRowChangeEventHandler(object sender, TestsRowChangeEvent e);

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [Serializable()]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public partial class TestsDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDescription;

            private DataColumn columnGUID;

            private DataColumn columnId;

            private DataColumn columnIsPractice;

            private DataColumn columnName;

            private DataColumn columnQuestionSubtypeId;

            private DataColumn columnQuestionTypeId;

            private DataColumn columnVersion;

            [DebuggerNonUserCode()]
            public TestsDataTable()
            {
                TableName = "Tests";
                BeginInit();
                InitClass();
                EndInit();
            }

            [DebuggerNonUserCode()]
            internal TestsDataTable(DataTable table)
            {
                TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode()]
            protected TestsDataTable(SerializationInfo info, StreamingContext context) :
                base(info, context)
            {
                InitVars();
            }

            [DebuggerNonUserCode()]
            public DataColumn DescriptionColumn
            {
                get { return columnDescription; }
            }

            [DebuggerNonUserCode()]
            public DataColumn GUIDColumn
            {
                get { return columnGUID; }
            }

            [DebuggerNonUserCode()]
            public DataColumn IdColumn
            {
                get { return columnId; }
            }

            [DebuggerNonUserCode()]
            public DataColumn IsPracticeColumn
            {
                get { return columnIsPractice; }
            }

            [DebuggerNonUserCode()]
            public DataColumn NameColumn
            {
                get { return columnName; }
            }

            [DebuggerNonUserCode()]
            public DataColumn QuestionSubtypeIdColumn
            {
                get { return columnQuestionSubtypeId; }
            }

            [DebuggerNonUserCode()]
            public DataColumn QuestionTypeIdColumn
            {
                get { return columnQuestionTypeId; }
            }

            [DebuggerNonUserCode()]
            public DataColumn VersionColumn
            {
                get { return columnVersion; }
            }

            [DebuggerNonUserCode()]
            [Browsable(false)]
            public int Count
            {
                get { return Rows.Count; }
            }

            [DebuggerNonUserCode()]
            public TestsRow this[int index]
            {
                get { return ((TestsRow) (Rows[index])); }
            }

            public event TestsRowChangeEventHandler TestsRowChanging;

            public event TestsRowChangeEventHandler TestsRowChanged;

            public event TestsRowChangeEventHandler TestsRowDeleting;

            public event TestsRowChangeEventHandler TestsRowDeleted;

            [DebuggerNonUserCode()]
            public void AddTestsRow(TestsRow row)
            {
                Rows.Add(row);
            }

            [DebuggerNonUserCode()]
            public TestsRow AddTestsRow(string Description, string GUID, bool IsPractice, string Name,
                                        int QuestionSubtypeId, int QuestionTypeId, int Version)
            {
                TestsRow rowTestsRow = ((TestsRow) (NewRow()));
                rowTestsRow.ItemArray = new object[]
                    {
                        Description,
                        GUID,
                        null,
                        IsPractice,
                        Name,
                        QuestionSubtypeId,
                        QuestionTypeId,
                        Version
                    };
                Rows.Add(rowTestsRow);
                return rowTestsRow;
            }

            [DebuggerNonUserCode()]
            public TestsRow FindById(int Id)
            {
                return ((TestsRow) (Rows.Find(new object[]
                                                  {
                                                      Id
                                                  })));
            }

            [DebuggerNonUserCode()]
            public virtual IEnumerator GetEnumerator()
            {
                return Rows.GetEnumerator();
            }

            [DebuggerNonUserCode()]
            public override DataTable Clone()
            {
                TestsDataTable cln = ((TestsDataTable) (base.Clone()));
                cln.InitVars();
                return cln;
            }

            [DebuggerNonUserCode()]
            protected override DataTable CreateInstance()
            {
                return new TestsDataTable();
            }

            [DebuggerNonUserCode()]
            internal void InitVars()
            {
                columnDescription = base.Columns["Description"];
                columnGUID = base.Columns["GUID"];
                columnId = base.Columns["Id"];
                columnIsPractice = base.Columns["IsPractice"];
                columnName = base.Columns["Name"];
                columnQuestionSubtypeId = base.Columns["QuestionSubtypeId"];
                columnQuestionTypeId = base.Columns["QuestionTypeId"];
                columnVersion = base.Columns["Version"];
            }

            [DebuggerNonUserCode()]
            private void InitClass()
            {
                columnDescription = new DataColumn("Description", typeof (string), null, MappingType.Element);
                base.Columns.Add(columnDescription);
                columnGUID = new DataColumn("GUID", typeof (string), null, MappingType.Element);
                base.Columns.Add(columnGUID);
                columnId = new DataColumn("Id", typeof (int), null, MappingType.Element);
                base.Columns.Add(columnId);
                columnIsPractice = new DataColumn("IsPractice", typeof (bool), null, MappingType.Element);
                base.Columns.Add(columnIsPractice);
                columnName = new DataColumn("Name", typeof (string), null, MappingType.Element);
                base.Columns.Add(columnName);
                columnQuestionSubtypeId = new DataColumn("QuestionSubtypeId", typeof (int), null, MappingType.Element);
                base.Columns.Add(columnQuestionSubtypeId);
                columnQuestionTypeId = new DataColumn("QuestionTypeId", typeof (int), null, MappingType.Element);
                base.Columns.Add(columnQuestionTypeId);
                columnVersion = new DataColumn("Version", typeof (int), null, MappingType.Element);
                base.Columns.Add(columnVersion);
                Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[]
                                                                        {
                                                                            columnId
                                                                        }, true));
                columnDescription.MaxLength = 536870910;
                columnGUID.MaxLength = 36;
                columnId.AutoIncrement = true;
                columnId.AllowDBNull = false;
                columnId.Unique = true;
                columnName.MaxLength = 128;
            }

            [DebuggerNonUserCode()]
            public TestsRow NewTestsRow()
            {
                return ((TestsRow) (NewRow()));
            }

            [DebuggerNonUserCode()]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TestsRow(builder);
            }

            [DebuggerNonUserCode()]
            protected override Type GetRowType()
            {
                return typeof (TestsRow);
            }

            [DebuggerNonUserCode()]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((TestsRowChanged != null))
                {
                    TestsRowChanged(this, new TestsRowChangeEvent(((TestsRow) (e.Row)), e.Action));
                }
            }

            [DebuggerNonUserCode()]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((TestsRowChanging != null))
                {
                    TestsRowChanging(this, new TestsRowChangeEvent(((TestsRow) (e.Row)), e.Action));
                }
            }

            [DebuggerNonUserCode()]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((TestsRowDeleted != null))
                {
                    TestsRowDeleted(this, new TestsRowChangeEvent(((TestsRow) (e.Row)), e.Action));
                }
            }

            [DebuggerNonUserCode()]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((TestsRowDeleting != null))
                {
                    TestsRowDeleting(this, new TestsRowChangeEvent(((TestsRow) (e.Row)), e.Action));
                }
            }

            [DebuggerNonUserCode()]
            public void RemoveTestsRow(TestsRow row)
            {
                Rows.Remove(row);
            }

            [DebuggerNonUserCode()]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                testById ds = new testById();
                xs.Add(ds.GetSchemaSerializable());
                XmlSchemaAny any1 = new XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                XmlSchemaAny any2 = new XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute1 = new XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "TestsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class TestsRow : DataRow
        {
            private TestsDataTable tableTests;

            [DebuggerNonUserCode()]
            internal TestsRow(DataRowBuilder rb) :
                base(rb)
            {
                tableTests = ((TestsDataTable) (Table));
            }

            [DebuggerNonUserCode()]
            public string Description
            {
                get
                {
                    try
                    {
                        return ((string) (this[tableTests.DescriptionColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException(
                            "The value for column \'Description\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.DescriptionColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public string GUID
            {
                get
                {
                    try
                    {
                        return ((string) (this[tableTests.GUIDColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'GUID\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.GUIDColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public int Id
            {
                get { return ((int) (this[tableTests.IdColumn])); }
                set { this[tableTests.IdColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public bool IsPractice
            {
                get
                {
                    try
                    {
                        return ((bool) (this[tableTests.IsPracticeColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException(
                            "The value for column \'IsPractice\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.IsPracticeColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public string Name
            {
                get
                {
                    try
                    {
                        return ((string) (this[tableTests.NameColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'Name\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.NameColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public int QuestionSubtypeId
            {
                get
                {
                    try
                    {
                        return ((int) (this[tableTests.QuestionSubtypeIdColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException(
                            "The value for column \'QuestionSubtypeId\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.QuestionSubtypeIdColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public int QuestionTypeId
            {
                get
                {
                    try
                    {
                        return ((int) (this[tableTests.QuestionTypeIdColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException(
                            "The value for column \'QuestionTypeId\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.QuestionTypeIdColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public int Version
            {
                get
                {
                    try
                    {
                        return ((int) (this[tableTests.VersionColumn]));
                    }
                    catch (InvalidCastException e)
                    {
                        throw new StrongTypingException(
                            "The value for column \'Version\' in table \'Tests\' is DBNull.", e);
                    }
                }
                set { this[tableTests.VersionColumn] = value; }
            }

            [DebuggerNonUserCode()]
            public bool IsDescriptionNull()
            {
                return IsNull(tableTests.DescriptionColumn);
            }

            [DebuggerNonUserCode()]
            public void SetDescriptionNull()
            {
                this[tableTests.DescriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsGUIDNull()
            {
                return IsNull(tableTests.GUIDColumn);
            }

            [DebuggerNonUserCode()]
            public void SetGUIDNull()
            {
                this[tableTests.GUIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsIsPracticeNull()
            {
                return IsNull(tableTests.IsPracticeColumn);
            }

            [DebuggerNonUserCode()]
            public void SetIsPracticeNull()
            {
                this[tableTests.IsPracticeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsNameNull()
            {
                return IsNull(tableTests.NameColumn);
            }

            [DebuggerNonUserCode()]
            public void SetNameNull()
            {
                this[tableTests.NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsQuestionSubtypeIdNull()
            {
                return IsNull(tableTests.QuestionSubtypeIdColumn);
            }

            [DebuggerNonUserCode()]
            public void SetQuestionSubtypeIdNull()
            {
                this[tableTests.QuestionSubtypeIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsQuestionTypeIdNull()
            {
                return IsNull(tableTests.QuestionTypeIdColumn);
            }

            [DebuggerNonUserCode()]
            public void SetQuestionTypeIdNull()
            {
                this[tableTests.QuestionTypeIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode()]
            public bool IsVersionNull()
            {
                return IsNull(tableTests.VersionColumn);
            }

            [DebuggerNonUserCode()]
            public void SetVersionNull()
            {
                this[tableTests.VersionColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class TestsRowChangeEvent : EventArgs
        {
            private TestsRow eventRow;

            private DataRowAction eventAction;

            [DebuggerNonUserCode()]
            public TestsRowChangeEvent(TestsRow row, DataRowAction action)
            {
                eventRow = row;
                eventAction = action;
            }

            [DebuggerNonUserCode()]
            public TestsRow Row
            {
                get { return eventRow; }
            }

            [DebuggerNonUserCode()]
            public DataRowAction Action
            {
                get { return eventAction; }
            }
        }
    }
}

#pragma warning restore 1591