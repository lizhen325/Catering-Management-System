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
            LoadRoomInfoByDelFlag(0);
        }

        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            List<RoomInfo> listRoom = bll.GetAllRoomInfoByDelFlag(p);
            for(int i=0; i<listRoom.Count; i++)
            {
                TabPage tp = new TabPage();
                tp.Text = listRoom[i].RoomName;
                tabControl1.TabPages.Add(tp);
            }
        }

        
        
    }
}
