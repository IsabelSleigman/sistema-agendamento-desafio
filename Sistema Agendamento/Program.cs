
using Sistema_Agendamento.Service;
using System;
using System.Globalization;
using System.Threading;

namespace Sistema_Agendamento
{
    class Program
    {
        static void Main(string[] args)
        {
			Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);

			ClienteService.AdicionarDados();

			string opcaoUsuario = "";

			while (opcaoUsuario.ToUpper() != "X")
            {
				Console.WriteLine();
				Console.WriteLine("Sistema de Agendamento");
				Console.WriteLine();
				Console.WriteLine("Informe a opção desejada:\n");

				Console.WriteLine("1- Clientes");
				Console.WriteLine("2- Processos");
				Console.WriteLine("X- Sair");
				Console.WriteLine("");

				opcaoUsuario = Console.ReadLine().ToUpper();

				switch (opcaoUsuario.ToUpper())
				{
					case "1":
						opcaoUsuario = MenuClienteUsuario();
						break;
					case "2":
						opcaoUsuario = MenuProcessoUsuario();
						break;
					case "V":
						Console.Clear();
						break;
					default:
						Console.Clear();
						break;
				}
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static string MenuClienteUsuario()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("Area Cliente");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:\n");

			Console.WriteLine("1- Listar Clientes");
			Console.WriteLine("2- Criar Novo Cliente");
			Console.WriteLine("3- Editar Cliente");
			Console.WriteLine("4- Excluir Cliente");
			Console.WriteLine("V- Voltar");
			Console.WriteLine("");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			Console.Clear();

			while (opcaoUsuario != "V")
			{
				switch (opcaoUsuario.ToUpper())
				{
					case "1":
						ClienteService.Listar();
						Console.WriteLine("Aperte enter para continuar");
						Console.ReadLine().ToUpper();
						Console.Clear();
						break;
					case "2":
                        while (opcaoUsuario != "N")
                        {
							ClienteService.CadastrarCliente();
							Console.WriteLine("Deseja Criar novo Cliente? S/n");
							opcaoUsuario = Console.ReadLine().ToUpper();
							Console.Clear();
						}
						break;
					case "3":
						ClienteService.EditarCliente();
						Console.Clear();
						break;
					case "4":
						ClienteService.ExcluirCliente();
						Console.Clear();
						break;
					default:
						Console.Clear();
						break;
				}

				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("Area Cliente");
				Console.WriteLine();
				Console.WriteLine("Informe a opção desejada:\n");

				Console.WriteLine("1- Listar Clientes");
				Console.WriteLine("2- Criar Novo Cliente");
				Console.WriteLine("3- Editar Cliente");
				Console.WriteLine("4- Excluir Cliente");
				Console.WriteLine("V- Voltar");
				Console.WriteLine("");

				opcaoUsuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				Console.Clear();
			}

			return opcaoUsuario;
		}
		private static string MenuProcessoUsuario()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("Processos");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:\n");

			Console.WriteLine("1- Listar Processos");
			Console.WriteLine("2- Criar Novo Processo");
			Console.WriteLine("3- Editar Processo");
			Console.WriteLine("4- Excluir Processo");
			Console.WriteLine("5- Somar Processos");
			Console.WriteLine("6- Calcular Média por Estado");
			Console.WriteLine("7- Listar Processos Data ");
			Console.WriteLine("8- Listar Processos Estado ");
			Console.WriteLine("9- Listar Processos TRAB ");
			Console.WriteLine("V- Voltar");
			Console.WriteLine("");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();

			Console.Clear();

			while (opcaoUsuario != "V")
			{
				switch (opcaoUsuario.ToUpper())
				{
					case "1":
						ProcessoService.Listar();
						Console.WriteLine("Aperte enter para continuar");
						Console.ReadLine().ToUpper();
						Console.Clear();
						break;
					case "2":
						while (opcaoUsuario != "N")
						{
							ProcessoService.NovoProcesso();
							Console.WriteLine("Deseja Criar novo Processo? S/n");
							opcaoUsuario = Console.ReadLine().ToUpper();
							Console.Clear();
						}
						break;
					case "3":
						ProcessoService.EditarProcesso();
						Console.Clear();
						break;
					case "4":
						ProcessoService.ExcluirProcesso();
						Console.Clear();
						break;
					case "5":
						ProcessoService.SomaProcessosAtivos();
						Console.Clear();
						break;
					case "6":
						ProcessoService.CalcularMediaPorEstado();
						Console.Clear();
						break;
					case "7":
						ProcessoService.ListarProcessoMesAno();
						Console.Clear();
						break;
					case "8":
						ProcessoService.ListarProcessoEstadoCliente();
						Console.Clear();
						break;
					case "9":
						ProcessoService.ListarProcessoSiglaTrab();
						Console.Clear();
						break;
					default:
						Console.Clear();
						break;
				}

				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("Processos");
				Console.WriteLine();
				Console.WriteLine("Informe a opção desejada:\n");

				Console.WriteLine("1- Listar Processos");
				Console.WriteLine("2- Criar Novo Processo");
				Console.WriteLine("3- Editar Processo");
				Console.WriteLine("4- Excluir Processo");
				Console.WriteLine("5- Somar Processos");
				Console.WriteLine("6- Calcular Média por Estados");
				Console.WriteLine("7- Listar Processos Data ");
				Console.WriteLine("8- Listar Processos Estado ");
				Console.WriteLine("9- Listar Processos TRAB ");
				Console.WriteLine("V- Voltar");
				Console.WriteLine("");

				opcaoUsuario = Console.ReadLine().ToUpper();
				Console.WriteLine();
				Console.Clear();
			}

			return opcaoUsuario;
		}
	}
}
