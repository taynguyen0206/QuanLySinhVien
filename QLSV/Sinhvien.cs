﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace QLSV
{
    public partial class Sinhvien : Form
    {
        public Sinhvien()
        {
            InitializeComponent();
        }
        StudentDataContextDataContext db = new StudentDataContextDataContext();

        private void Sinhvien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Show_DSSinhVien();
            //an hien button sinh vien
            txtMSSV.Enabled = false;
            txtHoTen.Enabled = false;
            NgaySinh.Enabled = false;
            txtPhone.Enabled = false;
            btnThem.Enabled = true;
            groupBox1.Enabled = false;
            btnLuu.Enabled = false;

            //Combox QueQuan 
            cbQueQuan.DisplayMember = "QueQuan";
            cbQueQuan.ValueMember = "QueQuan";
            cbQueQuan.DataSource = db.Show_DSSinhVien();
            cbQueQuan.Enabled = false;
            //Combobox Lop
            cbMaLop.DisplayMember = "TenLop";
            cbMaLop.ValueMember = "MaLop";
            cbMaLop.DataSource = db.Show_DSlop();
            cbMaLop.Enabled = false;
            // Combobox Khoa
            cbKhoa.DisplayMember = "TenKhoa";
            cbKhoa.ValueMember = "MaKhoa";
            cbKhoa.DataSource = db.DSKhoa();
            cbKhoa.Enabled = false;
        }
        private void cbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = db.SinhVien_SelectMaLop(cbMaLop.SelectedValue.ToString());
            
            dataGridView1.Columns["MSSV"].HeaderText = "MSSV";
            txtMSSV.DataBindings.Clear();
            txtMSSV.DataBindings.Add("Text", dataGridView1.DataSource, "MSSV");

            dataGridView1.Columns["TenSV"].HeaderText = "Ho va Ten";
            txtHoTen.DataBindings.Clear();
            txtHoTen.DataBindings.Add("Text", dataGridView1.DataSource, "TenSV");

            //dataGridView1.Columns["GioiTinh"].HeaderText = "Gioi Tinh";
            //txtMSSV.DataBindings.Clear();
            //txtMSSV.DataBindings.Add("Text", dataGridView1.DataSource, "GioiTinh");

            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngay Sinh";
            NgaySinh.DataBindings.Clear();
            NgaySinh.DataBindings.Add("Text", dataGridView1.DataSource, "NgaySinh");

            dataGridView1.Columns["QueQuan"].HeaderText = "Que Quan";
            cbQueQuan.DataBindings.Clear();
            cbQueQuan.DataBindings.Add("Text", dataGridView1.DataSource, "QueQuan");

            dataGridView1.Columns["SoDienThoai"].HeaderText = "So Dien Thoai";
            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text", dataGridView1.DataSource, "SoDienThoai");

            dataGridView1.Columns["MaLop"].HeaderText = "Ma Lop";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xoa = MessageBox.Show("Bạn có muốn xóa sinh viên này không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (xoa == DialogResult.Yes)
            {
                db.XoaSinhVien(txtMSSV.Text);
                cbMaLop_SelectedIndexChanged(sender, e);
            }
        }
        Boolean adSinhvien = false;
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            //Hien thong tin sv de them vao
            txtMSSV.Enabled = true;
            txtHoTen.Enabled = true;
            NgaySinh.Enabled = true;
            txtPhone.Enabled = true;
            groupBox1.Enabled = true;
            cbQueQuan.Enabled = true;
            cbKhoa.Enabled = true;
            cbMaLop.Enabled = true;
            txtMSSV.Focus();
            adSinhvien = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (adSinhvien)
            {
                try
                {
                    if (txtMSSV.Text=="")
                    {
                        MessageBox.Show("Bạn chưa nhập MSSV");
                        txtMSSV.Focus();
                    }
                    if (txtHoTen.Text == "") 
                    {
                        MessageBox.Show("Bạn chưa nhập Họ và Tên");
                        txtHoTen.Focus();
                    }
                    if (txtPhone.Text == "") 
                    {
                        MessageBox.Show("Bạn chưa nhập số điện thoại ");
                        txtPhone.Focus();
                    }
                    //if (gioitinh.Text == "")
                    //{
                    //    MessageBox.Show("Bạn chưa nhập gioi tinh ");
                    //    gioitinh.Focus();
                    //}
                    if (cbQueQuan.Text =="")
                    {
                        MessageBox.Show("Bạn chưa nhập quê quán ");
                        cbQueQuan.Focus();
                    }
                    if (NgaySinh.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập ngày sinh ");
                        NgaySinh.Focus();
                    }
                    //db.ThemMoiSinhVien(txtMSSV.Text, txtHoTen.Text, NgaySinh.Value, cbQueQuan.Text, txtPhone.Text, cbMaLop.Text);
                }
                catch
                {

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            //an thong tin sv
            txtMSSV.Enabled = false;
            txtHoTen.Enabled = true;
            NgaySinh.Enabled = true;
            txtPhone.Enabled = true;
            groupBox1.Enabled = true;
            cbQueQuan.Enabled = true;
            cbMaLop.Enabled = true;
            cbKhoa.Enabled = true;
        }
    }
    
}
