namespace Obsluga1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.but_dodaj = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_port = new System.Windows.Forms.Label();
            this.comboBox_porty = new System.Windows.Forms.ComboBox();
            this.but_openport = new System.Windows.Forms.Button();
            this.but_closeport = new System.Windows.Forms.Button();
            this.lab_portstatus = new System.Windows.Forms.Label();
            this.tBox_portstatus = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Czas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.but_choosepath = new System.Windows.Forms.Button();
            this.tBox_selectedPath = new System.Windows.Forms.TextBox();
            this.but_savedata = new System.Windows.Forms.Button();
            this.but_graph = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_dodaj
            // 
            this.but_dodaj.Location = new System.Drawing.Point(6, 29);
            this.but_dodaj.Name = "but_dodaj";
            this.but_dodaj.Size = new System.Drawing.Size(121, 23);
            this.but_dodaj.TabIndex = 0;
            this.but_dodaj.Text = "Wyszukaj porty";
            this.but_dodaj.UseVisualStyleBackColor = true;
            this.but_dodaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.informacjeToolStripMenuItem.Text = "Informacje";
            this.informacjeToolStripMenuItem.Click += new System.EventHandler(this.informacjeToolStripMenuItem_Click);
            // 
            // lab_port
            // 
            this.lab_port.AutoSize = true;
            this.lab_port.Location = new System.Drawing.Point(6, 67);
            this.lab_port.Name = "lab_port";
            this.lab_port.Size = new System.Drawing.Size(34, 13);
            this.lab_port.TabIndex = 8;
            this.lab_port.Text = "Porty:";
            this.lab_port.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // comboBox_porty
            // 
            this.comboBox_porty.FormattingEnabled = true;
            this.comboBox_porty.Location = new System.Drawing.Point(6, 83);
            this.comboBox_porty.Name = "comboBox_porty";
            this.comboBox_porty.Size = new System.Drawing.Size(121, 21);
            this.comboBox_porty.TabIndex = 9;
            this.comboBox_porty.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // but_openport
            // 
            this.but_openport.Location = new System.Drawing.Point(144, 29);
            this.but_openport.Name = "but_openport";
            this.but_openport.Size = new System.Drawing.Size(85, 23);
            this.but_openport.TabIndex = 10;
            this.but_openport.Text = "Otwórz port";
            this.but_openport.UseVisualStyleBackColor = true;
            this.but_openport.Click += new System.EventHandler(this.but_openport_Click);
            // 
            // but_closeport
            // 
            this.but_closeport.Location = new System.Drawing.Point(231, 29);
            this.but_closeport.Name = "but_closeport";
            this.but_closeport.Size = new System.Drawing.Size(85, 23);
            this.but_closeport.TabIndex = 11;
            this.but_closeport.Text = "Zamknij port";
            this.but_closeport.UseVisualStyleBackColor = true;
            this.but_closeport.Click += new System.EventHandler(this.but_closeport_Click);
            // 
            // lab_portstatus
            // 
            this.lab_portstatus.AutoSize = true;
            this.lab_portstatus.Location = new System.Drawing.Point(141, 67);
            this.lab_portstatus.Name = "lab_portstatus";
            this.lab_portstatus.Size = new System.Drawing.Size(67, 13);
            this.lab_portstatus.TabIndex = 12;
            this.lab_portstatus.Text = "Status portu:";
            this.lab_portstatus.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // tBox_portstatus
            // 
            this.tBox_portstatus.Location = new System.Drawing.Point(144, 84);
            this.tBox_portstatus.Name = "tBox_portstatus";
            this.tBox_portstatus.ReadOnly = true;
            this.tBox_portstatus.Size = new System.Drawing.Size(172, 20);
            this.tBox_portstatus.TabIndex = 13;
            this.tBox_portstatus.TextChanged += new System.EventHandler(this.tBox_portstatus_TextChanged);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nr,
            this.Czas,
            this.Temp});
            this.dataGridView1.Location = new System.Drawing.Point(6, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(275, 200);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nr
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Nr.DefaultCellStyle = dataGridViewCellStyle1;
            this.Nr.HeaderText = "Nr";
            this.Nr.MinimumWidth = 50;
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nr.Width = 50;
            // 
            // Czas
            // 
            this.Czas.HeaderText = "Czas";
            this.Czas.MinimumWidth = 110;
            this.Czas.Name = "Czas";
            this.Czas.ReadOnly = true;
            this.Czas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Czas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Czas.Width = 110;
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temp.";
            this.Temp.MinimumWidth = 110;
            this.Temp.Name = "Temp";
            this.Temp.ReadOnly = true;
            this.Temp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Temp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Temp.Width = 110;
            // 
            // but_choosepath
            // 
            this.but_choosepath.Location = new System.Drawing.Point(6, 29);
            this.but_choosepath.Name = "but_choosepath";
            this.but_choosepath.Size = new System.Drawing.Size(129, 23);
            this.but_choosepath.TabIndex = 17;
            this.but_choosepath.Text = "Wybierz ścieżkę zapisu";
            this.but_choosepath.UseVisualStyleBackColor = true;
            this.but_choosepath.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tBox_selectedPath
            // 
            this.tBox_selectedPath.Location = new System.Drawing.Point(6, 58);
            this.tBox_selectedPath.Name = "tBox_selectedPath";
            this.tBox_selectedPath.ReadOnly = true;
            this.tBox_selectedPath.Size = new System.Drawing.Size(275, 20);
            this.tBox_selectedPath.TabIndex = 18;
            // 
            // but_savedata
            // 
            this.but_savedata.Location = new System.Drawing.Point(152, 29);
            this.but_savedata.Name = "but_savedata";
            this.but_savedata.Size = new System.Drawing.Size(129, 23);
            this.but_savedata.TabIndex = 19;
            this.but_savedata.Text = "Zapisz dane do pliku .txt";
            this.but_savedata.UseVisualStyleBackColor = true;
            this.but_savedata.Click += new System.EventHandler(this.but_savedata_Click);
            // 
            // but_graph
            // 
            this.but_graph.Location = new System.Drawing.Point(6, 292);
            this.but_graph.Name = "but_graph";
            this.but_graph.Size = new System.Drawing.Size(275, 23);
            this.but_graph.TabIndex = 20;
            this.but_graph.Text = "Pokaż Wykres";
            this.but_graph.UseVisualStyleBackColor = true;
            this.but_graph.Click += new System.EventHandler(this.but_graph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(672, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 122);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontrola algorytmu grzałki";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Obsluga1.Properties.Resources.reddot;
            this.pictureBox1.Location = new System.Drawing.Point(82, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kontrola Procesu";
            this.label1.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(672, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 192);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacje";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "OFF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Status:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "-, min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Time:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "-, C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Set-point:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.but_dodaj);
            this.groupBox3.Controls.Add(this.but_openport);
            this.groupBox3.Controls.Add(this.lab_port);
            this.groupBox3.Controls.Add(this.comboBox_porty);
            this.groupBox3.Controls.Add(this.but_closeport);
            this.groupBox3.Controls.Add(this.lab_portstatus);
            this.groupBox3.Controls.Add(this.tBox_portstatus);
            this.groupBox3.Location = new System.Drawing.Point(24, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 122);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Komunikacja ze sterownikiem";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.but_choosepath);
            this.groupBox4.Controls.Add(this.but_savedata);
            this.groupBox4.Controls.Add(this.tBox_selectedPath);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.but_graph);
            this.groupBox4.Location = new System.Drawing.Point(376, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 321);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Obsługa danych";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Controls.Add(this.comboBox2);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(24, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(346, 192);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nastawy sterownika";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(9, 124);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(9, 74);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(144, 122);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(172, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Ustaw tryb";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(144, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ustaw czas, minuty";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ustaw Temperaturę, st. C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 372);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Kontroler sterownika pieca grzewczego";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_dodaj;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lab_port;
        private System.Windows.Forms.ComboBox comboBox_porty;
        private System.Windows.Forms.Button but_openport;
        private System.Windows.Forms.Button but_closeport;
        private System.Windows.Forms.Label lab_portstatus;
        private System.Windows.Forms.TextBox tBox_portstatus;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.Button but_choosepath;
        private System.Windows.Forms.TextBox tBox_selectedPath;
        private System.Windows.Forms.Button but_savedata;
        private System.Windows.Forms.Button but_graph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
    }
}

