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
    public partial class frmItem : Form
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

        public frmItem(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
        }

        #region Item List

        public void LoadItemList()
        {
            try
            {
                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active=1 ORDER BY category_name";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCategory = DataAccess.GetDataTable(strSQL);
                cmbSearchCategory.DataSource = dtCategory;
                cmbSearchCategory.ValueMember = "id";
                cmbSearchCategory.DisplayMember = "category_name";

                LoadItemList("");

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void LoadItemList(string value)
        {
            floItemList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ItemImages\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string strSQL="SELECT tbl_Item.*, tbl_Category.category_name FROM tbl_Item " +
                              "LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                              "WHERE  ( item_name LIKE '" + value + "%' ) " +
                              "OR ( item_code LIKE '" + value + "%' ) " +
                              "OR (category_name = '" + value + "')  ";

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Items Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button b = new Button();
                    //b.FlatStyle = FlatStyle.Flat;
                    //b.FlatAppearance.BorderSize = 1;
                    //b.FlatAppearance.BorderColor= Color.Gray;
                    //b.BackColor = Color.LightYellow;
                    b.Tag = dataReader["item_code"];
                    b.Click += new EventHandler(btnItem_Click);

                    b.Name = dataReader["id"].ToString(); 

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(32, 32);
                    il.Images.Add(Image.FromFile(img_directory + dataReader["image_name"]));


                    b.Image = il.Images[0];
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(150, 50);

                    b.Text = " " + dataReader["item_code"] + "\n ";
                    b.Text += dataReader["item_name"].ToString();
                    b.Text += "\n Price: " + dataReader["selling_price"];

                    b.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    floItemList.Controls.Add(b);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.ItemCode = s;
        }

        #endregion

        public string ItemCode
        {
            set { lblItemCode.Text = value; }
            get { return lblItemCode.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region DataBind

        private void GetItemByCode()
        {
            string strSQL="SELECT id, item_code, item_name, cost_price, selling_price, discount," +
                          "category_id, image_name, tax_apply, show_kitchen, print_kot, show_pos,"+
                          "stock_item,reorder_level,active,sort_order FROM tbl_Item WHERE item_code = '" + lblItemCode.Text + "'";

            DataAccess.ExecuteSQL(strSQL);
            DataTable dtItem = DataAccess.GetDataTable(strSQL);

            txtItemCode.Text = dtItem.Rows[0]["item_code"].ToString();
            txtItemName.Text = dtItem.Rows[0]["item_name"].ToString();
            txtCostPrice.Text = dtItem.Rows[0]["cost_price"].ToString();
            txtSellingPrice.Text = dtItem.Rows[0]["selling_price"].ToString();
            txtDiscount.Text = dtItem.Rows[0]["discount"].ToString();
            cmbCategory.SelectedValue =int.Parse(dtItem.Rows[0]["category_id"].ToString());

            lblImageName.Text = dtItem.Rows[0]["image_name"].ToString();
            string strImagePath = Application.StartupPath + @"\ItemImages\" + dtItem.Rows[0]["image_name"].ToString() + "";
            pbxItemImage.ImageLocation = strImagePath;
            pbxItemImage.InitialImage.Dispose();
            
            cbxTaxable.Checked = Convert.ToBoolean(dtItem.Rows[0]["tax_apply"]) ? true : false;
            cbxKitchenDisplay.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_kitchen"]) ? true : false;
            cbxPrintInKot.Checked = Convert.ToBoolean(dtItem.Rows[0]["print_kot"]) ? true : false;
            cbxShowInPOS.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_pos"]) ? true : false;
            cbxStockItem.Checked = Convert.ToBoolean(dtItem.Rows[0]["stock_item"]) ? true : false;
            cbxActive.Checked = Convert.ToBoolean(dtItem.Rows[0]["active"]) ? true : false;
            txtSortOrder.Text = dtItem.Rows[0]["sort_order"].ToString();
            txtReOrderLevel.Text = dtItem.Rows[0]["reorder_level"].ToString();
        }


        private void frmItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserInfo.UserType == "1")
                {
                    
                }
                else
                {
                    
                }

                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active=1 ORDER BY category_name ";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCategory = DataAccess.GetDataTable(strSQL);
                DataRow dr = dtCategory.NewRow();
                dr["id"] = 0;
                dr["category_name"] = "Select";
                dtCategory.Rows.InsertAt(dr, 0);
                cmbCategory.DataSource = dtCategory;
                cmbCategory.ValueMember = "id";
                cmbCategory.DisplayMember = "category_name";
                LoadItemList();
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion

        #region Insert , Update and delete Item
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == string.Empty )
            {
                Messages.InformationMessage("Enter item code");
                txtItemCode.Focus();
            }
            else if (txtItemName.Text == string.Empty)
            {
                Messages.InformationMessage("Enter item name");
                txtItemName.Focus();
            }

            else if (txtSellingPrice.Text == string.Empty)
            {
                Messages.InformationMessage("Enter selling price");
                txtSellingPrice.Focus();
            }
            else if (cmbCategory.SelectedValue.ToString() =="0")
            {
                Messages.InformationMessage("Select category");
                cmbCategory.Focus();
            }
            else
            {
                if (txtSortOrder.Text == string.Empty)
                {
                    txtSortOrder.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtCostPrice.Text == string.Empty)
                {
                    txtCostPrice.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtReOrderLevel.Text == string.Empty)
                {
                    txtReOrderLevel.Text = "0";
                }
                try
                {
                    bool TaxApply = cbxTaxable.Checked ? true : false;
                    bool ShowInKitchen = cbxKitchenDisplay.Checked ? true : false;
                    bool PrintInKot = cbxPrintInKot.Checked ? true : false;
                    bool ShowInPos = cbxShowInPOS.Checked ? true : false;
                    bool StockItem = cbxStockItem.Checked ? true : false;
                    bool Active = cbxActive.Checked ? true : false;
           
                    if (lblItemCode.Text == "-")
                    {
                        string imageName = txtItemCode.Text + lblFileExtension.Text;
                        string strSQLInsert = "INSERT INTO tbl_Item (item_code, item_name,cost_price, selling_price, " +
                                              "discount,category_id, image_name, tax_apply,show_kitchen,print_kot," +
                                              "show_pos,stock_item,reorder_level,stock_quantity,sort_order,active) " +
                                              "VALUES ('" + txtItemCode.Text + "', '" + txtItemName.Text + "','" + Convert.ToDecimal(txtCostPrice.Text) + "', " +
                                              "'" + Convert.ToDecimal(txtSellingPrice.Text) + "', '" + Convert.ToDecimal(txtDiscount.Text) + "', '" + cmbCategory.SelectedValue + "', " +
                                              "'" + imageName + "' , '" + TaxApply + "' , '" + ShowInKitchen + "','" + PrintInKot +
                                              "','" + ShowInPos + "','" + StockItem + "','" + Convert.ToDecimal(txtReOrderLevel.Text) + "','" + Convert.ToDecimal(txtOpeningStock.Text) + "','" + txtSortOrder.Text + "','" + Active + "')";
                        
                        DataAccess.ExecuteSQL(strSQLInsert);
                        //Add to Purchase Table
                        SavePurchase("OB",DateTime.Now.ToString(),Convert.ToDouble(txtOpeningStock.Text));
                     
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + imageName);
                        if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                        string filename = path + @"\" + openFileDialog1.SafeFileName;
                        pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        Clear();
                        LoadItemList();
                        //Messages.SavedMessage();
                    }
                    else  //Update
                    {
                        
                        string strImageName;
                        if (lblFileExtension.Text == "item.png") //if not select image
                        {
                            strImageName = lblImageName.Text;
                        }
                        else  // select image
                        {
                            strImageName = lblItemCode.Text + lblFileExtension.Text;
                        }

                        string strSQLUpdate = " UPDATE tbl_Item SET item_code = '" + txtItemCode.Text + "', " +
                                    " item_name = '" + txtItemName.Text + "', " +
                                    " cost_price = '" + txtCostPrice.Text + "', " +
                                    " selling_price = '" + txtSellingPrice.Text + "', " +
                                    " discount = '" + txtDiscount.Text + "', " +
                                    " category_id = '" + cmbCategory.SelectedValue + "', " +
                                    " image_name = '" + strImageName + "', " +
                                    " tax_apply = '" + TaxApply + "', " +
                                    " show_kitchen = '" + ShowInKitchen + "', " +
                                    " print_kot = '" + PrintInKot + "', " +
                                    " show_pos = '" + ShowInPos+ "', " +
                                    " stock_item = '" + StockItem + "', " +
                                    " reorder_level = '" + txtReOrderLevel.Text + "', " +
                                    " sort_order = '" + txtSortOrder.Text + "', " +
                                    " active = '" + Active + "'" +
                                    " WHERE item_code = '" + lblItemCode.Text + "'";
                        DataAccess.ExecuteSQL(strSQLUpdate);

                        //Update Item Image
                          if (lblFileExtension.Text != "item.png") // if select image
                          {
                              pbxItemImage.InitialImage.Dispose();
                              string path = Application.StartupPath + @"\ItemImages\";

                              System.GC.Collect();
                              System.GC.WaitForPendingFinalizers();
                              System.IO.File.Delete(path + @"\" + lblImageName.Text);

                              if (!System.IO.Directory.Exists(path))
                                  System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                              string filename = path + @"\" + openFileDialog1.SafeFileName;
                              pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                              System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + strImageName);
                          }
                          Clear();
                          LoadItemList();
                          //Messages.UpdatedMessage();
                          //_frmMain.LoadItems("",0,20);
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private void Clear()
        {
            lblItemCode.Text = "-";
            txtItemCode.Enabled = true;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSearchItem.Text = string.Empty;
            txtSortOrder.Text = string.Empty;
            txtReOrderLevel.Clear();
            cmbSearchCategory.Text = string.Empty;
            cmbCategory.SelectedValue = 0;
            cbxTaxable.Checked = false;
            cbxKitchenDisplay.Checked = false;
            cbxPrintInKot.Checked = false;
            cbxShowInPOS.Checked = true;
            cbxStockItem.Checked = false;
            cbxActive.Checked = true;
            txtOpeningStock.Enabled = true;
            lblImageName.Text = "-";
            pbxItemImage.Image = Properties.Resources.no_image;
            btnSave.BackgroundImage = Properties.Resources.save100x45;

            if (Settings.AutoItemNo)
            {
                txtItemCode.ReadOnly = true;
                int nextNo = Settings.LastItemAutoNo + 1;
                txtItemCode.Text = nextNo.ToString();
            }
            else
            {
                txtItemCode.ReadOnly = false;
                txtItemCode.Clear();
            }

            txtItemCode.Focus();
        }

      
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  openFileDialog1.InitialDirectory = @"C:\";
            //  openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".jpg";
            // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbxItemImage.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        
        #endregion

     
        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtSellingPrice.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscount.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
      
       
        #region Purchase 

        public void SavePurchase(string strType,string strDate , double dblQty)
        {          
            string strItemId = txtItemCode.Text;      
            double dblPrice = Convert.ToDouble(txtSellingPrice.Text);

            string strSQLInsert = "INSERT INTO tbl_Purchase (purchase_date, ref_no, supplier_id, product_id,quantity, price, purchase_type) " +
                                  "VALUES ('" + strDate + "', '" + "" + "','" + 0 + "', '" + strItemId + "', '" + dblQty + "','"  + dblPrice + "' ,'" + strType + "' )";
            DataAccess.ExecuteSQL(strSQLInsert);
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.QuestionMessage("Do you want to Delete?");

            if (result == true)
            {

                if (lblItemCode.Text == "-")
                {
                    Messages.InformationMessage("The record could not be deleted.");
                }
                else
                {
                    try
                    {
                        string sql = "DELETE FROM tbl_Item WHERE item_code ='" + lblItemCode.Text + "'";
                        DataAccess.ExecuteSQL(sql);

                        pbxItemImage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + lblImageName.Text);
                        //Messages.InformationMessage("Successfully deleted");
                        Clear();
                        LoadItemList();
                    }
                    catch (Exception ex)
                    {
                        Messages.ExceptionMessage(ex.Message);
                    }
                }
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

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblItemCode_TextChanged(object sender, EventArgs e)
        {
            if (lblItemCode.Text != "-")
            {
                GetItemByCode();
                txtItemCode.Enabled = false;
                txtOpeningStock.Enabled = false;
                btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
                btnDelete.Visible = true;
            }
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxItemImage.Image = cypos.Properties.Resources.no_image;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string sqlitemcode = "SELECT item_code FROM tbl_Item WHERE item_code = '" + txtItemCode.Text + "' ";
                DataAccess.ExecuteSQL(sqlitemcode);
                DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                if (dtitemcode.Rows.Count > 0)
                {
                    this.ItemCode = txtItemCode.Text;
                    btnKbItemCode.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
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

        private void btnKbSearchProduct_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchItem);
            frmKeyboard.ShowDialog(); 
        }


        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItemList(txtSearchItem.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void cmbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItemList(cmbSearchCategory.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtCostPrice.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtReOrderLevel.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbItemCode_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemCode);
            frmKeyboard.ShowDialog();
        }

        private void btnKbSortOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtSortOrder);
            frmNumberboard.ShowDialog();
        }

        private void btnKbItemName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbReOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtReOrderLevel);
            frmNumberboard.ShowDialog();
        }

        private void btnKbOpStock_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtOpeningStock);
            frmNumberboard.ShowDialog();
        }

        private void btnKbCost_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtCostPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbPrice_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtSellingPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbDiscount_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtDiscount);
            frmCurrencyboard.ShowDialog();
        }
    }
}
