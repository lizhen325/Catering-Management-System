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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            FrmMemberInfo mem = new FrmMemberInfo();
            mem.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCategory fc = new FrmCategory();
            fc.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //load room information
            LoadRoomInfoByDelFlag(0);
            //load desk information
            LoadDeskInfoByRoomIdAndByTabPageIndex(tabControl1.TabPages[0]);
            //Load other desk
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndex);
        }

        private void tabControl1_SelectedIndex(object sender, EventArgs e)
        {
            LoadDeskInfoByRoomIdAndByTabPageIndex(tabControl1.SelectedTab);
        }

        // load desk
        private void LoadDeskInfoByRoomIdAndByTabPageIndex(TabPage tp)
        {
            // RoomInfo object
            RoomInfo r = tp.Tag as RoomInfo;
            // ListView object
            ListView lv = tp.Controls[0] as ListView;
            lv.Clear();

            DeskInfoBLL bll = new DeskInfoBLL();
            //get deskinfo based on roomId
            List<DeskInfo> listDesk = bll.GetAllDeskInfoByRoomId(r.RoomId);
            for(int i=0; i<listDesk.Count; i++)
            {
                lv.Items.Add(listDesk[i].DeskName,listDesk[i].DeskState);
                lv.Items[i].Tag = listDesk[i];
            }
        }

        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> listRoom = bll.GetAllRoomInfoByDelFlag(p);
            for(int i=0; i<listRoom.Count; i++)
            {
                // tab object
                TabPage tp = new TabPage();
                // display room name
                tp.Text = listRoom[i].RoomName;
                // roomInfo object store in tag property
                tp.Tag = listRoom[i];

                // listview object
                ListView lv = new ListView();
                // bind image
                lv.LargeImageList = imageList1;
                // picture show style
                lv.View = View.LargeIcon;
                // fill to listview
                lv.Dock = DockStyle.Fill;
                // listview background color
                lv.BackColor = Color.Green;
                // multiselect 
                lv.MultiSelect = false;

                tp.Controls.Add(lv);
                tabControl1.TabPages.Add(tp);
            }
        }

        public event EventHandler evtFBI;
       

        private void btn_Bill_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;

            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中");
                return;
            }

            //desk State
            if((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 0)
            {
                MessageBox.Show("请选择未开单的餐桌");
                return;
            }
            MyEventArgs mea = new MyEventArgs();
            mea.Obj = lv.SelectedItems[0].Tag;

            FrmBilling fb = new FrmBilling();
            
            //RoomType, RoomMinimumConsume
            mea.Name = (tp.Tag as RoomInfo).RoomName;
            mea.Money = (tp.Tag as RoomInfo).RoomMinimumConsume;

            this.evtFBI += new EventHandler(fb.SetText);
            if(this.evtFBI != null)
            {
                this.evtFBI(this, mea);
                fb.FormClosed += new FormClosedEventHandler(fbi_FormClosed);
                fb.ShowDialog();
            }
        }

        //Load bill button closed
        private void fbi_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByRoomIdAndByTabPageIndex(tabControl1.SelectedTab);
        }

        //增加消费
        public event EventHandler evtFrmMoney;
        private void btnMoney_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;

            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中");
                return;
            }

            //desk State
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请选择要开单的餐桌");
                return;
            }

            //注册事件
            FrmAddMoney fam = new FrmAddMoney();
            this.evtFrmMoney += new EventHandler(fam.SetText);
            MyEventArgs mea = new MyEventArgs();
            mea.Name = (lv.SelectedItems[0].Tag as DeskInfo).DeskName;
            OrderInfoBLL bll = new OrderInfoBLL();
            mea.Temp = bll.GetOrderIdByDeskId((lv.SelectedItems[0].Tag as DeskInfo).DeskId);
            //窗体传值
            if(this.evtFrmMoney != null)
            {
                this.evtFrmMoney(this, mea);
                fam.FormClosed += new FormClosedEventHandler(fbi_FormClosed);
                fam.ShowDialog();
            }
        }

        public event EventHandler evtFBalance;
        //Pay
        private void btnPay_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;

            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中");
                return;
            }

            //desk State
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请选择要开单的餐桌");
                return;
            }
            
            FrmBalance fb = new FrmBalance();
            this.evtFBalance += new EventHandler(fb.SetText);
            MyEventArgs meaFB = new MyEventArgs();
            meaFB.Obj = lv.SelectedItems[0].Tag;
            if(this.evtFBalance != null)
            {
                this.evtFBalance(this, meaFB);
                fb.ShowDialog();
            }
            
        }

      

       

    }
}
