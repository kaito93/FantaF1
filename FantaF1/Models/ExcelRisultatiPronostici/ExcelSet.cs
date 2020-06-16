using System.Data;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class ExcelSet : DataSet
    {
        private ApolicesIDataTable _tableApolicesI;

        private TableDataTable _tableTable;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public ExcelSet()
        {
            BeginInit();
            InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = SchemaChanged;
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected ExcelSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context, false)
        {
            if (IsBinarySerialized(info, context))
            {
                InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = SchemaChanged;
                Tables.CollectionChanged += schemaChangedHandler1;
                Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            var strSchema = (string)info.GetValue("XmlSchema", typeof(string));
            if (DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
            {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if (ds.Tables["PROPOSTAS_I"] != null)
                {
                    base.Tables.Add(new PropostasIDataTable(ds.Tables["PROPOSTAS_I"]));
                }
                if (ds.Tables["APOLICES_I"] != null)
                {
                    base.Tables.Add(new ApolicesIDataTable(ds.Tables["APOLICES_I"]));
                }
                if (ds.Tables["Table"] != null)
                {
                    base.Tables.Add(new TableDataTable(ds.Tables["Table"]));
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
                ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = SchemaChanged;
            base.Tables.CollectionChanged += schemaChangedHandler;
            Relations.CollectionChanged += schemaChangedHandler;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public PropostasIDataTable PropostasI { get; private set; }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ApolicesIDataTable ApolicesI
        {
            get
            {
                return _tableApolicesI;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public TableDataTable Table
        {
            get
            {
                return _tableTable;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return _schemaSerializationMode;
            }
            set
            {
                _schemaSerializationMode = value;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            BeginInit();
            InitClass();
            EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public override DataSet Clone()
        {
            ExcelSet cln = (ExcelSet)base.Clone();
            cln.InitVars();
            cln.SchemaSerializationMode = SchemaSerializationMode;
            return cln;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader)
        {
            if (DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
            {
                Reset();
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                if (ds.Tables["PROPOSTAS_I"] != null)
                {
                    base.Tables.Add(new PropostasIDataTable(ds.Tables["PROPOSTAS_I"]));
                }
                if (ds.Tables["APOLICES_I"] != null)
                {
                    base.Tables.Add(new ApolicesIDataTable(ds.Tables["APOLICES_I"]));
                }
                if (ds.Tables["Table"] != null)
                {
                    base.Tables.Add(new TableDataTable(ds.Tables["Table"]));
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

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        internal void InitVars()
        {
            InitVars(true);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        internal void InitVars(bool initTable)
        {
            PropostasI = (PropostasIDataTable)base.Tables["PROPOSTAS_I"];
            if (initTable)
            {
                if (PropostasI != null)
                {
                    PropostasI.InitVars();
                }
            }
            _tableApolicesI = (ApolicesIDataTable)base.Tables["APOLICES_I"];
            if (initTable)
            {
                if (_tableApolicesI != null)
                {
                    _tableApolicesI.InitVars();
                }
            }
            _tableTable = (TableDataTable)base.Tables["Table"];
            if (initTable)
            {
                if (_tableTable != null)
                {
                    _tableTable.InitVars();
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        private void InitClass()
        {
            DataSetName = "ExcelSet";
            Prefix = "";
            Namespace = "http://tempuri.org/ExcelSet.xsd";
            EnforceConstraints = true;
            SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            PropostasI = new PropostasIDataTable();
            base.Tables.Add(PropostasI);
            _tableApolicesI = new ApolicesIDataTable();
            base.Tables.Add(_tableApolicesI);
            _tableTable = new TableDataTable();
            base.Tables.Add(_tableTable);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        private bool ShouldSerializePROPOSTAS_I()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        private bool ShouldSerializeAPOLICES_I()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        private bool ShouldSerializeTable()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if (e.Action == System.ComponentModel.CollectionChangeAction.Remove)
            {
                InitVars();
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs)
        {
            ExcelSet ds = new ExcelSet();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema?.TargetNamespace))
            {
                System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                try
                {
                    System.Xml.Schema.XmlSchema schema;
                    dsSchema?.Write(s1);
                    for (System.Collections.IEnumerator schemas = xs.Schemas(dsSchema?.TargetNamespace).GetEnumerator(); schemas.MoveNext();)
                    {
                        schema = (System.Xml.Schema.XmlSchema)schemas.Current;
                        s2.SetLength(0);
                        schema?.Write(s2);
                        if (s1.Length == s2.Length)
                        {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; s1.Position != s1.Length
                                   && s1.ReadByte() == s2.ReadByte();)
                            {
                            }
                            if (s1.Position == s1.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    s1.Close();
                    s2.Close();
                }
            }

            if (dsSchema != null)
                xs.Add(dsSchema);
            return type;
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public delegate void PropostasIRowChangeEventHandler(object sender, PropostasIRowChangeEvent e);

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public delegate void ApolicesIRowChangeEventHandler(object sender, ApolicesIRowChangeEvent e);

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public delegate void TableRowChangeEventHandler(object sender, TableRowChangeEvent e);

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public sealed class PropostasIDataTable : TypedTableBase<PropostasIRow>
        {

            private DataColumn _columnData;

            private DataColumn _columnPropostas;

            private DataColumn _columnPropostasNasc;

            private DataColumn _columnPropostasWeb;

            private DataColumn _columnPropostasNascBnc;

            private DataColumn _columnPropostasNascCar;

            private DataColumn _columnPropostasNascBco;

            private DataColumn _columnPropostasWebBnc;

            private DataColumn _columnPropostasWebCar;

            private DataColumn _columnPropostasWebBco;

            private DataColumn _columnPropostasNascPyp;

            private DataColumn _columnPropostasWebPyp;

            private DataColumn _columnPropostasWebFin;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIDataTable()
            {
                TableName = "PROPOSTAS_I";
                BeginInit();
                InitClass();
                EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal PropostasIDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private PropostasIDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                    base(info, context)
            {
                InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn DataColumn
            {
                get
                {
                    return _columnData;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasColumn
            {
                get
                {
                    return _columnPropostas;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasNascColumn
            {
                get
                {
                    return _columnPropostasNasc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebColumn
            {
                get
                {
                    return _columnPropostasWeb;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasNascBncColumn
            {
                get
                {
                    return _columnPropostasNascBnc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasNascCarColumn
            {
                get
                {
                    return _columnPropostasNascCar;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasNascBcoColumn
            {
                get
                {
                    return _columnPropostasNascBco;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebBncColumn
            {
                get
                {
                    return _columnPropostasWebBnc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebCarColumn
            {
                get
                {
                    return _columnPropostasWebCar;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebBcoColumn
            {
                get
                {
                    return _columnPropostasWebBco;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasNascPypColumn
            {
                get
                {
                    return _columnPropostasNascPyp;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebPypColumn
            {
                get
                {
                    return _columnPropostasWebPyp;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn PropostasWebFinColumn
            {
                get
                {
                    return _columnPropostasWebFin;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIRow this[int index]
            {
                get
                {
                    return (PropostasIRow)Rows[index];
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event PropostasIRowChangeEventHandler PropostasIRowChanging;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event PropostasIRowChangeEventHandler PropostasIRowChanged;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event PropostasIRowChangeEventHandler PropostasIRowDeleting;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event PropostasIRowChangeEventHandler PropostasIRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void AddPROPOSTAS_IRow(PropostasIRow row)
            {
                Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIRow AddPROPOSTAS_IRow(string data, string propostas, string propostasNasc, string propostasWeb, string propostasNascBnc, string propostasNascCar, string propostasNascBco, string propostasWebBnc, string propostasWebCar, string propostasWebBco, string propostasNascPyp, string propostasWebPyp, string propostasWebFin)
            {
                PropostasIRow rowPropostasIRow = (PropostasIRow)NewRow();
                object[] columnValuesArray = new object[] {
                        data,
                        propostas,
                        propostasNasc,
                        propostasWeb,
                        propostasNascBnc,
                        propostasNascCar,
                        propostasNascBco,
                        propostasWebBnc,
                        propostasWebCar,
                        propostasWebBco,
                        propostasNascPyp,
                        propostasWebPyp,
                        propostasWebFin};
                rowPropostasIRow.ItemArray = columnValuesArray;
                Rows.Add(rowPropostasIRow);
                return rowPropostasIRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public override DataTable Clone()
            {
                PropostasIDataTable cln = (PropostasIDataTable)base.Clone();
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new PropostasIDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal void InitVars()
            {
                _columnData = Columns["DATA"];
                _columnPropostas = Columns["PROPOSTAS"];
                _columnPropostasNasc = Columns["PROPOSTAS_NASC"];
                _columnPropostasWeb = Columns["PROPOSTAS_WEB"];
                _columnPropostasNascBnc = Columns["PROPOSTAS_NASC_BNC"];
                _columnPropostasNascCar = Columns["PROPOSTAS_NASC_CAR"];
                _columnPropostasNascBco = Columns["PROPOSTAS_NASC_BCO"];
                _columnPropostasWebBnc = Columns["PROPOSTAS_WEB_BNC"];
                _columnPropostasWebCar = Columns["PROPOSTAS_WEB_CAR"];
                _columnPropostasWebBco = Columns["PROPOSTAS_WEB_BCO"];
                _columnPropostasNascPyp = Columns["PROPOSTAS_NASC_PYP"];
                _columnPropostasWebPyp = Columns["PROPOSTAS_WEB_PYP"];
                _columnPropostasWebFin = Columns["PROPOSTAS_WEB_FIN"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private void InitClass()
            {
                _columnData = new DataColumn("DATA", typeof(string), null, MappingType.Element);
                Columns.Add(_columnData);
                _columnPropostas = new DataColumn("PROPOSTAS", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostas);
                _columnPropostasNasc = new DataColumn("PROPOSTAS_NASC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasNasc);
                _columnPropostasWeb = new DataColumn("PROPOSTAS_WEB", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWeb);
                _columnPropostasNascBnc = new DataColumn("PROPOSTAS_NASC_BNC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasNascBnc);
                _columnPropostasNascCar = new DataColumn("PROPOSTAS_NASC_CAR", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasNascCar);
                _columnPropostasNascBco = new DataColumn("PROPOSTAS_NASC_BCO", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasNascBco);
                _columnPropostasWebBnc = new DataColumn("PROPOSTAS_WEB_BNC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWebBnc);
                _columnPropostasWebCar = new DataColumn("PROPOSTAS_WEB_CAR", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWebCar);
                _columnPropostasWebBco = new DataColumn("PROPOSTAS_WEB_BCO", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWebBco);
                _columnPropostasNascPyp = new DataColumn("PROPOSTAS_NASC_PYP", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasNascPyp);
                _columnPropostasWebPyp = new DataColumn("PROPOSTAS_WEB_PYP", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWebPyp);
                _columnPropostasWebFin = new DataColumn("PROPOSTAS_WEB_FIN", typeof(string), null, MappingType.Element);
                Columns.Add(_columnPropostasWebFin);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIRow NewPROPOSTAS_IRow()
            {
                return (PropostasIRow)NewRow();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PropostasIRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(PropostasIRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (PropostasIRowChanged != null)
                {
                    PropostasIRowChanged(this, new PropostasIRowChangeEvent((PropostasIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (PropostasIRowChanging != null)
                {
                    PropostasIRowChanging(this, new PropostasIRowChangeEvent((PropostasIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (PropostasIRowDeleted != null)
                {
                    PropostasIRowDeleted(this, new PropostasIRowChangeEvent((PropostasIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (PropostasIRowDeleting != null)
                {
                    PropostasIRowDeleting(this, new PropostasIRowChangeEvent((PropostasIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void RemovePROPOSTAS_IRow(PropostasIRow row)
            {
                Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                ExcelSet ds = new ExcelSet();
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
                attribute2.FixedValue = "PROPOSTAS_IDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema?.TargetNamespace))
                {
                    System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                    System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                    try
                    {
                        System.Xml.Schema.XmlSchema schema;
                        dsSchema?.Write(s1);
                        for (System.Collections.IEnumerator schemas = xs.Schemas(dsSchema?.TargetNamespace).GetEnumerator(); schemas.MoveNext();)
                        {
                            schema = (System.Xml.Schema.XmlSchema)schemas.Current;
                            s2.SetLength(0);
                            schema?.Write(s2);
                            if (s1.Length == s2.Length)
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; s1.Position != s1.Length
                                       && s1.ReadByte() == s2.ReadByte();)
                                {
                                }
                                if (s1.Position == s1.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        s1.Close();
                        s2.Close();
                    }
                }

                if (dsSchema != null)
                    xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public sealed class ApolicesIDataTable : TypedTableBase<ApolicesIRow>
        {

            private DataColumn _columnData;

            private DataColumn _columnApolices;

            private DataColumn _columnApolicesNasc;

            private DataColumn _columnApolicesWeb;

            private DataColumn _columnApolicesNascBnc;

            private DataColumn _columnApolicesNascCar;

            private DataColumn _columnApolicesNascBco;

            private DataColumn _columnApolicesNascPyp;

            private DataColumn _columnApolicesWebBnc;

            private DataColumn _columnApolicesWebCar;

            private DataColumn _columnApolicesWebBco;

            private DataColumn _columnApolicesWebPyp;

            private DataColumn _columnApolicesWebFin;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIDataTable()
            {
                TableName = "APOLICES_I";
                BeginInit();
                InitClass();
                EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal ApolicesIDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private ApolicesIDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                    base(info, context)
            {
                InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn DataColumn
            {
                get
                {
                    return _columnData;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesColumn
            {
                get
                {
                    return _columnApolices;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesNascColumn
            {
                get
                {
                    return _columnApolicesNasc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebColumn
            {
                get
                {
                    return _columnApolicesWeb;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesNascBncColumn
            {
                get
                {
                    return _columnApolicesNascBnc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesNascCarColumn
            {
                get
                {
                    return _columnApolicesNascCar;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesNascBcoColumn
            {
                get
                {
                    return _columnApolicesNascBco;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesNascPypColumn
            {
                get
                {
                    return _columnApolicesNascPyp;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebBncColumn
            {
                get
                {
                    return _columnApolicesWebBnc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebCarColumn
            {
                get
                {
                    return _columnApolicesWebCar;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebBcoColumn
            {
                get
                {
                    return _columnApolicesWebBco;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebPypColumn
            {
                get
                {
                    return _columnApolicesWebPyp;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn ApolicesWebFinColumn
            {
                get
                {
                    return _columnApolicesWebFin;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIRow this[int index]
            {
                get
                {
                    return (ApolicesIRow)Rows[index];
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event ApolicesIRowChangeEventHandler ApolicesIRowChanging;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event ApolicesIRowChangeEventHandler ApolicesIRowChanged;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event ApolicesIRowChangeEventHandler ApolicesIRowDeleting;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event ApolicesIRowChangeEventHandler ApolicesIRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void AddAPOLICES_IRow(ApolicesIRow row)
            {
                Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIRow AddAPOLICES_IRow(string data, string apolices, string apolicesNasc, string apolicesWeb, string apolicesNascBnc, string apolicesNascCar, string apolicesNascBco, string apolicesNascPyp, string apolicesWebBnc, string apolicesWebCar, string apolicesWebBco, string apolicesWebPyp, string apolicesWebFin)
            {
                ApolicesIRow rowApolicesIRow = (ApolicesIRow)NewRow();
                object[] columnValuesArray = new object[] {
                        data,
                        apolices,
                        apolicesNasc,
                        apolicesWeb,
                        apolicesNascBnc,
                        apolicesNascCar,
                        apolicesNascBco,
                        apolicesNascPyp,
                        apolicesWebBnc,
                        apolicesWebCar,
                        apolicesWebBco,
                        apolicesWebPyp,
                        apolicesWebFin};
                rowApolicesIRow.ItemArray = columnValuesArray;
                Rows.Add(rowApolicesIRow);
                return rowApolicesIRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public override DataTable Clone()
            {
                ApolicesIDataTable cln = (ApolicesIDataTable)base.Clone();
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new ApolicesIDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal void InitVars()
            {
                _columnData = Columns["DATA"];
                _columnApolices = Columns["APOLICES"];
                _columnApolicesNasc = Columns["APOLICES_NASC"];
                _columnApolicesWeb = Columns["APOLICES_WEB"];
                _columnApolicesNascBnc = Columns["APOLICES_NASC_BNC"];
                _columnApolicesNascCar = Columns["APOLICES_NASC_CAR"];
                _columnApolicesNascBco = Columns["APOLICES_NASC_BCO"];
                _columnApolicesNascPyp = Columns["APOLICES_NASC_PYP"];
                _columnApolicesWebBnc = Columns["APOLICES_WEB_BNC"];
                _columnApolicesWebCar = Columns["APOLICES_WEB_CAR"];
                _columnApolicesWebBco = Columns["APOLICES_WEB_BCO"];
                _columnApolicesWebPyp = Columns["APOLICES_WEB_PYP"];
                _columnApolicesWebFin = Columns["APOLICES_WEB_FIN"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private void InitClass()
            {
                _columnData = new DataColumn("DATA", typeof(string), null, MappingType.Element);
                Columns.Add(_columnData);
                _columnApolices = new DataColumn("APOLICES", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolices);
                _columnApolicesNasc = new DataColumn("APOLICES_NASC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesNasc);
                _columnApolicesWeb = new DataColumn("APOLICES_WEB", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWeb);
                _columnApolicesNascBnc = new DataColumn("APOLICES_NASC_BNC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesNascBnc);
                _columnApolicesNascCar = new DataColumn("APOLICES_NASC_CAR", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesNascCar);
                _columnApolicesNascBco = new DataColumn("APOLICES_NASC_BCO", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesNascBco);
                _columnApolicesNascPyp = new DataColumn("APOLICES_NASC_PYP", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesNascPyp);
                _columnApolicesWebBnc = new DataColumn("APOLICES_WEB_BNC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWebBnc);
                _columnApolicesWebCar = new DataColumn("APOLICES_WEB_CAR", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWebCar);
                _columnApolicesWebBco = new DataColumn("APOLICES_WEB_BCO", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWebBco);
                _columnApolicesWebPyp = new DataColumn("APOLICES_WEB_PYP", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWebPyp);
                _columnApolicesWebFin = new DataColumn("APOLICES_WEB_FIN", typeof(string), null, MappingType.Element);
                Columns.Add(_columnApolicesWebFin);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIRow NewAPOLICES_IRow()
            {
                return (ApolicesIRow)NewRow();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ApolicesIRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(ApolicesIRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (ApolicesIRowChanged != null)
                {
                    ApolicesIRowChanged(this, new ApolicesIRowChangeEvent((ApolicesIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (ApolicesIRowChanging != null)
                {
                    ApolicesIRowChanging(this, new ApolicesIRowChangeEvent((ApolicesIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (ApolicesIRowDeleted != null)
                {
                    ApolicesIRowDeleted(this, new ApolicesIRowChangeEvent((ApolicesIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (ApolicesIRowDeleting != null)
                {
                    ApolicesIRowDeleting(this, new ApolicesIRowChangeEvent((ApolicesIRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void RemoveAPOLICES_IRow(ApolicesIRow row)
            {
                Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                ExcelSet ds = new ExcelSet();
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
                attribute2.FixedValue = "APOLICES_IDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema?.TargetNamespace))
                {
                    System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                    System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                    try
                    {
                        System.Xml.Schema.XmlSchema schema;
                        dsSchema?.Write(s1);
                        for (System.Collections.IEnumerator schemas = xs.Schemas(dsSchema?.TargetNamespace).GetEnumerator(); schemas.MoveNext();)
                        {
                            schema = (System.Xml.Schema.XmlSchema)schemas.Current;
                            s2.SetLength(0);
                            schema?.Write(s2);
                            if (s1.Length == s2.Length)
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; s1.Position != s1.Length
                                       && s1.ReadByte() == s2.ReadByte();)
                                {
                                }
                                if (s1.Position == s1.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        s1.Close();
                        s2.Close();
                    }
                }

                if (dsSchema != null)
                    xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public sealed class TableDataTable : TypedTableBase<TableRow>
        {

            private DataColumn _columnData;

            private DataColumn _columnSimulacoes;

            private DataColumn _columnSimulacoesNasc;

            private DataColumn _columnSimulacoesWeb;

            private DataColumn _columnSimulacoesIsvap;

            private DataColumn _columnSimulacoesOneclick;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableDataTable()
            {
                TableName = "Table";
                BeginInit();
                InitClass();
                EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal TableDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private TableDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                    base(info, context)
            {
                InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn DataColumn
            {
                get
                {
                    return _columnData;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn SimulacoesColumn
            {
                get
                {
                    return _columnSimulacoes;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn SimulacoesNascColumn
            {
                get
                {
                    return _columnSimulacoesNasc;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn SimulacoesWebColumn
            {
                get
                {
                    return _columnSimulacoesWeb;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn SimulacoesIsvapColumn
            {
                get
                {
                    return _columnSimulacoesIsvap;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataColumn SimulacoesOneclickColumn
            {
                get
                {
                    return _columnSimulacoesOneclick;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableRow this[int index]
            {
                get
                {
                    return (TableRow)Rows[index];
                }
            }

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event TableRowChangeEventHandler TableRowChanging;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event TableRowChangeEventHandler TableRowChanged;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event TableRowChangeEventHandler TableRowDeleting;

            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public event TableRowChangeEventHandler TableRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void AddTableRow(TableRow row)
            {
                Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableRow AddTableRow(string data, string simulacoes, string simulacoesNasc, string simulacoesWeb, string simulacoesIsvap, string simulacoesOneclick)
            {
                TableRow rowTableRow = (TableRow)NewRow();
                object[] columnValuesArray = new object[] {
                        data,
                        simulacoes,
                        simulacoesNasc,
                        simulacoesWeb,
                        simulacoesIsvap,
                        simulacoesOneclick};
                rowTableRow.ItemArray = columnValuesArray;
                Rows.Add(rowTableRow);
                return rowTableRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public override DataTable Clone()
            {
                TableDataTable cln = (TableDataTable)base.Clone();
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new TableDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal void InitVars()
            {
                _columnData = Columns["DATA"];
                _columnSimulacoes = Columns["SIMULACOES"];
                _columnSimulacoesNasc = Columns["SIMULACOES_NASC"];
                _columnSimulacoesWeb = Columns["SIMULACOES_WEB"];
                _columnSimulacoesIsvap = Columns["SIMULACOES_ISVAP"];
                _columnSimulacoesOneclick = Columns["SIMULACOES_ONECLICK"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            private void InitClass()
            {
                _columnData = new DataColumn("DATA", typeof(string), null, MappingType.Element);
                Columns.Add(_columnData);
                _columnSimulacoes = new DataColumn("SIMULACOES", typeof(string), null, MappingType.Element);
                Columns.Add(_columnSimulacoes);
                _columnSimulacoesNasc = new DataColumn("SIMULACOES_NASC", typeof(string), null, MappingType.Element);
                Columns.Add(_columnSimulacoesNasc);
                _columnSimulacoesWeb = new DataColumn("SIMULACOES_WEB", typeof(string), null, MappingType.Element);
                Columns.Add(_columnSimulacoesWeb);
                _columnSimulacoesIsvap = new DataColumn("SIMULACOES_ISVAP", typeof(string), null, MappingType.Element);
                Columns.Add(_columnSimulacoesIsvap);
                _columnSimulacoesOneclick = new DataColumn("SIMULACOES_ONECLICK", typeof(string), null, MappingType.Element);
                Columns.Add(_columnSimulacoesOneclick);
                ExtendedProperties.Add("Generator_RowClassName", "TableRow");
                ExtendedProperties.Add("Generator_RowEvArgName", "TableRowChangeEvent");
                ExtendedProperties.Add("Generator_RowEvHandlerName", "TableRowChangeEventHandler");
                ExtendedProperties.Add("Generator_TableClassName", "TableDataTable");
                ExtendedProperties.Add("Generator_TablePropName", "Table");
                ExtendedProperties.Add("Generator_TableVarName", "tableTable");
                ExtendedProperties.Add("Generator_UserTableName", "Table");
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableRow NewTableRow()
            {
                return (TableRow)NewRow();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TableRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override System.Type GetRowType()
            {
                return typeof(TableRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (TableRowChanged != null)
                {
                    TableRowChanged(this, new TableRowChangeEvent((TableRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (TableRowChanging != null)
                {
                    TableRowChanging(this, new TableRowChangeEvent((TableRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (TableRowDeleted != null)
                {
                    TableRowDeleted(this, new TableRowChangeEvent((TableRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (TableRowDeleting != null)
                {
                    TableRowDeleting(this, new TableRowChangeEvent((TableRow)e.Row, e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void RemoveTableRow(TableRow row)
            {
                Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                ExcelSet ds = new ExcelSet();
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
                attribute2.FixedValue = "TableDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema?.TargetNamespace))
                {
                    System.IO.MemoryStream s1 = new System.IO.MemoryStream();
                    System.IO.MemoryStream s2 = new System.IO.MemoryStream();
                    try
                    {
                        System.Xml.Schema.XmlSchema schema;
                        dsSchema?.Write(s1);
                        for (System.Collections.IEnumerator schemas = xs.Schemas(dsSchema?.TargetNamespace).GetEnumerator(); schemas.MoveNext();)
                        {
                            schema = (System.Xml.Schema.XmlSchema)schemas.Current;
                            s2.SetLength(0);
                            schema?.Write(s2);
                            if (s1.Length == s2.Length)
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; s1.Position != s1.Length
                                       && s1.ReadByte() == s2.ReadByte();)
                                {
                                }
                                if (s1.Position == s1.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        s1.Close();
                        s2.Close();
                    }
                }

                if (dsSchema != null)
                    xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public class PropostasIRow : DataRow
        {

            private PropostasIDataTable _tablePropostasI;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal PropostasIRow(DataRowBuilder rb) :
                    base(rb)
            {
                _tablePropostasI = (PropostasIDataTable)Table;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Data
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.DataColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'DATA\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.DataColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Propostas
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasNasc
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasNascColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_NASC\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasNascColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWeb
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasNascBnc
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasNascBncColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_NASC_BNC\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasNascBncColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasNascCar
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasNascCarColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_NASC_CAR\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasNascCarColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasNascBco
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasNascBcoColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_NASC_BCO\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasNascBcoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWebBnc
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebBncColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB_BNC\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebBncColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWebCar
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebCarColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB_CAR\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebCarColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWebBco
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebBcoColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB_BCO\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebBcoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasNascPyp
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasNascPypColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_NASC_PYP\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasNascPypColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWebPyp
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebPypColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB_PYP\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebPypColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string PropostasWebFin
            {
                get
                {
                    try
                    {
                        return (string)this[_tablePropostasI.PropostasWebFinColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'PROPOSTAS_WEB_FIN\' in table \'PROPOSTAS_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tablePropostasI.PropostasWebFinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsDataNull()
            {
                return IsNull(_tablePropostasI.DataColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetDataNull()
            {
                this[_tablePropostasI.DataColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPropostasNull()
            {
                return IsNull(_tablePropostasI.PropostasColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPropostasNull()
            {
                this[_tablePropostasI.PropostasColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_NASCNull()
            {
                return IsNull(_tablePropostasI.PropostasNascColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_NASCNull()
            {
                this[_tablePropostasI.PropostasNascColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEBNull()
            {
                return IsNull(_tablePropostasI.PropostasWebColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEBNull()
            {
                this[_tablePropostasI.PropostasWebColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_NASC_BNCNull()
            {
                return IsNull(_tablePropostasI.PropostasNascBncColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_NASC_BNCNull()
            {
                this[_tablePropostasI.PropostasNascBncColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_NASC_CARNull()
            {
                return IsNull(_tablePropostasI.PropostasNascCarColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_NASC_CARNull()
            {
                this[_tablePropostasI.PropostasNascCarColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_NASC_BCONull()
            {
                return IsNull(_tablePropostasI.PropostasNascBcoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_NASC_BCONull()
            {
                this[_tablePropostasI.PropostasNascBcoColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEB_BNCNull()
            {
                return IsNull(_tablePropostasI.PropostasWebBncColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEB_BNCNull()
            {
                this[_tablePropostasI.PropostasWebBncColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEB_CARNull()
            {
                return IsNull(_tablePropostasI.PropostasWebCarColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEB_CARNull()
            {
                this[_tablePropostasI.PropostasWebCarColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEB_BCONull()
            {
                return IsNull(_tablePropostasI.PropostasWebBcoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEB_BCONull()
            {
                this[_tablePropostasI.PropostasWebBcoColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_NASC_PYPNull()
            {
                return IsNull(_tablePropostasI.PropostasNascPypColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_NASC_PYPNull()
            {
                this[_tablePropostasI.PropostasNascPypColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEB_PYPNull()
            {
                return IsNull(_tablePropostasI.PropostasWebPypColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEB_PYPNull()
            {
                this[_tablePropostasI.PropostasWebPypColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsPROPOSTAS_WEB_FINNull()
            {
                return IsNull(_tablePropostasI.PropostasWebFinColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetPROPOSTAS_WEB_FINNull()
            {
                this[_tablePropostasI.PropostasWebFinColumn] = System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public class ApolicesIRow : DataRow
        {

            private ApolicesIDataTable _tableApolicesI;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal ApolicesIRow(DataRowBuilder rb) :
                    base(rb)
            {
                _tableApolicesI = (ApolicesIDataTable)Table;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Data
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.DataColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'DATA\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.DataColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Apolices
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesNasc
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesNascColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_NASC\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesNascColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWeb
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesNascBnc
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesNascBncColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_NASC_BNC\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesNascBncColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesNascCar
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesNascCarColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_NASC_CAR\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesNascCarColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesNascBco
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesNascBcoColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_NASC_BCO\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesNascBcoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesNascPyp
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesNascPypColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_NASC_PYP\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesNascPypColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWebBnc
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebBncColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB_BNC\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebBncColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWebCar
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebCarColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB_CAR\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebCarColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWebBco
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebBcoColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB_BCO\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebBcoColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWebPyp
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebPypColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB_PYP\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebPypColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string ApolicesWebFin
            {
                get
                {
                    try
                    {
                        return (string)this[_tableApolicesI.ApolicesWebFinColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'APOLICES_WEB_FIN\' in table \'APOLICES_I\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableApolicesI.ApolicesWebFinColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsDataNull()
            {
                return IsNull(_tableApolicesI.DataColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetDataNull()
            {
                this[_tableApolicesI.DataColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsApolicesNull()
            {
                return IsNull(_tableApolicesI.ApolicesColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetApolicesNull()
            {
                this[_tableApolicesI.ApolicesColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_NASCNull()
            {
                return IsNull(_tableApolicesI.ApolicesNascColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_NASCNull()
            {
                this[_tableApolicesI.ApolicesNascColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEBNull()
            {
                return IsNull(_tableApolicesI.ApolicesWebColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEBNull()
            {
                this[_tableApolicesI.ApolicesWebColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_NASC_BNCNull()
            {
                return IsNull(_tableApolicesI.ApolicesNascBncColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_NASC_BNCNull()
            {
                this[_tableApolicesI.ApolicesNascBncColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_NASC_CARNull()
            {
                return IsNull(_tableApolicesI.ApolicesNascCarColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_NASC_CARNull()
            {
                this[_tableApolicesI.ApolicesNascCarColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_NASC_BCONull()
            {
                return IsNull(_tableApolicesI.ApolicesNascBcoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_NASC_BCONull()
            {
                this[_tableApolicesI.ApolicesNascBcoColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_NASC_PYPNull()
            {
                return IsNull(_tableApolicesI.ApolicesNascPypColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_NASC_PYPNull()
            {
                this[_tableApolicesI.ApolicesNascPypColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEB_BNCNull()
            {
                return IsNull(_tableApolicesI.ApolicesWebBncColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEB_BNCNull()
            {
                this[_tableApolicesI.ApolicesWebBncColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEB_CARNull()
            {
                return IsNull(_tableApolicesI.ApolicesWebCarColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEB_CARNull()
            {
                this[_tableApolicesI.ApolicesWebCarColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEB_BCONull()
            {
                return IsNull(_tableApolicesI.ApolicesWebBcoColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEB_BCONull()
            {
                this[_tableApolicesI.ApolicesWebBcoColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEB_PYPNull()
            {
                return IsNull(_tableApolicesI.ApolicesWebPypColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEB_PYPNull()
            {
                this[_tableApolicesI.ApolicesWebPypColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsAPOLICES_WEB_FINNull()
            {
                return IsNull(_tableApolicesI.ApolicesWebFinColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetAPOLICES_WEB_FINNull()
            {
                this[_tableApolicesI.ApolicesWebFinColumn] = System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public class TableRow : DataRow
        {

            private TableDataTable _tableTable;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            internal TableRow(DataRowBuilder rb) :
                    base(rb)
            {
                _tableTable = (TableDataTable)Table;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Data
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.DataColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'DATA\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.DataColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string Simulacoes
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.SimulacoesColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'SIMULACOES\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.SimulacoesColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string SimulacoesNasc
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.SimulacoesNascColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'SIMULACOES_NASC\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.SimulacoesNascColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string SimulacoesWeb
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.SimulacoesWebColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'SIMULACOES_WEB\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.SimulacoesWebColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string SimulacoesIsvap
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.SimulacoesIsvapColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'SIMULACOES_ISVAP\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.SimulacoesIsvapColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public string SimulacoesOneclick
            {
                get
                {
                    try
                    {
                        return (string)this[_tableTable.SimulacoesOneclickColumn];
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new StrongTypingException("The value for column \'SIMULACOES_ONECLICK\' in table \'Table\' is DBNull.", e);
                    }
                }
                set
                {
                    this[_tableTable.SimulacoesOneclickColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsDataNull()
            {
                return IsNull(_tableTable.DataColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetDataNull()
            {
                this[_tableTable.DataColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsSimulacoesNull()
            {
                return IsNull(_tableTable.SimulacoesColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetSimulacoesNull()
            {
                this[_tableTable.SimulacoesColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsSIMULACOES_NASCNull()
            {
                return IsNull(_tableTable.SimulacoesNascColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetSIMULACOES_NASCNull()
            {
                this[_tableTable.SimulacoesNascColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsSIMULACOES_WEBNull()
            {
                return IsNull(_tableTable.SimulacoesWebColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetSIMULACOES_WEBNull()
            {
                this[_tableTable.SimulacoesWebColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsSIMULACOES_ISVAPNull()
            {
                return IsNull(_tableTable.SimulacoesIsvapColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetSIMULACOES_ISVAPNull()
            {
                this[_tableTable.SimulacoesIsvapColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public bool IsSIMULACOES_ONECLICKNull()
            {
                return IsNull(_tableTable.SimulacoesOneclickColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public void SetSIMULACOES_ONECLICKNull()
            {
                this[_tableTable.SimulacoesOneclickColumn] = System.Convert.DBNull;
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public class PropostasIRowChangeEvent : System.EventArgs
        {

            private PropostasIRow _eventRow;

            private DataRowAction _eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIRowChangeEvent(PropostasIRow row, DataRowAction action)
            {
                _eventRow = row;
                _eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public PropostasIRow Row
            {
                get
                {
                    return _eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return _eventAction;
                }
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public class ApolicesIRowChangeEvent : System.EventArgs
        {

            private ApolicesIRow _eventRow;

            private DataRowAction _eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIRowChangeEvent(ApolicesIRow row, DataRowAction action)
            {
                _eventRow = row;
                _eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public ApolicesIRow Row
            {
                get
                {
                    return _eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return _eventAction;
                }
            }
        }

        /// <summary>
        ///Row event argument class
        ///</summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
        public class TableRowChangeEvent : System.EventArgs
        {

            private TableRow _eventRow;

            private DataRowAction _eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableRowChangeEvent(TableRow row, DataRowAction action)
            {
                _eventRow = row;
                _eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public TableRow Row
            {
                get
                {
                    return _eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "15.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return _eventAction;
                }
            }
        }
    }
}