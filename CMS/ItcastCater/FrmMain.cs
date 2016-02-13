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
            //DeskId, DeskName,RoomType, RoomMinimumConsume

        }

       

    }
}
