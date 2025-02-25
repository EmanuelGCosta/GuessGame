namespace DesafioGameNewCentury
{
    partial class TabelaHistorico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridHistorico = new System.Windows.Forms.DataGridView();
            this.NomeJogador = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDificuldade = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.labelDificuldade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridHistorico);
            this.panel1.Controls.Add(this.NomeJogador);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 400);
            this.panel1.TabIndex = 4;
            // 
            // dataGridHistorico
            // 
            this.dataGridHistorico.AllowUserToAddRows = false;
            this.dataGridHistorico.AllowUserToDeleteRows = false;
            this.dataGridHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistorico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistorico.Location = new System.Drawing.Point(17, 59);
            this.dataGridHistorico.Margin = new System.Windows.Forms.Padding(8);
            this.dataGridHistorico.Name = "dataGridHistorico";
            this.dataGridHistorico.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHistorico.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHistorico.RowHeadersVisible = false;
            this.dataGridHistorico.Size = new System.Drawing.Size(766, 324);
            this.dataGridHistorico.TabIndex = 5;
            // 
            // NomeJogador
            // 
            this.NomeJogador.AutoSize = true;
            this.NomeJogador.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeJogador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NomeJogador.Location = new System.Drawing.Point(12, 368);
            this.NomeJogador.Name = "NomeJogador";
            this.NomeJogador.Size = new System.Drawing.Size(15, 23);
            this.NomeJogador.TabIndex = 4;
            this.NomeJogador.Text = ".";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Plum;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(733, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Plum;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Thistle;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 50);
            this.button2.TabIndex = 9;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "HISTÓRICO:";
            // 
            // labelDificuldade
            // 
            this.labelDificuldade.AutoSize = true;
            this.labelDificuldade.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDificuldade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labelDificuldade.Location = new System.Drawing.Point(181, 19);
            this.labelDificuldade.Name = "labelDificuldade";
            this.labelDificuldade.Size = new System.Drawing.Size(23, 32);
            this.labelDificuldade.TabIndex = 7;
            this.labelDificuldade.Text = "-";
            // 
            // TabelaHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabelaHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TabelaHistorico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridHistorico;
        private System.Windows.Forms.Label NomeJogador;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelDificuldade;
        private System.Windows.Forms.Label label1;
    }
}