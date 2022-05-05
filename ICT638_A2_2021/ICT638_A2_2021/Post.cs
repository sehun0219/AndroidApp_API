using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace WebserviceApp
{
   
    public class Post
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Pid { get; set; }
        public string PTitle { get; set; }
        public string PRoomNum { get; set; }
        public string PBathNum { get; set; }
        public int PRentalPrice { get; set; }
        public int Aid { get; set; }

    }


}
