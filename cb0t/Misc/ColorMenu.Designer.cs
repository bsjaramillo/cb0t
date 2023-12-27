using System.Drawing;

namespace cb0t
{
    partial class ColorMenu
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
            Color[] acols = new Color[]
            {
            Color.White,
            Color.Black,
            Color.Navy,
            Color.Green,
            Color.Red,
            Color.Maroon,
            Color.Purple,
            Color.Orange,
            Color.Yellow,
            Color.Lime,
            Color.Teal,
            Color.Aqua,
            Color.Blue,
            Color.Fuchsia,
            Color.Gray,
            Color.Silver,
            Color.OrangeRed,
            Color.SaddleBrown,
            Color.DarkCyan,
            Color.Indigo,
            Color.Crimson,
            Color.ForestGreen,
            Color.DarkOrchid,
            Color.HotPink,
            Color.DarkSlateGray,
            Color.LightSteelBlue,
            Color.LawnGreen,
            Color.LightSeaGreen,
            Color.BurlyWood,
            Color.Chartreuse,
            Color.DarkGoldenrod,
            Color.DarkMagenta,
            Color.DeepSkyBlue,
            Color.Gold,
            Color.LightCoral,
            Color.MediumPurple,
            Color.Olive,
            Color.PaleVioletRed,
            Color.RosyBrown,
            Color.SeaGreen,
            Color.SlateBlue,
            Color.SpringGreen,
            Color.Tomato,
            Color.Violet,
            Color.Wheat,
            Color.YellowGreen
        };
            ColorMenuItem[] colorMenuItems = new ColorMenuItem[46];
            for (int i = 0; i < acols.Length; i++)
            {

                colorMenuItems[i] = new cb0t.ColorMenuItem();
                colorMenuItems[i].BackColor = acols[0];
                colorMenuItems[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //colorMenuItems[i].Location = new System.Drawing.Point((i % 4) * 33, (i / 12) * 33); // Adjust positioning as needed
                colorMenuItems[i].Name = $"colorMenuItem{i + 1}";
                colorMenuItems[i].Size = new System.Drawing.Size(32, 32);
                colorMenuItems[i].TabIndex = i;
                colorMenuItems[i].Tag = i.ToString("00");
                colorMenuItems[i].BackColor = acols[i]; // Set the color from your array
                colorMenuItems[i].Click += new System.EventHandler(this.ColorClicked);

                // Add the newly created control to your form or container
                //this.Controls.Add(colorMenuItems[i]);
            }
            int columns = 12;
            int elementSize = 32;
            int spacing = 1; // Adjust spacing as needed
            int auxSpacing = 2;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int index = row * columns + col;
                    if (col == 0)
                        auxSpacing = 2;
                    else
                        auxSpacing = 0;
                    if (index < acols.Length)
                    {
                        colorMenuItems[index].Location = new Point(col * (elementSize + spacing)+auxSpacing, row * (elementSize + spacing));
                        this.Controls.Add(colorMenuItems[index]);
                    }
                }
            }
            // 
            // ColorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 246);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);

            #endregion
        }
    }
}