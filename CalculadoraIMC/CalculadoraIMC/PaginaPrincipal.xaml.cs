using CalculadoraIMC.Paginas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraIMC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            Sexo.ItemsSource = Enum.GetValues(typeof(OpcionSexo));
            Sexo.SelectedIndexChanged += Sexo_SelectedIndexChanged;
            btCalcular.Clicked += btCalcular_Clicked;
        }

        private void Sexo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void btCalcular_Clicked(object sender, EventArgs e)
        {
            #region
            //if (!string.IsNullOrEmpty(Altura.Text) &&
            //    !string.IsNullOrEmpty(Peso.Text))
            //{
            #endregion
            
            var altura = float.Parse(Altura.Text);      
            var peso = float.Parse(Peso.Text);      
            var edad = int.Parse(Edad.Text);     
            var imc = peso / (altura*altura);        
            IMC.Text = imc.ToString();        
            string resultado = "";
      
            bool Validar = float.TryParse(Altura.Text, out altura)          
                && float.TryParse(Peso.Text, out peso)
                && int.TryParse(Edad.Text, out edad);
            
            if (Validar)               
            {                           
                OpcionSexo opcionSexo = (OpcionSexo)Sexo.SelectedItem;               
                switch (opcionSexo)                
                {                    
                    case OpcionSexo.Hombre:                   
                        if ((imc <= 6 && imc < 15) && (edad < 18 || edad >= 20))//-->Hombre                      
                        {                         
                            ValidarEntradas($"Sos hombre y tu edad es: {edad} y tenes bajo peso {resultado}");
                        }
                        else if (imc >= 18.5 && imc <= 24.9 && (edad <= 23 || edad <= 25))//-->Hombre
                        {
                            ValidarEntradas($"Sos mujer y tu edad es: {edad} y tenes peso normal{resultado}");
                        }
                        else if (imc >= 25 && imc <= 29.9 && (edad.Equals(26) || edad.Equals(27)))//-->Hombre
                        {
                            ValidarEntradas($"Sos hombre y tu edad es: {edad} y tenes  sobrepeso {resultado}");
                        }
                        else
                        {
                            ValidarEntradas($"Sos hombre y tu edad es: {edad} y tenes obesidad {resultado}");//-->Hombre
                        }
                        break;
                        case OpcionSexo.Mujer:
                        if (imc < 18.5 && (edad >= 18 || edad < 20))//-->Mujer
                        {
                            ValidarEntradas($"Sos mujer y tu edad es: {edad} y tenes bajo peso {resultado}");
                        }
                        else if (imc >= 18.5 && imc <= 24.9 && (edad <= 23 || edad <= 25))//-->Mujer
                        {
                            ValidarEntradas($"Sos mujer y tu edad es: {edad} y tenes peso normal{resultado}");
                        }
                        else if (imc >= 25 && imc <= 29.9 && (edad.Equals(26) || edad.Equals(27)))//-->Mujer
                        {
                            ValidarEntradas($"Sos mujer y tu edad es: {edad} y tenes  sobrepeso {resultado}");
                        }
                        else
                        {
                            ValidarEntradas($"Sos mujer y tu edad es: {edad} y tenes obesidad {resultado}");//-->Mujer
                        } 
                        break;  
                    default:      
                        break;   
                }     
            }             
            else              
            {                
                lblResultado.Text = "¡Ingrese valores en los campos. No pueden quedar vacios!";               
            }
             
            #region
            // DisplayAlert("Resultado", resultado, "Ok");
            //}
            //else
            //{
            //    DisplayAlert("Datos erróneos",
            //        "Por favor, llena toda la información",
            //        "Ok");
            //}
            #endregion
        }

        private void btLimpiar_Clicked(object sender, EventArgs e)
        {
            Altura.Text = string.Empty;
            IMC.Text = string.Empty;
            Peso.Text = string.Empty;
            Edad.Text = string.Empty;
            Sexo.SelectedItem = null;
        }

        private void btSalir_Clicked(object sender, EventArgs e)
        {
          //  Environment.Exit(0);//-->PARA EL PROYECTO CalculadorIMC.UWP(FUNCIONA)
            OnBackButtonPressed();//-->PARA EL PROYECTO CalculadorIMC.Androiud(EN TEORIA)
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                bool salir = await DisplayAlert("Salir", "¿Esta seguro que quiere cerrar la aplicación?", "Si", "No");

                if (salir)
                {
                    // Cierra la aplicación
                    Environment.Exit(0);
                }
            });

            // Devuelve true para evitar que el botón de "Atrás" siga ejecutando su comportamiento predeterminado
            return true;
        }

        private async void ValidarEntradas(string message)
        {
            if (message.Contains("tenes bajo peso"))
            {
                await Navigation.PushModalAsync(new BajoPesoPagina());
                lblResultado.Text = message;
            }
            if (message.Contains("tenes sobrepeso"))
            {
                await Navigation.PushModalAsync(new SobrePesoPagina());
                lblResultado.Text = message;
            }
            if (message.Contains("tenes peso normal"))
            {
                await Navigation.PushModalAsync(new PesoNormalPagina());
                lblResultado.Text = message;
            }
            if (message.Contains("tenes obesidad"))
            {
                await Navigation.PushModalAsync(new ObesidadPagina());
                lblResultado.Text = message;
            }
        }      
        public enum OpcionSexo
        {
            Hombre=1,
            Mujer=2
        }
    }
}