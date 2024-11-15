namespace MauiAppEventos.Models
{
    internal class Evento
    {
        public String Nome { get; set; }
        public String Local { get; set; }
        public int NumeroParticipantes { get; set; }

        public double Custo { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }


        public int DiasTotais
        {
            get => DataTermino.Subtract(DataInicio).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valorParcial = Custo * NumeroParticipantes;
                double valorTotal = valorParcial * DiasTotais;

                return valorTotal;
            }
        }
    }
}
