//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proj.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff1
    {
        public int Id { get; set; }
        public int ID_Car_Price { get; set; }
        public int ID_Mark { get; set; }
        public int ID_Person { get; set; }
        public int ID_Type { get; set; }
        public int ID_Type_KPP { get; set; }
        public int ID_Type_Privod { get; set; }
        public int ID_Year_Car { get; set; }
    
        public virtual Car_Price Car_Price { get; set; }
        public virtual Mark Mark { get; set; }
        public virtual Person Person { get; set; }
        public virtual Type1 Type1 { get; set; }
        public virtual Type_KPP Type_KPP { get; set; }
        public virtual Type_Privod Type_Privod { get; set; }
        public virtual Year_Car Year_Car { get; set; }
    }
}
