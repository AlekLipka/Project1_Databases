//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movie_Catalog
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Favourite_Hated = new HashSet<Favourite_Hated>();
            this.Playlists = new HashSet<Playlist>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Favourite_Hated> Favourite_Hated { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
