namespace TcpServer_Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.nickName_Textbox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Message_Textbox = new System.Windows.Forms.TextBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.ChatLog_textbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nickname :";
            // 
            // nickName_Textbox
            // 
            this.nickName_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickName_Textbox.Location = new System.Drawing.Point(106, 10);
            this.nickName_Textbox.Name = "nickName_Textbox";
            this.nickName_Textbox.Size = new System.Drawing.Size(167, 26);
            this.nickName_Textbox.TabIndex = 1;
            this.nickName_Textbox.Text = "Guest";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(17, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 304);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Message_Textbox
            // 
            this.Message_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Textbox.Location = new System.Drawing.Point(17, 400);
            this.Message_Textbox.Name = "Message_Textbox";
            this.Message_Textbox.Size = new System.Drawing.Size(665, 26);
            this.Message_Textbox.TabIndex = 4;
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(689, 400);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(99, 26);
            this.Send_Button.TabIndex = 5;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Connect_Button
            // 
            this.Connect_Button.Location = new System.Drawing.Point(17, 353);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(256, 41);
            this.Connect_Button.TabIndex = 6;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // ChatLog_textbox
            // 
            this.ChatLog_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatLog_textbox.Location = new System.Drawing.Point(280, 42);
            this.ChatLog_textbox.Name = "ChatLog_textbox";
            this.ChatLog_textbox.Size = new System.Drawing.Size(508, 352);
            this.ChatLog_textbox.TabIndex = 7;
            this.ChatLog_textbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChatLog_textbox);
            this.Controls.Add(this.Connect_Button);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.Message_Textbox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.nickName_Textbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nickName_Textbox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox Message_Textbox;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.RichTextBox ChatLog_textbox;
    }
}

