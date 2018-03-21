﻿using System;
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
    /// Interaction logic for UsterkiWindow.xaml
    /// </summary>
    public partial class UsterkiWindow : Window
    {

        int? _idKlientaZlecenia=null;
        int? _idZlecenia=null;
        int? _idUrzadzenia = null;
        int ?_idKlientaUrzadzenia=null;

        bool pokazWszystkie = false;
        bool pokazUstdoUrzadzenia = false;
        bool pokazUstdoZlecenia = false;

        private int ButtonDelay = Repozytorium.GlobalButtonDelay;


        public UsterkiWindow()
        {
            InitializeComponent();

        }


        public UsterkiWindow(int? id_zlecenia, int? id_urzadzenia, int? id_klientaZlecenia, int? id_klientaUrzadzenia)
        {
            InitializeComponent();

            this._idZlecenia = id_zlecenia;
            this._idUrzadzenia = id_urzadzenia;
            this._idKlientaZlecenia = id_klientaZlecenia;
            this._idKlientaUrzadzenia = id_klientaUrzadzenia;
        }



        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9,]+");
            //e.Handled = regex.IsMatch(e.Text);
            //if (regex.IsMatch(e.Text))
            //{
            //    (sender as TextBox).Background = Brushes.Red;
            //    lblModel.Foreground = Brushes.Red;
            //    lblModel.Content = "Wpisz koszt! Tylko cyfry są dozwolone!";
            //}
            //else
            //{
            //    (sender as TextBox).Background = Brushes.White;
            //    lblModel.Foreground = Brushes.Black;
            //    lblModel.Content = "Wpisz całkowity koszt zlecenia:";
            //}
        }



        private void DatePrzyjValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[0123456789-:]");
            //if (!regex.IsMatch(e.Text))
            //{
            //    (sender as TextBox).Background = Brushes.Red;
            //    lblDatPrzyj.Foreground = Brushes.Red;
            //    lblDatPrzyj.Content = "Wpisz poprawną datę w formacie RRRR-MM-DD hh:mm:ss";
            //}
            //else
            //{
            //    (sender as TextBox).Background = Brushes.White;
            //    lblDatPrzyj.Foreground = Brushes.Black;
            //    lblDatPrzyj.Content = "Wpisz datę przyjęcia zlecenia:";
            //}
        }

        private void DateWykValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[0123456789-:]");
            //if (!regex.IsMatch(e.Text))
            //{
            //    (sender as TextBox).Background = Brushes.Red;
            //    lblDatWyk.Foreground = Brushes.Red;
            //    lblDatWyk.Content = "Wpisz poprawną datę w formacie RRRR-MM-DD hh:mm:ss";
            //}
            //else
            //{
            //    (sender as TextBox).Background = Brushes.White;
            //    lblDatWyk.Foreground = Brushes.Black;
            //    lblDatWyk.Content = "Wpisz datę wykonania zlecenia (zakończenie zlecenia):";
            //}
        }




        private async Task Odswiez()
        {
            if (pokazWszystkie == true)
            {
                Task<IEnumerable<Usterka>> task = new Task<IEnumerable<Usterka>>(() => Repozytorium.repoInstance.GetAllUsterki(urlStringUsterkiGetAll));
                task.Start();


                var x = await task;
                lstView1.Items.Clear();

                foreach (var item in x)
                {
                    lstView1.Items.Add(item);
                }
            }

            if(pokazUstdoUrzadzenia == true)
            {
                if (_idUrzadzenia != null)
                {
                    Task<IEnumerable<Usterka>> task = new Task<IEnumerable<Usterka>>(() => Repozytorium.repoInstance.GetUsterkiUrzadzenia(urlStringGetUsterkiUrządzenia, _idUrzadzenia));
                    task.Start();


                    var x = await task;
                    lstView1.Items.Clear();

                    foreach (var item in x)
                    {
                        lstView1.Items.Add(item);
                    }
                }
            }

            if (pokazUstdoZlecenia == true)
            {
                if (_idZlecenia != null)
                {
                    Task<IEnumerable<Usterka>> task = new Task<IEnumerable<Usterka>>(() => Repozytorium.repoInstance.GetUsterkiZlecenia(urlStringGetUsterkiZlecenia, _idZlecenia));
                    task.Start();


                    var x = await task;
                    lstView1.Items.Clear();

                    foreach (var item in x)
                    {
                        lstView1.Items.Add(item);
                    }
                }


            }
        }




        //URLs
        public string urlStringUsterkiGetAll = Repozytorium.repoInstance.urlString + "usterki/GetAll";
        public string urlStringGetUsterkiUrządzenia = Repozytorium.repoInstance.urlString + "Usterki/GeUsterkiUrzadzenia?urzadzenieId=";
        public string urlStringGetZlecenie = Repozytorium.repoInstance.urlString + "Zlecenia_dla_klienta/Get/";
        public string urlStringGetUrzadzenie = Repozytorium.repoInstance.urlString + "Urzadzenia/Get/";
        public string urlStringPostUsterka = Repozytorium.repoInstance.urlString + "Usterki/Post";
        public string urlStringDeleteUsterka = Repozytorium.repoInstance.urlString + "Usterki/Delete/";
        public string urlStringPutUsterka = Repozytorium.repoInstance.urlString + "Usterki/Put";
        public string urlStringGetUsterkiZlecenia = Repozytorium.repoInstance.urlString + "Usterki/GetUsterkiZlecenia?zlecenieId=";

        private async void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            pokazWszystkie = true;
            pokazUstdoUrzadzenia = false;
            pokazUstdoZlecenia = false;
            await Odswiez();

        }

        private async void btnPokazUsterkiZlecenia_Click(object sender, RoutedEventArgs e)
        {
            pokazUstdoUrzadzenia = false;
            pokazWszystkie = false;
            pokazUstdoZlecenia = true;
            if(_idZlecenia!=null)
            {
                await Odswiez();
            }
            else
            {
                lstView1.Items.Clear();
            }
        }

        private async void btnPokazUsterkiUrzadzenia_Click(object sender, RoutedEventArgs e)
        {
            pokazUstdoUrzadzenia = true;
            pokazWszystkie = false;
            pokazUstdoZlecenia = false;
            if (_idUrzadzenia != null)
            {
                await Odswiez();
            }
            else
            {
                lstView1.Items.Clear();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                int zz = ((Usterka)lstView1.SelectedItem).idUsterki;

                Task task = new Task(() => Repozytorium.repoInstance.DeleteUsterka(urlStringDeleteUsterka, zz));
                task.Start();

                await task;
                await Odswiez();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
            await Odswiez();
        }


        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            if (_idKlientaUrzadzenia == _idKlientaZlecenia || _idKlientaUrzadzenia==null || _idKlientaZlecenia==null)
            {
                Usterka usterka1 = new Usterka(ComboBox1_RodzajUsterki.SelectedValue.ToString(), txt3_OpisUsterki.Text, txt4_WykonanePrace.Text, _idZlecenia, _idUrzadzenia);

                Task task = new Task(() => Repozytorium.repoInstance.PostUsterka(urlStringPostUsterka, usterka1));
                task.Start();

                await task;
                await Odswiez();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Id klientów różnią się!");
            }
            await Odswiez();
        }

        private void lstView1_Loaded(object sender, RoutedEventArgs e)
        {
            //lstView1.Items.Clear();

            //foreach (var item in Repozytorium.repoInstance.GetZleceniaKlienta(urlStringGetZleceniaKlienta, _idKlienta))
            //{
            //    lstView1.Items.Add(item);
            //}
        }

        private void lblUidzlecenia_Loaded(object sender, RoutedEventArgs e)
        {
            if(_idUrzadzenia!=null)
            {
                Urzadzenie xx = Repozytorium.repoInstance.GetUrzadzenie(urlStringGetUrzadzenie, _idUrzadzenia);


                lblUidurzadzenia.Content = xx.idUrządzenia;
                lblUmodelurzadzenia.Content = xx.Model_urządzenia;
                lblUrodzajurzadzenia.Content = xx.Rodzaj_urzązenia;
                lblUparamteryurzaadzenia.Content = xx.Parametry_urządzenia;
                lblUidklientaUrzadzenia.Content = xx.idKlienta_fk;
                _idKlientaUrzadzenia = xx.idKlienta_fk;
            }
            else
            {
                _idKlientaUrzadzenia = null;
            }
           
        }

        private void lblUidurzadzenia_Loaded(object sender, RoutedEventArgs e)
        {
            if(_idZlecenia!=null)
            {
                Zlecenie_dla_klienta xx = Repozytorium.repoInstance.GetZlecenie(urlStringGetZlecenie, _idZlecenia);

                lblUidzlecenia.Content = xx.idZlecenia;
                lblUdataprzyjecia.Content = xx.Data_przyjęcia_zlecenia;
                lblUdatawykonania.Content = xx.Data_wykonania;
                lblUkoszt.Content = xx.Całkowity_koszt;
                lblUidKlientaZlecenia.Content = xx.idKlienta_fk;
                _idKlientaZlecenia = xx.idKlienta_fk;
            }
            else
            {
                _idKlientaZlecenia = null;
            }
         
        }

      

        private async void btnPut_Click(object sender, RoutedEventArgs e)
        {

            bool isAbleToChange;

            if (_idKlientaUrzadzenia == _idKlientaZlecenia || _idKlientaUrzadzenia == null || _idKlientaZlecenia == null)
            {
                isAbleToChange = true;
            }
            else
            {
                isAbleToChange = false;
                MessageBox.Show("Id klientów różnią się!");
                
            }


            if (lstView1.SelectedIndex != -1 && isAbleToChange == true)
            {
                int zz = ((Usterka)lstView1.SelectedItem).idUsterki;
                Usterka usterka1 = new Usterka(zz, ComboBox1_RodzajUsterki.SelectedValue.ToString(), txt3_OpisUsterki.Text, txt4_WykonanePrace.Text, _idZlecenia, _idUrzadzenia);
                Task task = new Task(() => Repozytorium.repoInstance.PutUsterka(urlStringPutUsterka, usterka1));
                task.Start();

                await task;
                await Odswiez();


                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }

            await Odswiez();

        }




        private void btnNavigateKlienci_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window1 = new MainWindow();
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }

        private void btnNavigateUrzadzenia_Click(object sender, RoutedEventArgs e)
        {
            UrzadzeniaWindow window1 = new UrzadzeniaWindow();
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }


        private void btnNavigateZlecenia_Click(object sender, RoutedEventArgs e)
        {
            ZleceniaWindow window1 = new ZleceniaWindow();
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }

       
        private void btn_wybierzInne_Click(object sender, RoutedEventArgs e)
        {
            WybierzWindow window1 = new WybierzWindow(_idKlientaZlecenia, _idKlientaUrzadzenia, _idUrzadzenia, _idZlecenia);
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }


        private void lstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                ComboBox1_RodzajUsterki.SelectedValue=(((Usterka)lstView1.SelectedItem).Rodzaj_usterki.ToString());


                txt3_OpisUsterki.Text = ((Usterka)lstView1.SelectedItem).Opis_usterki.ToString();
                txt4_WykonanePrace.Text = ((Usterka)lstView1.SelectedItem).Wykonane_prace.ToString();

            }

        }

        private void lstView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                //Dane Urządzenia

                if (((Usterka)lstView1.SelectedItem).idUrządzenia_fk != null)
                {
                    _idUrzadzenia = ((Usterka)lstView1.SelectedItem).idUrządzenia_fk;

                    Urzadzenie xx = Repozytorium.repoInstance.GetUrzadzenie(urlStringGetUrzadzenie, _idUrzadzenia);


                    lblUidurzadzenia.Content = xx.idUrządzenia;
                    lblUmodelurzadzenia.Content = xx.Model_urządzenia;
                    lblUrodzajurzadzenia.Content = xx.Rodzaj_urzązenia;
                    lblUparamteryurzaadzenia.Content = xx.Parametry_urządzenia;
                    lblUidklientaUrzadzenia.Content = xx.idKlienta_fk;
                    _idKlientaUrzadzenia = xx.idKlienta_fk;
                    
                }
                else
                {
                    _idUrzadzenia = null;

                    lblUidurzadzenia.Content = "Brak wybranego urzadzenia!";
                    lblUmodelurzadzenia.Content = "Brak";
                    lblUrodzajurzadzenia.Content = "Brak";
                    lblUparamteryurzaadzenia.Content = "Brak";
                    lblUidklientaUrzadzenia.Content = "Brak";
                    _idKlientaUrzadzenia = null;
                }



                //Dane Zlecenia

                if (((Usterka)lstView1.SelectedItem).idZlecenia_fk != null)
                {
                    _idZlecenia = ((Usterka)lstView1.SelectedItem).idZlecenia_fk;

                    Zlecenie_dla_klienta xx = Repozytorium.repoInstance.GetZlecenie(urlStringGetZlecenie, _idZlecenia);

                    lblUidzlecenia.Content = xx.idZlecenia;
                    lblUdataprzyjecia.Content = xx.Data_przyjęcia_zlecenia;
                    lblUdatawykonania.Content = xx.Data_wykonania;
                    lblUkoszt.Content = xx.Całkowity_koszt;
                    lblUidKlientaZlecenia.Content = xx.idKlienta_fk;
                    _idKlientaZlecenia = xx.idKlienta_fk;
                }
                else
                {
                    _idZlecenia = null;

                    lblUidzlecenia.Content = "Brak wybranego zlecenia!";
                    lblUdataprzyjecia.Content = "Brak";
                    lblUdatawykonania.Content = "Brak";
                    lblUkoszt.Content = "Brak";
                    lblUidKlientaZlecenia.Content = "Brak";
                    _idKlientaZlecenia = null;
                }
            }
        }



        private void txt1_RodzajUsterki_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox1_RodzajUsterki.Items.Add("Sprzetowa");
            ComboBox1_RodzajUsterki.Items.Add("Systemowa");

            ComboBox1_RodzajUsterki.SelectedIndex = 0;
        }

       

    }
}
