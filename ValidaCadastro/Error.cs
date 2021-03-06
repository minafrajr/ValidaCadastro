﻿using System;
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
		public override string Message => Const.erroTamanho;
	}

	public class ValorNuloException : Exception
	{
		public override string Message => Const.erroNulo;
	}

	public class NumeroInvalidoException : Exception
	{
		public override string Message => Const.erroNumero;
	}
	public class DataInvalidaException : Exception
	{
		public override string Message => Const.erroDataInvalida;
	}
	public class DataFormatoInvalidoException : Exception
	{
		public override string Message => Const.erroDataFormatoInvalido;
	}
	public class ValorIncorretoExcepetion : Exception
	{
		public override string Message => Const.erroValorIncorreto;
	}

	public class TamnahoMinimo : Exception
	{
		public override string Message => Const.erroTamanhoMinimo;
	}

	public class ValorNaoNuloException : Exception
	{
		public override string Message => Const.erroNaoNulo;
	}
	public class ValorMaximoPermitido : Exception
	{
		public override string Message => Const.erroValorMaximo;
	}

    public class ValorZero : Exception
    {
        public override string Message => Const.erroValorZero;
    }

    public class CampoEmBranco : Exception
    {
        public override string Message => Const.erroCamposEmBranco;
    }
}



