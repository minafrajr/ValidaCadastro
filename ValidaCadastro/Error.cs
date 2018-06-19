using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCadastro
{
	public class TamanhoErradoException : Exception
	{
		public override string Message
		{
			get { return Const.erroTamanho; }
		}
	}

	public class ValorNuloException : Exception
	{
		public override string Message
		{
			get { return Const.erroNulo; }
		}
	}

	public class NumeroInvalidoException : Exception
	{
		public override string Message
		{
			get { return Const.erroNumero; }
		}
	}
	public class DataInvalidaException : Exception
	{
		public override string Message
		{
			get { return Const.erroDataInvalida; }
		}
	}
	public class DataFormatoInvalidoException : Exception
	{
		public override string Message
		{
			get { return Const.erroDataFormatoInvalido; }
		}
	}
	public class ValorIncorretoExcepetion : Exception
	{
		public override string Message
		{
			get { return Const.erroValorIncorreto; }
		}
	}

    public class TamnahoMinimo : Exception
    {
        public override string Message
        {
            get { return Const.erroTamanhoMinimo; }
        }
    }
}



