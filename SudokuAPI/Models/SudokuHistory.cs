using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudokuAPI.Models
{
    public class SudokuHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Result { get; set; }
        public DateTime SolvedDate { get; set; }

    }
}
