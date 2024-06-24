namespace ChatServer
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
            btnStart = new Button();
            label1 = new Label();
            lbCount = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(161, 81);
            btnStart.TabIndex = 0;
            btnStart.Text = "시작";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 392);
            label1.Name = "label1";
            label1.Size = new Size(70, 25);
            label1.TabIndex = 1;
            label1.Text = "Count :";
            // 
            // lbCount
            // 
            lbCount.Location = new Point(102, 396);
            lbCount.Name = "lbCount";
            lbCount.Size = new Size(90, 38);
            lbCount.TabIndex = 2;
            lbCount.Text = "0";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(205, 14);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(505, 404);
            listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(lbCount);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label label1;
        private Label lbCount;
        private ListBox listBox1;
    }
}
