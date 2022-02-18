using Sistema_Agendamento.Enum;
using System;
using System.Globalization;

namespace Sistema_Agendamento.Entidades
{
    public class Processo
    {   
        public int ProcessoId { get; set; }
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public StatusProcessoEnum Status { get; set; }
        public string NumeroProcesso { get; set; }
        public EstadosEnum EstadoProcessoEnum { get; set; }
        public double Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Excluido { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Empresa - " + this.NomeCliente + Environment.NewLine;
            retorno += "\n";
            retorno += "Processo - " + this.ProcessoId + Environment.NewLine;
            retorno += "Status - " + this.EstadoProcessoEnum + Environment.NewLine;
            retorno += "Número - " + this.NumeroProcesso + Environment.NewLine;
            retorno += "Estado - " + this.EstadoProcessoEnum + Environment.NewLine;
            retorno += "Valor R$ " + this.Valor.ToString(CultureInfo.InvariantCulture) + Environment.NewLine;
            retorno += "Data Inicio: " + this.DataInicio.ToString("dd/MM/yyyy") + Environment.NewLine;
            retorno += "--------------------------------------\n";
            
            return retorno;
        }
    }
}
