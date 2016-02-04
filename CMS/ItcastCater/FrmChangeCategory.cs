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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }

        private int Tp { get; set; }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.Tp = mea.Temp;
            if(this.Tp == 1)
            {

            }
            else if(this.Tp == 2)
            {
                CategoryInfo ct = mea.Obj as CategoryInfo;
                txtCName.Text = ct.CatName;
                txtCNum.Text = ct.CatNum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.CatId.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(CheckEmpty())
            {
                CategoryInfo ct = new CategoryInfo();
                ct.CatName = txtCName.Text;
                ct.CatNum = txtCNum.Text;
                ct.Remark = txtCRemark.Text;
                if(this.Tp == 1)
                {
                    ct.DelFlag = 0;
                    ct.SubBy = 1;
                    ct.SubTime = DateTime.Now;
                }
                else if(this.Tp == 2)
                {
                    ct.CatId = Convert.ToInt32(labId.Text);
                }
                CategoryInfoBLL bll = new CategoryInfoBLL();
                string msg = bll.SaveCategoryInfo(ct, this.Tp) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }

        private bool CheckEmpty()
        {
            if(string.IsNullOrEmpty(txtCName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            return true;
        }
    }
}
