using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCadastro
{
	public partial class Form1 : Form
	{
		private readonly LogService _logService;
		private string arquivo;
		int contador;
		private DateTime tempoInicial, tempoFinal;
		private TimeSpan tempodecorrido;

		public Form1()
		{
			InitializeComponent();
			_logService = new LogService();
		}

		private void btn_iniciar_Click(object sender, EventArgs e)
		{
			try
			{
				contador = 1;
				lbl_tempodecorrido.ResetText();
				lbl_linhaslidas.ResetText();
				btn_abrirlog.Visible = false;
				lbl_concluída.Visible = false;
				progressBar1.Style = ProgressBarStyle.Marquee;

				//executa o processo de forma assincrona.
				backgroundWorker1.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				_logService.Log(ex);
			}
		}

		private void LeituraArquivo(int contador)
		{
			try
			{
				tempoInicial = DateTime.Now;

				if (String.IsNullOrEmpty(arquivo))
					throw new Exception("Arquivo Inválido!");
				else
				{
					char[] delim = { '|' };

					using (StreamReader texto = new StreamReader(arquivo))
					{
						_logService.Log("Início leitura arquivo");


						while (texto.Peek() >= 0)
						{
							string linha = texto.ReadLine();


							linha = linha.Replace("\"", "");

							string[] arrStrings = linha.Split(delim, StringSplitOptions.None);

							for (int i = 0; i < arrStrings.Length; i++)
							{
								switch (i)
								{
									case 3://Nome do aluno
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Nome do aluno CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome do aluno CRIANÇA: " +arrStrings[3]);
										break;
									case 4: //sexo
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Sexo CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Sexo CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "F", "M", contador + " campo: " + (i + 1) + " Sexo CRIANÇA: " +arrStrings[3]);
										break;
									case 5: //data de nascimento
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Data de nasc. CRIANÇA: " +arrStrings[3]);
										Validador.ConfereData(arrStrings[i], contador + " campo: " + (i + 1) + " Data de nasc CRIANÇA: " +arrStrings[3]);
										//if (DateTime.Compare(Convert.ToDateTime(arrStrings[i]), Convert.ToDateTime("31-03-2013")) >//	0)
										//{
										//	_logService.Log("Existe aluno com data de nascimento posterior a 31/03/2013 na linha: " + contador + " campo: " + (i + 1) + " Data de nasc CRIANÇA: " +arrStrings[3]);
										//}
										break;
									case 6://Deficiente?
										if (!string.IsNullOrEmpty(arrStrings[i]))
										{
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Deficiente? CRIANÇA: " +arrStrings[3]);
											Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Deficiente? CRIANÇA: " +arrStrings[3]);
											Validador.ConfereValorMaximo(arrStrings[i],8,contador + " campo: " + (i + 1) + " Deficiente? CRIANÇA: " +arrStrings[3]);
										}
										break;
									case 7://Nome da mãe
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Nome da mãe CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome da mãe CRIANÇA: " +arrStrings[3]);
										break;
									case 8://CPF da mãe
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Cpf da Mãe CRIANÇA: " +arrStrings[3]);
										break;
									case 9://Nome do pai
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome do Pai CRIANÇA: " +arrStrings[3]);
										break;
									case 10://CPF do pai
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " CPF do pai CRIANÇA: " +arrStrings[3]);
										break;
									case 11://CPF do estudante
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Cpf do estudante CRIANÇA: " +arrStrings[3]);
										break;
									case 12://Tipo de Certidão
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo de Certidão CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Tipo de Certidão CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "N", "C", contador + " campo: " + (i + 1) + " Tipo de Certidão CRIANÇA: " +arrStrings[3]);
										break;
									case 13://Certidão de Nascimento Foi Emitida
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "2", "2", contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida CRIANÇA: " +arrStrings[3]);
										break;
									case 18: //matrícula da certidao
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Matrícula CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 50, contador + " campo: " + (i + 1) + " Matrícula CRIANÇA: " +arrStrings[3]);
										//Validador.ConfereTamanho(arrStrings[i], 2, contador + " campo: " + (i + 1) + " Matrícula CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanhoMinimo(arrStrings[i], 40, contador + " campo: " + (i + 1) + " Matrícula - tamanho: " + arrStrings[i].Length.ToString());
										Validador.ConfereDoisEspacos(arrStrings[i],contador + " campo: " + (i + 1) + " Matrícula CRIANÇA: " + arrStrings[3]);
										break;
									case 19: //Carteira Identidade aluno
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " C.I. CRIANÇA: " +arrStrings[3]);
										break;
									case 21: //Altas habilidades
										Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Altas Habil. CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Altas Habili. CRIANÇA: " +arrStrings[3]);
										break;
									case 22: //zona
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Zona CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Zona CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Zona CRIANÇA: " +arrStrings[3]);
										break;
									case 23: //CEP
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " CEP CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 10, contador + " campo: " + (i + 1) + " CEP CRIANÇA: " +arrStrings[3]);
										break;
									case 24: //Tipo logradouro
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo Logradouro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 3, contador + " campo: " + (i + 1) + " Tipo logradouro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo Logradouro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereDiferenteZero(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo Logradouro CRIANÇA: " +arrStrings[3]);

										break;
									case 25: //logradouro
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Logradouro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Logradouro CRIANÇA: " +arrStrings[3]);
										break;
									case 26: //número da residência
										if (arrStrings[i + 1].Equals("N"))//caso tenha o número da residência
										{
											Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Numero resid. CRIANÇA: " +arrStrings[3]);
											Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Numero resid. CRIANÇA: " +arrStrings[3]);
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Numero resid. CRIANÇA: " +arrStrings[3]);
										}
										break;
									case 27: //Sem numero da resid
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Sem numero da resid CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Sem numero da resid CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "S", "N", contador + " campo: " + (i + 1) + " Sem numero da resid CRIANÇA: " +arrStrings[3]);
										break;
									case 28: //bairro
										if (arrStrings[i-6].Equals("1"))
										{
											Validador.ConfereObrigatorio(arrStrings[i],contador + " campo: " + (i + 1) + " bairro CRIANÇA: " +arrStrings[3]);
										}
										Validador.ConfereTamanho(arrStrings[i],100,contador + " campo: " + (i + 1) + " bairro CRIANÇA: " +arrStrings[3]);
										break; 
									   
									case 29: //complemento
										if (!string.IsNullOrEmpty(arrStrings[i]))
											Validador.ConfereTamanho(arrStrings[i], 150, contador + " campo: " + (i + 1) + " complemento CRIANÇA: " +arrStrings[3]);
										break;
									case 30: //responsável cadastro
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Responsável cadastro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Responsável cadastro CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Responsável cadastro CRIANÇA: " +arrStrings[3]);

										if (!arrStrings[i].Equals("3"))//se o responsável for o pai ou a mãe
										{
											//só pode conter os valores 1 ou 2
											Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Responsável cadastro CRIANÇA: " +arrStrings[3]);
											//os campos nome do resposável CPF devem ficar nulos
											Validador.ConfereNulo(arrStrings[i + 1], contador + " campo: " + (i + 1) + " Nome responsável -outro CRIANÇA: " +arrStrings[3]);
											Validador.ConfereNulo(arrStrings[i + 2], contador + " campo: " + (i + 1) + " cpf responsável CRIANÇA: " +arrStrings[3]);
										}
										else //se o responsável for OUTRO
										{
											//nome do responsável - índice 31
											Validador.ConfereObrigatorio(arrStrings[i + 1], contador + " campo: " + (i + 1) + " Nome responsável -outro CRIANÇA: " +arrStrings[3]);
											Validador.ConfereTamanho(arrStrings[i + 1], 255, contador + " campo: " + (i + 1) + " Nome Responsável - outro CRIANÇA: " +arrStrings[3]);
											//cpf do responsável - índice 32
											Validador.ConfereTamanho(arrStrings[i + 2], 15, contador + " campo: "+ (i + 2) + " cpf responsável - outro" );
										}
										break;
									case 33: //telefone 1 DDD
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + "DDD CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 3, contador + " campo: " + (i + 1) + " DDD CRIANÇA: " +arrStrings[3]);
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " DDD CRIANÇA: " +arrStrings[3]);
										break;
									case 34: //telefone 1
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " telefone 1 CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 20, contador + " campo: " + (i + 1) + " telefone 1 CRIANÇA: " +arrStrings[3]);
										break;
									case 35: //telefone 2 DDD
										Validador.ConfereTamanho(arrStrings[i], 3, contador + " campo: " + (i + 1) + " DDD2 CRIANÇA: " +arrStrings[3]);
										if (!string.IsNullOrEmpty(arrStrings[i]))
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " DDD2 CRIANÇA: " +arrStrings[3]);
										break;
									case 36: //telefone 2
										Validador.ConfereTamanho(arrStrings[i], 20, contador + " campo: " + (i + 1) + "telefone 2 CRIANÇA: " +arrStrings[3]);
										break;
									case 37: //email
										Validador.ConfereTamanho(arrStrings[i], 100, contador + " campo: " + (i + 1) + " E-mail CRIANÇA: " +arrStrings[3]);
										break;
									case 38: //modalidade de ensino
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Modalidade Ensino CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Modalidade Ensino CRIANÇA: " +arrStrings[3]);
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Modalidade Ensino CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "1", "1", contador + " campo: " + (i + 1) + "Modalidade Ensino CRIANÇA: " +arrStrings[3]); //nao pode ser outro valor a não ser 1-Ensino Fund. Regular
										break;
									case 39://Ano que irá cursar em 2020
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Ano que irá cursar CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Ano que irá cursar CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "1", "1", contador + " campo: " + (i + 1) + " Ano que irá cursar CRIANÇA: " +arrStrings[3]); //nao pode ser diferete de 1 - 1º ano
										break;
									case 40://Procedente de
										Validador.ConfereObrigatorio(arrStrings[i], contador + " campo: " + (i + 1) + " Procedente de CRIANÇA: " +arrStrings[3]);
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Procedente de CRIANÇA: " +arrStrings[3]);
										Validador.ConfereValor(arrStrings[i], "3", "3",contador + " campo: " + (i + 1) + " Procedente de CRIANÇA: " +arrStrings[3]);
										break;
								}
							}
							contador++;
							lbl_linhaslidas.Invoke(new Action(() => { lbl_linhaslidas.Text = contador.ToString(); }));

							this.backgroundWorker1.ReportProgress(contador);
						}
					}
					//lbl_erros.Text = _logService.Numero_errros.ToString();
					//lbl_erros.Invoke(new Action(() => { lbl_erros.Text = _logService.Numero_errros.ToString(); }));
					_logService.Log("Leitura concluída");
				}
			}
			catch (Exception e)
			{
				_logService.Log(e);
			}
		}

		private void btn_abrirarquivo_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = @"Validação arquivo Cadastro";
			openFileDialog1.InitialDirectory = @"d:\desktop"; //Se ja quiser em abrir em um diretorio especifico
			openFileDialog1.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				arquivo = openFileDialog1.FileName;
				txt_arquivo.Text = openFileDialog1.FileName;
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			LeituraArquivo(contador);

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar1.MarqueeAnimationSpeed = 0;
			//progressBar1.Style = ProgressBarStyle.Blocks;
			progressBar1.Value = 0;
			lbl_concluída.Visible = true;
			btn_abrirlog.Visible = true;
			tempoFinal = DateTime.Now;

			tempodecorrido = tempoFinal - tempoInicial;
			lbl_tempodecorrido.Text = tempodecorrido.TotalMinutes.ToString();
			//lbl_erros.Text = _logService.Numero_errros.ToString();

		}

		private void btn_abrirlog_Click(object sender, EventArgs e)
		{
			Process.Start(_logService.ArquivoLog);
		}
	}
}
