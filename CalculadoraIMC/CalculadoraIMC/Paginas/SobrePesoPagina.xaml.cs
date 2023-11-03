using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraIMC.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SobrePesoPagina : ContentPage
	{
		public SobrePesoPagina ()
		{
			InitializeComponent ();
		}
        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}