namespace WindowsFormsApplication1
{
    partial class Message
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Message));
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.metroTilePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTilePanel1
            // 
            this.metroTilePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.Controls.Add(this.line1);
            this.metroTilePanel1.ForeColor = System.Drawing.Color.Black;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.metroTilePanel1.Location = new System.Drawing.Point(0, -17);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(600, 269);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.line1.ForeColor = System.Drawing.Color.Black;
            this.line1.Location = new System.Drawing.Point(11, 251);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(651, 23);
            this.line1.TabIndex = 0;
            this.line1.Text = "line1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTileItem2,
            this.metroTileItem3,
            this.metroTileItem1,
            this.metroTileItem4});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.TitleText = "Message Type";
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Symbol = "";
            this.metroTileItem2.SymbolColor = System.Drawing.Color.Cornsilk;
            this.metroTileItem2.Text = "Information";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Symbol = "";
            this.metroTileItem3.SymbolColor = System.Drawing.Color.Gold;
            this.metroTileItem3.Text = "Warning";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.White;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.NotificationMarkColor = System.Drawing.Color.White;
            this.metroTileItem1.Symbol = "";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.LightSteelBlue;
            this.metroTileItem1.Text = "Question ";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.BackColor = System.Drawing.Color.IndianRed;
            this.metroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.IndianRed;
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.Symbol = "";
            this.metroTileItem4.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroTileItem4.Text = "Error";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(240, 256);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Yes/No";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(326, 256);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(122, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Abort/Retry/Ignore";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioButton3.ForeColor = System.Drawing.Color.Black;
            this.radioButton3.Location = new System.Drawing.Point(165, 256);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(40, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "OK";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxEx1.Location = new System.Drawing.Point(23, 280);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(577, 100);
            this.richTextBoxEx1.TabIndex = 4;
            this.richTextBoxEx1.Text = "richTextBoxEx1";
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 396);
            this.Controls.Add(this.richTextBoxEx1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.metroTilePanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Message";
            this.Text = "Message";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTilePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.RadioButton radioButton3;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
    }
}