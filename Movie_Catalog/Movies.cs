using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Catalog
{
    public class Movies
    {
        public int MovieID { get; set;}
        public string Movie_Name { get; set; }
        public string File_Name { get; set; }
        public string LikeOrDislike { get; set; }
        public string Path { get; set; }

        public Movies() { }
        public Movies(int _movieId, string _movieName, string _fileName)
        {
            MovieID=_movieId;
            Movie_Name = _movieName;
            File_Name = _fileName;
        }

        public Movies(int _movieId, string _movieName, string _fileName, int _likeOrDislike)
        {
            MovieID = _movieId;
            Movie_Name = _movieName;
            File_Name = _fileName;
            if (_likeOrDislike == 1) LikeOrDislike = "Favourite";
            else if (_likeOrDislike == 0) LikeOrDislike = "Hated";
            else LikeOrDislike = "";
        }

    }
}
