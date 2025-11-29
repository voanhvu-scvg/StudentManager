using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
        private class Student
        {
            public string Name { get; set; }
            public string Gender { get;set; }
            public string Class { get; set; }
        }
        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student
            {
                Name = txtName.Text,
                Gender = cboGender.Text,
                Class = txtClass.Text
            };

            students.Add(s);

           
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dgvStudents.CurrentRow != null)
            {
                int index = dgvStudents.CurrentRow.Index;
                students[index].Name = txtName.Text;
                students[index].Gender = cboGender.Text;
                students[index].Class = txtClass.Text;
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvStudents.CurrentRow !=null)
            {
                int index = dgvStudents.CurrentRow.Index;
                students.RemoveAt(index);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text.ToLower();
            var results = students.FindAll(s => s.Name.ToLower().Contains(keyword));
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = results;

        }

        

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                txtName.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboGender.Text = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtClass.Text = dgvStudents.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}
