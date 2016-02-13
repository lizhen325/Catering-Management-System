namespace ItcastCater
{
    partial class FrmBilling
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.wads = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labLittleMoney = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGetCostsMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labDeskName = new System.Windows.Forms.Label();
            this.labRoomType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersonCount = new System.Windows.Forms.TextBox();
            this.ckbMeal = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(282, 452);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(133, 40);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(467, 452);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(133, 40);
            this.btncancel.TabIndex = 29;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 145);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(380, 127);
            this.txtDescription.TabIndex = 4;
            // 
            // wads
            // 
            this.wads.AutoSize = true;
            this.wads.Location = new System.Drawing.Point(277, 84);
            this.wads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wads.Name = "wads";
            this.wads.Size = new System.Drawing.Size(78, 17);
            this.wads.TabIndex = 3;
            this.wads.Text = "最低消费：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "开单备注：";
            // 
            // labLittleMoney
            // 
            this.labLittleMoney.AutoSize = true;
            this.labLittleMoney.Location = new System.Drawing.Point(368, 84);
            this.labLittleMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLittleMoney.Name = "labLittleMoney";
            this.labLittleMoney.Size = new System.Drawing.Size(46, 17);
            this.labLittleMoney.TabIndex = 3;
            this.labLittleMoney.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.lblGetCostsMoney);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(153, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 29);
            this.panel1.TabIndex = 30;
            // 
            // lblGetCostsMoney
            // 
            this.lblGetCostsMoney.AutoSize = true;
            this.lblGetCostsMoney.Location = new System.Drawing.Point(263, 8);
            this.lblGetCostsMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGetCostsMoney.Name = "lblGetCostsMoney";
            this.lblGetCostsMoney.Size = new System.Drawing.Size(78, 17);
            this.lblGetCostsMoney.TabIndex = 0;
            this.lblGetCostsMoney.Text = "不计房间费";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间计费方法：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "顾客人数:";
            // 
            // labDeskName
            // 
            this.labDeskName.AutoSize = true;
            this.labDeskName.Location = new System.Drawing.Point(120, 43);
            this.labDeskName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDeskName.Name = "labDeskName";
            this.labDeskName.Size = new System.Drawing.Size(46, 17);
            this.labDeskName.TabIndex = 10;
            this.labDeskName.Text = "label7";
            // 
            // labRoomType
            // 
            this.labRoomType.AutoSize = true;
            this.labRoomType.Location = new System.Drawing.Point(367, 43);
            this.labRoomType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRoomType.Name = "labRoomType";
            this.labRoomType.Size = new System.Drawing.Size(46, 17);
            this.labRoomType.TabIndex = 9;
            this.labRoomType.Text = "label6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "房间类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "餐桌编号:";
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Location = new System.Drawing.Point(116, 72);
            this.txtPersonCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Size = new System.Drawing.Size(132, 22);
            this.txtPersonCount.TabIndex = 12;
            // 
            // ckbMeal
            // 
            this.ckbMeal.AutoSize = true;
            this.ckbMeal.Location = new System.Drawing.Point(40, 315);
            this.ckbMeal.Margin = new System.Windows.Forms.Padding(4);
            this.ckbMeal.Name = "ckbMeal";
            this.ckbMeal.Size = new System.Drawing.Size(128, 21);
            this.ckbMeal.TabIndex = 6;
            this.ckbMeal.Text = "开单后添加消费";
            this.ckbMeal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPersonCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labDeskName);
            this.groupBox1.Controls.Add(this.labRoomType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbMeal);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.wads);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labLittleMoney);
            this.groupBox1.Location = new System.Drawing.Point(169, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(523, 352);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顾客开单";
            // 
            // FrmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 501);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmBilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label wads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labLittleMoney;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGetCostsMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labDeskName;
        private System.Windows.Forms.Label labRoomType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPersonCount;
        private System.Windows.Forms.CheckBox ckbMeal;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}