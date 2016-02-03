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
    public partial class FrmUpdateMemberInfo : Form
    {
        public FrmUpdateMemberInfo()
        {
            InitializeComponent();
        }


        private int TP { get; set; }

        //直接写个方法，不要load方法
        private void LoadMemberTypeByDelFlag(int p)
        {
            MemberTypeBAL bll = new MemberTypeBAL();
            List<MemberType> list = bll.GetAllMemberTypeByDelFlag(p);
            list.Insert(0, new MemberType() { MemType = -1, MemTpName = "请选择" });
            cmbMemType.DataSource = list;
            cmbMemType.DisplayMember = "MemTpName";
            cmbMemType.ValueMember = "MemType";
        }
        /// <summary>
        /// 为该窗体中的所有文本框赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetText(object sender, EventArgs e)
        {
            LoadMemberTypeByDelFlag(0);
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;//标识存起来
            if (mea.Temp == 1)
            {
                //新增
                //foreach(Control item in this.Controls)
                //{
                //    TextBox tb = item as TextBox;
                //    tb.Text = "";
                //}
                txtMemIntegral.Text = "0";
                rdoMan.Checked = true;
            }

            else if (mea.Temp == 2)
            {
                //修改
                //赋值
                MemberInfo mem = mea.Obj as MemberInfo;//获取会员对象
                //先保证id存起来
                labId.Text = mem.MemmberId.ToString();
                //为每个文本框赋值
                //会员的等级必须显示出来
                txtBirs.Text = mem.MemBirthdaty.ToString();
                txtMemDiscount.Text = mem.MemDiscount.ToString();
                txtMemIntegral.Text = mem.MemIntegral.ToString();
                txtmemMoney.Text = mem.MemMoney.ToString();
                txtMemName.Text = mem.MemName;
                txtMemNum.Text = mem.MemNum;
                txtMemPhone.Text = mem.MemMobilePhone;
                rdoMan.Checked = mem.MemGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemGender == "女" ? true : false;
                dtEndServerTime.Value = Convert.ToDateTime(mem.MemEndServerTime);
                //绑定会员的等级
                cmbMemType.SelectedValue = mem.MemType;
            }
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                //获取每一个文本框的值
                MemberInfo mem = new MemberInfo();
                mem.MemBirthdaty = Convert.ToDateTime(txtBirs.Text);
                mem.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                mem.MemEndServerTime = Convert.ToDateTime(dtEndServerTime.Text);
                mem.MemGender = CheckGender();
                mem.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                //mem.MemmberId = Convert.ToInt32(labId.Text);
                mem.MemMobilePhone = txtMemPhone.Text;
                mem.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                mem.MemNum = txtMemNum.Text;
                mem.MemNum = txtMemName.Text;
                mem.MemType = Convert.ToInt32(cmbMemType.SelectedValue);
                if (this.TP == 1)
                {
                    //Insert
                    mem.SubTime = System.DateTime.Now;
                    mem.DelFlag = 0;
                }
                else if (this.TP == 2)
                {
                    //Update
                    mem.MemmberId = Convert.ToInt32(labId.Text);
                }
                MemberInfoBLL bll = new MemberInfoBLL();
                string msg = bll.SaveMemberInfo(mem, this.TP)?"操作成功":"操作失败";
                MessageBox.Show(msg);
                this.Close();
            }

        }

        private string CheckGender()
        {
            string str = "";
            if(rdoMan.Checked)
            {
                str = "男";
            }
            else if(rdoWomen.Checked)
            {
                str = "女";
            }
            return str;
        }

        private bool CheckEmpty()
        {
            if(string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            if(string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("钱不能为空");
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
            }
            if(cmbMemType.SelectedIndex==0)
            {
                MessageBox.Show("请选择会员级别");
                return false;
            }
            
            return true;

        }
    }
}
