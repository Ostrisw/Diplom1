namespace Dip
{
    partial class Select_Kafedra_Form
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
            this.F3_dgv_select_kafedra = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.F3_dgv_select_kafedra)).BeginInit();
            this.SuspendLayout();
            // 
            // F3_dgv_select_kafedra
            // 
            this.F3_dgv_select_kafedra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.F3_dgv_select_kafedra.Location = new System.Drawing.Point(12, 12);
            this.F3_dgv_select_kafedra.Name = "F3_dgv_select_kafedra";
            this.F3_dgv_select_kafedra.ReadOnly = true;
            this.F3_dgv_select_kafedra.Size = new System.Drawing.Size(347, 219);
            this.F3_dgv_select_kafedra.TabIndex = 0;
            this.F3_dgv_select_kafedra.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.F3_dgv_select_kafedra_CellMouseDoubleClick_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(380, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // Select_Kafedra_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 240);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.F3_dgv_select_kafedra);
            this.Name = "Select_Kafedra_Form";
            this.Text = "Выбор кафедры";
            ((System.ComponentModel.ISupportInitialize)(this.F3_dgv_select_kafedra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView F3_dgv_select_kafedra;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}