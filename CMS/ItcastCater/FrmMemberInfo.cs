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
    public partial class FrmMemberInfo : Form
    {
        
        public FrmMemberInfo()
        {
            InitializeComponent();
        }

        private void FrmMemberInfo_Load(object sender, EventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
        }
        
        private void LoadMemberInfoByDelFlag(int p)
        {
            MemberInfoBLL bll = new MemberInfoBLL();
            //禁止自动生成列
            dgvMemmber.AutoGenerateColumns = false;
            dgvMemmber.DataSource = bll.GetAllMemberInfoByDelFlag(0);
            dgvMemmber.SelectedRows[0].Selected = false;
            //dataGridView1.AutoGenerateColumns = false;
            //.DataSource = bll.GetAllMemberInfoByDelFlag(0);
            //禁止默认第一行选中
            //dataGridView1.SelectedRows[0].Selected = false;
        }

        //删除会员
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvMemmber.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
                MemberInfoBLL bll = new MemberInfoBLL();
                string msg = bll.DeleteMemberInfoByMemberId(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadMemberInfoByDelFlag(0);
            }
        }
        public event EventHandler evtMember;
        //标识1----新增，2----修改
        //增加会员
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            ShowFrmUpdateMemberInfo(1);
        }

        //修改会员
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if(dgvMemmber.SelectedRows.Count > 0)
            {
                //获取选中行的id
                //根据id去数据库查询
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
                //去查询数据库数据
                MemberInfoBLL bll = new MemberInfoBLL();
                mea.Obj = bll.GetMemmberInfoByMemmberId(id);
                ShowFrmUpdateMemberInfo(2);
            }
            else
            {
                MessageBox.Show("请选择要修改的行");
            }
            
        }

        MyEventArgs mea = new MyEventArgs();
        public void ShowFrmUpdateMemberInfo(int p)
        {
            FrmUpdateMemberInfo fum = new FrmUpdateMemberInfo();
            this.evtMember += new EventHandler(fum.SetText);
            mea.Temp = p;
            if(this.evtMember!=null)
            {
                this.evtMember(this, mea);
                fum.FormClosed += new FormClosedEventHandler(fum_FormClosed);
                fum.ShowDialog();
            }
            
        }

        private void fum_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                LoadMemberInfoByDelFlag(0);
                return;
            }

            if (char.IsDigit(textBox1.Text[0]))
            {
                n = 2;
            }
            else
            {
                n = 1;
            }
            MemberInfoBLL bll = new MemberInfoBLL();
            dgvMemmber.AutoGenerateColumns = false;
            dgvMemmber.DataSource = bll.GetMemberInfoByNameOrNum(textBox1.Text, n);
            if (dgvMemmber.SelectedRows.Count > 0)
            {
                dgvMemmber.SelectedRows[0].Selected = false;
            }
        }
    }
}
