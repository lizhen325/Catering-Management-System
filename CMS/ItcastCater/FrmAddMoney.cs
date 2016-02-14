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
        }

        private void FrmAddMoney_Load(object sender, EventArgs e)
        {
            //load all product
            LoadProductInfoByDelFlag(0);

            //Load
            LoadCategoryInfoByDelFlag(0);
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
    }
}
