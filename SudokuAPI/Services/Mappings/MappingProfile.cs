using AutoMapper;
using SudokuAPI.Models;
using SudokuAPI.Models.DTOs;

namespace SudokuAPI.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<SaveSudokuHistoryDTO, SudokuHistory>();
            CreateMap<SudokuHistory, SudokuHistoryDTO>();
        }
    }
}
