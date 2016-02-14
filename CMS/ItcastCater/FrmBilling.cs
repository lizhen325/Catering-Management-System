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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        private int ID { get; set; }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo dk = mea.Obj as DeskInfo;
            labDeskName.Text = dk.DeskName;
            labRoomType.Text = mea.Name;
            labLittleMoney.Text = mea.Money.ToString();
            //DeskId
            this.ID = dk.DeskId;
        }
        public event EventHandler evtFrmMoney;
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //change desk state
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool dkFlag = dkBll.UpdateDeskStateByDeskId(this.ID, 1);
            //add an order
            OrderInfoBLL orBll = new OrderInfoBLL();
            OrderInfo or = new OrderInfo();
            or.SubTime = System.DateTime.Now;
            or.OrderMoney = 0;
            or.DelFlag = 0;
            or.OrderState = 1;
            or.Remark = txtPersonCount.Text + txtDescription.Text;
            or.SubBy = 1;
            int orderId = orBll.AddOrderInfo(or);

            //add R_Order_Desk
            R_Order_DeskBLL rodBll = new R_Order_DeskBLL();
            R_Order_Desk rod = new R_Order_Desk();
            rod.DeskId = this.ID;
            rod.OrderId = orderId;
            bool rodFlag = rodBll.AddROrderDesk(rod);

            if(dkFlag && rodFlag)
            {
                MessageBox.Show("开单成功");
                if(ckbMeal.Checked)
                {
                    MyEventArgs mea = new MyEventArgs();
                    //deskName
                    mea.Name = labDeskName.Text;
                    //Order Id
                    mea.Temp = orderId;
                    FrmAddMoney fam = new FrmAddMoney();
                    this.evtFrmMoney += new EventHandler(fam.SetText);
                    if(this.evtFrmMoney != null)
                    {
                        this.evtFrmMoney(this, mea);
                        fam.FormClosed += new FormClosedEventHandler(fam_FormClosed);
                        fam.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("开单失败");
            }
        }

        private void fam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        
    }
}
