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
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Nome do aluno");
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome do aluno");
										break;
									case 4: //sexo
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Sexo");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Sexo");
										Validador.ConfereValor(arrStrings[i], "F", "M", contador + " campo: " + (i + 1) + " Sexo");
										break;
									case 5: //data de nascimento
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Data de nasc.");
										Validador.ConfereData(arrStrings[i], contador + " campo: " + (i + 1) + " Data de nasc");
										if (DateTime.Compare(Convert.ToDateTime(arrStrings[i]), Convert.ToDateTime("01-01-2010")) <
											0)
										{
											_logService.Log("Existe aluno com data de nascimetno inferior a 2010 na linha: " +
															contador + " campo: " + (i + 1) + " Data de nasc");
										}
										break;
									case 6://Deficiente?
										if (!string.IsNullOrEmpty(arrStrings[i]))
										{
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Deficiente?");
											Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Deficiente?");
										}
										break;
									case 7://Nome da mãe
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Nome da mãe");
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome da mãe");
										break;
									case 8://CPF da mãe
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Cpf da Mãe");
										break;
									case 9://Nome do pai
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Nome do Pai");
										break;
									case 10://CPF do pai
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " CPF do pai");
										break;
									case 11://CPF do estudante
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Cpf do estudante");
										break;
									case 12://Tipo de Certidão
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo de Certidão");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Tipo de Certidão");
										Validador.ConfereValor(arrStrings[i], "N", "C", contador + " campo: " + (i + 1) + " Tipo de Certidão");
										break;
									case 13://Certidão de Nascimento Foi Emitida
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida");
										Validador.ConfereValor(arrStrings[i], "2", "2", contador + " campo: " + (i + 1) + " Certidão de Nascimento Foi Emitida");
										break;
									case 18: //matrícula da certidao
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Matrícula");
										Validador.ConfereTamanho(arrStrings[i], 50, contador + " campo: " + (i + 1) + " Matrícula");
										Validador.ConfereTamanhoMinimo(arrStrings[i], 2, contador + " campo: " + (i + 1) + " Matrícula");
										break;
									case 19: //Carteira Identidade aluno
										Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " C.I.");
										break;
									case 21: //Altas habilidades
										Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Altas Habil.");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Altas Habili.");
										break;
									case 22: //zona
										Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Zona");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Zona");
										break;
									case 23: //CEP
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " CEP");
										Validador.ConfereTamanho(arrStrings[i], 10, contador + " campo: " + (i + 1) + " CEP");
										break;
									case 24: //Tipo logradouro
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo Logradouro");
										Validador.ConfereTamanho(arrStrings[i], 11, contador + " campo: " + (i + 1) + " Tipo logradouro");
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Tipo Logradouro");
										break;
									case 25: //logradouro
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Logradouro");
										Validador.ConfereTamanho(arrStrings[i], 255, contador + " campo: " + (i + 1) + " Logradouro");
										break;
									case 26: //número da resid
										if (arrStrings[i + 1].Equals("N"))//caso tenha o número da residência
										{
											Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Numero resid.");
											Validador.ConfereTamanho(arrStrings[i], 15, contador + " campo: " + (i + 1) + " Numero resid.");
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Numero resid.");
										}
										break;
									case 27: //Sem numero da resid
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Sem numero da resid");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Sem numero da resid");
										Validador.ConfereValor(arrStrings[i], "S", "N", contador + " campo: " + (i + 1) + " Sem numero da resid");
										break;
									case 28: //bairro
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " bairro");
										Validador.ConfereTamanho(arrStrings[i], 100, contador + " campo: " + (i + 1) + " bairro");
										break;
									case 29: //complemento
										if (!string.IsNullOrEmpty(arrStrings[i]))
											Validador.ConfereTamanho(arrStrings[i], 150, contador + " campo: " + (i + 1) + " complemento");
										break;
									case 30: //responsável cadastro
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Responsável cadastro");
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Responsável cadastro");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Responsável cadastro");

										if (!arrStrings[i].Equals("3"))//se p responsável for o pai ou a mãe
										{
											//só pode conter os valores 1 ou 2
											Validador.ConfereValor(arrStrings[i], "1", "2", contador + " campo: " + (i + 1) + " Responsável cadastro");
											//os campos nome do resposável CPF devem ficar nulos
											Validador.ConfereNulo(arrStrings[i + 1], contador + " campo: " + (i + 1) + " Nome responsável -outro");
											Validador.ConfereNulo(arrStrings[i + 2], contador + " campo: " + (i + 1) + " cpf responsável");

										}
										else
										{
											//nome do responsável - índice 31
											Validador.ConfereNaoNulo(arrStrings[i + 1], contador + " campo: " + (i + 1) + " Nome responsável -outro");
											Validador.ConfereTamanho(arrStrings[i + 1], 255, contador + " campo: " + (i + 1) + " Nome Responsável - outro");
											//cpf do responsável - índice 32
											Validador.ConfereTamanho(arrStrings[i + 2], 15, contador + " campo: cpf responsável" + (i + 2));
										}
										break;
									case 33: //telefone 1 DDD
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + "DDD");
										Validador.ConfereTamanho(arrStrings[i], 3, contador + " campo: " + (i + 1) + " DDD");
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " DDD");
										break;
									case 34: //telefone 1
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " telefone 1");
										Validador.ConfereTamanho(arrStrings[i], 20, contador + " campo: " + (i + 1) + " telefone 1");
										break;
									case 35: //telefone 2 DDD
										Validador.ConfereTamanho(arrStrings[i], 3, contador + " campo: " + (i + 1) + " DDD2");
										if (!string.IsNullOrEmpty(arrStrings[i]))
											Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " DDD2");
										break;
									case 36: //telefone 2
										Validador.ConfereTamanho(arrStrings[i], 20, contador + " campo: " + (i + 1) + "telefone 2");
										break;
									case 37: //email
										Validador.ConfereTamanho(arrStrings[i], 100, contador + " campo: " + (i + 1) + " E-mail");
										break;
									case 38: //modalidade de ensino
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Modalidade Ensino");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Modalidade Ensino");
										Validador.ConfereNumero(arrStrings[i], contador + " campo: " + (i + 1) + " Modalidade Ensino");
										Validador.ConfereValor(arrStrings[i], "1", "1",
											contador + " campo: " +
											(i + 1) + "Modalidade Ensino"); //nao pode ser outro valor a não ser 1-Ensino Fund. Regular
										break;
									case 39://Ano que irá cursar em 2018
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Ano que irá cursar");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Ano que irá cursar");
										Validador.ConfereValor(arrStrings[i], "1", "1",
											contador + " campo: " + (i + 1) + " Ano que irá cursar"); //nao pode ser diferete de 1 - 1º ano
										break;
									case 40://Procedente de
										Validador.ConfereNaoNulo(arrStrings[i], contador + " campo: " + (i + 1) + " Procedente de");
										Validador.ConfereTamanho(arrStrings[i], 1, contador + " campo: " + (i + 1) + " Procedente de");
										Validador.ConfereValor(arrStrings[i], "3", "3",
											contador + " campo: " + (i + 1) + " Procedente de");
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
			lbl_erros.Text = _logService.Numero_errros.ToString();

		}

		private void btn_abrirlog_Click(object sender, EventArgs e)
		{
			Process.Start(_logService.ArquivoLog);
		}
	}
}
