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
    
    public partial class MealTag
    {
        public int ID { get; set; }
        public int MealOptionID { get; set; }
        public int MealTagCategoriesID { get; set; }
    
        public virtual MealOption MealOption { get; set; }
        public virtual MealTagCategory MealTagCategory { get; set; }
    }
}
