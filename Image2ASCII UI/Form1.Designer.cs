namespace Image2ASCII_UI
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
            path = new TextBox();
            label1 = new Label();
            multiplier = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // path
            // 
            path.Location = new Point(270, 178);
            path.Name = "path";
            path.PlaceholderText = "path/to/image.png";
            path.Size = new Size(235, 23);
            path.TabIndex = 0;
            path.Tag = "input";
            path.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 160);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 1;
            label1.Text = "Image Path";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            // 
            // multiplier
            // 
            multiplier.Location = new Point(270, 222);
            multiplier.Name = "multiplier";
            multiplier.Size = new Size(30, 23);
            multiplier.TabIndex = 2;
            multiplier.Tag = "sizeMultiplier";
            multiplier.Text = "1";
            multiplier.TextAlign = HorizontalAlignment.Center;
            multiplier.TextChanged += multiplier_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 204);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 3;
            label2.Text = "Size Multiplier";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(338, 262);
            button1.Name = "button1";
            button1.Size = new Size(90, 39);
            button1.TabIndex = 5;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(255, 44);
            label3.Name = "label3";
            label3.Size = new Size(265, 59);
            label3.TabIndex = 6;
            label3.Text = "Image2ASCII";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 465);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(multiplier);
            Controls.Add(label1);
            Controls.Add(path);
            Name = "Image2ASCII";
            Text = "Image2ASCII";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox path;
        private Label label1;
        private TextBox multiplier;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}