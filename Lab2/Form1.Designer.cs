namespace Lab2
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
            this.one = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.four = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.equals = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // one
            // 
            this.one.Location = new System.Drawing.Point(12, 101);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(109, 48);
            this.one.TabIndex = 0;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(554, 58);
            this.textBox.TabIndex = 1;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // four
            // 
            this.four.Location = new System.Drawing.Point(12, 155);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(109, 48);
            this.four.TabIndex = 2;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // seven
            // 
            this.seven.Location = new System.Drawing.Point(12, 209);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(109, 48);
            this.seven.TabIndex = 3;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = true;
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // two
            // 
            this.two.Location = new System.Drawing.Point(144, 101);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(109, 48);
            this.two.TabIndex = 5;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // five
            // 
            this.five.Location = new System.Drawing.Point(144, 156);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(109, 48);
            this.five.TabIndex = 6;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // eight
            // 
            this.eight.Location = new System.Drawing.Point(144, 209);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(109, 48);
            this.eight.TabIndex = 7;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = true;
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // zero
            // 
            this.zero.Location = new System.Drawing.Point(144, 263);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(109, 51);
            this.zero.TabIndex = 8;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = true;
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // three
            // 
            this.three.Location = new System.Drawing.Point(275, 101);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(109, 48);
            this.three.TabIndex = 9;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // six
            // 
            this.six.Location = new System.Drawing.Point(275, 158);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(109, 45);
            this.six.TabIndex = 10;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = true;
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // nine
            // 
            this.nine.Location = new System.Drawing.Point(275, 209);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(109, 48);
            this.nine.TabIndex = 11;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = true;
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // dot
            // 
            this.dot.Location = new System.Drawing.Point(275, 263);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(109, 51);
            this.dot.TabIndex = 12;
            this.dot.Text = ".";
            this.dot.UseVisualStyleBackColor = true;
            this.dot.Click += new System.EventHandler(this.dot_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(457, 101);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(109, 51);
            this.plus.TabIndex = 13;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(457, 158);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(109, 46);
            this.minus.TabIndex = 14;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // multiply
            // 
            this.multiply.Location = new System.Drawing.Point(457, 210);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(109, 47);
            this.multiply.TabIndex = 15;
            this.multiply.Text = "*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // division
            // 
            this.division.Location = new System.Drawing.Point(457, 263);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(109, 51);
            this.division.TabIndex = 16;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = true;
            this.division.Click += new System.EventHandler(this.division_Click);
            // 
            // equals
            // 
            this.equals.Location = new System.Drawing.Point(91, 344);
            this.equals.Name = "equals";
            this.equals.Size = new System.Drawing.Size(386, 71);
            this.equals.TabIndex = 17;
            this.equals.Text = "=";
            this.equals.UseVisualStyleBackColor = true;
            this.equals.Click += new System.EventHandler(this.equals_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(12, 263);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(109, 51);
            this.clear.TabIndex = 18;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.equals);
            this.Controls.Add(this.division);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.dot);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.six);
            this.Controls.Add(this.three);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.five);
            this.Controls.Add(this.two);
            this.Controls.Add(this.seven);
            this.Controls.Add(this.four);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.one);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button one;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button dot;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button division;
        private System.Windows.Forms.Button equals;
        private System.Windows.Forms.Button clear;
    }
}

