using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SQLAssignment
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlCommand _cmd;
        SqlDataReader reader;
        DataTable dataTable;
        SqlParameter param;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-559GMKJ\SQLEXPRESS;Initial Catalog=JOHNSON;Integrated Security=True;Pooling=False";

        }

        private void label3_Click(object sender, EventArgs e)
        { }
        private void label5_Click(object sender, EventArgs e)
        { }
        private void label7_Click(object sender, EventArgs e)
        { }
        private void label9_Click(object sender, EventArgs e)
        { }
        private void pictureBox1_Click(object sender, EventArgs e)
        { }
        private void jText_Box5_Load(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        { }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReadData();
        }
        private void ReadData()
        {
            try
            {
                com = new SqlCommand("Select * from StudentTable", con);
                con.Open();
                reader = com.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(reader);
                dgvOutput.DataSource = dataTable;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //spcode
            _cmd = new SqlCommand("StudentCRUD", con);
            _cmd.Parameters.AddWithValue("@status", "INSERT");
            _cmd.Parameters.AddWithValue("@Id", txtID.Text);
            _cmd.Parameters.AddWithValue("@Name", txtCourse.Text);
            _cmd.Parameters.AddWithValue("@Course", txtName.Text);
            _cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            _cmd.Parameters.AddWithValue("@SEM_1", Int32.Parse(txtSem1.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_2", Int32.Parse(txtSem2.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_3", Int32.Parse(txtSem3.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_4", Int32.Parse(txtSem4.Text.Trim()));
           //_cmd.Parameters.AddWithValue("@Percentage", Int32.Parse(txtPercent.Text.Trim()));
            //_cmd.Parameters.AddWithValue("@Grade", txtGrad.Text);

            _cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int record = _cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted");
            //spcode
            ReadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //spcode
            _cmd = new SqlCommand("StudentCRUD", con);
            _cmd.Parameters.AddWithValue("@status", "UPDATE");
            _cmd.Parameters.AddWithValue("@Id", txtID.Text);
            _cmd.Parameters.AddWithValue("@Name", txtCourse.Text);
            _cmd.Parameters.AddWithValue("@Course", txtName.Text);
            _cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            _cmd.Parameters.AddWithValue("@SEM_1", Int32.Parse(txtSem1.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_2", Int32.Parse(txtSem2.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_3", Int32.Parse(txtSem3.Text.Trim()));
            _cmd.Parameters.AddWithValue("@SEM_4", Int32.Parse(txtSem4.Text.Trim()));
            _cmd.Parameters.AddWithValue("@Percentage", Int32.Parse(txtPercent.Text.Trim()));
            _cmd.Parameters.AddWithValue("@Grade", txtGrad.Text);

            _cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int record = _cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated");
            //spcode
            ReadData();
        }

      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _cmd = new SqlCommand("StudentCRUD", con);
            _cmd.Parameters.AddWithValue("@status", "DELETE");
            _cmd.Parameters.AddWithValue("@Id", txtID.Text);
            _cmd.Parameters.AddWithValue("@Name", txtCourse.Text);
            _cmd.Parameters.AddWithValue("@Course", txtName.Text);
            _cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            _cmd.Parameters.AddWithValue("@SEM_1", Int32.Parse(txtSem1.Text));
            _cmd.Parameters.AddWithValue("@SEM_2", Int32.Parse(txtSem2.Text));
            _cmd.Parameters.AddWithValue("@SEM_3", Int32.Parse(txtSem3.Text));
            _cmd.Parameters.AddWithValue("@SEM_4", Int32.Parse(txtSem4.Text));
           // _cmd.Parameters.AddWithValue("@Percentage", Int32.Parse(txtPercent.Text));
            //_cmd.Parameters.AddWithValue("@Grade", txtGrad.Text);

            _cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            int record = _cmd.ExecuteNonQuery();
            MessageBox.Show(record + "record has been deleted");
            con.Close();
            ReadData();
        }

        private void dgvEmployeeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtTotal_Load(object sender, EventArgs e)
        {}
        private void txtPercent_Load(object sender, EventArgs e)
        {}
        private void txtGrad_Load(object sender, EventArgs e)
        {}

        private void cmbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strQuery = "select * from StudentTable where Grade=@Grade";
                com = new SqlCommand(strQuery, con);
                param = new SqlParameter("@Grade", cmbData.SelectedItem.ToString());
                com.Parameters.Add(param);

                con.Open();
                reader = com.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(reader);
                dgvOutput.DataSource = dataTable;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtID.Text = dgvOutput.Rows[row].Cells[0].Value.ToString();
            txtCourse.Text = dgvOutput.Rows[row].Cells[1].Value.ToString();
            txtName.Text = dgvOutput.Rows[row].Cells[2].Value.ToString();
            txtEmail.Text = dgvOutput.Rows[row].Cells[3].Value.ToString();
            txtSem1.Text = dgvOutput.Rows[row].Cells[4].Value.ToString();
            txtSem3.Text = dgvOutput.Rows[row].Cells[5].Value.ToString();
            txtSem2.Text = dgvOutput.Rows[row].Cells[5].Value.ToString();
            txtSem4.Text = dgvOutput.Rows[row].Cells[5].Value.ToString();
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if (txtID.Text == "")
            {
                errorProvider1.SetError(txtID, "Please Enter Valid ID");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider2.SetError(txtName, "Enter Valid Name");
            }
            else if (!Regex.IsMatch(txtName.Text, @"[aA-zZ]"))
            {
                errorProvider2.SetError(txtName, "Name must be alphabet only");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtName, "");


            }
        }

        private void txtSem1_Validating(object sender, CancelEventArgs e)
        {
            if (txtSem1.Text == "")
            {
                errorProvider3.SetError(txtSem1, "Enter Valid Marks");
            }
            else if (Int32.Parse(txtSem1.Text) > 100)
            {
                errorProvider3.SetError(txtSem1, "Enter marks between 1 to 100");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtSem1, "");
            }
        }

        private void txtSem2_Validating(object sender, CancelEventArgs e)
        {
            if (txtSem2.Text == "")
            {
                errorProvider4.SetError(txtSem2, "Enter Valid Marks");
            }
            else if (Int32.Parse(txtSem2.Text) > 100)
            {
                errorProvider4.SetError(txtSem2, "Enter marks between 1 to 100");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtSem2, "");
            }
        }

        private void txtSem3_Validating(object sender, CancelEventArgs e)
        {
            if (txtSem3.Text == "")
            {
                errorProvider5.SetError(txtSem3, "Enter Valid Marks");
            }
            else if (Int32.Parse(txtSem3.Text) > 100)
            {
                errorProvider5.SetError(txtSem3, "Enter marks between 1 to 100");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtSem3, "");
            }
        }

        private void txtSem4_Validating(object sender, CancelEventArgs e)
        {
            if (txtSem4.Text == "")
            {
                errorProvider6.SetError(txtSem4, "Enter Valid Marks");
            }
            else if (Int32.Parse(txtSem4.Text) > 100)
            {
                errorProvider6.SetError(txtSem4, "Enter marks between 1 to 100");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(txtSem4, "");
            }
        }

        private void txtPercent_Leave(object sender, EventArgs e)
        {
            int p = Int32.Parse(txtPercent.Text);
            if (p > 75)
            {
                txtGrad.Text = "A";
            }
            else if (p > 60 && p <= 75)
            {
                txtGrad.Text = "B";
            }
            else
            {
                txtGrad.Text = "C";
            }
        }

        private void txtSem4_Leave(object sender, EventArgs e)
        {
            txtTotal.Text = (Int32.Parse(txtSem1.Text) + Int32.Parse(txtSem2.Text) + Int32.Parse(txtSem3.Text) + Int32.Parse(txtSem4.Text)).ToString();
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            txtPercent.Text = (Int32.Parse(txtTotal.Text) / 4).ToString();
        }
    }
}
