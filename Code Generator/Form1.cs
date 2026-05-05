using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Code_Generator
{
    public partial class frmCodeGenerator : Form
    {
        private List<clsColumn> _columns = new List<clsColumn>();

        private string _businessCode = "";
        private string _dataAccessCode = "";

        public frmCodeGenerator()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void AddAllDataTypesToComboBox()
        {
            string[] dataTypes = {
               "int", "bigint", "smallint", "tinyint",
               "bit",
               "decimal", "numeric", "float", "real",
               "date", "datetime", "datetime2", "smalldatetime", "time",
               "char", "varchar", "text",
               "nchar", "nvarchar", "ntext",
               "uniqueidentifier"
            };

            cmbDataType.Items.AddRange(dataTypes);
            cmbDataType.SelectedIndex = 0; // default selection
        }
        private void frmCodeGenerator_Load(object sender, EventArgs e)
        {
            AddAllDataTypesToComboBox();

            txtTableName.Focus();
        }


        private void RefreshGrid()
        {
            dgvTableInfo.Rows.Clear();

            foreach (var col in _columns)
            {
                dgvTableInfo.Rows.Add(
                    col.ColumnName,
                    col.DataType,
                    col.IsNull,
                    col.IsPrimaryKey
                );
            }

            lblRecordsCount.Text = dgvTableInfo.Rows.Count.ToString();
        }
        private bool ValidationForAddingColumn()
        {
            //If column name is empty
            if (string.IsNullOrWhiteSpace(txtColumnName.Text.Trim()))
            {
                MessageBox.Show("You have to fill the column name", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }


            //PK Should Be Not Allowed Null
            if (chkPK.Checked && chkNull.Checked)
            {
                MessageBox.Show("PK Should Be Not Allowed Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }


            //Prevent Duplicate Column Names
            if (_columns.Any(c => c.ColumnName.ToLower() == txtColumnName.Text.Trim().ToLower()))
            {
                MessageBox.Show("Column already exists!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }


            //Only one Primary Key is allowed!
            if (chkPK.Checked && _columns.Any(c => c.IsPrimaryKey))
            {
                MessageBox.Show("Only one Primary Key is allowed!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;

        }
        private void ResetTheItemsAfterAdding()
        {
            txtColumnName.Text = "";
            cmbDataType.SelectedIndex = 0;
            chkNull.Checked = false;
            chkPK.Checked = false;

            txtColumnName.Focus();
        }
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (ValidationForAddingColumn())
                return;

            string columnName = txtColumnName.Text.Trim();
            string DataType = cmbDataType.Text;
            bool IsNull = chkNull.Checked;
            bool IsPrimaryKey = chkPK.Checked;


            clsColumn column = new clsColumn
            {
                ColumnName = columnName,
                DataType = DataType,
                IsNull = IsNull,
                IsPrimaryKey = IsPrimaryKey
            };

            _columns.Add(column);

            //Make PK Always First in DataGridView
            if (column.IsPrimaryKey)
            {
                //Where does the previous first row go?
                //It automatically shifts to index 1

                _columns.Remove(column);
                _columns.Insert(0, column);
                RefreshGrid();
            }
            else
            {
                dgvTableInfo.Rows.Add(columnName, DataType, IsNull, IsPrimaryKey);

                lblRecordsCount.Text = _columns.Count.ToString();
            }
           

            ResetTheItemsAfterAdding();
        }


        private void tsmDeletePatient_Click(object sender, EventArgs e)
        {
            int index = dgvTableInfo.CurrentRow.Index;

            _columns.RemoveAt(index);
            dgvTableInfo.Rows.RemoveAt(index);

            lblRecordsCount.Text = _columns.Count.ToString();
        }


        private string ConvertToCSharpType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                // Integers
                case "int": return "int";
                case "bigint": return "long";
                case "smallint": return "short";
                case "tinyint": return "byte";

                // Boolean
                case "bit": return "bool";

                // Decimal / Floating
                case "decimal":
                case "numeric": return "decimal";
                case "float": return "double";
                case "real": return "float";

                // Date & Time
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    return "DateTime";
                case "time":
                    return "TimeSpan";

                // Strings
                case "char":
                case "varchar":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                    return "string";

                // Special
                case "uniqueidentifier":
                    return "Guid";

                default:
                    return "string";
            }
        }
        private string GetDefaultValue(string type)
        {
            string defaultValue = "";

            if (type == "int" || type == "long")
                defaultValue = "-1";
            else if (type == "string")
                defaultValue = "\"\"";
            else if (type == "DateTime")
                defaultValue = "DateTime.Now";
            else if (type == "bool")
                defaultValue = "false";
            else
                defaultValue = "0";


            return defaultValue;
        }
        private string GenerateBusinessLayerCode()
        {
            StringBuilder sb = new StringBuilder();
            var pk = _columns.First(c => c.IsPrimaryKey); // Data for the PK row

            //Namespace + Class
            string className1 = "cls" + txtTableSingleName.Text.Trim(); // class of Business Layer
            string namespaceName = txtBusinessLayerName.Text.Trim();
            string DataAccessName = txtDataAcsessLayerName.Text.Trim();
            string dataAccessClass = "cls" + txtTableSingleName.Text.Trim() + "DataAccess"; // class of Data Access Layer

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine($"using {DataAccessName};");

            sb.AppendLine();

            sb.AppendLine($"namespace {namespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {className1}");
            sb.AppendLine("    {");
            sb.AppendLine();




            //Generate Properties Dynamically
            sb.AppendLine("        public enum enMode { AddMode, UpdateMode }");
            sb.AppendLine("        private enMode Mode;");
            sb.AppendLine();

            foreach (var col in _columns)
            {
                string type = ConvertToCSharpType(col.DataType);

                //If column allows null,  Why not string? Because string is already nullable
                if (col.IsNull && type != "string")
                {
                    type += "?";
                }

                sb.AppendLine($"        public {type} {col.ColumnName} {{ get; set; }}");
            }
            sb.AppendLine();




            //Generate Constructors
            sb.AppendLine($"        public {className1}()");
            sb.AppendLine("        {");

            foreach (var col in _columns)
            {
                string type = ConvertToCSharpType(col.DataType);
                string defaultValue = GetDefaultValue(type);

                sb.AppendLine($"            this.{col.ColumnName} = {defaultValue};");
            }

            sb.AppendLine("            Mode = enMode.AddMode;");
            sb.AppendLine("        }");
            sb.AppendLine();




            string parameters = string.Join(", ",  _columns.Select(col =>
                 $"{ConvertToCSharpType(col.DataType)} {col.ColumnName}"
            ));
            sb.AppendLine($"        private {className1}({parameters})");
            sb.AppendLine("        {");

            foreach (var col in _columns)
            {
                sb.AppendLine($"            this.{col.ColumnName} = {col.ColumnName};");
            }

            sb.AppendLine("            Mode = enMode.UpdateMode;");
            sb.AppendLine("        }");
            sb.AppendLine();




            //Generate Find
            //Contain PK items
            sb.AppendLine($"        public static {className1} Find({ConvertToCSharpType(pk.DataType)} {pk.ColumnName})");
            sb.AppendLine("        {");

            foreach (var col in _columns.Where(c => !c.IsPrimaryKey))
            {
                string type = ConvertToCSharpType(col.DataType);
                string defaultValue = GetDefaultValue(type);

                sb.AppendLine($"            {type} {col.ColumnName} = {defaultValue};");
            }
            sb.AppendLine();


            string refParams = string.Join(",\n                ",
                _columns.Where(c => !c.IsPrimaryKey).Select(c => $"ref {c.ColumnName}"));

            sb.AppendLine();
            sb.AppendLine($"            bool IsFound = {dataAccessClass}.Get{txtTableSingleName.Text}InfoByID(");
            sb.AppendLine($"                {pk.ColumnName},");
            sb.AppendLine($"                {refParams}");
            sb.AppendLine("            );");


            string constructorParams = string.Join(", ", _columns.Select(c => c.ColumnName));

            sb.AppendLine();
            sb.AppendLine("            if (IsFound)");
            sb.AppendLine($"                return new {className1}({constructorParams});");
            sb.AppendLine("            else");
            sb.AppendLine("                return null;");

            sb.AppendLine("        }");
            sb.AppendLine();




            //AddNew
            sb.AppendLine($"        private bool _AddNew{txtTableSingleName.Text}()");
            sb.AppendLine("        {");

            string thisParams = string.Join(",\n                ",
                _columns.Where(c => !c.IsPrimaryKey).Select(c => $"this.{c.ColumnName}"));

            sb.AppendLine();
            sb.AppendLine($"            this.{pk.ColumnName} = {dataAccessClass}.AddNew{txtTableSingleName.Text}({thisParams});");
            sb.AppendLine($"             return(this.{pk.ColumnName} != -1);");

            sb.AppendLine("        }");
            sb.AppendLine();




            //Update
            sb.AppendLine($"        private bool _Update{txtTableSingleName.Text}()");
            sb.AppendLine("        {");

            string thisParamsWithPK = string.Join(",\n                ",
                _columns.Select(c => $"this.{c.ColumnName}"));

            sb.AppendLine();
            sb.AppendLine($"            return {dataAccessClass}.Update{txtTableSingleName.Text}({thisParamsWithPK});");

            sb.AppendLine("        }");
            sb.AppendLine();




            //Save
            sb.AppendLine("        public bool Save()");
            sb.AppendLine("        {");

            sb.AppendLine("            switch (Mode)");
            sb.AppendLine("            {");

            sb.AppendLine("                case enMode.AddMode:");
            sb.AppendLine($"                    if (_AddNew{txtTableSingleName.Text}())");
            sb.AppendLine("                    {");
            sb.AppendLine("                        Mode = enMode.UpdateMode;");
            sb.AppendLine("                        return true;");
            sb.AppendLine("                    }");
            sb.AppendLine("                    else");
            sb.AppendLine("                        return false;");

            sb.AppendLine();

            sb.AppendLine("                case enMode.UpdateMode:");
            sb.AppendLine($"                    return _Update{txtTableSingleName.Text}();");

            sb.AppendLine("            }");

            sb.AppendLine("            return false;");
            sb.AppendLine("        }");
            sb.AppendLine();




            //Delete
            string pkType = ConvertToCSharpType(pk.DataType);
            string pkName = pk.ColumnName;

            sb.AppendLine($"        public static bool Delete{txtTableSingleName.Text}({pkType} {pkName})");
            sb.AppendLine("        {");
            sb.AppendLine($"            return {dataAccessClass}.Delete{txtTableSingleName.Text}({pkName});");
            sb.AppendLine("        }");
            sb.AppendLine();



            //Generate GetAll
            sb.AppendLine($"        public static DataTable GetAll{txtTableName.Text}()");
            sb.AppendLine("        {");
            sb.AppendLine($"            return {dataAccessClass}.GetAll{txtTableName.Text}();");
            sb.AppendLine("        }");
            sb.AppendLine();










            //Closing the Business Layer 
            sb.AppendLine("    }");
            sb.AppendLine("}");

            

            return sb.ToString();

        }
        private string GenerateDataAccessLayerCode()
        {


            StringBuilder sb = new StringBuilder();
            var pk = _columns.First(c => c.IsPrimaryKey); // Data for the PK row

            //Namespace + Class
            string TableSingleName = txtTableSingleName.Text;
            string TableName = txtTableName.Text;
            string className1 = "cls" + txtTableSingleName.Text.Trim(); // class of Business Layer
            string namespaceName = txtDataAcsessLayerName.Text.Trim();
            string dataAccessClass = "cls" + txtTableSingleName.Text.Trim() + "DataAccess"; // class of Data Access Layer

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");

            sb.AppendLine();

            sb.AppendLine($"namespace {namespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {dataAccessClass}");
            sb.AppendLine("    {");
            sb.AppendLine();





            //Get Info By ID Method
            string parameters = string.Join(",\n                ",
                _columns.Where(c => !c.IsPrimaryKey).Select(c => $"ref {ConvertToCSharpType(c.DataType)} {c.ColumnName}"));

            sb.AppendLine($"        public static bool Get{TableSingleName}InfoByID({ConvertToCSharpType(pk.DataType)} {pk.ColumnName}, {parameters})");
            sb.AppendLine("        {");

            sb.AppendLine("            bool isFound = false;");
            sb.AppendLine();

            sb.AppendLine("            try");
            sb.AppendLine("            {");

            sb.AppendLine("                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))");
            sb.AppendLine("                {");

            sb.AppendLine("                    connection.Open();");
            sb.AppendLine();

            sb.AppendLine($"                    string query = \"SELECT * FROM {TableName} WHERE {pk.ColumnName} = @{pk.ColumnName}\";");
            sb.AppendLine();

            sb.AppendLine("                    using (SqlCommand command = new SqlCommand(query, connection))");
            sb.AppendLine("                    {");

            sb.AppendLine($"                        command.Parameters.AddWithValue(\"@{pk.ColumnName}\", {pk.ColumnName});");
            sb.AppendLine();

            sb.AppendLine("                        using (SqlDataReader reader = command.ExecuteReader())");
            sb.AppendLine("                        {");

            sb.AppendLine("                            if (reader.Read())");
            sb.AppendLine("                            {");

            sb.AppendLine("                                isFound = true;");

            foreach (var col in _columns.Where(c => !c.IsPrimaryKey))
            {
                string name = col.ColumnName;
                string type = ConvertToCSharpType(col.DataType);

                if (col.IsNull && type == "string")
                {
                    sb.AppendLine($"                                if (reader[\"{name}\"] != DBNull.Value)");
                    sb.AppendLine($"                                    {name} = ({type})reader[\"{name}\"];");
                    sb.AppendLine($"                                else");
                    sb.AppendLine($"                                    {name} = \"\";");
                }
                else if (col.IsNull)
                {
                    sb.AppendLine($"                                if (reader[\"{name}\"] != DBNull.Value)");
                    sb.AppendLine($"                                    {name} = ({type})reader[\"{name}\"];");
                }
                else
                {
                    sb.AppendLine($"                                {name} = ({type})reader[\"{name}\"];");
                }

                sb.AppendLine();
            }

            sb.AppendLine("                            }");
            sb.AppendLine("                        }");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                isFound = false;");
            sb.AppendLine("            }");

            sb.AppendLine();
            sb.AppendLine("            return isFound;");
            sb.AppendLine("        }");




            //Add Method
            var nonPK = _columns.Where(c => !c.IsPrimaryKey).ToList();

            string parameters1 = string.Join(", ",
                nonPK.Select(c => $"{ConvertToCSharpType(c.DataType)} {c.ColumnName}")
            );

            sb.AppendLine($"        public static int AddNew{txtTableSingleName.Text}({parameters1})");
            sb.AppendLine("        {");
            sb.AppendLine("            int NewID = -1;");
            sb.AppendLine();

            string columnsNames = string.Join(", ", nonPK.Select(c => c.ColumnName));
            string paramNames = string.Join(", ", nonPK.Select(c => "@" + c.ColumnName));

            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");

            sb.AppendLine();
            sb.AppendLine($"                    string query = @\"INSERT INTO {txtTableName.Text} ({columnsNames})");
            sb.AppendLine($"                                     VALUES ({paramNames});");
            sb.AppendLine($"                                     SELECT SCOPE_IDENTITY();\";");

            sb.AppendLine();
            sb.AppendLine("                    using (SqlCommand command = new SqlCommand(query, connection))");
            sb.AppendLine("                    {");

            foreach (var col in nonPK)
            {
                if (col.IsNull)
                {
                    sb.AppendLine($"                        if ({col.ColumnName} != null && {col.ColumnName}.ToString() != \"\")");
                    sb.AppendLine($"                            command.Parameters.AddWithValue(\"@{col.ColumnName}\", {col.ColumnName});");
                    sb.AppendLine("                        else");
                    sb.AppendLine($"                            command.Parameters.AddWithValue(\"@{col.ColumnName}\", DBNull.Value);");
                }
                else
                {
                    sb.AppendLine($"                        command.Parameters.AddWithValue(\"@{col.ColumnName}\", {col.ColumnName});");
                }

                sb.AppendLine();
            }

            sb.AppendLine("                        object result = command.ExecuteScalar();");
            sb.AppendLine();
            sb.AppendLine("                        if (result != null && int.TryParse(result.ToString(), out int insertedID))");
            sb.AppendLine("                        {");
            sb.AppendLine("                            NewID = insertedID;");
            sb.AppendLine("                        }");

            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("            }");

            sb.AppendLine();
            sb.AppendLine("            return NewID;");
            sb.AppendLine("        }");
            sb.AppendLine();




            //Update Method
            string parameters3 = string.Join(", ",
            _columns.Select(c => $"{ConvertToCSharpType(c.DataType)} {c.ColumnName}")
            );

            sb.AppendLine($"        public static bool Update{txtTableSingleName.Text}({parameters3})");
            sb.AppendLine("        {");
            sb.AppendLine("            int rowsAffected = 0;");
            sb.AppendLine();

            string setClause = string.Join(",\n                                ",
                _columns.Where(c => !c.IsPrimaryKey)
                        .Select(c => $"{c.ColumnName} = @{c.ColumnName}")
            );

            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");

            sb.AppendLine();
            sb.AppendLine($"                    string query = @\"UPDATE {txtTableName.Text}");
            sb.AppendLine($"                                SET {setClause}");
            sb.AppendLine($"                                WHERE {pk.ColumnName} = @{pk.ColumnName}\";");

            sb.AppendLine();
            sb.AppendLine("                    using (SqlCommand command = new SqlCommand(query, connection))");
            sb.AppendLine("                    {");

            foreach (var col in _columns)
            {
                if (col.IsNull)
                {
                    sb.AppendLine($"                        if ({col.ColumnName} != null && {col.ColumnName}.ToString() != \"\")");
                    sb.AppendLine($"                            command.Parameters.AddWithValue(\"@{col.ColumnName}\", {col.ColumnName});");
                    sb.AppendLine("                        else");
                    sb.AppendLine($"                            command.Parameters.AddWithValue(\"@{col.ColumnName}\", DBNull.Value);");
                }
                else
                {
                    sb.AppendLine($"                        command.Parameters.AddWithValue(\"@{col.ColumnName}\", {col.ColumnName});");
                }

                sb.AppendLine();
            }

            sb.AppendLine("                        rowsAffected = command.ExecuteNonQuery();");

            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                return false;");
            sb.AppendLine("            }");

            sb.AppendLine();
            sb.AppendLine("            return (rowsAffected > 0);");
            sb.AppendLine("        }");
            sb.AppendLine();




            //Delete Method
            sb.AppendLine($"        public static bool Delete{txtTableSingleName.Text}({ConvertToCSharpType(pk.DataType)} {pk.ColumnName})");
            sb.AppendLine("        {");
            sb.AppendLine("            int rowsAffected = 0;");
            sb.AppendLine();

            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");

            sb.AppendLine();
            sb.AppendLine($"                    string query = @\"DELETE FROM {txtTableName.Text}");
            sb.AppendLine($"                                WHERE {pk.ColumnName} = @{pk.ColumnName}\";");

            sb.AppendLine();
            sb.AppendLine("                    using (SqlCommand command = new SqlCommand(query, connection))");
            sb.AppendLine("                    {");

            sb.AppendLine($"                        command.Parameters.AddWithValue(\"@{pk.ColumnName}\", {pk.ColumnName});");              
            sb.AppendLine();
            
            sb.AppendLine("                        rowsAffected = command.ExecuteNonQuery();");

            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                return false;");
            sb.AppendLine("            }");

            sb.AppendLine();
            sb.AppendLine("            return (rowsAffected > 0);");
            sb.AppendLine("        }");
            sb.AppendLine();




            //GetAll Method
            sb.AppendLine($"        public static DataTable GetAll{txtTableName.Text}()");
            sb.AppendLine("        {");
            sb.AppendLine("            DataTable dt = new DataTable();");
            sb.AppendLine();

            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))");
            sb.AppendLine("                {");
            sb.AppendLine("                    connection.Open();");

            sb.AppendLine();
            sb.AppendLine($"                    string query = @\"SELECT * FROM {txtTableName.Text}\";");

            sb.AppendLine();
            sb.AppendLine("                    using (SqlCommand command = new SqlCommand(query, connection))");
            sb.AppendLine("                    {");

            sb.AppendLine("                        using (SqlDataReader reader = command.ExecuteReader())");
            sb.AppendLine("                        {");

            sb.AppendLine("                            if (reader.HasRows)");
            sb.AppendLine("                            {");
            sb.AppendLine("                                dt.Load(reader);");
            sb.AppendLine("                            }");
            sb.AppendLine("                        }");

            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception)");
            sb.AppendLine("            {");
            sb.AppendLine("                // log or handle error");
            sb.AppendLine("            }");

            sb.AppendLine();
            sb.AppendLine("            return dt;");
            sb.AppendLine("        }");
            sb.AppendLine();




            //Closing the Data Access Layer 
            sb.AppendLine("    }");
            sb.AppendLine("}");


            return sb.ToString();
        }

        //Validation
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Table Name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTableSingleName.Text))
            {
                MessageBox.Show("Single Name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBusinessLayerName.Text))
            {
                MessageBox.Show("Business Layer Name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDataAcsessLayerName.Text))
            {
                MessageBox.Show("Data Access Layer Name is required", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_columns.Count == 0)
            {
                MessageBox.Show("You must add at least one column", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        //Create Generate
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            //Primary Key exists
            if (!_columns.Any(c => c.IsPrimaryKey))
            {
                MessageBox.Show("Primary Key Is Not Exist", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _businessCode = GenerateBusinessLayerCode();
            _dataAccessCode = GenerateDataAccessLayerCode();

            // Default view (optional)
            rtbCodeAsOutput.Text = _businessCode;

        }

        private void btnBusinessLayer_Click(object sender, EventArgs e)
        {
            rtbCodeAsOutput.Text = _businessCode;

        }
        private void tbnDataAccessLayer_Click(object sender, EventArgs e)
        {
            rtbCodeAsOutput.Text = _dataAccessCode;

        }


        //Improvements
        private void btnCopy_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(rtbCodeAsOutput.Text))
            {
                MessageBox.Show("There is no code to copy.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Clipboard.SetText(rtbCodeAsOutput.Text);

            MessageBox.Show("Copied successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Movements
        private void txtTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtTableSingleName.Focus();
        }
        private void txtTableSingleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtBusinessLayerName.Focus();
        }
        private void txtBusinessLayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtDataAcsessLayerName.Focus();
        }
        private void txtDataAccessLayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                txtColumnName.Focus();

        }
        private void txtColumnName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                cmbDataType.Focus();

        }



    }
}
