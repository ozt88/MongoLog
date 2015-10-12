namespace mongoLogViewer
{
    partial class MongoLogViewer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.FromDateTime = new System.Windows.Forms.DateTimePicker();
            this.ToDateTime = new System.Windows.Forms.DateTimePicker();
            this.LogLevel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ShowButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserId";
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(57, 8);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(84, 21);
            this.userId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(221, 8);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(112, 21);
            this.password.TabIndex = 3;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(371, 8);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(94, 22);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "LogIn";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // FromDateTime
            // 
            this.FromDateTime.Enabled = false;
            this.FromDateTime.Location = new System.Drawing.Point(339, 49);
            this.FromDateTime.Name = "FromDateTime";
            this.FromDateTime.Size = new System.Drawing.Size(200, 21);
            this.FromDateTime.TabIndex = 7;
            // 
            // ToDateTime
            // 
            this.ToDateTime.Enabled = false;
            this.ToDateTime.Location = new System.Drawing.Point(545, 48);
            this.ToDateTime.Name = "ToDateTime";
            this.ToDateTime.Size = new System.Drawing.Size(200, 21);
            this.ToDateTime.TabIndex = 8;
            // 
            // LogLevel
            // 
            this.LogLevel.Enabled = false;
            this.LogLevel.FormattingEnabled = true;
            this.LogLevel.Items.AddRange(new object[] {
            "ALL",
            "DEBUG",
            "INFO",
            "WARN",
            "FATAL"});
            this.LogLevel.Location = new System.Drawing.Point(194, 49);
            this.LogLevel.Name = "LogLevel";
            this.LogLevel.Size = new System.Drawing.Size(130, 20);
            this.LogLevel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Level";
            // 
            // ShowButton
            // 
            this.ShowButton.Enabled = false;
            this.ShowButton.Location = new System.Drawing.Point(751, 12);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(113, 57);
            this.ShowButton.TabIndex = 14;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Level,
            this.Time,
            this.Log});
            this.dataGridView.Location = new System.Drawing.Point(12, 89);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(850, 318);
            this.dataGridView.TabIndex = 15;
            // 
            // Level
            // 
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.Width = 50;
            // 
            // Time
            // 
            this.Time.HeaderText = "TIme";
            this.Time.Name = "Time";
            // 
            // Log
            // 
            this.Log.FillWeight = 1000F;
            this.Log.HeaderText = "Log";
            this.Log.Name = "Log";
            this.Log.Width = 700;
            // 
            // nameBox
            // 
            this.nameBox.Enabled = false;
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Items.AddRange(new object[] {
            "ALL",
            "DEBUG",
            "INFO",
            "WARN",
            "FATAL"});
            this.nameBox.Location = new System.Drawing.Point(57, 48);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(90, 20);
            this.nameBox.TabIndex = 16;
            // 
            // MongoLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 419);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LogLevel);
            this.Controls.Add(this.ToDateTime);
            this.Controls.Add(this.FromDateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userId);
            this.Controls.Add(this.label1);
            this.Name = "MongoLogViewer";
            this.Text = "MongoLogViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker FromDateTime;
        private System.Windows.Forms.DateTimePicker ToDateTime;
        private System.Windows.Forms.ComboBox LogLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log;
        private System.Windows.Forms.ComboBox nameBox;

    }
}

