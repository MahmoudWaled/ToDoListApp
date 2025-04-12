using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Repositories.Interfaces
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAllGoalsAsync();

        Task<Goal> GetGoalByIdAsync(int id);

        Task AddGoalAsync(Goal goal);

        Task UpdateGoalAsync(Goal goal);

        Task DeleteGoalAsync(int id);

        Task<IEnumerable<Goal>> GetGoalsByColorAsync(string color);

        Task<IEnumerable<Goal>> GetGoalsByDueDateAsync(DateTime dueDate);

        Task<IEnumerable<Goal>> GetCompletedGoalsAsync();

        Task<IEnumerable<Goal>> GetPendingGoalAsync();
    }
}