namespace Dip
{
    partial class Glavnayaform
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavnayaform));
            this.dgvSpisokZakupok = new System.Windows.Forms.DataGridView();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dipDataSet = new Dip.DipDataSet();
            this.reportTableAdapter = new Dip.DipDataSetTableAdapters.ReportTableAdapter();
            this.cmbKafedra = new System.Windows.Forms.ComboBox();
            this.cmbKalendarniyGod = new System.Windows.Forms.ComboBox();
            this.lblKafedra = new System.Windows.Forms.Label();
            this.lblKalendarniyGod = new System.Windows.Forms.Label();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdatetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbAllSelect = new System.Windows.Forms.ComboBox();
            this.lblJurnal = new System.Windows.Forms.Label();
            this.cmbPoiskUsera = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisokZakupok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dipDataSet)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSpisokZakupok
            // 
            this.dgvSpisokZakupok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpisokZakupok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpisokZakupok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSpisokZakupok.Location = new System.Drawing.Point(0, 95);
            this.dgvSpisokZakupok.Name = "dgvSpisokZakupok";
            this.dgvSpisokZakupok.ReadOnly = true;
            this.dgvSpisokZakupok.Size = new System.Drawing.Size(1213, 428);
            this.dgvSpisokZakupok.TabIndex = 19;
            this.dgvSpisokZakupok.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpisokZakupok_CellDoubleClick);
            // 
            // reportBindingSource
            // 
            this.reportBindingSource.DataMember = "Report";
            this.reportBindingSource.DataSource = this.dipDataSet;
            // 
            // dipDataSet
            // 
            this.dipDataSet.DataSetName = "DipDataSet";
            this.dipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportTableAdapter
            // 
            this.reportTableAdapter.ClearBeforeFill = true;
            // 
            // cmbKafedra
            // 
            this.cmbKafedra.FormattingEnabled = true;
            this.cmbKafedra.Items.AddRange(new object[] {
            "ФиПМ",
            "КиТП"});
            this.cmbKafedra.Location = new System.Drawing.Point(637, 49);
            this.cmbKafedra.Name = "cmbKafedra";
            this.cmbKafedra.Size = new System.Drawing.Size(121, 21);
            this.cmbKafedra.TabIndex = 25;
            this.cmbKafedra.TextChanged += new System.EventHandler(this.cmbKafedra_TextChanged);
            // 
            // cmbKalendarniyGod
            // 
            this.cmbKalendarniyGod.FormattingEnabled = true;
            this.cmbKalendarniyGod.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbKalendarniyGod.Location = new System.Drawing.Point(406, 49);
            this.cmbKalendarniyGod.Name = "cmbKalendarniyGod";
            this.cmbKalendarniyGod.Size = new System.Drawing.Size(121, 21);
            this.cmbKalendarniyGod.TabIndex = 26;
            this.cmbKalendarniyGod.TextChanged += new System.EventHandler(this.cmbKalendarniyGod_TextChanged);
            // 
            // lblKafedra
            // 
            this.lblKafedra.AutoSize = true;
            this.lblKafedra.Location = new System.Drawing.Point(563, 52);
            this.lblKafedra.Name = "lblKafedra";
            this.lblKafedra.Size = new System.Drawing.Size(55, 13);
            this.lblKafedra.TabIndex = 27;
            this.lblKafedra.Text = "Кафедра:";
            // 
            // lblKalendarniyGod
            // 
            this.lblKalendarniyGod.AutoSize = true;
            this.lblKalendarniyGod.Location = new System.Drawing.Point(304, 52);
            this.lblKalendarniyGod.Name = "lblKalendarniyGod";
            this.lblKalendarniyGod.Size = new System.Drawing.Size(99, 13);
            this.lblKalendarniyGod.TabIndex = 28;
            this.lblKalendarniyGod.Text = "Календарный год:";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.AutoSize = false;
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "&Создать";
            this.addToolStripButton.ToolTipText = "Добавить";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Сохранить в БД";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // UpdatetoolStripButton
            // 
            this.UpdatetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdatetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdatetoolStripButton.Image")));
            this.UpdatetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdatetoolStripButton.Name = "UpdatetoolStripButton";
            this.UpdatetoolStripButton.Size = new System.Drawing.Size(24, 24);
            this.UpdatetoolStripButton.Text = "toolStripButton1";
            this.UpdatetoolStripButton.ToolTipText = "Обновить";
            this.UpdatetoolStripButton.Click += new System.EventHandler(this.UpdatetoolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // startToolStripButton
            // 
            this.startToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripButton.Image")));
            this.startToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripButton.Name = "startToolStripButton";
            this.startToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.startToolStripButton.Text = "&Печать";
            this.startToolStripButton.ToolTipText = "Отправить в печать";
            this.startToolStripButton.Click += new System.EventHandler(this.startToolStripButton_Click);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.UpdatetoolStripButton,
            this.toolStripSeparator6,
            this.toolStripSeparator5,
            this.startToolStripButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1213, 27);
            this.toolStripMenu.TabIndex = 29;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbAllSelect
            // 
            this.cmbAllSelect.FormattingEnabled = true;
            this.cmbAllSelect.Items.AddRange(new object[] {
            "Kafedra_Jurnal",
            "Kbk_Jurnal",
            "Kvr_Jurnal",
            "Sroc_Zakupki_Jurnal",
            "Zakupka_Jurnal"});
            this.cmbAllSelect.Location = new System.Drawing.Point(1025, 49);
            this.cmbAllSelect.Name = "cmbAllSelect";
            this.cmbAllSelect.Size = new System.Drawing.Size(176, 21);
            this.cmbAllSelect.TabIndex = 30;
            this.cmbAllSelect.TextChanged += new System.EventHandler(this.cmbAllSelect_TextChanged_1);
            // 
            // lblJurnal
            // 
            this.lblJurnal.AutoSize = true;
            this.lblJurnal.Location = new System.Drawing.Point(969, 52);
            this.lblJurnal.Name = "lblJurnal";
            this.lblJurnal.Size = new System.Drawing.Size(50, 13);
            this.lblJurnal.TabIndex = 31;
            this.lblJurnal.Text = "Журнал:";
            // 
            // cmbPoiskUsera
            // 
            this.cmbPoiskUsera.Enabled = false;
            this.cmbPoiskUsera.FormattingEnabled = true;
            this.cmbPoiskUsera.Location = new System.Drawing.Point(1025, 49);
            this.cmbPoiskUsera.Name = "cmbPoiskUsera";
            this.cmbPoiskUsera.Size = new System.Drawing.Size(121, 21);
            this.cmbPoiskUsera.TabIndex = 32;
            this.cmbPoiskUsera.Visible = false;
            // 
            // Glavnayaform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1213, 523);
            this.Controls.Add(this.cmbPoiskUsera);
            this.Controls.Add(this.lblJurnal);
            this.Controls.Add(this.cmbAllSelect);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.lblKalendarniyGod);
            this.Controls.Add(this.lblKafedra);
            this.Controls.Add(this.cmbKalendarniyGod);
            this.Controls.Add(this.cmbKafedra);
            this.Controls.Add(this.dgvSpisokZakupok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Glavnayaform";
            this.Text = "Список закупок";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisokZakupok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dipDataSet)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSpisokZakupok;
        private DipDataSet dipDataSet;
        private System.Windows.Forms.BindingSource reportBindingSource;
        private DipDataSetTableAdapters.ReportTableAdapter reportTableAdapter;
        private System.Windows.Forms.ComboBox cmbKafedra;
        private System.Windows.Forms.ComboBox cmbKalendarniyGod;
        private System.Windows.Forms.Label lblKafedra;
        private System.Windows.Forms.Label lblKalendarniyGod;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton UpdatetoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton startToolStripButton;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbAllSelect;
        private System.Windows.Forms.Label lblJurnal;
        private System.Windows.Forms.ComboBox cmbPoiskUsera;
    }
}

