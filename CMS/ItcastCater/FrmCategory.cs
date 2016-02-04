using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItcastCater.Model;
using ItcastCater.BLL;

namespace ItcastCater
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

       
        private void FrmCategory_Load(object sender, EventArgs e)
        {

            LoadCategoryInfoByDelFlag(0);
            LoadProductInfoByDelFlag(0);

        }

        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBLL bal = new ProductInfoBLL();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bal.GetProductInfoByDelFlag(0);
            dgvProductInfo.SelectedRows[0].Selected = false;
        }

        private void LoadCategoryInfoByDelFlag(int p)
        {

            CategoryInfoBLL bal = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;
            dgvCategoryInfo.DataSource = bal.GetCategoryInfoByDelFlag(p);
            dgvCategoryInfo.SelectedRows[0].Selected = false;

            
        }

        private void benDeleteCategory_Click(object sender, EventArgs e)
        {
           
        }

        //Insert ProductCategory
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadFrmChangeCategoryInfo(1);
            
        }

        //UpdateProductCategory
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if(dgvCategoryInfo.SelectedRows.Count>0)
            {
                //选中行后获取id
                //根据id获取该对象
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
                //根据id去数据库查询
                CategoryInfoBLL bll = new CategoryInfoBLL();
                CategoryInfo ct = bll.GetCategoryInfoById(id);
                if(ct !=null)
                {
                    mea.Obj = ct;
                    LoadFrmChangeCategoryInfo(2);
                }
            }
            else
            {
                MessageBox.Show("please select!!");
            }
            
        }

        MyEventArgs mea = new MyEventArgs();
        public event EventHandler etvFcc;
        //p---1 Insert, p---2 Update
        private void LoadFrmChangeCategoryInfo(int p)
        {
            FrmChangeCategory fcc = new FrmChangeCategory();
            this.etvFcc += new EventHandler(fcc.SetText);
            mea.Temp = p;
            if(this.etvFcc !=null)
            {
                this.etvFcc(this, mea);
                fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
                fcc.ShowDialog();
            }
        }

        //是新增或修改窗体关闭后调用的方法
        private void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }



        
    }
}
