namespace Viselka
{
    partial class FormViselka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViselka));
            this.picStep = new System.Windows.Forms.PictureBox();
            this.labelWord = new System.Windows.Forms.Label();
            this.panelKeys = new System.Windows.Forms.Panel();
            this.txtList = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStep)).BeginInit();
            this.SuspendLayout();
            // 
            // picStep
            // 
            this.picStep.BackColor = System.Drawing.Color.White;
            this.picStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStep.Image = global::Viselka.Properties.Resources.step0;
            this.picStep.Location = new System.Drawing.Point(0, 2);
            this.picStep.Name = "picStep";
            this.picStep.Size = new System.Drawing.Size(200, 250);
            this.picStep.TabIndex = 0;
            this.picStep.TabStop = false;
            // 
            // labelWord
            // 
            this.labelWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelWord.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWord.Location = new System.Drawing.Point(207, 2);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(452, 66);
            this.labelWord.TabIndex = 1;
            this.labelWord.Text = "****";
            this.labelWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWord.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelWord_MouseDoubleClick);
            // 
            // panelKeys
            // 
            this.panelKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKeys.Location = new System.Drawing.Point(207, 72);
            this.panelKeys.Name = "panelKeys";
            this.panelKeys.Size = new System.Drawing.Size(452, 174);
            this.panelKeys.TabIndex = 2;
            // 
            // txtList
            // 
            this.txtList.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtList.Location = new System.Drawing.Point(0, 2);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtList.Size = new System.Drawing.Size(200, 250);
            this.txtList.TabIndex = 3;
            this.txtList.Visible = false;
            // 
            // FormViselka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 258);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.panelKeys);
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.picStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormViselka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра виселка";
            ((System.ComponentModel.ISupportInitialize)(this.picStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picStep;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Panel panelKeys;
        private System.Windows.Forms.TextBox txtList;
    }
}

