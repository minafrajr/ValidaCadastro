using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCadastro
{
	public class LogService
	{
		public static readonly string arquivoLog =
			@"D:\minaf\Documents\Visual Studio 2013\Projects\ValidaCadastro\ValidaCadastro\Log\log.txt";
		public void Log(string mensagem)
		{
			try
			{
				GravaLog(mensagem);
			}
			catch (Exception e)
			{
				this.Log(e);
			}
		}

		public void Log(Exception ex)
		{
			try
			{
				GravaLog(string.Format("ERRO INTERNO: " + ex.Message));
			}
			catch (Exception e)
			{
				this.Log(e);
			}
		}
		public void Log(Exception ex, string linha)
		{
			try
			{
				GravaLog(string.Format("ERRO: linha: {0} - {1}", linha, ex.Message));
			}
			catch (Exception e)
			{
				this.Log(e);
			}
		}
		private static void GravaLog(string log)
		{
			FileStream fs = new FileStream(arquivoLog, FileMode.Append);
			using (StreamWriter escritor = new StreamWriter(fs))
			{
				escritor.WriteLine("{0}  |  {1}", DateTime.Now, log);
			}
		}
	}
}
