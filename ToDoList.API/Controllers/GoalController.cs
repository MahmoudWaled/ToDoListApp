using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService goalService;

        public GoalController(IGoalService goalService)
        {
            this.goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var goals = await goalService.GetAllGoalsDtosAsync();
            if (goals == null)
            {
                return NotFound();
            }
            return Ok(goals ?? Enumerable.Empty<GoalDto>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById(int id)
        {
            var goal = await goalService.GetGoalByIdAsync(id);
            return Ok(goal);
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] GoalDto goalDto)
        {
            if (!ModelState.

                IsValid)
            {
                return BadRequest(ModelState);
            }

            await goalService.AddGoalAsync(goalDto);
            return CreatedAtAction(nameof(GetGoalById), new { id = goalDto.Id }, goalDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] GoalDto goalDto)
        {
            if (id != goalDto.Id)
            {
                return BadRequest("Goal ID mismatch");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await goalService.UpdateGoalAsync(goalDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            await goalService.DeleteGoalAsync(id);
            return NoContent();
        }

        [HttpGet("color/{color}")]
        public async Task<IActionResult> GetGoalsByColor(string color)
        {
            var goalsByColor = await goalService.GetGoalsByColorAsync(color);
            if (goalsByColor == null)
            {
                return NotFound($"No goals found with color {color}.");
            }
            return Ok(goalsByColor ?? Enumerable.Empty<GoalDto>());
        }

        [HttpGet("dueDate/{dueDate}")]
        public async Task<IActionResult> GetGoalsByDueDate(DateTime dueDate)
        {
            var goalsByDueDate = await goalService.GetGoalsByDueDateAsync(dueDate);
            if (goalsByDueDate == null)
            {
                return NotFound($"No goals found with DueDate {dueDate}.");
            }
            return Ok(goalsByDueDate ?? Enumerable.Empty<GoalDto>());
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetComlpetetGoals()
        {
            var completedGoals = await goalService.GetCompletedGoalsAsync();
            if (completedGoals == null)
            {
                return NotFound($"No completed goals found.");
            }

            return Ok(completedGoals ?? Enumerable.Empty<GoalDto>());
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingGoals()
        {
            var pendingGoals = await goalService.GetPendingGoalsAsync();
            if (pendingGoals == null)
            {
                return NotFound($"No pending goals found.");
            }
            return Ok(pendingGoals ?? Enumerable.Empty<GoalDto>());
        }
    }
}