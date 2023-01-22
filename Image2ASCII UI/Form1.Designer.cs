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
            multiplier = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // multiplier
            // 
            multiplier.Location = new Point(338, 224);
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
            label2.Location = new Point(338, 206);
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
            label3.Location = new Point(266, 46);
            label3.Name = "label3";
            label3.Size = new Size(265, 59);
            label3.TabIndex = 6;
            label3.Text = "Image2ASCII";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(338, 162);
            button2.Name = "button2";
            button2.Size = new Size(90, 31);
            button2.TabIndex = 7;
            button2.Text = "Select Image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 465);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(multiplier);
            Name = "Form1";
            Text = "Image2ASCII";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox multiplier;
        private Label label2;
        private Button button1;
        private Label label3;
        private Button button2;
    }
}