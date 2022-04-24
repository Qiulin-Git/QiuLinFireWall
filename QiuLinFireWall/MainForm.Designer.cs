
namespace QiuLinFireWall
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEnableGW = new System.Windows.Forms.Button();
            this.buttonDeleteGW = new System.Windows.Forms.Button();
            this.buttonUpIpList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCustomDelete = new System.Windows.Forms.Button();
            this.richTextBoxCustomRemoteIp = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxCustomLocalIp = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExCustomApp = new QiuLinFireWall.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxExCustomRuleName = new QiuLinFireWall.TextBoxEx();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomPrevent = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomAllow = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomANY = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomUDP = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomTCP = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomOut = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomIn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCustomAdd = new System.Windows.Forms.Button();
            this.buttonSelectApp = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dvgData = new System.Windows.Forms.DataGridView();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleDirectionTpye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpPriticolTpye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonEnableGW);
            this.groupBox2.Controls.Add(this.buttonDeleteGW);
            this.groupBox2.Controls.Add(this.buttonUpIpList);
            this.groupBox2.Location = new System.Drawing.Point(223, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "禁止国外IP访问";
            // 
            // buttonEnableGW
            // 
            this.buttonEnableGW.BackColor = System.Drawing.Color.LightGreen;
            this.buttonEnableGW.Location = new System.Drawing.Point(11, 82);
            this.buttonEnableGW.Name = "buttonEnableGW";
            this.buttonEnableGW.Size = new System.Drawing.Size(155, 25);
            this.buttonEnableGW.TabIndex = 3;
            this.buttonEnableGW.Text = "启用禁止国外IP访问规则";
            this.buttonEnableGW.UseVisualStyleBackColor = false;
            this.buttonEnableGW.Click += new System.EventHandler(this.buttonEnableGW_Click);
            // 
            // buttonDeleteGW
            // 
            this.buttonDeleteGW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteGW.Location = new System.Drawing.Point(11, 51);
            this.buttonDeleteGW.Name = "buttonDeleteGW";
            this.buttonDeleteGW.Size = new System.Drawing.Size(155, 25);
            this.buttonDeleteGW.TabIndex = 2;
            this.buttonDeleteGW.Text = "删除禁止国外IP访问规则";
            this.buttonDeleteGW.UseVisualStyleBackColor = false;
            this.buttonDeleteGW.Click += new System.EventHandler(this.buttonDeleteGW_Click);
            // 
            // buttonUpIpList
            // 
            this.buttonUpIpList.Location = new System.Drawing.Point(11, 20);
            this.buttonUpIpList.Name = "buttonUpIpList";
            this.buttonUpIpList.Size = new System.Drawing.Size(155, 25);
            this.buttonUpIpList.TabIndex = 1;
            this.buttonUpIpList.Text = "更新本地IP库";
            this.buttonUpIpList.UseVisualStyleBackColor = true;
            this.buttonUpIpList.Click += new System.EventHandler(this.buttonUpIpList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeleteAll);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.buttonEnable);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "防火墙启用与关闭";
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteAll.Location = new System.Drawing.Point(6, 82);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(177, 25);
            this.buttonDeleteAll.TabIndex = 2;
            this.buttonDeleteAll.Text = "删除本程序设置的所有规则";
            this.buttonDeleteAll.UseVisualStyleBackColor = false;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(6, 51);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(177, 25);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭WindowsDefender防火墙";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(6, 20);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(177, 25);
            this.buttonEnable.TabIndex = 0;
            this.buttonEnable.Text = "启用WindowsDefender防火墙";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBox2);
            this.panelLeft.Controls.Add(this.groupBox3);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(411, 621);
            this.panelLeft.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCustomDelete);
            this.groupBox3.Controls.Add(this.richTextBoxCustomRemoteIp);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.richTextBoxCustomLocalIp);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxExCustomApp);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxExCustomRuleName);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonCustomAdd);
            this.groupBox3.Controls.Add(this.buttonSelectApp);
            this.groupBox3.Location = new System.Drawing.Point(12, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 469);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自定义防火墙规则";
            // 
            // buttonCustomDelete
            // 
            this.buttonCustomDelete.BackColor = System.Drawing.Color.Red;
            this.buttonCustomDelete.Location = new System.Drawing.Point(222, 426);
            this.buttonCustomDelete.Name = "buttonCustomDelete";
            this.buttonCustomDelete.Size = new System.Drawing.Size(133, 37);
            this.buttonCustomDelete.TabIndex = 15;
            this.buttonCustomDelete.Text = "删除规则";
            this.buttonCustomDelete.UseVisualStyleBackColor = false;
            this.buttonCustomDelete.Click += new System.EventHandler(this.buttonCustomDelete_Click);
            // 
            // richTextBoxCustomRemoteIp
            // 
            this.richTextBoxCustomRemoteIp.Location = new System.Drawing.Point(211, 195);
            this.richTextBoxCustomRemoteIp.Name = "richTextBoxCustomRemoteIp";
            this.richTextBoxCustomRemoteIp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxCustomRemoteIp.Size = new System.Drawing.Size(166, 222);
            this.richTextBoxCustomRemoteIp.TabIndex = 14;
            this.richTextBoxCustomRemoteIp.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "此规则应用于哪些远程IP地址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "此规则应用于哪些本地IP地址：";
            // 
            // richTextBoxCustomLocalIp
            // 
            this.richTextBoxCustomLocalIp.Location = new System.Drawing.Point(17, 195);
            this.richTextBoxCustomLocalIp.Name = "richTextBoxCustomLocalIp";
            this.richTextBoxCustomLocalIp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxCustomLocalIp.Size = new System.Drawing.Size(171, 222);
            this.richTextBoxCustomLocalIp.TabIndex = 11;
            this.richTextBoxCustomLocalIp.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(65, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "*";
            // 
            // textBoxExCustomApp
            // 
            this.textBoxExCustomApp.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxExCustomApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExCustomApp.EmptyTextTip = "选择应用程序，空表示所有程序";
            this.textBoxExCustomApp.Location = new System.Drawing.Point(71, 141);
            this.textBoxExCustomApp.Name = "textBoxExCustomApp";
            this.textBoxExCustomApp.Size = new System.Drawing.Size(218, 21);
            this.textBoxExCustomApp.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = " 程  序";
            // 
            // textBoxExCustomRuleName
            // 
            this.textBoxExCustomRuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExCustomRuleName.EmptyTextTip = "请输入规则名称";
            this.textBoxExCustomRuleName.Location = new System.Drawing.Point(82, 36);
            this.textBoxExCustomRuleName.Name = "textBoxExCustomRuleName";
            this.textBoxExCustomRuleName.Size = new System.Drawing.Size(106, 21);
            this.textBoxExCustomRuleName.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButtonCustomPrevent);
            this.groupBox6.Controls.Add(this.radioButtonCustomAllow);
            this.groupBox6.Location = new System.Drawing.Point(211, 81);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(166, 46);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "连接类型";
            // 
            // radioButtonCustomPrevent
            // 
            this.radioButtonCustomPrevent.AutoSize = true;
            this.radioButtonCustomPrevent.Checked = true;
            this.radioButtonCustomPrevent.Location = new System.Drawing.Point(85, 20);
            this.radioButtonCustomPrevent.Name = "radioButtonCustomPrevent";
            this.radioButtonCustomPrevent.Size = new System.Drawing.Size(71, 16);
            this.radioButtonCustomPrevent.TabIndex = 1;
            this.radioButtonCustomPrevent.TabStop = true;
            this.radioButtonCustomPrevent.Text = "阻止连接";
            this.radioButtonCustomPrevent.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomAllow
            // 
            this.radioButtonCustomAllow.AutoSize = true;
            this.radioButtonCustomAllow.Location = new System.Drawing.Point(7, 20);
            this.radioButtonCustomAllow.Name = "radioButtonCustomAllow";
            this.radioButtonCustomAllow.Size = new System.Drawing.Size(71, 16);
            this.radioButtonCustomAllow.TabIndex = 0;
            this.radioButtonCustomAllow.Text = "允许连接";
            this.radioButtonCustomAllow.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonCustomANY);
            this.groupBox5.Controls.Add(this.radioButtonCustomUDP);
            this.groupBox5.Controls.Add(this.radioButtonCustomTCP);
            this.groupBox5.Location = new System.Drawing.Point(17, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(171, 46);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "通讯协议规则类型";
            // 
            // radioButtonCustomANY
            // 
            this.radioButtonCustomANY.AutoSize = true;
            this.radioButtonCustomANY.Checked = true;
            this.radioButtonCustomANY.Location = new System.Drawing.Point(119, 20);
            this.radioButtonCustomANY.Name = "radioButtonCustomANY";
            this.radioButtonCustomANY.Size = new System.Drawing.Size(41, 16);
            this.radioButtonCustomANY.TabIndex = 2;
            this.radioButtonCustomANY.TabStop = true;
            this.radioButtonCustomANY.Text = "ANY";
            this.radioButtonCustomANY.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomUDP
            // 
            this.radioButtonCustomUDP.AutoSize = true;
            this.radioButtonCustomUDP.Location = new System.Drawing.Point(63, 21);
            this.radioButtonCustomUDP.Name = "radioButtonCustomUDP";
            this.radioButtonCustomUDP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonCustomUDP.TabIndex = 1;
            this.radioButtonCustomUDP.Text = "UDP";
            this.radioButtonCustomUDP.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomTCP
            // 
            this.radioButtonCustomTCP.AutoSize = true;
            this.radioButtonCustomTCP.Location = new System.Drawing.Point(7, 21);
            this.radioButtonCustomTCP.Name = "radioButtonCustomTCP";
            this.radioButtonCustomTCP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonCustomTCP.TabIndex = 0;
            this.radioButtonCustomTCP.Text = "TCP";
            this.radioButtonCustomTCP.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonCustomOut);
            this.groupBox4.Controls.Add(this.radioButtonCustomIn);
            this.groupBox4.Location = new System.Drawing.Point(211, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 46);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "出入站规则类型";
            // 
            // radioButtonCustomOut
            // 
            this.radioButtonCustomOut.AutoSize = true;
            this.radioButtonCustomOut.Location = new System.Drawing.Point(85, 20);
            this.radioButtonCustomOut.Name = "radioButtonCustomOut";
            this.radioButtonCustomOut.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCustomOut.TabIndex = 1;
            this.radioButtonCustomOut.Text = "出站";
            this.radioButtonCustomOut.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomIn
            // 
            this.radioButtonCustomIn.AutoSize = true;
            this.radioButtonCustomIn.Checked = true;
            this.radioButtonCustomIn.Location = new System.Drawing.Point(7, 20);
            this.radioButtonCustomIn.Name = "radioButtonCustomIn";
            this.radioButtonCustomIn.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCustomIn.TabIndex = 0;
            this.radioButtonCustomIn.TabStop = true;
            this.radioButtonCustomIn.Text = "入站";
            this.radioButtonCustomIn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "规则名称";
            // 
            // buttonCustomAdd
            // 
            this.buttonCustomAdd.BackColor = System.Drawing.Color.LightGreen;
            this.buttonCustomAdd.Location = new System.Drawing.Point(24, 426);
            this.buttonCustomAdd.Name = "buttonCustomAdd";
            this.buttonCustomAdd.Size = new System.Drawing.Size(133, 37);
            this.buttonCustomAdd.TabIndex = 1;
            this.buttonCustomAdd.Text = "添加规则";
            this.buttonCustomAdd.UseVisualStyleBackColor = false;
            this.buttonCustomAdd.Click += new System.EventHandler(this.buttonCustomAdd_Click);
            // 
            // buttonSelectApp
            // 
            this.buttonSelectApp.Location = new System.Drawing.Point(296, 139);
            this.buttonSelectApp.Name = "buttonSelectApp";
            this.buttonSelectApp.Size = new System.Drawing.Size(81, 25);
            this.buttonSelectApp.TabIndex = 0;
            this.buttonSelectApp.Text = "浏 览";
            this.buttonSelectApp.UseVisualStyleBackColor = true;
            this.buttonSelectApp.Click += new System.EventHandler(this.buttonSelectApp_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBox7);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(411, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(573, 621);
            this.panelMain.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dvgData);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(573, 621);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "我设置的规则";
            // 
            // dvgData
            // 
            this.dvgData.BackgroundColor = System.Drawing.Color.White;
            this.dvgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RuleName,
            this.RuleDirectionTpye,
            this.ActionType,
            this.IpPriticolTpye,
            this.AppPath});
            this.dvgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgData.Location = new System.Drawing.Point(3, 17);
            this.dvgData.Name = "dvgData";
            this.dvgData.RowTemplate.Height = 23;
            this.dvgData.Size = new System.Drawing.Size(567, 601);
            this.dvgData.TabIndex = 0;
            // 
            // RuleName
            // 
            this.RuleName.DataPropertyName = "RuleName";
            this.RuleName.HeaderText = "规则名称";
            this.RuleName.Name = "RuleName";
            this.RuleName.ReadOnly = true;
            this.RuleName.Width = 150;
            // 
            // RuleDirectionTpye
            // 
            this.RuleDirectionTpye.DataPropertyName = "RuleDirectionTpye";
            this.RuleDirectionTpye.HeaderText = "规则类型";
            this.RuleDirectionTpye.Name = "RuleDirectionTpye";
            this.RuleDirectionTpye.ReadOnly = true;
            // 
            // ActionType
            // 
            this.ActionType.DataPropertyName = "ActionType";
            this.ActionType.HeaderText = "操作类型";
            this.ActionType.Name = "ActionType";
            this.ActionType.ReadOnly = true;
            // 
            // IpPriticolTpye
            // 
            this.IpPriticolTpye.DataPropertyName = "IpPriticolTpye";
            this.IpPriticolTpye.HeaderText = "通讯类型";
            this.IpPriticolTpye.Name = "IpPriticolTpye";
            this.IpPriticolTpye.ReadOnly = true;
            // 
            // AppPath
            // 
            this.AppPath.DataPropertyName = "AppPath";
            this.AppPath.HeaderText = "应用程序";
            this.AppPath.Name = "AppPath";
            this.AppPath.ReadOnly = true;
            this.AppPath.Width = 200;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows防火墙设置";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonUpIpList;
        private System.Windows.Forms.Button buttonDeleteGW;
        private System.Windows.Forms.Button buttonEnableGW;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCustomAdd;
        private System.Windows.Forms.Button buttonSelectApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonCustomIn;
        private System.Windows.Forms.RadioButton radioButtonCustomOut;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonCustomUDP;
        private System.Windows.Forms.RadioButton radioButtonCustomTCP;
        private System.Windows.Forms.RadioButton radioButtonCustomANY;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonCustomPrevent;
        private System.Windows.Forms.RadioButton radioButtonCustomAllow;
        private TextBoxEx textBoxExCustomRuleName;
        private System.Windows.Forms.Label label3;
        private TextBoxEx textBoxExCustomApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxCustomLocalIp;
        private System.Windows.Forms.RichTextBox richTextBoxCustomRemoteIp;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonCustomDelete;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dvgData;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleDirectionTpye;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpPriticolTpye;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppPath;
    }
}

