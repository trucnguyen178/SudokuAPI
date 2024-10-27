using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SudokuAPI.Models;
using SudokuAPI.Models.DTOs;
using SudokuAPI.Models.Enum;
using SudokuAPI.Services.Interfaces;

namespace SudokuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuHistoriesController : ControllerBase
    {
        private readonly ISudokuService _service;

        public SudokuHistoriesController(ISudokuService service)
        {
            _service = service;
        }


        // GET: api/SudokuHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SudokuHistoryDTO>>> GetSudokuHistories()
        {
            var result = await _service.GetSudokuHistoriesAsync();
            return Ok(result);
        }

        // GET: api/SudokuHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SudokuHistoryDTO>> GetSudokuHistory(int id)
        {
            var sudokuHistory = await _service.GetSudokuHistoryAsync(id);

            if (sudokuHistory == null)
            {
                return NotFound();
            }

            return sudokuHistory;
        }

        // POST: api/SudokuHistories
        [HttpPost]
        public async Task<ActionResult<SudokuHistory>> PostSudokuHistory(SaveSudokuHistoryDTO sudokuHistory)
        {
            var result = await _service.SaveSudokuHistoryAsync(sudokuHistory);
            return CreatedAtAction("GetSudokuHistory", new { id = result.Id }, result);
        }
    }
}
