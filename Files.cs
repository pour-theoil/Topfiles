using System;

namespace topfiles
{
    public class Files{
        public string filename {get; set;}
        public DateTime time {get; set; }
        public int filesize {get; set; }

        public Files(string file){
            filename = file; 
        }
    }
}