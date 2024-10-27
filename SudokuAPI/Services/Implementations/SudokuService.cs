using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SudokuAPI.Models;
using SudokuAPI.Models.DTOs;
using SudokuAPI.Models.Enum;
using SudokuAPI.Services.Interfaces;

namespace SudokuAPI.Services.Implementations
{
    public class SudokuService : ISudokuService
    {
        private readonly SudokuDbContext _context;
        private readonly IMapper _mapper;

        public SudokuService(SudokuDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SudokuHistoryDTO>> GetSudokuHistoriesAsync()
        {
            var histories = await _context.SudokuHistories.OrderByDescending(x => x.SolvedDate).ToListAsync();
            return _mapper.Map<List<SudokuHistoryDTO>>(histories);
        }

        public async Task<SudokuHistoryDTO> GetSudokuHistoryAsync(int id)
        {
            var history = await _context.SudokuHistories.FindAsync(id);
            if (history != null)
            {
                return _mapper.Map<SudokuHistoryDTO>(history);
            }

            return null;
        }

        public async Task<SudokuHistoryDTO> SaveSudokuHistoryAsync(SaveSudokuHistoryDTO dto)
        {
            var sudokuHistory = _mapper.Map<SudokuHistory>(dto);
            sudokuHistory.SolvedDate = DateTime.Now;

            await _context.SudokuHistories.AddAsync(sudokuHistory);
            await _context.SaveChangesAsync();

            return _mapper.Map<SudokuHistoryDTO>(sudokuHistory);
        }
    }
}
