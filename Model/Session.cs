//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentProgress.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Session
    {
        public int ID_session { get; set; }
        public int ID_Subject { get; set; }
        public int ID_Teacher { get; set; }
        public int ID_Group { get; set; }
        public int ID_Student { get; set; }
        public string TypeOfCertification { get; set; }
        public string DueDate { get; set; }
        public string Grade { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}