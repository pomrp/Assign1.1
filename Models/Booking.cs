//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assign1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.FeedBacks = new HashSet<FeedBack>();
            this.Restaurants = new HashSet<Restaurant>();
        }
    
        public int Id { get; set; }
        public string UserID { get; set; }
        [Required]
        [Phone (ErrorMessage ="please input vaild phone number")]
        public string Phone_No { get; set; }
        public System.DateTime Booking_Time { get; set; }
        [Required]
        [Range (1,20,ErrorMessage ="customer can't more than 20 people and less than 1") ]
        public int NofCustomer { get; set; }
        public int UserId1 { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
