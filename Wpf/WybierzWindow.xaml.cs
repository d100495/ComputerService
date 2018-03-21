using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Modele;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for WybierzWindow.xaml
    /// </summary>
    public partial class WybierzWindow : Window
    {
        public WybierzWindow()
        {
            InitializeComponent();
        }

        int? _idKlientaZlecenia=null;
        int? _idKlientaUrzadzenia=null;
        int? _idUrzadzenia=null;
        int? _idZlecenia=null;

        public WybierzWindow(int? idKlientaZlecenia, int? idKlientaUrzadzenia, int? idUrzadzenia, int? idZlecenia)
        {
            InitializeComponent();

            this._idKlientaUrzadzenia = idKlientaUrzadzenia;
            this._idKlientaZlecenia = idKlientaZlecenia;
            this._idUrzadzenia = idUrzadzenia;
            this._idZlecenia = idZlecenia;
        }



        //URLs
        public string urlStringGetAllUrzadzenia = Repozytorium.repoInstance.urlString + "urzadzenia/GetAll";
        public string urlStringGetAllZlecenia = Repozytorium.repoInstance.urlString + "Zlecenia_dla_klienta/GetAll";


        private async void lstView1_Loaded(object sender, RoutedEventArgs e)
        {
            //Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repozytorium.repoInstance.GetAllZlecenia(urlStringGetAllZlecenia));
            //task.Start();


            //var x = await task;
            //lstView1.Items.Clear();



            //foreach (var item in x)
            //{
            //    lstView1.Items.Add(item);
            //}
        }
        


        void IdChecking()
        {
            if (_idKlientaZlecenia != _idKlientaUrzadzenia && _idKlientaUrzadzenia != null)
            {
                lstView1.Background = Brushes.Pink;
            }
            else if (_idKlientaZlecenia == _idKlientaUrzadzenia && _idKlientaUrzadzenia != null)
            {
                lstView1.Background = Brushes.LightGreen;
            }
            else
            {
                lstView1.Background = Brushes.White;
            }


            if (_idKlientaUrzadzenia != _idKlientaZlecenia && _idKlientaZlecenia != null)
            {
                lstView2.Background = Brushes.Pink;
            }
            else if (_idKlientaUrzadzenia == _idKlientaZlecenia && _idKlientaZlecenia != null)
            {
                lstView2.Background = Brushes.LightGreen;
            }
            else
            {
                lstView2.Background = Brushes.White;
            }
        }


        private void lstView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void lstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                _idZlecenia = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idZlecenia;
                _idKlientaZlecenia = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idKlienta_fk;
                lblWybranyzlecenieValue.Content = _idKlientaZlecenia;
            }
            IdChecking();
        }


        private void lstView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView2.SelectedIndex != -1)
            {
                _idUrzadzenia = ((Urzadzenie)lstView2.SelectedItem).idUrządzenia;
                _idKlientaUrzadzenia = ((Urzadzenie)lstView2.SelectedItem).idKlienta_fk;
                lblWybranyurzadzenieValue.Content = _idKlientaUrzadzenia;
            }

            IdChecking();
        }



        private async void btn_GetAllZlecenia_Click(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repozytorium.repoInstance.GetAllZlecenia(urlStringGetAllZlecenia));
            task.Start();


            var x = await task;
            lstView1.Items.Clear();



            foreach (var item in x)
            {
                lstView1.Items.Add(item);
            }
        }


        private async void btn_GetAllUrzadzenia_Click(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia));
            task.Start();


            var x = await task;
            lstView2.Items.Clear();



            foreach (var item in x)
            {
                lstView2.Items.Add(item);
            }
        }


        private async void lstView2_Loaded(object sender, RoutedEventArgs e)
        {

            //Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia));
            //task.Start();


            //var x = await task;
            //lstView2.Items.Clear();



            //foreach (var item in x)
            //{
            //    lstView2.Items.Add(item);
            //}
        }


        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            UsterkiWindow window1 = new UsterkiWindow(_idZlecenia,_idUrzadzenia,_idKlientaZlecenia,_idKlientaUrzadzenia);
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }

        private async void btn_GetAllZlecenia_Copy_Click(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repozytorium.repoInstance.GetAllZlecenia(urlStringGetAllZlecenia).Where(zx=>zx.idKlienta_fk==_idKlientaUrzadzenia));
            task.Start();


            var x = await task;
            lstView1.Items.Clear();



            foreach (var item in x)
            {
                lstView1.Items.Add(item);
            }
        }

        private async void btn_GetAllUrzadzenia_Copy_Click(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia).Where(zx=>zx.idKlienta_fk==_idKlientaZlecenia));
            task.Start();


            var x = await task;
            lstView2.Items.Clear();



            foreach (var item in x)
            {
                lstView2.Items.Add(item);
            }
        }

        private void lblWybranyzlecenieValue_Loaded(object sender, RoutedEventArgs e)
        {
            lblWybranyzlecenieValue.Content = _idKlientaZlecenia;
        }

        private void lblWybranyurzadzenieValue_Loaded(object sender, RoutedEventArgs e)
        {
            lblWybranyurzadzenieValue.Content = _idKlientaUrzadzenia;
        }
    }
}
