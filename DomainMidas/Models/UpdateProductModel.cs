using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMidas.Models
{
    public class UpdateProductModel
    {
        //Айди задачи которую мы хотим изменить
        public int Id { get; set; }
        //Новые значение полей для задачи
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
