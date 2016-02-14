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
    public partial class FrmAddMoney : Form
    {
        public FrmAddMoney()
        {
            InitializeComponent();
        }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            labDeskName.Text = mea.Name;

            //orderId
            labOrderId.Text = mea.Temp.ToString();
        }

        private void FrmAddMoney_Load(object sender, EventArgs e)
        {
            //load all product
            LoadProductInfoByDelFlag(0);

            //Load
            LoadCategoryInfoByDelFlag(0);

            //load order
            LoadROrderInfoProductByOrderId(Convert.ToInt32(labOrderId.Text));
        }

        private void LoadROrderInfoProductByOrderId(int p)
        {
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            dgvROrderProduct.AutoGenerateColumns = false;
            dgvROrderProduct.DataSource = bll.GetROrderProduct(p);
            if(dgvROrderProduct.SelectedRows.Count>0)
            {
                dgvROrderProduct.SelectedRows[0].Selected = false;
            }

            //
            R_OrderInfo_Product rop = bll.GetMoneyAndCount(p);
            labSumMoney.Text = rop.MONEY.ToString();
            labCount.Text = rop.CT.ToString();
        }

        private void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBLL bll = new CategoryInfoBLL();
            List<CategoryInfo> list = bll.GetCategoryInfoByDelFlag(p);
            for(int i=0; i < list.Count; i++)
            {
                TreeNode tn = tvCategory.Nodes.Add(list[i].CatName);
                LoadProductInfoByCatId(list[i].CatId, tn.Nodes);
            }
        }

        private void LoadProductInfoByCatId(int p, TreeNodeCollection tnc)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            List<ProductInfo> list = bll.GetProductInfoByCatId(p);
            for(int i=0; i<list.Count; i++)
            {
                tnc.Add(list[i].ProName + "====="+list[i].ProPrice+"元");
            }
        }


        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetProductInfoByDelFlag(p);
            dgvProduct.SelectedRows[0].Selected = false;
        }

        //start order with cell double click event
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                int proId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());
                R_OrderInfo_Product rop = new R_OrderInfo_Product();
                rop.OrderId = Convert.ToInt32(labOrderId.Text);
                rop.ProId = proId;
                rop.DelFlag = 0;
                rop.SubTime = System.DateTime.Now;
                rop.State = 0;
                if(string.IsNullOrEmpty(txtCount.Text) || txtCount.Text=="0" || txtCount.Text=="1")
                {
                    rop.UnitCount = 1;
                }
                else
                {
                    rop.UnitCount = Convert.ToInt32(txtCount.Text);
                }
                R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
                string msg = bll.AddROrderInfoProduct(rop) ? "成功" : "失败";
                LoadROrderInfoProductByOrderId(Convert.ToInt32(rop.OrderId));
         }

        //search for id and alphaet
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadProductInfoByDelFlag(0);
                return;
            }
            int n = 0;
            if(char.IsLetter(txtSearch.Text[0]))
            {
                //the first text is alphaet
                n = 1;
            }
            else
            {
                //the first is number
                n = 2;
            }
            ProductInfoBLL bll = new ProductInfoBLL();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetProductInfoBySpellOrNum(txtSearch.Text, n);
            if(dgvProduct.SelectedRows.Count > 0)
            {
                dgvProduct.SelectedRows[0].Selected = false;
            }
        }

        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            if(dgvROrderProduct.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvROrderProduct.SelectedRows[0].Cells[0].Value.ToString());
                R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
                string msg = bll.SoftDeletROrderProName(id) ? "退菜成功" : "退菜失败";
                MessageBox.Show(msg);
                LoadROrderInfoProductByOrderId(Convert.ToInt32(labOrderId.Text));
            }
            else
            {
                MessageBox.Show("请选择要取消的order");
            }
        }
            
        
    }
}
