using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEvento : ContentPage
{

    App PropriedadesApp;
    public CadastroEvento()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_termino.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_termino.MinimumDate = dtpck_inicio.Date.AddDays(1);
        dtpck_termino.MaximumDate = dtpck_inicio.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento ev = new Evento
            {
                Nome = nomeEntry.Text,  
                Local = localEntry.Text,  
                NumeroParticipantes = int.Parse(participantesEntry.Text), 
                Custo = double.Parse(custoEntry.Text),
                DataInicio = dtpck_inicio.Date,
                DataTermino = dtpck_termino.Date,
            };
            await Navigation.PushAsync(new ResumoEvento()


            { BindingContext = ev });

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_inicio = elemento.Date;

        dtpck_termino.MinimumDate = data_selecionada_inicio.AddDays(1);
        dtpck_termino.MaximumDate = data_selecionada_inicio.AddMonths(6);
    }
}
