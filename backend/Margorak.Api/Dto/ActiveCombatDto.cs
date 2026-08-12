namespace Margorak.Api.Dto
{
    public class ActiveCombatDto
    {
        public string CombatantName { get; set; } = string .Empty;
        public string CombatantImageKey { get; set; } = string.Empty;
        public int CurrentCharacterHp {  get; set; }
        public int CurrentCombatantHp { get;set; }
        public int CombatantMaxHp { get; set; }
        public List<string> CombatLogs { get; set; } = [];

    }
}
