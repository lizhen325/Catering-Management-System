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
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }

        private static FrmRoom _instance;

        public FrmRoom Instance
        {
            get
            {
                if(_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmRoom();
                }
                return _instance;
            }
            
        }

        private void FrmRoom_Load(object sender, EventArgs e)
        {
            //Load Room Info
            LoadRoomByDelFlag(0);
            
            //Load DeskInfo
            LoadDeskInfoByDelFlag(0);
        }

        //load desk
        private void LoadDeskInfoByDelFlag(int p)
        {
            DeskInfoBLL bll = new DeskInfoBLL();
            dgvDeskInfo.AutoGenerateColumns = false;
            dgvDeskInfo.DataSource = bll.GetAllDeskInfoByDelFlag(p);
            dgvDeskInfo.SelectedRows[0].Selected = false;
            
            
        }

        //load room
        private void LoadRoomByDelFlag(int p)
        {
            RoomInfoBLL bll = new RoomInfoBLL();
            dgvRoomInfo.AutoGenerateColumns = false; ;
            dgvRoomInfo.DataSource = bll.GetAllRoomInfoByDelFlag(p);
            dgvRoomInfo.SelectedRows[0].Selected = false;
        }

        //Add Room =>3
        public event EventHandler evtRoom;
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            LoadFrmChangeRoom(3);
        }

        MyEventArgs meaRoom = new MyEventArgs();
        private void LoadFrmChangeRoom(int p)
        {
            FrmChangeRoom fcr = new FrmChangeRoom();
            this.evtRoom += new EventHandler(fcr.SetText);
            meaRoom.Temp = p;
            if(this.evtRoom != null)
            {
                this.evtRoom(this, meaRoom);
                fcr.FormClosed += new FormClosedEventHandler(fcr_FormClosed);
                fcr.ShowDialog();
            }
        }

        private void fcr_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadRoomByDelFlag(0);
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if(dgvRoomInfo.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value.ToString());
                RoomInfoBLL bll = new RoomInfoBLL();
                meaRoom.Obj = bll.GetRoomInfoByRoomId(id);
                LoadFrmChangeRoom(4);
            }
            else
            {
                MessageBox.Show("请选择要修改房间的行数");
            }
        }

        /// <summary>
        /// delete room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            //RoomInfoBLL bll = new RoomInfoBLL();
            if(dgvRoomInfo.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvRoomInfo.SelectedRows[0].Cells[0].Value.ToString());
                DeskInfoBLL dbll = new DeskInfoBLL();
                if(dbll.GetDeskCountByRoomId(id))
                {
                    MessageBox.Show("房间有桌子不能删除");
                }
                else
                {
                    RoomInfoBLL rbll = new RoomInfoBLL();
                    if(rbll.SoftDeleteRoomInfoByRoomId(id))
                    {
                        MessageBox.Show("操作成功");
                        LoadRoomByDelFlag(0);
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的房间");
            }
        }


    }
}
