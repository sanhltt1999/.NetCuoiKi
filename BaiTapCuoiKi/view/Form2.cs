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
    public partial class Form2 : Form
    {
        private int idXe;

        public delegate void MyDel();
        public MyDel del { get; set; }

        public Form2()
        {
            InitializeComponent();
            setCBB();

        }

        public void setCBB()
        {
            List<DTO.LoaiXe> loaiXes = BLL.QL.Instance.getLoaiXe();
            foreach(DTO.LoaiXe i in loaiXes)
            {
                comboBox1.Items.Add(new DTO.cbbIteam()
                {
                    id = i.Id_LoaiXe,
                    soGhe = i.SoGhe,
                    loai = i.Loai
                });
            }
            comboBox1.SelectedIndex = 0;
        }

        public Form2(int idXe)
        {
            InitializeComponent();
            this.idXe = idXe;
            setCBB();
            setView(idXe);
           
        }

        public void setView(int idXe)
        {
            List<DTO.Xe> xes = BLL.QL.Instance.getXebyID_BLL(idXe);
            txt2BienSo.Text = xes[0].BienSo;
            txt2ChuXe.Text = xes[0].ChuXe;
            txt2GiaThue.Text = xes[0].GiaThue.ToString();
            txt2Sdt.Text = xes[0].SoDienThoai;
            comboBox1.SelectedIndex = xes[0].Id_LoaiXe - 1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(idXe != 0)
            {
                if (txt2BienSo.Text.Equals("") == true ||
                    txt2ChuXe.Text.Equals("") == true ||
                    txt2GiaThue.Text.Equals("") == true ||
                    txt2Sdt.Text.Equals("") == true ||
                    comboBox1.Text.Equals("") == true)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    DTO.Xe xe = new DTO.Xe()
                    {
                        Id_Xe = idXe,
                        BienSo = txt2BienSo.Text.ToString(),
                        GiaThue = Convert.ToInt32(txt2GiaThue.Text.ToString()),
                        SoDienThoai = txt2Sdt.Text.ToString(),
                        ChuXe = txt2ChuXe.Text.ToString(),
                        Id_LoaiXe = ((DTO.cbbIteam)(comboBox1.SelectedItem)).id
                    };
                    if (BLL.QL.Instance.updateXe_BLL(xe) == true)
                    {
                        MessageBox.Show("edit thành công");
                        this.Dispose();
                        del();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                  
                }
            } else
            {
                if(txt2BienSo.Text.Equals("") == true ||
                    txt2ChuXe.Text.Equals("") == true ||
                    txt2GiaThue.Text.Equals("") == true||
                    txt2Sdt.Text.Equals("") == true)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                } else
                {
                  
                    DTO.Xe xe = new DTO.Xe()
                    {
                        BienSo = txt2BienSo.Text.ToString(),
                        GiaThue = Convert.ToInt32(txt2GiaThue.Text.ToString()),
                        SoDienThoai = txt2Sdt.Text.ToString(),
                        ChuXe = txt2ChuXe.Text.ToString(),
                        Id_LoaiXe = ((DTO.cbbIteam)(comboBox1.SelectedItem)).id
                    };
                    if (BLL.QL.Instance.addXe_BLL(xe) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        this.Dispose();
                        del();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

