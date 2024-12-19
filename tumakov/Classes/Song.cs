using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    public class Song
    {
        private string name;
        private string author;
        private Song prev;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Song()
        {
            name = "Ноунейм";
            author = "Ноунейм";
            prev = null;
        }
        

        /// <summary>
        /// конструктор
        /// </summary>
        public Song(string name, string author, Song prev = null)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        /// <summary>
        /// метод, который устанавливает название песни
        /// </summary>
        public void SongName(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// метод, который устанавливает атвора песни
        /// </summary>
        public void AuthorName(string author)
        {
            this.author = author;
        }
        /// <summary>
        /// метод, который устанавливает ссылку на предыдущую песню
        /// </summary>
        /// <param name="prev"></param>
        public void Prev(Song prev)
        {
            this.prev = prev;
        }
        /// <summary>
        /// метод, который выводит название песни и автора
        /// </summary>
        public void Info()
        {
            Console.WriteLine(Title());
        }
        /// <summary>
        /// метод, который возвращает название песни и автора
        /// </summary>
        public string Title()
        {
            return $"{name} - {author}";
        }
        /// <summary>
        /// Метод, который сравнивает между собой два объекта-песни
        /// </summary>
        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return name == otherSong.name && author == otherSong.author;
            }
            return false;
        }
    }
}
