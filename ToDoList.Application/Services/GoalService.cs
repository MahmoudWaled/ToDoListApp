using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Repositories.Interfaces;

namespace ToDoList.Application.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository goalRepository;
        private readonly IMapper mapper;

        public GoalService(IGoalRepository goalRepository, IMapper mapper)
        {
            this.goalRepository = goalRepository;
            this.mapper = mapper;
        }

        public async Task AddGoalAsync(GoalDto goalDto)
        {
            var mappedGoal = mapper.Map<Goal>(goalDto);
            await goalRepository.AddGoalAsync(mappedGoal);
        }

        public async Task DeleteGoalAsync(int id)
        {
            var goal = await goalRepository.GetGoalByIdAsync(id);
            if (goal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {id} not found.");
            }
            await goalRepository.DeleteGoalAsync(id);
        }

        public async Task<IEnumerable<GoalDto>> GetAllGoalsDtosAsync()
        {
            var goals = await goalRepository.GetAllGoalsAsync();
            return mapper.Map<IEnumerable<GoalDto>>(goals) ?? Enumerable.Empty<GoalDto>();
        }

        public async Task<GoalDto> GetGoalByIdAsync(int id)
        {
            var goal = await goalRepository.GetGoalByIdAsync(id);
            if (goal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {id} not found.");
            }
            return mapper.Map<GoalDto>(goal);
        }

        public async Task<IEnumerable<GoalDto>> GetGoalsByColorAsync(string color)
        {
            var goalsByColor = await goalRepository.GetGoalsByColorAsync(color);
            return mapper.Map<IEnumerable<GoalDto>>(goalsByColor) ?? Enumerable.Empty<GoalDto>();
        }

        public async Task<IEnumerable<GoalDto>> GetGoalsByDueDateAsync(DateTime dueDate)
        {
            var goalsByDueDate = await goalRepository.GetGoalsByDueDateAsync(dueDate);
            return mapper.Map<IEnumerable<GoalDto>>(goalsByDueDate) ?? Enumerable.Empty<GoalDto>();
        }

        public async Task<IEnumerable<GoalDto>> GetCompletedGoalsAsync()
        {
            var completedGoals = await goalRepository.GetCompletedGoalsAsync();
            return mapper.Map<IEnumerable<GoalDto>>(completedGoals) ?? Enumerable.Empty<GoalDto>();
        }

        public async Task<IEnumerable<GoalDto>> GetPendingGoalsAsync()
        {
            var pendingGoals = await goalRepository.GetPendingGoalAsync();
            return mapper.Map<IEnumerable<GoalDto>>(pendingGoals) ?? Enumerable.Empty<GoalDto>();
        }

        public async Task UpdateGoalAsync(GoalDto goalDto)
        {
            var existingGoal = await goalRepository.GetGoalByIdAsync(goalDto.Id);
            if (existingGoal == null)
            {
                throw new KeyNotFoundException($"Goal with ID {goalDto.Id} not found.");
            }
            var mappedGoal = mapper.Map<Goal>(goalDto);
            await goalRepository.UpdateGoalAsync(mappedGoal);
        }
    }
}