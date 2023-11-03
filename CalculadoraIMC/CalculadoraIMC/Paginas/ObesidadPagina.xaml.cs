using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraIMC.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ObesidadPagina : ContentPage
	{
		public ObesidadPagina ()
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