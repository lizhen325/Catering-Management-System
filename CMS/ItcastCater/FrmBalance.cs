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
    public partial class FrmBalance : Form
    {
        public FrmBalance()
        {
            InitializeComponent();
        }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo dk = mea.Obj as DeskInfo;
            //DeskName
            labDeskName.Text = dk.DeskName;
            OrderInfoBLL bll = new OrderInfoBLL();
            //OrderId
            int orderId = bll.GetOrderIdByDeskId(dk.DeskId);
            labOrderId.Text = orderId.ToString();
            //get sum money
            decimal money = bll.GetSumMoney(orderId);
            labMoney.Text = money.ToString();
            lblMoney.Text = money.ToString();

        }

        private void FrmBalance_Load(object sender, EventArgs e)
        {
            //load member
            LoadMemberInfoDelFlag(0);

            //Load order
            LoadROrderInfoProductByOrderId(Convert.ToInt32(labOrderId.Text));
        }

        private void LoadROrderInfoProductByOrderId(int p)
        {
            R_OrderInfo_ProductBLL bll = new R_OrderInfo_ProductBLL();
            dgvAllPro.AutoGenerateColumns = false;
            dgvAllPro.DataSource = bll.GetROrderProduct(p);
            dgvAllPro.SelectedRows[0].Selected = false;
        }

        private void LoadMemberInfoDelFlag(int p)
        {
            MemberInfoBLL bll = new MemberInfoBLL();
            List<MemberInfo> list = bll.GetAllMemberInfoByDelFlag(p);
            list.Insert(0, new MemberInfo() { MemmberId = -1, MemName = "请选择" });
            cmbMemmber.DataSource = list;
            cmbMemmber.DisplayMember = "MemName";
            cmbMemmber.ValueMember = "MemmberId";
        }

        private void cmbMemmber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMemmber.SelectedIndex != 0)
            {
                MemberInfoBLL bll = new MemberInfoBLL();
                MemberInfo mem = cmbMemmber.SelectedItem as MemberInfo;
                //memberType
                labTp.Text = bll.GetMemberTypeByMemberId(mem.MemmberId);
                //member money
                labyeMoney.Text = mem.MemMoney.ToString();
                //discount
                lblDis.Text = mem.MemDiscount.ToString();
            }
            else
            {
                labTp.Text = "";
                labyeMoney.Text = "";
                lblDis.Text = "";
            }
        }
    }
}
