﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
namespace cypos
{
    public partial class frmPaymentType : Form
    {
        private frmMain _frmMain;  

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;       /*The WM_NCLBUTTONDOWN message is one of those messages. 
                                                         WM = Window Message. NC = Non Client, the part of the 
                                                         * window that's not the client area, the borders and the title bar. 
                                                         L = Left button, you can figure out BUTTONDOWN. */
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /*********************************************/
	    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmPaymentType(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	


        public string TableId
        {
            set { lblPayTypeId.Text = value;} 
            get{return lblPayTypeId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtPayType.Text == "") 
                 { 
                     Messages.InformationMessage("Enter payment type"); 
                     txtPayType.Focus(); 
                 }
                else
                 {
                     if (lblPayTypeId.Text == "-")
                     {
                         if (DataAccess.RecordExits("tbl_PaymentType", "payment_type", txtPayType.Text) == 1)
                         {
                             Messages.InformationMessage("Payment type already exist");
                             txtPayType.Focus();
                         }
                         else
                         {
                             string strSQLInsert = " INSERT INTO tbl_PaymentType (payment_type) VALUES ('" + txtPayType.Text + "')";
                             DataAccess.ExecuteSQL(strSQLInsert);
                             LoadPayTypeList("");
                             Clear();
                         }
                     }
                     else 
                     {
                         string strSQLUpdate = "UPDATE tbl_PaymentType SET payment_type = '" + txtPayType.Text + "' " +
                                               "WHERE id = '" + lblPayTypeId.Text + "'";
                         DataAccess.ExecuteSQL(strSQLUpdate);
                         LoadPayTypeList("");
                         Clear();
                         OpenedForms.Close();
                     }
                 }         
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmTableLocation_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPayTypeList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            lblPayTypeId.Text = "-";
            txtPayType.Clear();
            txtPayType.Focus();
        }

        public void LoadPayTypeList(string value = "")
        {
            floPayTypeList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_PaymentType ORDER BY payment_type";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnTable = new Button();
                    btnTable.Name = dataReader["id"].ToString();
                    btnTable.Tag = dataReader["id"];
                    btnTable.Text = dataReader["payment_type"].ToString();
                    //btnTable.Text += dataReader["no_of_chairs"].ToString();

                    btnTable.Margin = new Padding(3, 3, 3, 3);
                    btnTable.Size = new Size(100, 50);

                    btnTable.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Click += new EventHandler(btnTable_Click);
                    floPayTypeList.Controls.Add(btnTable);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnTable_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.TableId = s;
        }

   
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenedForms.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result == true)
            {
                if (lblPayTypeId.Text != "-")
                {
                    string strSQLDelete = "DELETE FROM tbl_PaymentType WHERE id = '" + lblPayTypeId.Text.ToString() + "'";
                    DataAccess.ExecuteSQL(strSQLDelete);
                    //Messages.DeletedMessage();
                    LoadPayTypeList("");
                    Clear();
                }
            }
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void lblTableId_TextChanged(object sender, EventArgs e)
        {
            if (lblPayTypeId.Text != "-")
            {
                GetLocationById(lblPayTypeId.Text);
                btnDelete.Visible = true;
            }
        }

        private void GetLocationById(string strLocationId)
        {
            string strSQL = "SELECT * FROM tbl_PaymentType WHERE (id ='" + strLocationId + "' )";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtTable = DataAccess.GetDataTable(strSQL);

            lblPayTypeId.Text = dtTable.Rows[0]["id"].ToString();
            txtPayType.Text = dtTable.Rows[0]["payment_type"].ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnKbPayType_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPayType);
            frmKeyboard.ShowDialog();
        }
    }
}
