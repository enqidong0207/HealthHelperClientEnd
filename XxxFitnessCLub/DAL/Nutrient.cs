//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XxxFitnessCLub.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nutrient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nutrient()
        {
            this.MealOptions = new HashSet<MealOption>();
        }
    
        public int ID { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Sugar { get; set; }
        public double VitA { get; set; }
        public double VitB { get; set; }
        public double VitC { get; set; }
        public double VitD { get; set; }
        public double VitE { get; set; }
        public double Na { get; set; }
        public double Ka { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MealOption> MealOptions { get; set; }
    }
}
