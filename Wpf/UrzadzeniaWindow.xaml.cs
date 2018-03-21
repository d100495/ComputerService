﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UrzadzeniaWindow.xaml
    /// </summary>
    public partial class UrzadzeniaWindow : Window
    {
        int? _idKlienta;
        bool pokazWszystkie = false;

        private int ButtonDelay = Repozytorium.GlobalButtonDelay;


        public UrzadzeniaWindow()
        {
            InitializeComponent();          

        }


        public UrzadzeniaWindow(int? idKlienta)
        {
            InitializeComponent();

            this._idKlienta = idKlienta;
            //this.txt4_idklientaFk.Text = _idKlienta.ToString();

            //comboBoxID.SelectedItem = _idKlienta;
            //lblUid.Content = _idKlienta;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private async Task Odswiez()
        {
            if(pokazWszystkie==false)
            {
                if (_idKlienta != null)
                {
                    btnPut.Content = "Zmień";
                    Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetUrzadzeniaKlienta(urlStringGetUrzadzeniaKlienta, _idKlienta));
                    task.Start();


                    var x = await task;
                    lstView1.Items.Clear();

                    foreach (var item in x)
                    {
                        lstView1.Items.Add(item);
                    }
                }
            }

            if(pokazWszystkie==true)
            {
                btnPut.Content = "Zmień i przypisz";
                Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetAllUrzadzenia(urlStringGetAllUrzadzenia));
                task.Start();


                var x = await task;
                lstView1.Items.Clear();



                foreach (var item in x)
                {
                    lstView1.Items.Add(item);
                }
            }
           

        }

        


        //URLs
        public string urlStringGetAllUrzadzenia = Repozytorium.repoInstance.urlString + "urzadzenia/GetAll";
        public string urlStringGetUrzadzeniaKlienta = Repozytorium.repoInstance.urlString + "urzadzenia/GetUrzadzeniaKlienta?klientId=";
        public string urlStringDeleteUrzadzenie = Repozytorium.repoInstance.urlString + "urzadzenia/Delete/";
        public string urlStringPostUrzadzenie = Repozytorium.repoInstance.urlString + "urzadzenia/Post/";
        public string urlStringPUTUrzadzenie = Repozytorium.repoInstance.urlString + "urzadzenia/Put/";
        public string urlStringGetKlient = Repozytorium.repoInstance.urlString + "klienci/Get/";

        private async void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            pokazWszystkie = true;
            await Odswiez();
        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            pokazWszystkie = false;
            await Odswiez();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                int zz = ((Urzadzenie)lstView1.SelectedItem).idUrządzenia;

                Task task = new Task(() => Repozytorium.repoInstance.DeleteUrzadzenie(urlStringDeleteUrzadzenie, zz));
                task.Start();

                await task;
                await Odswiez();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
        }


        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {
            if (_idKlienta != null)
            {
                Urzadzenie urzadzenie1 = new Urzadzenie(txt1_Rodzaj.Text, txt3_Model.Text, txt4_Parametry.Text, _idKlienta);

                Task task = new Task(() => Repozytorium.repoInstance.PostUrzadzenie(urlStringPostUrzadzenie, urzadzenie1));
                task.Start();

                await task;
                await Odswiez();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
        }

        private void lstView1_Loaded(object sender, RoutedEventArgs e)
        {
            if (_idKlienta != null)
            {
                lstView1.Items.Clear();

                foreach (var item in Repozytorium.repoInstance.GetUrzadzeniaKlienta(urlStringGetUrzadzeniaKlienta, _idKlienta))
                {
                    lstView1.Items.Add(item);
                }
            }
        }

        //private void comboBoxID_Loaded(object sender, RoutedEventArgs e)
        //{
        //    foreach (var x in Repozytorium.repoInstance.GetAllKlient(urlStringKlienciGetAll))
        //    {
        //        comboBoxID.Items.Add(x.idKlienta);

        //    }

        //    var klienty = Repozytorium.repoInstance.GetAllKlient(urlStringKlienciGetAll).Where(kli => kli.idKlienta.ToString().Equals(comboBoxID.Text));

        //    foreach (var xx in klienty)
        //    {
        //        lblUim.Content = xx.Imie;
        //        lblUnazw.Content = xx.Nazwisko;
        //        lblUadr.Content = xx.Adres;
        //        lblUnrTel.Content = xx.Numer_telefonu;

        //    }
        //}

        //private void comboBoxID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    lstView1.Items.Clear();

        //    var selectedId = Convert.ToInt32(comboBoxID.SelectedValue);

        //    foreach (var item in Repozytorium.repoInstance.GetUrzadzeniaKlienta(urlStringGetUrzadzeniaKlienta, selectedId))
        //    {
        //        lstView1.Items.Add(item);
        //    }
        //}

        //private void comboBoxID_DropDownClosed(object sender, EventArgs e)
        //{

        //    if(comboBoxID.SelectedIndex!=-1)
        //    {
        //        var klienty = Repozytorium.repoInstance.GetAllKlient(urlStringKlienciGetAll).Where(kli => kli.idKlienta.ToString().Equals(comboBoxID.Text));

        //        foreach (var xx in klienty)
        //        {
        //            lblUim.Content = xx.Imie;
        //            lblUnazw.Content = xx.Nazwisko;
        //            lblUadr.Content = xx.Adres;
        //            lblUnrTel.Content = xx.Numer_telefonu;

        //        }

                

        //        txt4_idklientaFk.Text= (comboBoxID.SelectedValue).ToString();
        //    }
            
        //}




        private void lblUid_Loaded(object sender, RoutedEventArgs e)
        {
            if (_idKlienta != null)
            {
                Klient xx = Repozytorium.repoInstance.GetKlient(urlStringGetKlient, _idKlienta);

            
                    lblUid.Content = xx.idKlienta;
                    lblUim.Content = xx.Imie;
                    lblUnazw.Content = xx.Nazwisko;
                    lblUadr.Content = xx.Adres;
                    lblUnrTel.Content = xx.Numer_telefonu;
            }
        }

        private async void btnPut_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1 && _idKlienta!=null)
            {
                
                int zz = ((Urzadzenie)lstView1.SelectedItem).idUrządzenia;
                Urzadzenie urzadzenie1 = new Urzadzenie(zz, txt1_Rodzaj.Text, txt3_Model.Text, txt4_Parametry.Text, _idKlienta);
                Task task = new Task(() => Repozytorium.repoInstance.PutUrzadzenie(urlStringPUTUrzadzenie, urzadzenie1));
                task.Start();

                await task;
                await Odswiez();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }


     
        }

        private void lstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                txt1_Rodzaj.Text = ((Urzadzenie)lstView1.SelectedItem).Rodzaj_urzązenia.ToString();
                txt3_Model.Text = ((Urzadzenie)lstView1.SelectedItem).Model_urządzenia.ToString();
                txt4_Parametry.Text = ((Urzadzenie)lstView1.SelectedItem).Parametry_urządzenia.ToString();

            }
        }

        private void lstView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                if (((Urzadzenie)lstView1.SelectedItem).idKlienta_fk != null)
                {
                    _idKlienta = ((Urzadzenie)lstView1.SelectedItem).idKlienta_fk;

                    Klient xx = Repozytorium.repoInstance.GetKlient(urlStringGetKlient, _idKlienta);

                 
                        lblUid.Content = xx.idKlienta;
                        lblUim.Content = xx.Imie;
                        lblUnazw.Content = xx.Nazwisko;
                        lblUadr.Content = xx.Adres;
                        lblUnrTel.Content = xx.Numer_telefonu;

                    

                }
                else
                {
                    lblUid.Content = "Brak przypisanego klienta";
                    lblUim.Content = "Brak";
                    lblUnazw.Content = "Brak";
                    lblUadr.Content = "Brak";
                    lblUnrTel.Content = "Brak";
                }

                

            }
        }

        private void btnGoToUsterki_Click(object sender, RoutedEventArgs e)
        {
            int? zz = ((Urzadzenie)lstView1.SelectedItem).idUrządzenia;
            int? xx = ((Urzadzenie)lstView1.SelectedItem).idKlienta_fk;

            UsterkiWindow window1 = new UsterkiWindow(null,zz,null,xx);
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
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

        private void btnNavigateUsterki_Click(object sender, RoutedEventArgs e)
        {
            UsterkiWindow window1 = new UsterkiWindow();
            window1.Top = this.Top;
            window1.Left = this.Left;
            window1.Width = this.Width;
            window1.Height = this.Height;
            window1.WindowState = this.WindowState;
            this.Close();
            window1.Show();
        }








        //private async void btnGetAllUrzadzenia_Click(object sender, RoutedEventArgs e)
        //{
        //    Task<IEnumerable<Urzadzenie>> task = new Task<IEnumerable<Urzadzenie>>(() => Repozytorium.repoInstance.GetAllUrzadzenia(urlStringUrzadzenia + "GetAll"));
        //    task.Start();

        //    lstView1.Items.Clear();

        //    var x = await task;
        //    foreach (var item in x)
        //    {
        //        lstView1.Items.Add(item);
        //    }


        //}




    }
}
