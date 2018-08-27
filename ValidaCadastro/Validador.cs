using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCadastro
{
	static class Validador
	{
		private static LogService _logService = new LogService();

		public static void ConfereNumero(string valor, string linha)
		{
			try
			{
				if (!(Convert.ToInt32(valor) > 0))
					throw new NumeroInvalidoException();
			}
			catch (Exception ex)
			{
				_logService.Log(ex, linha);
			}
		}

		public static void ConfereTamanho(string campo, int maxtamanho, string linha)
		{
			try
			{
				if (campo.Length > maxtamanho)
					throw new TamanhoErradoException();
			}
			catch (Exception ex)
			{
				_logService.Log(ex, linha);
			}
		}
		public static void ConfereTamanhoMinimo(string campo, int maxtamanho, string linha)
		{
			try
			{
				if (campo.Length < maxtamanho)
					throw new TamnahoMinimo();
			}
			catch (Exception ex)
			{
				_logService.Log(ex, linha);
			}
		}

		/// <summary>
		/// Confere se um campo obrigatório está em branco
		/// </summary>
		/// <param name="valor"></param>
		/// <param name="linha"></param>
		public static void ConfereNaoNulo(string valor, string linha)
		{
			try
			{
				if (string.IsNullOrEmpty(valor))
					throw new ValorNuloException();
			}
			catch (Exception ex)
			{
				_logService.Log(ex, linha);
			}
		}
		public static void ConfereNulo(string valor, string linha)
		{
			try
			{
				if (!string.IsNullOrEmpty(valor))
					throw new ValorNaoNuloException();
			}
			catch (Exception ex)
			{
				_logService.Log(ex, linha);
			}
		}
		public static void ConfereData(string data, string linha)
		{
			try
			{
				DateTime datareal = new DateTime();

				if (!DateTime.TryParse(data, out datareal))
					throw new DataInvalidaException();

				if (!datareal.ToString("yyyy-MM-dd").Equals(data))
					throw new DataFormatoInvalidoException();
			}
			catch (Exception e)
			{
				_logService.Log(e, linha);
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
				bool correto = false;

				if (valor.Equals(valor1))
					correto = true;

				if (valor.Equals(valor2))
					correto = true;

				if (!correto)
					throw new ValorIncorretoExcepetion();
			}
			catch (Exception e)
			{
				_logService.Log(e, linha);
			}
		}
	}
}
