using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naruto_Wikia
{
    public class ChuyenMuc
    {
        public string Title { get; set; }
        public string LinkAnh { get; set; }
        public Uri AnhUri
        {
            get
            {
                return new Uri(LinkAnh, UriKind.Relative);
            }
        }
        public Uri HomeUri { get; set; }

    }

    public static class ChuyenMucTH
    {
        public static ChuyenMuc VIDEOS = new ChuyenMuc() { Title = "videos", HomeUri = new Uri("http://naruto.wikia.com/wiki/Special:Videos"), LinkAnh = "/Assets/videos.png" };
        public static ChuyenMuc PHOTOS = new ChuyenMuc() { Title = "photos", HomeUri = new Uri("http://naruto.wikia.com/wiki/Special:NewFiles"), LinkAnh = "/Assets/photos.png" };
        public static ChuyenMuc MANGA = new ChuyenMuc() { Title = "manga", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Chapters"), LinkAnh = "/Assets/manga.png" };
        public static ChuyenMuc ANIME = new ChuyenMuc() { Title = "anime", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Episodes"), LinkAnh = "/Assets/anime.png" };
        public static ChuyenMuc GAMES = new ChuyenMuc() { Title = "games", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Video_games"), LinkAnh = "/Assets/games.png" };

        public static ChuyenMuc CHARACTERS = new ChuyenMuc() { Title = "characters", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Characters"), LinkAnh = "/Assets/characters.png" };
        public static ChuyenMuc JUTSU = new ChuyenMuc() { Title = "jutsu", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Jutsu"), LinkAnh = "/Assets/jutsu.png" };
        public static ChuyenMuc TOOLS = new ChuyenMuc() { Title = "tools", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Tools"), LinkAnh = "/Assets/tools.png" };
        public static ChuyenMuc LOCATIONS = new ChuyenMuc() { Title = "locations", HomeUri = new Uri("http://naruto.wikia.com/wiki/Category:Locations"), LinkAnh = "/Assets/locations.png" };

        public static ChuyenMuc QUESTIONS = new ChuyenMuc() { Title = "questions", HomeUri = new Uri("http://naruto.answers.wikia.com/wiki/Category:Answered_questions"), LinkAnh = "/Assets/question.png" };
    }
}
