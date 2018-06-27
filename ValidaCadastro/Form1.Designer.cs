using System;
using System.Windows.Forms;

namespace ValidaCadastro
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_arquivo = new System.Windows.Forms.TextBox();
            this.btn_abrirarquivo = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_linhaslidas = new System.Windows.Forms.Label();
            this.lbl_concluída = new System.Windows.Forms.Label();
            this.btn_abrirlog = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_tempodecorrido = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_erros = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.Location = new System.Drawing.Point(581, 88);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(102, 26);
            this.btn_iniciar.TabIndex = 0;
            this.btn_iniciar.Text = "Iniciar";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arquivo:";
            // 
            // txt_arquivo
            // 
            this.txt_arquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_arquivo.Location = new System.Drawing.Point(120, 50);
            this.txt_arquivo.Name = "txt_arquivo";
            this.txt_arquivo.Size = new System.Drawing.Size(455, 26);
            this.txt_arquivo.TabIndex = 2;
            // 
            // btn_abrirarquivo
            // 
            this.btn_abrirarquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abrirarquivo.Location = new System.Drawing.Point(581, 51);
            this.btn_abrirarquivo.Name = "btn_abrirarquivo";
            this.btn_abrirarquivo.Size = new System.Drawing.Size(102, 26);
            this.btn_abrirarquivo.TabIndex = 3;
            this.btn_abrirarquivo.Text = "Abrir Arquivo";
            this.btn_abrirarquivo.UseVisualStyleBackColor = true;
            this.btn_abrirarquivo.Click += new System.EventHandler(this.btn_abrirarquivo_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(120, 89);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(455, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Progresso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nº de Registros Analisados:";
            // 
            // lbl_linhaslidas
            // 
            this.lbl_linhaslidas.AutoSize = true;
            this.lbl_linhaslidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_linhaslidas.Location = new System.Drawing.Point(251, 130);
            this.lbl_linhaslidas.Name = "lbl_linhaslidas";
            this.lbl_linhaslidas.Size = new System.Drawing.Size(64, 24);
            this.lbl_linhaslidas.TabIndex = 8;
            this.lbl_linhaslidas.Text = "linhas ";
            // 
            // lbl_concluída
            // 
            this.lbl_concluída.AutoSize = true;
            this.lbl_concluída.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_concluída.Location = new System.Drawing.Point(205, 216);
            this.lbl_concluída.Name = "lbl_concluída";
            this.lbl_concluída.Size = new System.Drawing.Size(164, 24);
            this.lbl_concluída.TabIndex = 9;
            this.lbl_concluída.Text = "Análise concluída!";
            this.lbl_concluída.Visible = false;
            // 
            // btn_abrirlog
            // 
            this.btn_abrirlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abrirlog.Location = new System.Drawing.Point(388, 216);
            this.btn_abrirlog.Name = "btn_abrirlog";
            this.btn_abrirlog.Size = new System.Drawing.Size(96, 29);
            this.btn_abrirlog.TabIndex = 10;
            this.btn_abrirlog.Text = "Abrir Log";
            this.btn_abrirlog.UseVisualStyleBackColor = true;
            this.btn_abrirlog.Visible = false;
            this.btn_abrirlog.Click += new System.EventHandler(this.btn_abrirlog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tempo decorrido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(134, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(484, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Validador de arquivo de exportação do Cadastro Escolar";
            // 
            // lbl_tempodecorrido
            // 
            this.lbl_tempodecorrido.AutoSize = true;
            this.lbl_tempodecorrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_tempodecorrido.Location = new System.Drawing.Point(170, 191);
            this.lbl_tempodecorrido.Name = "lbl_tempodecorrido";
            this.lbl_tempodecorrido.Size = new System.Drawing.Size(64, 24);
            this.lbl_tempodecorrido.TabIndex = 13;
            this.lbl_tempodecorrido.Text = "linhas ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(12, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nº de erros encontrados:";
            // 
            // lbl_erros
            // 
            this.lbl_erros.AutoSize = true;
            this.lbl_erros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_erros.Location = new System.Drawing.Point(239, 162);
            this.lbl_erros.Name = "lbl_erros";
            this.lbl_erros.Size = new System.Drawing.Size(53, 24);
            this.lbl_erros.TabIndex = 15;
            this.lbl_erros.Text = "erros";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 249);
            this.Controls.Add(this.lbl_erros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_abrirlog);
            this.Controls.Add(this.lbl_concluída);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_abrirarquivo);
            this.Controls.Add(this.txt_arquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.lbl_linhaslidas);
            this.Controls.Add(this.lbl_tempodecorrido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Validador de arquivo de exportação do Cadastro Escolar";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_iniciar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_arquivo;
		private System.Windows.Forms.Button btn_abrirarquivo;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbl_linhaslidas;
		private System.Windows.Forms.Label lbl_concluída;
		private System.Windows.Forms.Button btn_abrirlog;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Label lbl_tempodecorrido;
        private Label label6;
        private Label lbl_erros;
    }
}

