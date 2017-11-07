//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeMVCProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sho()
        {
            this.Outfits = new HashSet<Outfit>();
        }

        [Display(Name = "Footwear")]
        public int ShoesID { get; set; }

        [Display(Name = "Footwear Name")]
        public string ShoesName { get; set; }

        [Display(Name = "Footwear Photo")]
        public string ShoesPhoto { get; set; }

        [Display(Name = "Footwear Type")]
        public string ShoesType { get; set; }
        public int ColorID { get; set; }
        public int SeasonID { get; set; }
        public int OccasionID { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Occasion Occasion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outfit> Outfits { get; set; }
        public virtual Season Season { get; set; }
    }
}
