using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCadastro
{
	/// <summary>
	/// Classe de validação
	/// </summary>
	static class Validador
	{
		/// <summary>
		/// Objeto de serviço de log do sistema
		/// </summary>
		private static readonly LogService LogService = new LogService();

		/// <summary>
		/// Confere se um determinado valor pode ser convertido em número inteiro de 32 bits
		/// </summary>
		/// <param name="valor">O valor a ser verificado se é um número</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereNumero(string valor, string linha)
		{
			try
			{
				if (!(Convert.ToInt32(valor) > 0))
					throw new NumeroInvalidoException();
			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}
		/// <summary>
		/// Confere se o tamanho um campo est tamanho máximo
		/// </summary>
		/// <param name="campo">O campo ao qual se quer conferir</param>
		/// <param name="maxtamanho">O tamnho máximo que o campo deve ter</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereTamanho(string campo, int maxtamanho, string linha)
		{
			try
			{
				if (campo.Length > maxtamanho)
					throw new TamanhoErradoException();
			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}
		/// <summary>
		/// Confere se um campo possui um tamnho mínimo
		/// </summary>
		/// <param name="campo">O campo ao qual se quer conferir</param>
		/// <param name="maxtamanho">O tamanho mínimo que o campo deve possuir</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereTamanhoMinimo(string campo, int maxtamanho, string linha)
		{
			try
			{
				if (campo.Length < maxtamanho)
					throw new TamnahoMinimo();
			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}

		/// <summary>
		/// Confere se um campo obrigatório está em branco
		/// </summary>
		/// <param name="valor">O campo que não deve estar em branco</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereObrigatorio(string valor, string linha)
		{
			try
			{
				if (string.IsNullOrEmpty(valor))
					throw new ValorNuloException();
			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}
		/// <summary>
		/// Confere se um campo está nulo
		/// </summary>
		/// <param name="valor">O campo</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereNulo(string valor, string linha)
		{
			try
			{
				if (!string.IsNullOrEmpty(valor))
					throw new ValorNaoNuloException();
			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}
		/// <summary>
		/// Confere se uma data está no formato aaaa-mm-dd
		/// </summary>
		/// <param name="data">A data que se quer conferir</param>
		/// <param name="linha">O texto para o arquivo de log</param>
		public static void ConfereData(string data, string linha)
		{
			try
			{
				if (!DateTime.TryParse(data, out var datareal))
					throw new DataInvalidaException();

				if (!datareal.ToString("yyyy-MM-dd").Equals(data))
					throw new DataFormatoInvalidoException();
			}
			catch (Exception e)
			{
				LogService.Log(e, linha);
			}
		}

		/// <summary>
		/// Confere o valor possui o valor correto
		/// </summary>
		/// <param name="valor">o que se está testando</param>
		/// <param name="valorcorreto">o valor determinado</param>
		/// <returns></returns>
		public static void ConfereValor(string valor, string valor1, string valor2, string linha)
		{
			try
			{
				bool correto = false || valor.Equals(valor1) || valor.Equals(valor2);

				if (!correto)
					throw new ValorIncorretoExcepetion();
			}
			catch (Exception e)
			{
				LogService.Log(e, linha);
			}
		}

		/// <summary>
		/// Confere se um campo possui o valor máximo
		/// </summary>
		/// <param name="campo">O nome do campo</param>
		/// <param name="valormax"> valor máximo do campo</param>
		/// <param name="linha">a linha </param>
		public static void ConfereValorMaximo(string campo,int valormax,string linha)
		{
			try
			{
				if (Convert.ToInt32(campo) > valormax)
					throw new ValorMaximoPermitido();
			}
			catch (Exception ex)
			{
				LogService.Log(ex,linha);
			}
		}

		public static void ConfereDiferenteZero(string campo, string linha)
		{
			try
			{
				if (Convert.ToInt32(campo) == 0)
				{
				 throw new ValorZero();
				}
			}
			catch (Exception ex)
			{
				LogService.Log(ex,linha);
			}
		}

		public static void ConfereDoisEspacos(string campo, string linha)
		{
			try
			{
				if (campo.Contains("  "))
				{
					throw new CampoEmBranco();
				}

			}
			catch (Exception ex)
			{
				LogService.Log(ex, linha);
			}
		}
	}
}
