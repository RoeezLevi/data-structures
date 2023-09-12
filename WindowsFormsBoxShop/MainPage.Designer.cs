namespace WindowsFormsBoxShop
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.ManagerButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EXITbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ManagerButton
            // 
            this.ManagerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerButton.Location = new System.Drawing.Point(333, 443);
            this.ManagerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ManagerButton.Name = "ManagerButton";
            this.ManagerButton.Size = new System.Drawing.Size(336, 81);
            this.ManagerButton.TabIndex = 0;
            this.ManagerButton.Text = "Manager";
            this.ManagerButton.UseVisualStyleBackColor = true;
            this.ManagerButton.Click += new System.EventHandler(this.ManagerButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(333, 340);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(336, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "Customer ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to the BOX STORE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EXITbutton
            // 
            this.EXITbutton.BackColor = System.Drawing.Color.Crimson;
            this.EXITbutton.Location = new System.Drawing.Point(970, 0);
            this.EXITbutton.Name = "EXITbutton";
            this.EXITbutton.Size = new System.Drawing.Size(33, 27);
            this.EXITbutton.TabIndex = 3;
            this.EXITbutton.Text = "X";
            this.EXITbutton.UseMnemonic = false;
            this.EXITbutton.UseVisualStyleBackColor = false;
            this.EXITbutton.Click += new System.EventHandler(this.EXITbutton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 563);
            this.Controls.Add(this.EXITbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ManagerButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ManagerButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EXITbutton;
    }
}