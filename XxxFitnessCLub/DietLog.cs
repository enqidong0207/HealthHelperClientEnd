//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XxxFitnessCLub
{
    using System;
    using System.Collections.Generic;
    
    public partial class DietLog
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int TimeOfDayID { get; set; }
        public System.DateTime EditTime { get; set; }
        public double Portion { get; set; }
        public int MealOptionID { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsValid { get; set; }
    
        public virtual MealOption MealOption { get; set; }
        public virtual Member Member { get; set; }
        public virtual TimesOfDay TimesOfDay { get; set; }
    }
}
