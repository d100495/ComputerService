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
    
    public partial class Urządzenia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urządzenia()
        {
            this.Usterki = new HashSet<Usterki>();
        }
    
        public int idUrządzenia { get; set; }
        public string Rodzaj_urzązenia { get; set; }
        public string Model_urządzenia { get; set; }
        public string Parametry_urządzenia { get; set; }
        public int idKlienta_fk { get; set; }
    
        public virtual Klienci Klienci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usterki> Usterki { get; set; }
    }
}
