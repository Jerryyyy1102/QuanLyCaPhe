namespace QL_CaPhe.Presentation
{
    partial class fr_KetNoiSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_KetNoiSQL));
            this.txt_TenServer = new System.Windows.Forms.TextBox();
            this.txt_TenCSDL = new System.Windows.Forms.TextBox();
            this.panelRounded1 = new QL_CaPhe.PanelRounded();
            this.btn_Dong = new QL_CaPhe.ButtonRounded();
            this.btn_KetNoi = new QL_CaPhe.ButtonRounded();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelRounded1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_TenServer
            // 
            this.txt_TenServer.Location = new System.Drawing.Point(313, 160);
            this.txt_TenServer.Multiline = true;
            this.txt_TenServer.Name = "txt_TenServer";
            this.txt_TenServer.Size = new System.Drawing.Size(322, 36);
            this.txt_TenServer.TabIndex = 0;
            this.txt_TenServer.Text = "YOONA\\SQLEXPRESS";
            // 
            // txt_TenCSDL
            // 
            this.txt_TenCSDL.Location = new System.Drawing.Point(313, 259);
            this.txt_TenCSDL.Multiline = true;
            this.txt_TenCSDL.Name = "txt_TenCSDL";
            this.txt_TenCSDL.Size = new System.Drawing.Size(322, 36);
            this.txt_TenCSDL.TabIndex = 1;
            this.txt_TenCSDL.Text = "QLy_CaPhe";
            // 
            // panelRounded1
            // 
            this.panelRounded1.BackColor = System.Drawing.Color.White;
            this.panelRounded1.BorderRadius = 150;
            this.panelRounded1.Controls.Add(this.btn_Dong);
            this.panelRounded1.Controls.Add(this.btn_KetNoi);
            this.panelRounded1.Controls.Add(this.label6);
            this.panelRounded1.Controls.Add(this.panel1);
            this.panelRounded1.Controls.Add(this.label5);
            this.panelRounded1.ForeColor = System.Drawing.Color.Black;
            this.panelRounded1.GradientAngle = 90F;
            this.panelRounded1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(172)))), ((int)(((byte)(140)))));
            this.panelRounded1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(172)))), ((int)(((byte)(140)))));
            this.panelRounded1.Location = new System.Drawing.Point(224, 68);
            this.panelRounded1.Name = "panelRounded1";
            this.panelRounded1.Size = new System.Drawing.Size(506, 421);
            this.panelRounded1.TabIndex = 8;
            // 
            // btn_Dong
            // 
            this.btn_Dong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(92)))), ((int)(((byte)(44)))));
            this.btn_Dong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(92)))), ((int)(((byte)(44)))));
            this.btn_Dong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Dong.BorderRadius = 10;
            this.btn_Dong.BorderSize = 0;
            this.btn_Dong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Dong.FlatAppearance.BorderSize = 0;
            this.btn_Dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dong.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.ForeColor = System.Drawing.Color.Wheat;
            this.btn_Dong.Location = new System.Drawing.Point(261, 320);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(150, 51);
            this.btn_Dong.TabIndex = 11;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextColor = System.Drawing.Color.Wheat;
            this.btn_Dong.UseVisualStyleBackColor = false;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_KetNoi
            // 
            this.btn_KetNoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(92)))), ((int)(((byte)(44)))));
            this.btn_KetNoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(92)))), ((int)(((byte)(44)))));
            this.btn_KetNoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_KetNoi.BorderRadius = 10;
            this.btn_KetNoi.BorderSize = 0;
            this.btn_KetNoi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_KetNoi.FlatAppearance.BorderSize = 0;
            this.btn_KetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_KetNoi.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KetNoi.ForeColor = System.Drawing.Color.Wheat;
            this.btn_KetNoi.Location = new System.Drawing.Point(105, 320);
            this.btn_KetNoi.Name = "btn_KetNoi";
            this.btn_KetNoi.Size = new System.Drawing.Size(150, 51);
            this.btn_KetNoi.TabIndex = 7;
            this.btn_KetNoi.Text = "Kết nối";
            this.btn_KetNoi.TextColor = System.Drawing.Color.Wheat;
            this.btn_KetNoi.UseVisualStyleBackColor = false;
            this.btn_KetNoi.Click += new System.EventHandler(this.btn_KetNoi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(172)))), ((int)(((byte)(140)))));
            this.label6.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Brown;
            this.label6.Location = new System.Drawing.Point(129, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên Server";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(25, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 103);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(172)))), ((int)(((byte)(140)))));
            this.label5.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(84, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tên Cơ Sở Dữ Liệu";
            // 
            // fr_KetNoiSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(858, 518);
            this.Controls.Add(this.txt_TenCSDL);
            this.Controls.Add(this.txt_TenServer);
            this.Controls.Add(this.panelRounded1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fr_KetNoiSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr_KetNoiSQL";
            this.panelRounded1.ResumeLayout(false);
            this.panelRounded1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TenServer;
        private System.Windows.Forms.TextBox txt_TenCSDL;
        private ButtonRounded btn_KetNoi;
        private PanelRounded panelRounded1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private ButtonRounded btn_Dong;
    }
}