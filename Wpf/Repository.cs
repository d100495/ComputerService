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

    public sealed class Repository
    {
        private static Repository repo = null;
        private int numberOfInstances = 0;


        public static Repository repoInstance
        {
            get
            {
                if (repo == null)
                {
                    repo = new Repository();
                }
                return repo;
            }
        }

        private Repository()
        {
            numberOfInstances = 1;
        }



        public string urlString = "http://localhost:50966/api/";


        public static int GlobalButtonDelay = 3000;


        public IEnumerable<Klient> GetAllClients(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Klient>>(s);
        }

        public Klient GetKlient(string uri, int? clientId)
        {
            string xx = uri + clientId;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Klient>(s);
        }


        public void PostClient(string uri, Klient client)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idKlienta = client.idKlienta,
                    Nazwisko = client.Nazwisko,
                    Imie = client.Imie,
                    Adres = client.Adres,
                    Numer_telefonu = client.Numer_telefonu

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }



        public void DeleteClient(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }




        public void PutClient(string uri, Klient client)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idKlienta = client.idKlienta,
                    Imie = client.Imie,
                    Nazwisko = client.Nazwisko,
                    Adres = client.Adres,
                    Numer_telefonu = client.Numer_telefonu


                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }

        public IEnumerable<Urzadzenie> GetAllDevices(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Urzadzenie>>(s);
        }


        public Urzadzenie GetUrzadzenie(string uri, int? idUrzadzenia)
        {
            string xx = uri + idUrzadzenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Urzadzenie>(s);
        }


        public IEnumerable<Urzadzenie> GetClientDevices(string uri, int? idKlienta)
        {
            string sURL = uri + idKlienta;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Urzadzenie>>(s);
        }


        public void DeleteDevice(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }


        public void PostDevice(string uri, Urzadzenie Urzadzenie)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUrządzenia = Urzadzenie.idUrządzenia,
                    Rodzaj_urzązenia = Urzadzenie.Rodzaj_urzązenia,
                    Model_urządzenia = Urzadzenie.Model_urządzenia,
                    Parametry_urządzenia = Urzadzenie.Parametry_urządzenia,
                    idKlienta_fk = Urzadzenie.idKlienta_fk

                });
                streamWriter.Write(json);

            }

            var httpResponse = (HttpWebResponse)webRequest.GetResponse();


        }

        public void PutDevice(string uri, Urzadzenie Urzadzenie)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUrządzenia = Urzadzenie.idUrządzenia,
                    Rodzaj_urzązenia = Urzadzenie.Rodzaj_urzązenia,
                    Model_urządzenia = Urzadzenie.Model_urządzenia,
                    Parametry_urządzenia = Urzadzenie.Parametry_urządzenia,
                    idKlienta_fk = Urzadzenie.idKlienta_fk,
                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }

        public IEnumerable<Zlecenie_dla_klienta> GetAllOrders(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Zlecenie_dla_klienta>>(s);
        }

        public Zlecenie_dla_klienta GetOrder(string uri, int? orderId)
        {
            string xx = uri + orderId;
            var webRequest = (HttpWebRequest)WebRequest.Create(xx);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Zlecenie_dla_klienta>(s);
        }


        public IEnumerable<Zlecenie_dla_klienta> GetClientOrders(string uri, int? idKlienta)
        {
            string sURL = uri + idKlienta;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Zlecenie_dla_klienta>>(s);
        }


        public void DeleteOrder(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }


        public void PostOrder(string uri, Zlecenie_dla_klienta zlec)
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


        }

        public void PutOrder(string uri, Zlecenie_dla_klienta zlec)
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

        }



        public IEnumerable<Usterka> GetAllFlaws(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
        }


        public IEnumerable<Usterka> GetFlawsForDevice(string uri, int? deviceId)
        {
            string sURL = uri + deviceId;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
        }



        public IEnumerable<Usterka> GetFlawsForOrder(string uri, int? idZlecenia)
        {
            string sURL = uri + idZlecenia;
            var webRequest = (HttpWebRequest)WebRequest.Create(sURL);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Usterka>>(s);
        }



        public void DeleteFlaw(string uri, int id)
        {
            string sURL = uri + id;

            WebRequest request = WebRequest.Create(sURL);
            request.Method = "DELETE";


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }


        public void PostFlaw(string uri, Usterka usterka)
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


        }

        public void PutFlaw(string uri, Usterka flaw)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);


            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    idUsterki = flaw.idUsterki,
                    Opis_usterki = flaw.Opis_usterki,
                    idUrządzenia_fk = flaw.idUrządzenia_fk,
                    Rodzaj_usterki = flaw.Rodzaj_usterki,
                    Wykonane_prace = flaw.Wykonane_prace,
                    idZlecenia_fk = flaw.idZlecenia_fk,
                });
                streamWriter.Write(json);

            }


            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

        }



    }







}

