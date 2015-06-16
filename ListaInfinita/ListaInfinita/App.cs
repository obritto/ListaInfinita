using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ListaInfinita
{
    public class App : Application
    {

        ObservableCollection<string> listaGrandona = new ObservableCollection<string>();

        ObservableCollection<string> listaTela = new ObservableCollection<string>();

        public void MontarListaGrandona()
        {
            for (int i = 0; i < 10000; i++)
            {
                listaGrandona.Add("ITEM "+i);
            }
        }


        public App()
        {
            MontarListaGrandona();

            CarregarItens();

            ListView lista = new ListView
            {
                ItemsSource = listaTela
            };
            lista.ItemAppearing += Lista_ItemAppearing;


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                       lista
                    }
                }
            };
        }

        private void CarregarItens()
        {
            // carrega itens iniciais
            for (int i = 0; i < tamanhoPagina; i++)
            {
                listaTela.Add(listaGrandona[i]);
            }
        }

        int tamanhoPagina = 10;

        private void Lista_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (listaTela == null)
            {
                return;
            }

            var itemMostradoTela = e.Item as string;

            var ultimoItem = listaTela[listaTela.Count - 1];
            var primeiroItem = listaTela[0];

            if (itemMostradoTela == ultimoItem)
            {
                var posicaoAtual = listaGrandona.IndexOf(itemMostradoTela) + 1;
                for (int i = posicaoAtual; i < posicaoAtual + tamanhoPagina; i++)
                {
                    if (i >= 0 && i < listaGrandona.Count)
                    {
                        listaTela.Add(listaGrandona[i]);
                    }
                }
            }
            

            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
