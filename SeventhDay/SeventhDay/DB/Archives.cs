//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeventhDay.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Archives
    {
        public int ID { get; set; }
        public int JobblessID { get; set; }
        public int JobID { get; set; }
        public int ArchivistID { get; set; }
        public System.DateTime ArchivesDate { get; set; }
    
        public virtual Jobless Jobless { get; set; }
        public virtual Users Users { get; set; }
        public virtual Vacancies Vacancies { get; set; }
    }
}
