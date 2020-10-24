namespace Lab1
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.rowsLabel = new System.Windows.Forms.ToolStripLabel();
            this.rowsAddButton = new System.Windows.Forms.ToolStripButton();
            this.rowsDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.columnsLabel = new System.Windows.Forms.ToolStripLabel();
            this.columnsAddButton = new System.Windows.Forms.ToolStripButton();
            this.columnsDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.FormulaTextBox = new System.Windows.Forms.TextBox();
            this.ToolStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowsLabel,
            this.rowsAddButton,
            this.rowsDeleteButton,
            this.columnsLabel,
            this.columnsAddButton,
            this.columnsDeleteButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 28);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(800, 32);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip_ItemClicked);
            // 
            // rowsLabel
            // 
            this.rowsLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.rowsLabel.BackColor = System.Drawing.SystemColors.Window;
            this.rowsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rowsLabel.ImageTransparentColor = System.Drawing.Color.Red;
            this.rowsLabel.Margin = new System.Windows.Forms.Padding(540, 1, 0, 2);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(49, 29);
            this.rowsLabel.Text = "Рядки";
            // 
            // rowsAddButton
            // 
            this.rowsAddButton.AutoSize = false;
            this.rowsAddButton.AutoToolTip = false;
            this.rowsAddButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.rowsAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rowsAddButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rowsAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowsAddButton.Margin = new System.Windows.Forms.Padding(0);
            this.rowsAddButton.Name = "rowsAddButton";
            this.rowsAddButton.Size = new System.Drawing.Size(20, 29);
            this.rowsAddButton.Text = "+";
            this.rowsAddButton.Click += new System.EventHandler(this.rowsAddButton_Click);
            // 
            // rowsDeleteButton
            // 
            this.rowsDeleteButton.AutoSize = false;
            this.rowsDeleteButton.AutoToolTip = false;
            this.rowsDeleteButton.BackColor = System.Drawing.Color.Crimson;
            this.rowsDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rowsDeleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rowsDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowsDeleteButton.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rowsDeleteButton.Name = "rowsDeleteButton";
            this.rowsDeleteButton.Size = new System.Drawing.Size(20, 29);
            this.rowsDeleteButton.Text = "-";
            this.rowsDeleteButton.Click += new System.EventHandler(this.rowsDeleteButton_Click);
            // 
            // columnsLabel
            // 
            this.columnsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.columnsLabel.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(63, 29);
            this.columnsLabel.Text = "Столбці";
            // 
            // columnsAddButton
            // 
            this.columnsAddButton.AutoSize = false;
            this.columnsAddButton.AutoToolTip = false;
            this.columnsAddButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this.columnsAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.columnsAddButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.columnsAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.columnsAddButton.Name = "columnsAddButton";
            this.columnsAddButton.Size = new System.Drawing.Size(20, 29);
            this.columnsAddButton.Text = "+";
            this.columnsAddButton.Click += new System.EventHandler(this.columnsAddButton_Click);
            // 
            // columnsDeleteButton
            // 
            this.columnsDeleteButton.AutoSize = false;
            this.columnsDeleteButton.AutoToolTip = false;
            this.columnsDeleteButton.BackColor = System.Drawing.Color.Crimson;
            this.columnsDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.columnsDeleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.columnsDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.columnsDeleteButton.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.columnsDeleteButton.Name = "columnsDeleteButton";
            this.columnsDeleteButton.Size = new System.Drawing.Size(20, 29);
            this.columnsDeleteButton.Text = "-";
            this.columnsDeleteButton.Click += new System.EventHandler(this.columnsDeleteButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFile,
            this.MenuStripHelp});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip.Size = new System.Drawing.Size(800, 28);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "File";
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
            // 
            // MenuStripFile
            // 
            this.MenuStripFile.Checked = true;
            this.MenuStripFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFileOpen,
            this.MenuStripFileSave});
            this.MenuStripFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStripFile.Name = "MenuStripFile";
            this.MenuStripFile.Size = new System.Drawing.Size(59, 24);
            this.MenuStripFile.Tag = "в";
            this.MenuStripFile.Text = "Файл";
            // 
            // MenuStripFileOpen
            // 
            this.MenuStripFileOpen.BackColor = System.Drawing.SystemColors.Window;
            this.MenuStripFileOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStripFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("MenuStripFileOpen.Image")));
            this.MenuStripFileOpen.Name = "MenuStripFileOpen";
            this.MenuStripFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuStripFileOpen.Size = new System.Drawing.Size(233, 26);
            this.MenuStripFileOpen.Text = "Відкрити";
            this.MenuStripFileOpen.Click += new System.EventHandler(this.MenuStripFileOpen_Click);
            // 
            // MenuStripFileSave
            // 
            this.MenuStripFileSave.BackColor = System.Drawing.Color.White;
            this.MenuStripFileSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStripFileSave.Image = ((System.Drawing.Image)(resources.GetObject("MenuStripFileSave.Image")));
            this.MenuStripFileSave.Name = "MenuStripFileSave";
            this.MenuStripFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuStripFileSave.Size = new System.Drawing.Size(233, 26);
            this.MenuStripFileSave.Text = "Зберегти як...";
            this.MenuStripFileSave.Click += new System.EventHandler(this.MenuStripFileSave_Click);
            // 
            // MenuStripHelp
            // 
            this.MenuStripHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStripHelp.Name = "MenuStripHelp";
            this.MenuStripHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuStripHelp.Size = new System.Drawing.Size(81, 24);
            this.MenuStripHelp.Text = "Справка";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 60);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.ShowCellToolTips = false;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.Size = new System.Drawing.Size(800, 390);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.Text = "dataGridView1";
            this.dataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEnter);
            // 
            // FormulaTextBox
            // 
            this.FormulaTextBox.Location = new System.Drawing.Point(12, 31);
            this.FormulaTextBox.Name = "FormulaTextBox";
            this.FormulaTextBox.Size = new System.Drawing.Size(510, 27);
            this.FormulaTextBox.TabIndex = 3;
            this.FormulaTextBox.Leave += new System.EventHandler(this.FormulaTextBox_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormulaTextBox);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "ExcelLight";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuStripFile;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuStripFileOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuStripFileSave;
        private System.Windows.Forms.ToolStripLabel rowsLabel;
        private System.Windows.Forms.ToolStripButton rowsAddButton;
        private System.Windows.Forms.ToolStripButton rowsDeleteButton;
        private System.Windows.Forms.ToolStripLabel columnsLabel;
        private System.Windows.Forms.ToolStripButton columnsAddButton;
        private System.Windows.Forms.ToolStripButton columnsDeleteButton;
        private System.Windows.Forms.TextBox FormulaTextBox;
        private System.Windows.Forms.ToolStripMenuItem MenuStripHelp;
    }
}

