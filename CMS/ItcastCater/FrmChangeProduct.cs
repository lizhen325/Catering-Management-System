using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItcastCater.BLL;
using ItcastCater.Model;

namespace ItcastCater
{
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }

        private int Tp { get; set; }
        private void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = new List<CategoryInfo>();
            list = bll.GetCategoryInfoByDelFlag(p);
            list.Insert(0, new CategoryInfo() { CatName = "请选择", CatId = -1 });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        public void SetText(object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
            MyEventArgs mea = e as MyEventArgs;
            this.Tp = mea.Temp;
            if(this.Tp == 3)
            {
                //insert

            }
            else if(this.Tp == 4)
            {
                //update
                ProductInfo pro = mea.Obj as ProductInfo;
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName;
                txtNum.Text = pro.ProNum;
                txtPrice.Text = pro.ProPrice.ToString();
                txtRemark.Text = pro.Remark;
                txtSpell.Text = pro.ProSpell;
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit;
                labId.Text = pro.ProId.ToString();

                cmbCategory.SelectedValue = pro.CatId;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(CheckEmpty())
            {
                ProductInfo pro = new ProductInfo();
                pro.CatId = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;
                
                if(this.Tp == 3)
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }
                
                else if(this.Tp == 4)
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }
                ProductInfoBLL bll = new ProductInfoBLL();
                if(bll.SaverProduct(pro,this.Tp))
                {
                    MessageBox.Show("操作失败");
                }
                else
                {
                    MessageBox.Show("操作成功");
                }
                this.Close();
            }
        }

        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("商品成本不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("商品价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("商品备注不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("商品拼音不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("商品库存不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                return false;
            }
            if(cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("请选择类别");
                return false;
            }
            return true;
        }
    }
}
