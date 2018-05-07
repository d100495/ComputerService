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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Modele;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private int ButtonDelay = Repository.GlobalButtonDelay;


        public void Regexp(string re, TextBox tb, Label lbl, string s)
        {
            //Regex regex = new Regex(re);

            //if (regex.IsMatch(tb.Text))
            //{

            //    lbl.ForeColor = Color.Green;
            //    lbl.Text = s + " Valid";
            //}
            //else
            //{

            //    lbl.ForeColor = Color.Red;
            //    lbl.Text = s + " InValid";
            //}
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            TextBox textboxsender = sender as TextBox;

            if (string.IsNullOrEmpty(textboxsender.Text) || string.IsNullOrWhiteSpace(textboxsender.Text) || textboxsender.Text == "")
            {
                textboxsender.Background = Brushes.Red;
                lblNrtel.Foreground = Brushes.Red;
                lblNrtel.Content = "Brak numeru!";
            }
            else
            {
                textboxsender.Background = Brushes.White;
                lblNrtel.Foreground = Brushes.Black;
                lblNrtel.Content = "Wpisz numer telefonu";
            }

            if (regex.IsMatch(e.Text))
            {
                textboxsender.Background = Brushes.Red;
                lblNrtel.Foreground = Brushes.Red;
                lblNrtel.Content = "Tylko cyfry!";
            }



        }


        private async Task Refresh()
        {
            Task<IEnumerable<Klient>> task = new Task<IEnumerable<Klient>>(() => Repository.repoInstance.GetAllKlient(urlStringKlienci + "GetAll"));
            task.Start();


            var x = await task;
            lstView1.Items.Clear();

            foreach (var item in x)
            {
                lstView1.Items.Add(item);
            }
            //Jest problemo z odświeżaniem wszystkiego ogólnie, trzeba wrzucic na serwer i sprawdzic jak to dziala
        }



        //URLs
        public string urlStringKlienci = Repository.repoInstance.urlString + "klienci/";





        private async void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            await Refresh();

        }


        private async void btnPut_Click(object sender, RoutedEventArgs e)
        {
            int? nrtel;

            if (string.IsNullOrEmpty(txt4_NumerTel.Text) || string.IsNullOrWhiteSpace(txt4_NumerTel.Text))
            {
                nrtel = null;

            }
            else
            {
                nrtel = Convert.ToInt32(txt4_NumerTel.Text);
            }

            if (lstView1.SelectedIndex != -1)
            {
                int zz = ((Klient)lstView1.SelectedItem).idKlienta;
                Klient device1 = new Klient(zz, txt1_Nazwisko.Text, txt2_Imie.Text, txt3_Adres.Text, nrtel);
                Task task = new Task(() => Repository.repoInstance.PutKlient(urlStringKlienci + "Put", device1));
                task.Start();

                await task;
                await Refresh();

                (sender as Button).IsEnabled = false;
                await Task.Delay(ButtonDelay);
                (sender as Button).IsEnabled = true;
            }
        }



        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                int zz = ((Klient)lstView1.SelectedItem).idKlienta;

                Task task = new Task(() => Repository.repoInstance.DeleteKlient(urlStringKlienci + "Delete/", zz));
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
            int? nrtel;

            if (string.IsNullOrEmpty(txt4_NumerTel.Text) || string.IsNullOrWhiteSpace(txt4_NumerTel.Text))
            {
                nrtel = null;

            }
            else
            {
                nrtel = Convert.ToInt32(txt4_NumerTel.Text);
            }



            Klient klient1 = new Klient(txt1_Nazwisko.Text, txt2_Imie.Text, txt3_Adres.Text, nrtel);

            Task task = new Task(() => Repository.repoInstance.PostClient(urlStringKlienci + "Post", klient1));
            task.Start();

            await task;
            await Refresh();

            (sender as Button).IsEnabled = false;
            await Task.Delay(ButtonDelay);
            (sender as Button).IsEnabled = true;

        }



        private async void lstView1_Loaded(object sender, RoutedEventArgs e)
        {
            Task<IEnumerable<Klient>> task = new Task<IEnumerable<Klient>>(() => Repository.repoInstance.GetAllKlient(urlStringKlienci + "GetAll"));
            task.Start();


            var x = await task;
            lstView1.Items.Clear();

            foreach (var item in x)
            {
                lstView1.Items.Add(item);
            }
        }

        private void lstView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                var item = ((Klient)lstView1.SelectedItem).idKlienta;


                UrzadzeniaWindow window1 = new UrzadzeniaWindow(item);
                window1.Top = this.Top;
                window1.Left = this.Left;
                window1.Width = this.Width;
                window1.Height = this.Height;
                window1.WindowState = this.WindowState;

                this.Close();
                window1.Show();


            }






        }

        private void btnPokazZlec_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                var item = ((Klient)lstView1.SelectedItem).idKlienta;


                ZleceniaWindow window1 = new ZleceniaWindow(item);
                window1.Top = this.Top;
                window1.Left = this.Left;
                window1.Width = this.Width;
                window1.Height = this.Height;
                window1.WindowState = this.WindowState;

                this.Close();
                window1.Show();


            }
        }

        private void btnPokazUrz_Click(object sender, RoutedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                var item = ((Klient)lstView1.SelectedItem).idKlienta;


                UrzadzeniaWindow window1 = new UrzadzeniaWindow(item);
                window1.Top = this.Top;
                window1.Left = this.Left;
                window1.Width = this.Width;
                window1.Height = this.Height;
                window1.WindowState = this.WindowState;

                this.Close();
                window1.Show();


            }
        }

        private void lstView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView1.SelectedIndex != -1)
            {
                txt2_Imie.Text = ((Klient)lstView1.SelectedItem).Imie.ToString();
                txt1_Nazwisko.Text = ((Klient)lstView1.SelectedItem).Nazwisko.ToString();
                txt3_Adres.Text = ((Klient)lstView1.SelectedItem).Adres.ToString();
                txt4_NumerTel.Text = ((Klient)lstView1.SelectedItem).Numer_telefonu.ToString();
            }
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


        private async void txtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Task<IEnumerable<Klient>> task = new Task<IEnumerable<Klient>>(() => Repository.repoInstance.GetAllKlient(urlStringKlienci + "GetAll").Where(xz => xz.Nazwisko.ToUpper().Contains(txtSearchBar.Text.ToUpper())));
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

