namespace PresentationLayer
{
    partial class HomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.makeAnOrderBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.makeAReservationBtn = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // makeAnOrderBtn
            // 
            this.makeAnOrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(186)))));
            this.makeAnOrderBtn.FlatAppearance.BorderSize = 3;
            this.makeAnOrderBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.makeAnOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeAnOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeAnOrderBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.makeAnOrderBtn.Location = new System.Drawing.Point(104, 186);
            this.makeAnOrderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.makeAnOrderBtn.Name = "makeAnOrderBtn";
            this.makeAnOrderBtn.Size = new System.Drawing.Size(225, 190);
            this.makeAnOrderBtn.TabIndex = 4;
            this.makeAnOrderBtn.Text = "Make an Order";
            this.makeAnOrderBtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.knife_fork_svgrepo_com;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(903, 596);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // makeAReservationBtn
            // 
            this.makeAReservationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(186)))));
            this.makeAReservationBtn.FlatAppearance.BorderSize = 3;
            this.makeAReservationBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.makeAReservationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeAReservationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeAReservationBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.makeAReservationBtn.Location = new System.Drawing.Point(560, 186);
            this.makeAReservationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.makeAReservationBtn.Name = "makeAReservationBtn";
            this.makeAReservationBtn.Size = new System.Drawing.Size(225, 190);
            this.makeAReservationBtn.TabIndex = 6;
            this.makeAReservationBtn.Text = "Make a Reservation";
            this.makeAReservationBtn.UseVisualStyleBackColor = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.welcomeLabel.Location = new System.Drawing.Point(222, 0);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(400, 31);
            this.welcomeLabel.TabIndex = 7;
            this.welcomeLabel.Text = "WELCOME, ALEKSANDAR";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.makeAReservationBtn);
            this.Controls.Add(this.makeAnOrderBtn);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeUserControl";
            this.Size = new System.Drawing.Size(903, 596);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button makeAnOrderBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button makeAReservationBtn;
        private System.Windows.Forms.Label welcomeLabel;
    }
}
