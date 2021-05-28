using System;
using System.Collections.Generic;

namespace topfiles
{
    public class RecentFiles
    {
        public Dictionary<Files, DateTime> recents {get; set; }
        
        public RecentFiles(){
            recents = new Dictionary<Files, DateTime>();

        }

        public void addFile(Files toadd, DateTime time)
        {
            recents.Add(toadd, time);
        }   
    }
}