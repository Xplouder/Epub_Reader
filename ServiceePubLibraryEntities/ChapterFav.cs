//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceePubLibraryEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChapterFav
    {
        public int Id { get; set; }
        public int Chapter_Id { get; set; }
        public int User_Id { get; set; }
    
        public virtual Chapter Chapter { get; set; }
        public virtual User User { get; set; }
    }
}
