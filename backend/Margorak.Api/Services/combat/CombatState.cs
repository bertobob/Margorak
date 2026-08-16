using System.Text;

namespace Margorak.Api.Services.combat
{
    public class CombatState
    {
        public required int CharacterCurrentHp { get; set; }
        public required int CombatantCurrentHp { get; set; }
        public required int CharacterTimeLine { get; set; }
        public required int CombatantTimeLine { get; set; }
        public required StringBuilder Log { get; set; }
        public bool CombatantDead => CombatantCurrentHp <= 0;
        public bool CharacterDead => CharacterCurrentHp <= 0;
    }
}
