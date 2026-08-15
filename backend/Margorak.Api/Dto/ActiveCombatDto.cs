namespace Margorak.Api.Dto
{
    public class ActiveCombatDto
    {
        public string CombatantName { get; set; } = string.Empty;
        public string CombatantImageKey { get; set; } = string.Empty;
        public int CurrentCharacterHp {  get; set; }
        public int CurrentCombatantHp { get;set; }
        public int CombatantMaxHp { get; set; }
        public string CombatLogs { get; set; } = string.Empty;
        public bool BattleOver { get; set; } = false;
    }
}
