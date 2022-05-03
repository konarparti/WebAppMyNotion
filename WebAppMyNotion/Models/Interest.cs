using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMyNotion.Models
{
    public class Interest
    {
        public Interest() => DateAdded = DateTime.Now;
        
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Тип")]
        public string? Type { get; set; }
        [Display(Name = "Область")]
        public string? Scope { get; set; }
        [Display(Name = "Статус")]
        public string? Status { get; set; }
        [Display(Name = "Прогресс")]
        public string? Progress { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата добавления/изменения")]
        public DateTime DateAdded { get; set; }
    }
}
