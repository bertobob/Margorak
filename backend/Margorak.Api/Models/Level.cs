using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class Level
    {
        [Key]
        public int Value {  get; set; }
        public int ExpRequiered {  get; set; }
    }
}
