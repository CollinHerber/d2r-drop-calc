using System.Threading.Tasks;
using D2RDropCalc.Server.Models.DTOs.Shared;

namespace D2RDropCalc.Server.Services.Interfaces
{
    public interface IItemService
    {
        public Task<bool> GenerateDropRates(string name, Difficulty difficulty, int players, int mf, MonsterType monsterType);
    }
}