//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMyWorldEC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int Id { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public decimal Price { get; set; }
        public bool IsUse { get; set; }
        public System.DateTime PreOrder_Date { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
