using Margorak.Api.Interfaces;
using Margorak.Api.Repositories;

namespace Margorak.Api.Services
{
    public class CombatService
    {
        private readonly ICombatantRepository _combatantRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CombatService(ICombatantRepository combatantRepository, ICharacterRepository characterRepository,IUnitOfWork unitOfWork)
        {
            _combatantRepository = combatantRepository;
            _characterRepository = characterRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
