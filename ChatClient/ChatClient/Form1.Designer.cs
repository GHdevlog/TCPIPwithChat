namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            textBox1 = new TextBox();
            btnSend = new Button();
            label1 = new Label();
            lbCount = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(43, 33);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(150, 70);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "연결";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 109);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(43, 155);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(150, 100);
            btnSend.TabIndex = 2;
            btnSend.Text = "메세지 전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 399);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 3;
            label1.Text = "Count : ";
            // 
            // lbCount
            // 
            lbCount.AutoSize = true;
            lbCount.Location = new Point(147, 399);
            lbCount.Name = "lbCount";
            lbCount.Size = new Size(22, 25);
            lbCount.TabIndex = 4;
            lbCount.Text = "0";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(233, 35);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(465, 379);
            listBox1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(lbCount);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(textBox1);
            Controls.Add(btnConnect);
            Cursor = Cursors.Default;
            Name = "Form1";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private TextBox textBox1;
        private Button btnSend;
        private Label label1;
        private Label lbCount;
        private ListBox listBox1;
    }
}
