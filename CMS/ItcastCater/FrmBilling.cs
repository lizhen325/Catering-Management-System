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

        private void btnOK_Click(object sender, EventArgs e)
        {
            //change desk state

        }

        
    }
}
