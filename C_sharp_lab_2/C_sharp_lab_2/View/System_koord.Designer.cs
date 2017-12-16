namespace C_sharp_lab_2
{
    partial class System_koord
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
            this.numericUpDown_pitch = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pitch)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_pitch
            // 
            this.numericUpDown_pitch.DecimalPlaces = 1;
            this.numericUpDown_pitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_pitch.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_pitch.Location = new System.Drawing.Point(119, 17);
            this.numericUpDown_pitch.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_pitch.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown_pitch.Name = "numericUpDown_pitch";
            this.numericUpDown_pitch.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_pitch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Угол тангажа:";
            // 
            // System_koord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 113);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_pitch);
            this.Name = "System_koord";
            this.Text = "Система координат";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_pitch;
        private System.Windows.Forms.Label label1;
    }
}