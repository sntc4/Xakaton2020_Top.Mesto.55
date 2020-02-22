using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XakatonIT.Models
{
    public class Parks
    {
        public int ID { get; set; }
        public string Title { get; set; } //Название парка
        public string Address { get; set; } //Адрес парка
        public int Area { get; set; } //Размер парка
        public double Rating { get; set; } //Рейтинг парка
    }
}
