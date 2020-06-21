using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapCuoiKi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = BLL.QL.Instance.convertXeToX2(BLL.QL.Instance.getAllXe());
            comboBox1.SelectedIndex = 0;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.del += new Form2.MyDel(show);
            f.Show();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BLL.QL.Instance.searchXebyChuXe_BLL(txtNameSv.Text.ToString()).Count > 0 && txtNameSv.Text.ToString().Equals("") == false)
            {
                dataGridView1.DataSource = BLL.QL.Instance.searchXebyChuXe_BLL(txtNameSv.Text.ToString());
            }
            else
            {
                MessageBox.Show("Rỗng");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;
            if(row.Count == 1)
            {
                Form2 f = new Form2((int)row[0].Cells["Id_Xe"].Value);
                f.del += new Form2.MyDel(show);
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lại");
            }
        }

        public void show()
        {
            dataGridView1.DataSource = BLL.QL.Instance.getAllXe();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.QL.Instance.deleteXe_BLL(dataGridView1.SelectedRows);
            show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                List<DTO.Xe> xes = BLL.QL.Instance.getAllXe();
                dataGridView1.DataSource = BLL.QL.Instance.sortListXe(xes, BLL.QL.increase);
            } else
            {
                List<DTO.Xe> xes = BLL.QL.Instance.getAllXe();
                dataGridView1.DataSource = BLL.QL.Instance.sortListXe(xes, BLL.QL.decrease);
            }   
           
        }
    }
}
