using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMyNotion.Models
{
    public class Note
    {
        public Note() => DateAdded = DateTime.Now;

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Содержание заметки")]
        public string? Content { get; set; }
        [Display(Name = "Ссылки на другие заметки")]
        public string Links { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата добавления/изменения")]
        public DateTime DateAdded { get; set; }
    }
}
