//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SerwisKomputerowy_v1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usterki
    {
        public int idUsterki { get; set; }
        public string Rodzaj_usterki { get; set; }
        public string Opis_usterki { get; set; }
        public string Wykonane_prace { get; set; }
        public Nullable<int> idZlecenia_fk { get; set; }
        public Nullable<int> idUrządzenia_fk { get; set; }
    
        public virtual Urządzenia Urządzenia { get; set; }
        public virtual Zlecenia_dla_klienta Zlecenia_dla_klienta { get; set; }
    }
}
