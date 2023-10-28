using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace CalculadoraIMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void btCalcular_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Altura.Text) &&
                !string.IsNullOrEmpty(Peso.Text))
            {
                var altura = float.Parse(Altura.Text);
                var peso = float.Parse(Peso.Text);

                var imc = peso / (altura*altura);
                IMC.Text = imc.ToString();

                string resultado = string.Empty;

                if (imc < 18.5)
                {
                    resultado = "Tenes bajo peso";
                }
                else if (imc >= 18.5 && imc <= 24.9)
                {
                    resultado = "Tu peso es normal";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    resultado = "Tenes sobrepreso";                   
                }
                else
                {
                    resultado = "Tenes obesidad, ¡Cuídate!";
                }

                DisplayAlert("Resultado", resultado, "Ok");
            }
            else
            {
                DisplayAlert("Datos erróneos",
                    "Por favor, llena toda la información",
                    "Ok");
            }
        }

        private void btLimpiar_Clicked(object sender, EventArgs e)
        {
            Altura.Text = string.Empty;
            IMC.Text = string.Empty;
            Peso.Text = string.Empty;
        }

        private void btSalir_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }   
    }
}