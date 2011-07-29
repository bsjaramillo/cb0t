namespace cb0t_chat_client_v2
{
    partial class Scribble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scribble));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.colorButton1 = new cb0t_chat_client_v2.ColorButton();
            this.scribbleScreen1 = new cb0t_chat_client_v2.ScribbleScreen();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(67, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "·";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(88, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(18, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "•";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gainsboro;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(109, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(18, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "●";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // colorButton1
            // 
            this.colorButton1.Location = new System.Drawing.Point(12, 204);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.SelectedColor = System.Drawing.Color.Red;
            this.colorButton1.Size = new System.Drawing.Size(46, 23);
            this.colorButton1.TabIndex = 1;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // scribbleScreen1
            // 
            this.scribbleScreen1.AllowDrop = true;
            this.scribbleScreen1.BackColor = System.Drawing.Color.White;
            this.scribbleScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scribbleScreen1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.scribbleScreen1.Location = new System.Drawing.Point(12, 12);
            this.scribbleScreen1.Name = "scribbleScreen1";
            this.scribbleScreen1.Size = new System.Drawing.Size(512, 186);
            this.scribbleScreen1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(434, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button5.Location = new System.Drawing.Point(482, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Send";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Scribble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 232);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorButton1);
            this.Controls.Add(this.scribbleScreen1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(554, 268);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(554, 268);
            this.Name = "Scribble";
            this.Text = "Scribble";
            this.Move += new System.EventHandler(this.Scribble_Move);
            this.ResumeLayout(false);

        }

        #endregion

        private ScribbleScreen scribbleScreen1;
        private ColorButton colorButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}