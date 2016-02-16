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
    public partial class FrmChangeRoom : Form
    {
        public FrmChangeRoom()
        {
            InitializeComponent();
        }
        public int TP { get; set; }

        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;
            //foreach(Control item in this.Controls)
            //{
            //    TextBox tb = item as TextBox;
            //    tb.Text = "";
            //}

            if(this.TP == 3)
            {
                //insert
            }
            else if(this.TP == 4)
            {
                //update
                RoomInfo room = mea.Obj as RoomInfo;
                txtIsDeflaut.Text = room.IsDefault.ToString();
                txtRMinMoney.Text = room.RoomMinimunConsume.ToString();
                txtRName.Text = room.RoomName;
                txtRPerNum.Text = room.RoomMaxConsumer.ToString();//最多人数
                txtRType.Text = room.RoomType.ToString();
                labId.Text = room.RoomId.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RoomInfo r = new RoomInfo();
            
            if(txtRName.Text=="")
            {
                MessageBox.Show("请添加房间名");
                return;
            }
            if(txtRType.Text == "")
            {
                MessageBox.Show("请添加房间类型");
                return;
            }
            if(txtRMinMoney.Text=="")
            {
                MessageBox.Show("请添加房间的最低消费");
                return;
            }
            if(txtRPerNum.Text == "")
            {
                MessageBox.Show("请添加房间人数");
                return;
            }
            if (txtIsDeflaut.Text == "")
            {
                MessageBox.Show("请添加默认编号");
                return;
            }
            if (txtRName.Text != "" && txtRType.Text != "" && txtRMinMoney.Text!="" && txtRPerNum.Text!="" && txtIsDeflaut.Text!="")
            {
                r.IsDefault = Convert.ToInt32(txtIsDeflaut.Text);
                //r.RoomId = Convert.ToInt32(txtRType.Text);
                r.RoomMaxConsumer = Convert.ToInt32(txtRPerNum.Text);
                r.RoomMinimunConsume = Convert.ToDecimal(txtRMinMoney.Text);
                r.RoomName = txtRName.Text;
                r.RoomType = Convert.ToInt32(txtRType.Text);
                if(this.TP == 3)
                {
                    r.SubBy = 1;
                    r.SubTime = System.DateTime.Now;
                    r.DelFlag = 0;
                }
                else if(this.TP == 4)
                {
                    r.RoomId = Convert.ToInt32(labId.Text);
                }
                RoomInfoBLL bll = new RoomInfoBLL();
                string msg = bll.AddOrUpdate(r,this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
            }
            
            
        }
    }
}
