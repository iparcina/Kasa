//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kasa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proizvodi
    {
        public int ID_proizvod { get; set; }
        public string Naziv { get; set; }
        public int Sifra { get; set; }
        public double Cijena { get; set; }
        public Nullable<int> Kolicina { get; set; }
    }
}
