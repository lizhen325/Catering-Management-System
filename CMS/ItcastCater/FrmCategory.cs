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
            //加载所有的商品类别
            LoadCategoryInfoByDelFlag(0);
            //加载所有的产品
            LoadProductInfoByDelFlag(0);
            //加载所有的类别
            LoadCategoryInfoByDelFlagToCmb(0);

        }

        private void LoadCategoryInfoByDelFlagToCmb(int p)
        {
            CategoryInfoBLL bal = new CategoryInfoBLL();
            dgvCategoryInfo.AutoGenerateColumns = false;
            List<CategoryInfo> list = bal.GetCategoryInfoByDelFlag(p);
            list.Insert(0, new CategoryInfo() { CatId = -1, CatName = "请选择" });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
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
            if(dgvCategoryInfo.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if(DialogResult.OK == MessageBox.Show("删除类别","Are you sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
            {
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
                ProductInfoBLL bll = new ProductInfoBLL();
                int r = bll.GetProductInfoCountByCatId(id);
                if(r > 0)
                {
                    MessageBox.Show("该类别有产品，不能删除");
                    return;
                }
                CategoryInfoBLL cbll = new CategoryInfoBLL();
                string msg = cbll.SoftDeleteCategoryInfoByCatId(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadCategoryInfoByDelFlag(0);
            }
            
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

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if(dgvProductInfo.SelectedRows.Count>0)
            {
                //提示
                if(DialogResult.OK == MessageBox.Show("真的要删除吗","删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
                {
                    int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
                    ProductInfoBLL bll = new ProductInfoBLL();
                    if(bll.DeleteProductInfoByProId(id))
                    {
                        MessageBox.Show("操作成功");
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                    LoadProductInfoByDelFlag(0);
                    
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行");
            }
        }

        public event EventHandler evtFcp;

        //Insert Product
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            InsertOrUpdate(3);
        }

        //Update Product
        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if(dgvProductInfo.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
                ProductInfoBLL bll = new ProductInfoBLL();
                ProductInfo pro = bll.GetProductInfoById(id);
                if(pro!=null)
                {
                    meaFcp.Obj = pro;
                    InsertOrUpdate(4);
                }
            }
            else
            {
                MessageBox.Show("请选中Product");
            }
            
        }
        MyEventArgs meaFcp = new MyEventArgs();
        
        //表示3---insert，4----Update
        private void InsertOrUpdate(int p)
        {
            FrmChangeProduct fcp = new FrmChangeProduct();
            //注册事件
            this.evtFcp += new EventHandler(fcp.SetText);
            //村标识
            meaFcp.Temp = p;
            if(this.evtFcp!=null)
            {
                this.evtFcp(this, meaFcp);
                fcp.FormClosed += new FormClosedEventHandler(fcp_FormClosed);
                fcp.ShowDialog();
            }
        }

        private void fcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCategory.SelectedIndex !=0)
            {
                int id = Convert.ToInt32(cmbCategory.SelectedValue);
                ProductInfoBLL bll = new ProductInfoBLL();
                dgvProductInfo.AutoGenerateColumns = false;
                dgvProductInfo.DataSource = bll.GetProductInfoByCatId(id);
                if(dgvProductInfo.SelectedRows.Count>0)
                {
                    dgvProductInfo.SelectedRows[0].Selected = false;
                }
                
            }
            else
            {
                LoadProductInfoByDelFlag(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //获取文本框的内容
            string txt = txtSearch.Text;
            //传到bll层
            ProductInfoBLL bll = new ProductInfoBLL();
           List<ProductInfo> list = bll.GetProductInfoByProNum(txt);
            //集合绑定到dgv上
           dgvProductInfo.AutoGenerateColumns = false;
           dgvProductInfo.DataSource = list;
            if(dgvProductInfo.SelectedRows.Count>0)
            {
                dgvProductInfo.SelectedRows[0].Selected = false;
            }
         }

        
    }
}
