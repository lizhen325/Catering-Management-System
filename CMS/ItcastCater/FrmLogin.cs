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

namespace ItcastCater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断用户登录是否成功
            if(CheckText())
            {
                UserInfoBLL bll = new UserInfoBLL();
                string msg = "";
                bool flag = bll.IsLoginByLoginName(txtName.Text,txtPwd.Text,out msg);
                if(flag)
                {
                    msgDiv1.MsgDivShow(msg, 1,Bind);
                }
                else
                {
                    msgDiv1.MsgDivShow(msg, 1);
                }
            }
            //设置当前的登陆窗口值
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Bind()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 该方法是判断账号和密码不能为空
        /// </summary>
        /// <returns></returns>
        private bool CheckText()
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                msgDiv1.MsgDivShow("账号不能为空", 1);
                return false;
            }
            if(string.IsNullOrEmpty(txtPwd.Text))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }
    }
}
