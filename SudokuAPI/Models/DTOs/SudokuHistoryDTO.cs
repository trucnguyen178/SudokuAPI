namespace SudokuAPI.Models.DTOs
{
    public class SudokuHistoryDTO
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public DateTime SolvedDate { get; set; }
    }
}
