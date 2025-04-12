using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Data;
using ToDoList.Infrastructure.Repositories.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationDbContext context;

        public GoalRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddGoalAsync(Goal goal)
        {
            await context.Goals.AddAsync(goal);
            await context.SaveChangesAsync();
        }

        public async Task DeleteGoalAsync(int id)
        {
            var goal = await context.Goals.FindAsync(id);
            if (goal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {id} not found.");
            }
            context.Remove(goal);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Goal>> GetAllGoalsAsync()
        {
            var goals = await context.Goals.ToListAsync();
            return goals;
        }

        public async Task<IEnumerable<Goal>> GetCompletedGoalsAsync()
        {
            var completedGoals = await context.Goals.Where(g => g.IsCompleted).ToListAsync();
            return completedGoals;
        }

        public async Task<Goal> GetGoalByIdAsync(int id)
        {
            var goal = await context.Goals.FindAsync(id);
            return goal;
        }

        public async Task<IEnumerable<Goal>> GetGoalsByColorAsync(string color)
        {
            var goalsByColor = await context.Goals.Where(g => g.Color == color).ToListAsync();
            return goalsByColor;
        }

        public async Task<IEnumerable<Goal>> GetGoalsByDueDateAsync(DateTime dueDate)
        {
            var goalsByDueDate = await context.Goals.Where(g => g.DueDate == dueDate).ToListAsync();
            return goalsByDueDate;
        }

        public async Task<IEnumerable<Goal>> GetPendingGoalAsync()
        {
            var pendingGoals = await context.Goals.Where(g => !g.IsCompleted).ToListAsync();
            return pendingGoals;
        }

        public async Task UpdateGoalAsync(Goal goal)
        {
            var existingGoal = await context.Goals.FindAsync(goal.Id);
            if (existingGoal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {goal.Id} not found.");
            }
            context.Entry(existingGoal).CurrentValues.SetValues(goal);
            await context.SaveChangesAsync();
        }
    }
}