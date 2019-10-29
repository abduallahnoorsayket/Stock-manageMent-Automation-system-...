namespace StockManagementSystem.UI
{
    partial class AddCustomerUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomerUi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveOrUpdateButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.addressErrorLabel = new System.Windows.Forms.Label();
            this.loyaltyPointErrorLabel = new System.Windows.Forms.Label();
            this.contactErrorLabel = new System.Windows.Forms.Label();
            this.emailErrorLabel = new System.Windows.Forms.Label();
            this.nameErrorLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.loyaltyPointTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(158)))), ((int)(((byte)(132)))));
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 40);
            this.panel1.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(388, 9);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveOrUpdateButton
            // 
            this.saveOrUpdateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveOrUpdateButton.Location = new System.Drawing.Point(152, 383);
            this.saveOrUpdateButton.Name = "saveOrUpdateButton";
            this.saveOrUpdateButton.Size = new System.Drawing.Size(77, 28);
            this.saveOrUpdateButton.TabIndex = 21;
            this.saveOrUpdateButton.Text = "Save";
            this.saveOrUpdateButton.UseVisualStyleBackColor = true;
            this.saveOrUpdateButton.Click += new System.EventHandler(this.saveOrUpdateButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(155, 292);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(188, 63);
            this.addressTextBox.TabIndex = 19;
            this.addressTextBox.TextChanged += new System.EventHandler(this.addressTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(24, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Loyalty Point:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(26, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Contact:";
            // 
            // contactTextBox
            // 
            this.contactTextBox.Location = new System.Drawing.Point(155, 205);
            this.contactTextBox.MaxLength = 11;
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(188, 27);
            this.contactTextBox.TabIndex = 17;
            this.contactTextBox.TextChanged += new System.EventHandler(this.contactTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(26, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(155, 157);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(188, 27);
            this.emailTextBox.TabIndex = 16;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(26, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Address:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(155, 112);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(188, 27);
            this.nameTextBox.TabIndex = 15;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Enabled = false;
            this.codeTextBox.Location = new System.Drawing.Point(155, 65);
            this.codeTextBox.MaxLength = 4;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(188, 27);
            this.codeTextBox.TabIndex = 20;
            // 
            // addressErrorLabel
            // 
            this.addressErrorLabel.AutoSize = true;
            this.addressErrorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.addressErrorLabel.Location = new System.Drawing.Point(152, 353);
            this.addressErrorLabel.Name = "addressErrorLabel";
            this.addressErrorLabel.Size = new System.Drawing.Size(99, 20);
            this.addressErrorLabel.TabIndex = 14;
            this.addressErrorLabel.Text = "ErrorMessage";
            // 
            // loyaltyPointErrorLabel
            // 
            this.loyaltyPointErrorLabel.AutoSize = true;
            this.loyaltyPointErrorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loyaltyPointErrorLabel.Location = new System.Drawing.Point(152, 276);
            this.loyaltyPointErrorLabel.Name = "loyaltyPointErrorLabel";
            this.loyaltyPointErrorLabel.Size = new System.Drawing.Size(99, 20);
            this.loyaltyPointErrorLabel.TabIndex = 10;
            this.loyaltyPointErrorLabel.Text = "ErrorMessage";
            // 
            // contactErrorLabel
            // 
            this.contactErrorLabel.AutoSize = true;
            this.contactErrorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contactErrorLabel.Location = new System.Drawing.Point(152, 231);
            this.contactErrorLabel.Name = "contactErrorLabel";
            this.contactErrorLabel.Size = new System.Drawing.Size(99, 20);
            this.contactErrorLabel.TabIndex = 8;
            this.contactErrorLabel.Text = "ErrorMessage";
            // 
            // emailErrorLabel
            // 
            this.emailErrorLabel.AutoSize = true;
            this.emailErrorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.emailErrorLabel.Location = new System.Drawing.Point(148, 183);
            this.emailErrorLabel.Name = "emailErrorLabel";
            this.emailErrorLabel.Size = new System.Drawing.Size(99, 20);
            this.emailErrorLabel.TabIndex = 6;
            this.emailErrorLabel.Text = "ErrorMessage";
            // 
            // nameErrorLabel
            // 
            this.nameErrorLabel.AutoSize = true;
            this.nameErrorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameErrorLabel.Location = new System.Drawing.Point(152, 138);
            this.nameErrorLabel.Name = "nameErrorLabel";
            this.nameErrorLabel.Size = new System.Drawing.Size(99, 20);
            this.nameErrorLabel.TabIndex = 4;
            this.nameErrorLabel.Text = "ErrorMessage";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label.Location = new System.Drawing.Point(26, 68);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(47, 20);
            this.label.TabIndex = 3;
            this.label.Text = "Code:";
            // 
            // loyaltyPointTextBox
            // 
            this.loyaltyPointTextBox.Location = new System.Drawing.Point(156, 253);
            this.loyaltyPointTextBox.Name = "loyaltyPointTextBox";
            this.loyaltyPointTextBox.Size = new System.Drawing.Size(187, 27);
            this.loyaltyPointTextBox.TabIndex = 22;
            // 
            // AddCustomerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 423);
            this.Controls.Add(this.loyaltyPointTextBox);
            this.Controls.Add(this.saveOrUpdateButton);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.addressErrorLabel);
            this.Controls.Add(this.loyaltyPointErrorLabel);
            this.Controls.Add(this.contactErrorLabel);
            this.Controls.Add(this.emailErrorLabel);
            this.Controls.Add(this.nameErrorLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddCustomerUi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCustomerUi";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddCustomerUi_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label addressErrorLabel;
        private System.Windows.Forms.Label loyaltyPointErrorLabel;
        private System.Windows.Forms.Label contactErrorLabel;
        private System.Windows.Forms.Label emailErrorLabel;
        private System.Windows.Forms.Label nameErrorLabel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Button saveOrUpdateButton;
        public System.Windows.Forms.TextBox addressTextBox;
        public System.Windows.Forms.TextBox contactTextBox;
        public System.Windows.Forms.TextBox emailTextBox;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.TextBox codeTextBox;
        public System.Windows.Forms.TextBox loyaltyPointTextBox;
    }
}