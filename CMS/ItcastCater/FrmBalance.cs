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
        private int deskId { get; set; }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo dk = mea.Obj as DeskInfo;
            //store deskId
            this.deskId = dk.DeskId;
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
            //dgvAllPro.SelectedRows[0].Selected = false;
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

                //show the money after discount
                lblMoney.Text = (Convert.ToDecimal(labMoney.Text) * mem.MemDiscount / 10).ToString();
            }
            else
            {
                labTp.Text = "";
                labyeMoney.Text = "";
                lblDis.Text = "";
                //show the bill money for non-member (no discount)
                lblMoney.Text = labMoney.Text;
            }
        }

        //Pay the bill
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            MemberInfo mem = cmbMemmber.SelectedItem as MemberInfo;
            if(string.IsNullOrEmpty(txtMoney.Text))
            {
                MessageBox.Show("请输入钱");
                return;
            }
            if(Convert.ToDecimal(txtMoney.Text) < Convert.ToDecimal(lblMoney.Text))
            {
                MessageBox.Show("就这点钱？ 搞笑呢");
                return;
            }
            OrderInfo order = new OrderInfo();
            //deskState in DeskInfo table
            DeskInfoBLL bll = new DeskInfoBLL();
            bool deskFlag = bll.UpdateDeskStateByDeskId(this.deskId, 0);
            //non-member
            if(cmbMemmber.SelectedIndex != 0)
            {
                order.OrderMemId = mem.MemmberId;
                order.DisCount = Convert.ToDecimal(mem.MemDiscount);
                //after pay in member money
                decimal money = mem.MemMoney - Convert.ToDecimal(lblMoney.Text);
                MemberInfoBLL mbll = new MemberInfoBLL();
                //if(money < 0)
                //{
                
                //}
                //Member money in MemmberInfo table
                bool memFlag = mbll.UpdateMoneyByMemId(mem.MemmberId, money);
            }
            order.EndTime = System.DateTime.Now;
            order.OrderId = Convert.ToInt32(labOrderId.Text);
            order.OrderMoney = Convert.ToDecimal(lblMoney.Text);
            OrderInfoBLL obll = new OrderInfoBLL();
            bool orderFlag = obll.UpdateOrderInfoMoney(order);
            lblSpareMoney.Text = (Convert.ToDecimal(txtMoney.Text) - Convert.ToDecimal(lblMoney.Text)).ToString();
            if(deskFlag && orderFlag)
            {
                MessageBox.Show("结账成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        //show the money change
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMoney.Text))
            {
                lblSpareMoney.Text = (Convert.ToDecimal(txtMoney.Text) - Convert.ToDecimal(lblMoney.Text)).ToString();
            }
            else
            {
                lblSpareMoney.Text = "没付钱";
            }
        }
    }
}
