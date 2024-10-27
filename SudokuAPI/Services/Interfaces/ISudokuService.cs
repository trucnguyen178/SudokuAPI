using SudokuAPI.Models.DTOs;
using SudokuAPI.Models.Enum;

namespace SudokuAPI.Services.Interfaces
{
    public interface ISudokuService
    {
        public Task<IEnumerable<SudokuHistoryDTO>> GetSudokuHistoriesAsync();
        public Task<SudokuHistoryDTO> GetSudokuHistoryAsync(int id);
        public Task<SudokuHistoryDTO> SaveSudokuHistoryAsync(SaveSudokuHistoryDTO dto);
    }
}
