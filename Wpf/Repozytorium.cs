using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Wpf.Modele;

namespace Wpf
{

     public sealed class Repozytorium
     {
                private static Repozytorium repo = null;
                private int liczbaInstancji = 0;


                public static Repozytorium repoInstance
                {
                    get
                    {
                        if (repo == null)
                        {
                            repo = new Repozytorium();
                        }
                        return repo;
                    }
                }

                private Repozytorium()
                {
                    liczbaInstancji = 1;    //debugging
                }


        //
        //=======================URLs============================
        //

      
        public string urlString = "http://localhost:50966/api/";

        //public string urlString = "http://d100495-001-site1.htempurl.com/api/";


        //
        //=======================Variables============================
        //

        public static int GlobalButtonDelay = 3000;


        //
        //===============================================<KLIENCI>============================================
        //

        public IEnumerable<Klient> GetAllKlient(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Klient>>(s);
        }//getall

        public Klient GetKlient(string uri, int? idKlienta)
        {
            string xx = uri + idKlienta;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Klient>(s);
        }//get


        public void PostKlient(string uri, Klient klient)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idKlienta = klient.idKlienta,
                    Nazwisko = klient.Nazwisko,
                    Imie = klient.Imie,
                    Adres = klient.Adres,
                    Numer_telefonu = klient.Numer_telefonu

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }//post



        public void DeleteKlient(string uri,int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           
        }//delete




        public void PutKlient(string uri, Klient klient)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idKlienta = klient.idKlienta,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    Adres = klient.Adres,
                    Numer_telefonu = klient.Numer_telefonu
                    

                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }//put

        //
        //===============================================<URZADZENIA>============================================
        //

        public IEnumerable<Urzadzenie> GetAllUrzadzenia(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Urzadzenie>>(s);
        }//getall


        public Urzadzenie GetUrzadzenie(string uri, int? idUrzadzenia)
        {
            string xx = uri + idUrzadzenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Urzadzenie>(s);
        }//get


        public IEnumerable<Urzadzenie> GetUrzadzeniaKlienta(string uri,int? idKlienta)
        {
            string sURL = uri + idKlienta;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Urzadzenie>>(s);
        }//geturzadzeniaklienta


        public void DeleteUrzadzenie(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }//delete


        public void PostUrzadzenie(string uri, Urzadzenie urzadzenie)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUrządzenia = urzadzenie.idUrządzenia,
                    Rodzaj_urzązenia = urzadzenie.Rodzaj_urzązenia,
                    Model_urządzenia = urzadzenie.Model_urządzenia,
                    Parametry_urządzenia = urzadzenie.Parametry_urządzenia,
                    idKlienta_fk = urzadzenie.idKlienta_fk

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }//post

        public void PutUrzadzenie(string uri, Urzadzenie urzadzenie)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUrządzenia = urzadzenie.idUrządzenia,
                    Rodzaj_urzązenia = urzadzenie.Rodzaj_urzązenia,
                    Model_urządzenia = urzadzenie.Model_urządzenia,
                    Parametry_urządzenia = urzadzenie.Parametry_urządzenia,
                    idKlienta_fk = urzadzenie.idKlienta_fk,
                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }//put
        //


        //
        //===============================================<Zlecenia>============================================
        //

        public IEnumerable<Zlecenie_dla_klienta> GetAllZlecenia(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Zlecenie_dla_klienta>>(s);
        }//getall

        public Zlecenie_dla_klienta GetZlecenie(string uri, int? idZlecenia)
        {
            string xx = uri + idZlecenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Zlecenie_dla_klienta>(s);
        }//get


        public IEnumerable<Zlecenie_dla_klienta> GetZleceniaKlienta(string uri, int? idKlienta)
        {
            string sURL = uri + idKlienta;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Zlecenie_dla_klienta>>(s);
        }//getzleceniaklienta


        public void DeleteZlecenie(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }//delete


        public void PostZlecenie(string uri, Zlecenie_dla_klienta zlec)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idZlecenia = zlec.idZlecenia,
                    Data_przyjęcia_zlecenia = zlec.Data_przyjęcia_zlecenia,
                    Data_wykonania = zlec.Data_wykonania,
                    Całkowity_koszt = zlec.Całkowity_koszt,
                    idKlienta_fk = zlec.idKlienta_fk

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }//post

        public void PutZlecenie(string uri, Zlecenie_dla_klienta zlec)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idZlecenia = zlec.idZlecenia,
                    Data_przyjęcia_zlecenia = zlec.Data_przyjęcia_zlecenia,
                    Data_wykonania = zlec.Data_wykonania,
                    Całkowity_koszt = zlec.Całkowity_koszt,
                    idKlienta_fk = zlec.idKlienta_fk
                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }//put



    //
    //===============================================<Usterki>============================================
    //

    public IEnumerable<Usterka> GetAllUsterki(string uri)
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        var webResponse = (HttpWebResponse)webRequest.GetResponse();
        var reader = new StreamReader(webResponse.GetResponseStream());
        string s = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
    }//getall


        public IEnumerable<Usterka> GetUsterkiUrzadzenia(string uri, int? idUrzadzenia)
        {
            string sURL = uri + idUrzadzenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
        }//getusterkiurzadzenia



        public IEnumerable<Usterka> GetUsterkiZlecenia(string uri, int? idZlecenia)
        {
            string sURL = uri + idZlecenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
        }//getusterkiZlecenia



        public void DeleteUsterka(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }//delete


        public void PostUsterka(string uri, Usterka usterka)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUsterki = usterka.idUsterki,
                    Opis_usterki = usterka.Opis_usterki,
                    idUrządzenia_fk = usterka.idUrządzenia_fk,
                    Rodzaj_usterki = usterka.Rodzaj_usterki,
                    Wykonane_prace = usterka.Wykonane_prace,
                    idZlecenia_fk = usterka.idZlecenia_fk,

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }//post

        public void PutUsterka(string uri, Usterka usterka)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUsterki = usterka.idUsterki,
                    Opis_usterki = usterka.Opis_usterki,
                    idUrządzenia_fk = usterka.idUrządzenia_fk,
                    Rodzaj_usterki = usterka.Rodzaj_usterki,
                    Wykonane_prace = usterka.Wykonane_prace,
                    idZlecenia_fk = usterka.idZlecenia_fk,
                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }//put



    }//repozytorium







}//namespace

