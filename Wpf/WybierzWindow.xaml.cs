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
    public partial class WybierzWindow : Window
    {
        public WybierzWindow()
        {
            InitializeComponent();
        }

        int? _idClientOrder = null;
        int? _idKlientaUrzadzenia = null;
        int? _idUrzadzenia = null;
        int? _idZlecenia = null;

        public WybierzWindow(int? idKlientaZlecenia, int? idKlientaUrzadzenia, int? idUrzadzenia, int? idZlecenia)
        {
            InitializeComponent();

            this._idKlientaUrzadzenia = idKlientaUrzadzenia;
            this._idClientOrder = idKlientaZlecenia;
            this._idUrzadzenia = idUrzadzenia;
            this._idZlecenia = idZlecenia;
        }



        public string urlStringGetAllUrzadzenia = Repository.repoInstance.urlString + "urzadzenia/GetAll";
        public string urlStringGetAllZlecenia = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/GetAll";


        void IdChecking()
        {
            if (_idClientOrder != _idKlientaUrzadzenia && _idKlientaUrzadzenia != null)
            {
                lstView1.Background = Brushes.Pink;
            }
            else if (_idClientOrder == _idKlientaUrzadzenia && _idKlientaUrzadzenia != null)
            {
                lstView1.Background = Brushes.LightGreen;
            }
            else
            {
                lstView1.Background = Brushes.White;
            }


            if (_idKlientaUrzadzenia != _idClientOrder && _idClientOrder != null)
            {
                lstView2.Background = Brushes.Pink;
            }
            else if (_idKlientaUrzadzenia == _idClientOrder && _idClientOrder != null)
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
                _idClientOrder = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idKlienta_fk;
                lblWybranyzlecenieValue.Content = _idClientOrder;
            }
            IdChecking();
        }


        private void lstView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView2.SelectedIndex != -1)
            {
                _idUrzadzenia = ((device)lstView2.SelectedItem).idUrządzenia;
                _idKlientaUrzadzenia = ((device)lstView2.SelectedItem).idKlienta_fk;
                lblWybranydeviceValue.Content = _idKlientaUrzadzenia;
            }

            IdChecking();
        }



        private async void btn_GetAllZlecenia_Click(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repository.repoInstance.GetAllZlecenia(urlStringGetAllZlecenia));
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
            Task<IEnumerable<device>> task = new Task<IEnumerable<device>>(() => Repository.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia));
            task.Start();


            var x = await task;
            lstView2.Items.Clear();



            foreach (var item in x)
            {
                lstView2.Items.Add(item);
            }
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            UsterkiWindow window1 = new UsterkiWindow(_idZlecenia, _idUrzadzenia, _idClientOrder, _idKlientaUrzadzenia);
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
            Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repository.repoInstance.GetAllZlecenia(urlStringGetAllZlecenia).Where(zx => zx.idKlienta_fk == _idKlientaUrzadzenia));
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
            Task<IEnumerable<device>> task = new Task<IEnumerable<device>>(() => Repository.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia).Where(zx => zx.idKlienta_fk == _idClientOrder));
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
            lblWybranyzlecenieValue.Content = _idClientOrder;
        }

        private void lblWybranydeviceValue_Loaded(object sender, RoutedEventArgs e)
        {
            lblWybranydeviceValue.Content = _idKlientaUrzadzenia;
        }
    }
}
