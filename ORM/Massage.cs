//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Massage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IdUserFrom { get; set; }
        public int IdUserTo { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual User User { get; set; }
    }
}
