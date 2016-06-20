using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

namespace OfflineScrubber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.LoadExcelInMemory = new System.ComponentModel.BackgroundWorker();
            LoadExcelInMemory.WorkerSupportsCancellation = false;
            LoadExcelInMemory.DoWork += new System.ComponentModel.DoWorkEventHandler(loadFile);


        }
        private System.ComponentModel.BackgroundWorker LoadExcelInMemory;
        public DataSet whole_excel = new DataSet();
        public DataTable dta = new DataTable();
        public string filePath = "";

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            comboBox_sheet.Visible = false;
            comboBox_type.Visible = false;
            loadingBar.Visible = false;
            sheet_and_type.Visible = false;
            filename_holder.Visible = false;
            Refresh_btn.Visible = false;
            Reload_btn.Visible = false;
            Export_btn.Visible = false;


            this.comboBox_sheet.SelectedIndexChanged +=
            new System.EventHandler(setData);

            this.comboBox_type.SelectedIndexChanged +=
            new System.EventHandler(setData);
        }

        public void Reload_btn_Click(object sender, EventArgs e)
        {
            //  loadFile();
            this.LoadExcelInMemory.RunWorkerAsync(2000);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user
            {
                filePath = file.FileName; //get the path of the file
                //  loadFile();
                this.LoadExcelInMemory.RunWorkerAsync(2000);
            }
        }


        void LoadFinished(object sender, EventArgs ea)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(LoadFinished), sender, ea);
                return;
            }


            if (whole_excel.Tables.Count < 2) throw new Exception("Worksheet is not in expected format.");

            // Add names to combolist
            foreach (DataTable dts in whole_excel.Tables)
            {
                comboBox_sheet.Items.Add(dts.TableName.Replace("$", ""));
            }

            comboBox_type.SelectedIndex = 0;
            comboBox_sheet.SelectedIndex = 0;
            comboBox_sheet.Visible = true;
            comboBox_type.Visible = true;
            dataGridView1.Visible = true;
            loadingBar.Visible = false;
            sheet_and_type.Visible = true;
            filename_holder.Visible = true;
            Refresh_btn.Visible = true;
            Reload_btn.Visible = true;
            Export_btn.Visible = true;


            filename_holder.Text = Path.GetFileName(filePath);

            this.Refresh();

            if (whole_excel.Tables["filter$"] == null)
                MessageBox.Show("Data Imported Successfully But Filter sheet not found!");
            else
                MessageBox.Show("Data Imported Successfully!");

            FlashWindow.Flash(this);


        }

        void LoadStarting(object sender, EventArgs ea)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(LoadStarting), sender, ea);
                return;
            }

            comboBox_sheet.Items.Clear();
            comboBox_sheet.Visible = false;
            comboBox_type.Visible = false;
            dataGridView1.Visible = false;
            loadingBar.Visible = true;
            sheet_and_type.Visible = false;
            filename_holder.Visible = false;
            Refresh_btn.Visible = false;
            Reload_btn.Visible = false;
            Export_btn.Visible = false;
            sheet_and_type.Text = "";
            filename_holder.Text = "";
            this.Refresh();

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            setData(sender, e);
        }
        public void loadFile(object sender, DoWorkEventArgs e)
        {
            string fileExt = Path.GetExtension(filePath);//get the file extension
            if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
            {
                try
                {
                    this.LoadStarting(sender, e);

                    whole_excel = null;
                    whole_excel = Parse(filePath); //read excel file   

                    this.LoadFinished(sender, e);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
            }
        }

        static DataSet Parse(string fileName)
        {
            string connectionString = "";
            if (Path.GetExtension(fileName).CompareTo(".xls") == 0)//compare the extension of the file
                connectionString = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007


            DataSet data = new DataSet();

            List<string> sheets = GetExcelSheetNames(connectionString);

            foreach (string sheetName in sheets)
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM [{0}]", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    dataTable.TableName = sheetName;
                    data.Tables.Add(dataTable);
                }
            }

            return data;
        }

        static List<string> GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            List<string> excelSheetNames = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                if (row["TABLE_NAME"].ToString().EndsWith("$") || row["TABLE_NAME"].ToString().EndsWith("$'"))
                {
                    excelSheetNames.Add(row["TABLE_NAME"].ToString());
                }
            }

            return excelSheetNames;
        }

        public void setData(object sender, System.EventArgs e)

        {
            sheet_and_type.Text = "";
            sheet_and_type.Visible = false;
            sheet_and_type.Refresh();
            loadingBar.Visible = true;
            loadingBar.Refresh();
            string selectedSheet = ((string)comboBox_sheet.SelectedItem);
            string selectedType = (string)comboBox_type.SelectedItem;

            if (selectedSheet == null) return;

            if (selectedSheet.StartsWith("'") && selectedSheet.EndsWith("'"))
            {
                selectedSheet = selectedSheet.Replace("'", "");
                selectedSheet = "'" + selectedSheet + "$'";
            }
            else
                selectedSheet += "$";

            dta = whole_excel.Tables[selectedSheet];
            int whole_Datarows = dta.Rows.Count;

            Thread t2 = new Thread(delegate ()
            {
                switch (selectedType)
                {
                    case "Show All":
                        //  dta = whole_excel.Tables[selectedSheet];
                        break;

                    case "Random 500":
                        dta = random(dta, 500);
                        break;

                    case "Random 1000":
                        dta = random(dta, 1000);
                        break;

                    case "Remaining True Positives":
                        dta = excludes(dta);
                        break;
                }

                this.Invoke((MethodInvoker)delegate
                {

                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dta;

                    loadingBar.Visible = false;
                    loadingBar.Refresh();

                    sheet_and_type.Text = "Showing: " + selectedType + ", from sheet: " + selectedSheet.Replace("$", "") + ", Total: " + dta.Rows.Count + "/" + whole_Datarows;

                    sheet_and_type.Visible = true;
                    sheet_and_type.Refresh();

                    FlashWindow.Flash(this);
                });


            });
            t2.Start();



        }

        // Data filters
        public DataTable getFilters()
        {
            return whole_excel.Tables["filter$"];

        }

        public DataTable random(DataTable dt, int limit)
        {
            DataTable newTable = dt.Clone();
            newTable.TableName = newTable.TableName + " - Random - " + limit;
            double total_loops = dt.Rows.Count * 1.5;
            int loop_index = 0;
            //Make a new Random generator
            Random rnd = new Random();
            while (newTable.Rows.Count != (limit > dt.Rows.Count ? dt.Rows.Count : limit) && loop_index < total_loops)
            {
                //index generation
                int index = rnd.Next(0, dt.Rows.Count);
                //add the row to newTable
                DataRow dr = dt.Rows[index];
                if (!scrubRow(dr))
                    newTable.ImportRow(dr);
                loop_index++;
            }
            return newTable;
        }

        public bool scrubRow(DataRow dr)
        {
            DataTable filter = getFilters();
            if (filter == null) return false;

            foreach (DataColumn col in filter.Columns)
            {
                string regex = "";
                //condition += (condition == "" ? " WHERE " : " AND ") + " [" + col.ColumnName + "] not IN (select [" + col.ColumnName + "] from [filter$] where [" + col.ColumnName + "] <> '' )";
                foreach (DataRow row in filter.Rows)
                {
                    string s = row[col.ColumnName].ToString();
                    if (s.Trim() != "")
                    {
                        regex += (regex == "" ? "" : "|") + s;

                    }
                }
                if (regex != "")
                    if (dr[col.ColumnName] != null)
                        if (Regex.IsMatch(dr[col.ColumnName].ToString(), regex, RegexOptions.IgnoreCase))
                            return true;
            }
            return false;
        }

        public DataTable excludes(DataTable dt)
        {
            DataTable newTable = dt.Clone();
            newTable.TableName = newTable.TableName + " - Excludes";

            foreach (DataRow dr in dt.Rows)
            {
                if (!scrubRow(dr))
                    newTable.ImportRow(dr);
            }
            return newTable;
        }

        private void Export_Click(object sender, EventArgs e)
        {

            loadingBar.Visible = true;
            loadingBar.Refresh();

            sheet_and_type.Visible = false;
            sheet_and_type.Refresh();

            string selectedSheet = ((string)comboBox_sheet.SelectedItem);
            string selectedType = (string)comboBox_type.SelectedItem;


            Thread t3 = new Thread(delegate ()
            {

                DataTable dt = (DataTable)dataGridView1.DataSource;

                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine( string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString().Replace(",", " "));
                    sb.AppendLine(string.Join(",", fields));                 
                }
                if (File.Exists(Path.GetDirectoryName(filePath) + "/" + Path.GetFileNameWithoutExtension(filePath) + "-" + selectedSheet + "-" + selectedType + ".csv"))
                {
                    File.Delete(Path.GetDirectoryName(filePath) + "/" + Path.GetFileNameWithoutExtension(filePath) + "-" + selectedSheet + "-" + selectedType + ".csv");
                }
                File.WriteAllText(Path.GetDirectoryName(filePath) + "/" + Path.GetFileNameWithoutExtension(filePath) + "-" + selectedSheet + "-" + selectedType + ".csv", sb.ToString());

                this.Invoke((MethodInvoker)delegate
                {

                    loadingBar.Visible = false;
                    sheet_and_type.Visible = true;
                    FlashWindow.Flash(this);
                    MessageBox.Show("Data Exported Successfully!");
                });
            });
            t3.Start();
        }

    }

}
