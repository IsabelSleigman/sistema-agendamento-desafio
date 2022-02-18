using Sistema_Agendamento.Data;
using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Enum;
using System;

namespace Sistema_Agendamento.Service
{
    public static class ProcessoService
    {
        public static ClienteRepository clienteRepository = new ClienteRepository();
        public static ProcessoRepository processoRepository = new ProcessoRepository(clienteRepository);

        public static void Listar()
        {
            Console.WriteLine();
            Console.WriteLine("Processos\n");

            var lista = processoRepository.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma processo Cadastrado.");
            }
            else
            {
                foreach (var processo in lista)
                {
                    Console.WriteLine(processo.ToString());
                }
            }
        }
        public static void NovoProcesso()
        {
            System.Console.WriteLine();
            Console.WriteLine("Novo Processo");

            Console.WriteLine();
            Console.Write("Digite o id do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");
                clienteId = int.Parse(Console.ReadLine());
            }
            var cliente = clienteRepository.RetornaPorId(clienteId);
            Console.Clear();
            Console.Write("Número do Processo: ");
            string numeroProcesso = Console.ReadLine();
            Console.Clear();
            foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
            {
                Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
            }
            Console.Write("Digite o estado entre as opções acima: ");
            int estadoProcesso = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Valor do Processo: ");
            double valorProcesso = double.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Data de Inicio: \n");
            var dataInicio = NovaDataValida();



            var processo = new Processo
            {
                ClienteId = cliente.ClienteId,
                NomeCliente = cliente.Nome,
                EstadoProcessoEnum = (EstadosEnum)estadoProcesso,
                NumeroProcesso = numeroProcesso,
                ProcessoId = ClienteRepository.contadorProcesso += 1,
                Status = StatusProcessoEnum.Ativo,
                DataInicio = dataInicio,
                Excluido = false,
                Valor = valorProcesso
            };

            Console.WriteLine("Processo criado, Deseja salvar processo? (S/n)\n");
            Console.WriteLine(processo.ToString());
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Clear();
            if (opcaoUsuario == "S")
            {
                processoRepository.Criar(processo);
                Console.Write("Processo salvo com sucesso, aperte enter para continuar");
                Console.ReadLine();
            }

            Console.Clear();
        }
        public static void EditarCliente()
        {
            Console.WriteLine();
            Console.Write("Digite o id do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");
                clienteId = int.Parse(Console.ReadLine());
            }
            var cliente = clienteRepository.RetornaPorId(clienteId);
            Console.Clear();

            Console.WriteLine("Deseja realmente editar esse cliente? (S/n)\n");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                Console.Write("Digite o nome da Empresa: ");
                string nomeEmpresa = Console.ReadLine();

                Console.Write("Digite o CNPJ: ");
                string cnpjEmpresa = Console.ReadLine();

                foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
                {
                    Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
                }
                Console.Write("Digite o estado entre as opções acima: ");
                int estadoEmpresa = int.Parse(Console.ReadLine());

                //var clienteEditado = new Cliente
                //{
                //    Nome = nomeEmpresa,
                //    Cnpj = cnpjEmpresa,
                //    EstadoClienteEnum = (EstadosEnum)estadoEmpresa,
                //    Excluido = false,
                //    ClienteId = clienteId
                //};
                //Console.Clear();
                //clienteRepository.Editar(clienteEditado);
                Console.WriteLine("Cliente Editado com sucesso, aperte enter para continuar");
                Console.ReadLine();
            }
        }
        public static void ExcluirCliente()
        {
            Console.Write("Digite o id do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");
                clienteId = int.Parse(Console.ReadLine());
            }

            var cliente = clienteRepository.RetornaPorId(clienteId);
            Console.Clear();

            Console.WriteLine("Deseja Realmente excluir esse cliente? (S/n)\n");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                clienteRepository.Excluir(clienteId);
                Console.WriteLine("Cliente excluido com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static DateTime NovaDataValida()
        {
            Console.Write("Digite o dia: ");
            var dia = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            while (dia < 1 || dia > 31)
            {
                Console.Clear();
                Console.WriteLine("Dia Invalido: \n");
                Console.Write("Digite o dia: ");
                dia = int.Parse(Console.ReadLine());

            }
            Console.Write("Digite o mês: ");
            var mes = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            while (mes < 1 || mes > 12)
            {
                Console.Clear();
                Console.WriteLine("Mês Invalido: \n");
                Console.Write("Digite o Mês: ");
                mes = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Digite o ano: ");
            var ano = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            DateTime dataDeHoje = DateTime.Now;
            while (ano < 1 || ano > dataDeHoje.Year)
            {
                Console.Clear();
                Console.WriteLine("Ano Invalido: \n");
                Console.Write("Digite o Ano: ");
                ano = int.Parse(Console.ReadLine());

            }
             var dataValida = new DateTime(dia, mes, ano);
            return dataValida;
        }
    }
}
