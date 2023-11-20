﻿namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stockPanel = new System.Windows.Forms.Panel();
            this.customersPanel = new System.Windows.Forms.Panel();
            this.customerDeleteBtn = new System.Windows.Forms.Button();
            this.customerUpdateBtn = new System.Windows.Forms.Button();
            this.customerAddBtn = new System.Windows.Forms.Button();
            this.customerAddressTxtbox = new System.Windows.Forms.TextBox();
            this.customerAddressLbl = new System.Windows.Forms.Label();
            this.customerEmailLbl = new System.Windows.Forms.Label();
            this.customerPhoneLbl = new System.Windows.Forms.Label();
            this.customerEmailTxtbox = new System.Windows.Forms.TextBox();
            this.customerPhoneTxtbox = new System.Windows.Forms.TextBox();
            this.customerNameTxtbox = new System.Windows.Forms.TextBox();
            this.customerNameLbl = new System.Windows.Forms.Label();
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.stockPanel.SuspendLayout();
            this.customersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.warehouseBackground;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.stockPanel);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 681);
            this.panel1.TabIndex = 0;
            // 
            // stockPanel
            // 
            this.stockPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.stockPanel.Controls.Add(this.customersPanel);
            this.stockPanel.Location = new System.Drawing.Point(180, 108);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.Size = new System.Drawing.Size(810, 548);
            this.stockPanel.TabIndex = 5;
            // 
            // customersPanel
            // 
            this.customersPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.customersPanel.Controls.Add(this.customerDeleteBtn);
            this.customersPanel.Controls.Add(this.customerUpdateBtn);
            this.customersPanel.Controls.Add(this.customerAddBtn);
            this.customersPanel.Controls.Add(this.customerAddressTxtbox);
            this.customersPanel.Controls.Add(this.customerAddressLbl);
            this.customersPanel.Controls.Add(this.customerEmailLbl);
            this.customersPanel.Controls.Add(this.customerPhoneLbl);
            this.customersPanel.Controls.Add(this.customerEmailTxtbox);
            this.customersPanel.Controls.Add(this.customerPhoneTxtbox);
            this.customersPanel.Controls.Add(this.customerNameTxtbox);
            this.customersPanel.Controls.Add(this.customerNameLbl);
            this.customersPanel.Controls.Add(this.customerDataGrid);
            this.customersPanel.Location = new System.Drawing.Point(0, 0);
            this.customersPanel.Name = "customersPanel";
            this.customersPanel.Size = new System.Drawing.Size(810, 512);
            this.customersPanel.TabIndex = 0;
            this.customersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.customersPanel_Paint);
            // 
            // customerDeleteBtn
            // 
            this.customerDeleteBtn.Location = new System.Drawing.Point(437, 127);
            this.customerDeleteBtn.Name = "customerDeleteBtn";
            this.customerDeleteBtn.Size = new System.Drawing.Size(124, 37);
            this.customerDeleteBtn.TabIndex = 7;
            this.customerDeleteBtn.Text = "DELETE";
            this.customerDeleteBtn.UseVisualStyleBackColor = true;
            this.customerDeleteBtn.Click += new System.EventHandler(this.customerDeleteBtn_Click);
            // 
            // customerUpdateBtn
            // 
            this.customerUpdateBtn.Location = new System.Drawing.Point(230, 127);
            this.customerUpdateBtn.Name = "customerUpdateBtn";
            this.customerUpdateBtn.Size = new System.Drawing.Size(127, 37);
            this.customerUpdateBtn.TabIndex = 7;
            this.customerUpdateBtn.Text = "UPDATE";
            this.customerUpdateBtn.UseVisualStyleBackColor = true;
            this.customerUpdateBtn.Click += new System.EventHandler(this.customerUpdateBtn_Click);
            // 
            // customerAddBtn
            // 
            this.customerAddBtn.Location = new System.Drawing.Point(30, 127);
            this.customerAddBtn.Name = "customerAddBtn";
            this.customerAddBtn.Size = new System.Drawing.Size(127, 37);
            this.customerAddBtn.TabIndex = 7;
            this.customerAddBtn.Text = "ADD";
            this.customerAddBtn.UseVisualStyleBackColor = true;
            this.customerAddBtn.Click += new System.EventHandler(this.customerAddClick);
            // 
            // customerAddressTxtbox
            // 
            this.customerAddressTxtbox.Location = new System.Drawing.Point(30, 91);
            this.customerAddressTxtbox.Name = "customerAddressTxtbox";
            this.customerAddressTxtbox.Size = new System.Drawing.Size(531, 20);
            this.customerAddressTxtbox.TabIndex = 6;
            // 
            // customerAddressLbl
            // 
            this.customerAddressLbl.AutoSize = true;
            this.customerAddressLbl.Location = new System.Drawing.Point(30, 75);
            this.customerAddressLbl.Name = "customerAddressLbl";
            this.customerAddressLbl.Size = new System.Drawing.Size(45, 13);
            this.customerAddressLbl.TabIndex = 5;
            this.customerAddressLbl.Text = "Address";
            this.customerAddressLbl.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // customerEmailLbl
            // 
            this.customerEmailLbl.AutoSize = true;
            this.customerEmailLbl.Location = new System.Drawing.Point(434, 23);
            this.customerEmailLbl.Name = "customerEmailLbl";
            this.customerEmailLbl.Size = new System.Drawing.Size(72, 13);
            this.customerEmailLbl.TabIndex = 4;
            this.customerEmailLbl.Text = "Email address";
            // 
            // customerPhoneLbl
            // 
            this.customerPhoneLbl.AutoSize = true;
            this.customerPhoneLbl.Location = new System.Drawing.Point(227, 23);
            this.customerPhoneLbl.Name = "customerPhoneLbl";
            this.customerPhoneLbl.Size = new System.Drawing.Size(78, 13);
            this.customerPhoneLbl.TabIndex = 4;
            this.customerPhoneLbl.Text = "Phone Number";
            this.customerPhoneLbl.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // customerEmailTxtbox
            // 
            this.customerEmailTxtbox.Location = new System.Drawing.Point(437, 39);
            this.customerEmailTxtbox.Name = "customerEmailTxtbox";
            this.customerEmailTxtbox.Size = new System.Drawing.Size(127, 20);
            this.customerEmailTxtbox.TabIndex = 3;
            // 
            // customerPhoneTxtbox
            // 
            this.customerPhoneTxtbox.Location = new System.Drawing.Point(230, 39);
            this.customerPhoneTxtbox.Name = "customerPhoneTxtbox";
            this.customerPhoneTxtbox.Size = new System.Drawing.Size(127, 20);
            this.customerPhoneTxtbox.TabIndex = 3;
            // 
            // customerNameTxtbox
            // 
            this.customerNameTxtbox.Location = new System.Drawing.Point(30, 39);
            this.customerNameTxtbox.Name = "customerNameTxtbox";
            this.customerNameTxtbox.Size = new System.Drawing.Size(127, 20);
            this.customerNameTxtbox.TabIndex = 3;
            // 
            // customerNameLbl
            // 
            this.customerNameLbl.AutoSize = true;
            this.customerNameLbl.Location = new System.Drawing.Point(27, 23);
            this.customerNameLbl.Name = "customerNameLbl";
            this.customerNameLbl.Size = new System.Drawing.Size(35, 13);
            this.customerNameLbl.TabIndex = 2;
            this.customerNameLbl.Text = "Name";
            this.customerNameLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerDataGrid.AutoGenerateColumns = false;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.customerDataGrid.DataSource = this.customerBindingSource1;
            this.customerDataGrid.Location = new System.Drawing.Point(3, 182);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.RowHeadersWidth = 55;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.Size = new System.Drawing.Size(804, 327);
            this.customerDataGrid.TabIndex = 1;
            this.customerDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 268);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Customers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Products";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Orders";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Stock check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Manager App";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn2.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn4.HeaderText = "Email";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // customerBindingSource1
            // 
            this.customerBindingSource1.DataSource = typeof(WindowsFormsApp1.Customer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 682);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.stockPanel.ResumeLayout(false);
            this.customersPanel.ResumeLayout(false);
            this.customersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.Panel stockPanel;
        private System.Windows.Forms.Panel customersPanel;
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.TextBox customerNameTxtbox;
        private System.Windows.Forms.Label customerNameLbl;
        private System.Windows.Forms.Label customerEmailLbl;
        private System.Windows.Forms.Label customerPhoneLbl;
        private System.Windows.Forms.TextBox customerEmailTxtbox;
        private System.Windows.Forms.TextBox customerPhoneTxtbox;
        private System.Windows.Forms.Label customerAddressLbl;
        private System.Windows.Forms.TextBox customerAddressTxtbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button customerDeleteBtn;
        private System.Windows.Forms.Button customerUpdateBtn;
        private System.Windows.Forms.Button customerAddBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource customerBindingSource1;
    }
}
