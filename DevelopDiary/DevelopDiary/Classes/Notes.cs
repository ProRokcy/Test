//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevelopDiary.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentNote { get; set; }
        public int IdWriter { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
