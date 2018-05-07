using System;
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
    /// Interaction logic for ZleceniaWindow.xaml
    /// </summary>
    public partial class ZleceniaWindow : Window
    {

        int? _idKlienta;
        bool pokazWszystkie = false;

        private int ButtonDelay = Repository.GlobalButtonDelay;

        public ZleceniaWindow()
        {
            InitializeComponent();
        }

        public ZleceniaWindow(int idKlienta)
        {
            InitializeComponent();

            this._idKlienta = idKlienta;
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
            if (regex.IsMatch(e.Text))
            {
                (sender as TextBox).Background = Brushes.Red;
                lblModel.Foreground = Brushes.Red;
                lblModel.Content = "Wpisz koszt! Tylko cyfry są dozwolone!";
            }
            else
            {
                (sender as TextBox).Background = Brushes.White;
                lblModel.Foreground = Brushes.Black;
                lblModel.Content = "Wpisz całkowity koszt zlecenia:";
            }
        }



        private void DatePrzyjValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0123456789-:]");
            if (!regex.IsMatch(e.Text))
            {
                (sender as TextBox).Background = Brushes.Red;
                lblDatPrzyj.Foreground = Brushes.Red;
                lblDatPrzyj.Content = "Wpisz poprawną datę w formacie RRRR-MM-DD hh:mm:ss";
            }
            else
            {
                (sender as TextBox).Background = Brushes.White;
                lblDatPrzyj.Foreground = Brushes.Black;
                lblDatPrzyj.Content = "Wpisz datę przyjęcia zlecenia:";
            }
        }

        private void DateWykValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0123456789-:]");
            if (!regex.IsMatch(e.Text))
            {
                (sender as TextBox).Background = Brushes.Red;
                lblDatWyk.Foreground = Brushes.Red;
                lblDatWyk.Content = "Wpisz poprawną datę w formacie RRRR-MM-DD hh:mm:ss";
            }
            else
            {
                (sender as TextBox).Background = Brushes.White;
                lblDatWyk.Foreground = Brushes.Black;
                lblDatWyk.Content = "Wpisz datę wykonania zlecenia (zakończenie zlecenia):";
            }
        }


        private bool CheckDate(String data)
        {
            try
            {
                DateTime dt = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }





        private async Task Refresh()
        {
            if (pokazWszystkie == false)
            {
                if (_idKlienta != null)
                {
                    btnPut.Content = "Zmień";
                    Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repository.repoInstance.GetClientOrders(urlStringGetClientOrders, _idKlienta));
                    task.Start();


                    var x = await task;
                    lstView1.Items.Clear();

                    foreach (var item in x)
                    {
                        lstView1.Items.Add(item);
                    }
                }
            }


            if (pokazWszystkie == true)
            {
                btnPut.Content = "Zmień i przypisz";
                Task<IEnumerable<Zlecenie_dla_klienta>> task = new Task<IEnumerable<Zlecenie_dla_klienta>>(() => Repository.repoInstance.GetAllOrders(urlStringGetAllOrders));
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
        public string urlStringGetAllOrders = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/GetAll";
        public string urlStringGetClientOrders = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/GetClientOrders?clientId=";
        public string urlStringDeleteOrder = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/Delete/";
        public string urlStringPostOrder = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/Post";
        public string urlStringPutOrder = Repository.repoInstance.urlString + "Zlecenia_dla_klienta/Put";
        public string urlStringGetKlient = Repository.repoInstance.urlString + "klienci/Get/";

        private async void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            pokazWszystkie = true;
            await Refresh();

        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            pokazWszystkie = false;
            await Refresh();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                int zz = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idZlecenia;

                Task task = new Task(() => Repository.repoInstance.DeleteDevice(urlStringDeleteOrder, zz));
                task.Start();

                await task;
                await Refresh();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
        }


        private async void btnPost_Click(object sender, RoutedEventArgs e)
        {

            bool isAbleToChange = true;
            System.DateTime? datPrzyjecia, datWykonania;


            if (string.IsNullOrEmpty(txt1_datPrzyjecia.Text) || txt1_datPrzyjecia.Text == "____-__-__ __:__:__" || string.IsNullOrWhiteSpace(txt1_datPrzyjecia.Text))
            {
                datPrzyjecia = null;
            }
            else if (CheckDate(txt1_datPrzyjecia.Text) == false)
            {
                isAbleToChange = false;
                datPrzyjecia = null;
                lblDatPrzyj.Foreground = Brushes.Red;
                lblDatPrzyj.Content = "Niepoprawna data!";
            }
            else
            {
                datPrzyjecia = Convert.ToDateTime(txt1_datPrzyjecia.Text);
            }



            if (string.IsNullOrEmpty(txt4_datWykonania.Text) || txt4_datWykonania.Text == "____-__-__ __:__:__" || string.IsNullOrWhiteSpace(txt1_datPrzyjecia.Text))
            {
                datWykonania = null;
            }
            else if (CheckDate(txt4_datWykonania.Text) == false)
            {
                isAbleToChange = false;
                datWykonania = null;
                lblDatWyk.Foreground = Brushes.Red;
                lblDatWyk.Content = "Niepoprawna data!";
            }
            else
            {
                datWykonania = Convert.ToDateTime(txt4_datWykonania.Text);
            }
            if (string.IsNullOrEmpty(txt3_KosztCal.Text) || string.IsNullOrWhiteSpace(txt3_KosztCal.Text))
            {
                isAbleToChange = false;
                lblModel.Foreground = Brushes.Red;
                lblModel.Content = "Kwota nie może być pusta!";
            }



            if (isAbleToChange == true && _idKlienta != null)
            {
                Zlecenie_dla_klienta zlecenie1 = new Zlecenie_dla_klienta(datPrzyjecia, datWykonania, Convert.ToDecimal(txt3_KosztCal.Text), _idKlienta);

                Task task = new Task(() => Repository.repoInstance.PostOrder(urlStringPostOrder, zlecenie1));
                task.Start();

                await task;
                await Refresh();

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

                foreach (var item in Repository.repoInstance.GetClientOrders(urlStringGetClientOrders, _idKlienta))
                {
                    lstView1.Items.Add(item);
                }
            }
        }



        private void lblUid_Loaded(object sender, RoutedEventArgs e)
        {

            if (_idKlienta != null)
            {
                Klient xx = Repository.repoInstance.GetKlient(urlStringGetKlient, _idKlienta);

                lblUid.Content = xx.idKlienta;
                lblUim.Content = xx.Imie;
                lblUnazw.Content = xx.Nazwisko;
                lblUadr.Content = xx.Adres;
                lblUnrTel.Content = xx.Numer_telefonu;

            }
        }

        private async void btnPut_Click(object sender, RoutedEventArgs e)
        {

            bool isAbleToChange = true;
            System.DateTime? datPrzyjecia, datWykonania;


            if (string.IsNullOrEmpty(txt1_datPrzyjecia.Text) || txt1_datPrzyjecia.Text == "____-__-__ __:__:__" || string.IsNullOrWhiteSpace(txt1_datPrzyjecia.Text))
            {
                datPrzyjecia = null;
            }
            else if (CheckDate(txt1_datPrzyjecia.Text) == false)
            {
                isAbleToChange = false;
                datPrzyjecia = null;
                lblDatPrzyj.Foreground = Brushes.Red;
                lblDatPrzyj.Content = "Niepoprawna data!";
            }
            else
            {
                datPrzyjecia = Convert.ToDateTime(txt1_datPrzyjecia.Text);
            }



            if (string.IsNullOrEmpty(txt4_datWykonania.Text) || txt4_datWykonania.Text == "____-__-__ __:__:__" || string.IsNullOrWhiteSpace(txt1_datPrzyjecia.Text))
            {
                datWykonania = null;
            }
            else if (CheckDate(txt4_datWykonania.Text) == false)
            {
                isAbleToChange = false;
                datWykonania = null;
                lblDatWyk.Foreground = Brushes.Red;
                lblDatWyk.Content = "Niepoprawna data!";
            }
            else
            {
                datWykonania = Convert.ToDateTime(txt4_datWykonania.Text);
            }
            if (string.IsNullOrEmpty(txt3_KosztCal.Text) || string.IsNullOrWhiteSpace(txt3_KosztCal.Text))
            {
                isAbleToChange = false;
                lblModel.Foreground = Brushes.Red;
                lblModel.Content = "Kwota nie może być pusta!";
            }

            if (((Zlecenie_dla_klienta)lstView1.SelectedItem).Data_wykonania < System.DateTime.Now && ((Zlecenie_dla_klienta)lstView1.SelectedItem).Data_przyjęcia_zlecenia != null)
            {
                isAbleToChange = false;
                MessageBox.Show("Zlecenie zostało zakończone!");
            }


            if (lstView1.SelectedIndex != -1 && isAbleToChange == true && _idKlienta != null)
            {
                int zz = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idZlecenia;
                Zlecenie_dla_klienta zlecenie1 = new Zlecenie_dla_klienta(zz, datPrzyjecia, datWykonania, Convert.ToDecimal(txt3_KosztCal.Text), _idKlienta);
                Task task = new Task(() => Repository.repoInstance.PutOrder(urlStringPutOrder, zlecenie1));
                task.Start();

                await task;
                await Refresh();


                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }



        }

        private void lstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                txt1_datPrzyjecia.Text = ((Zlecenie_dla_klienta)lstView1.SelectedItem).Data_przyjęcia_zlecenia.ToString();
                txt3_KosztCal.Text = ((Zlecenie_dla_klienta)lstView1.SelectedItem).Całkowity_koszt.ToString();
                txt4_datWykonania.Text = ((Zlecenie_dla_klienta)lstView1.SelectedItem).Data_wykonania.ToString();
            }

        }

        private void lstView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {

                if (((Zlecenie_dla_klienta)lstView1.SelectedItem).idKlienta_fk != null)
                {
                    _idKlienta = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idKlienta_fk;

                    Klient xx = Repository.repoInstance.GetKlient(urlStringGetKlient, _idKlienta);


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

            int? zz = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idZlecenia;
            int? xx = ((Zlecenie_dla_klienta)lstView1.SelectedItem).idKlienta_fk;

            UsterkiWindow window1 = new UsterkiWindow(zz, null, xx, null);
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
    }
}
