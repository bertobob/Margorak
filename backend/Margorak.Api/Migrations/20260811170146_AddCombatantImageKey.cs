using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCombatantImageKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageKey",
                table: "Combatants",
                type: "TEXT",
                nullable: false,
                defaultValue: "unknown");

            migrationBuilder.Sql(
                """
                UPDATE Combatants
                SET ImageKey = CASE Name
                    WHEN 'Dog' THEN 'dog'
                    WHEN 'grey wolf' THEN 'grey-wolf'
                    WHEN 'black wolf' THEN 'black-wolf'
                    WHEN 'brown bear' THEN 'brown-bear'
                    WHEN 'lower Skeleton' THEN 'lower-skeleton'
                    WHEN 'skeleton' THEN 'skeleton'
                    WHEN 'skeleton warrior' THEN 'skeleton-warrior'
                    WHEN 'mummy' THEN 'mummy'
                    WHEN 'bullrat' THEN 'bullrat'
                    WHEN 'vampire bat' THEN 'vampire-bat'
                    WHEN 'orcish scout' THEN 'orcish-scout'
                    WHEN 'Ghoul' THEN 'ghoul'
                    WHEN 'Lower fire elemental' THEN 'lower-fire-elemental'
                    WHEN 'Lower ice elemental' THEN 'lower-ice-elemental'
                    WHEN 'Lower light elemental' THEN 'lower-light-elemental'
                    WHEN 'samurai' THEN 'samurai'
                    WHEN 'samurai leader' THEN 'samurai-leader'
                    WHEN 'moon ghoul' THEN 'moon-ghoul'
                    WHEN 'ghoul warrior' THEN 'ghoul-warrior'
                    WHEN 'ghoul berserker' THEN 'ghoul-berserker'
                    WHEN 'dragon snapper' THEN 'dragon-snapper'
                    WHEN 'snapper' THEN 'snapper'
                    WHEN 'Razor' THEN 'razor'
                    WHEN 'nine-tailed demon fox' THEN 'nine-tailed-demon-fox'
                    WHEN 'Bandit' THEN 'bandit'
                    WHEN 'Bandit Chieftain' THEN 'bandit-chieftain'
                    WHEN 'young Boar' THEN 'young-boar'
                    WHEN 'adult Boar' THEN 'adult-boar'
                    WHEN 'will-o''-the-wisp' THEN 'will-o-the-wisp'
                    WHEN 'giant mosquito' THEN 'giant-mosquito'
                    WHEN 'hill giant' THEN 'hill-giant'
                    WHEN 'rock giant' THEN 'rock-giant'
                    ELSE ImageKey
                END;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageKey",
                table: "Combatants");
        }
    }
}
