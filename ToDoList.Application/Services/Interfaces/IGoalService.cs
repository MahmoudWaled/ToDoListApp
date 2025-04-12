using ToDoList.Application.DTOs;

namespace ToDoList.Application.Services.Interfaces
{
    public interface IGoalService
    {
        Task<IEnumerable<GoalDto>> GetAllGoalsDtosAsync();

        Task<GoalDto> GetGoalByIdAsync(int id);

        Task AddGoalAsync(GoalDto goalDto);

        Task UpdateGoalAsync(GoalDto goalDto);

        Task DeleteGoalAsync(int id);

        Task<IEnumerable<GoalDto>> GetGoalsByColorAsync(string color);

        Task<IEnumerable<GoalDto>> GetGoalsByDueDateAsync(DateTime dueDate);

        Task<IEnumerable<GoalDto>> GetCompletedGoalsAsync();

        Task<IEnumerable<GoalDto>> GetPendingGoalsAsync();
    }
}