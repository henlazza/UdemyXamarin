using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;


namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Lógica do Programa


            
            //TODO - Validações 
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2}, {3}, {0} - {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O CEP: " + cep + " não existe", "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            Boolean valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }

            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter apenas números", "OK");
                valido = false;
            }
            return valido;
        }
	}
}
