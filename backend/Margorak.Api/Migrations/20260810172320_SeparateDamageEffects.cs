using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeparateDamageEffects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveCombats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCombats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveCombats_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackEffects",
                columns: table => new
                {
                    AttackId = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxValue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackEffects", x => new { x.AttackId, x.EffectTypeId });
                    table.ForeignKey(
                        name: "FK_AttackEffects_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackEffects_EffectTypes_EffectTypeId",
                        column: x => x.EffectTypeId,
                        principalTable: "EffectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemEffects",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxValue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEffects", x => new { x.ItemId, x.EffectTypeId });
                    table.ForeignKey(
                        name: "FK_ItemEffects_EffectTypes_EffectTypeId",
                        column: x => x.EffectTypeId,
                        principalTable: "EffectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEffects_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActiveCombatCombatants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveCombatId = table.Column<int>(type: "INTEGER", nullable: false),
                    CombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHp = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCombatCombatants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveCombatCombatants_ActiveCombats_ActiveCombatId",
                        column: x => x.ActiveCombatId,
                        principalTable: "ActiveCombats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveCombatCombatants_Combatants_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackStatusEffects",
                columns: table => new
                {
                    AttackId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusEffectId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MinDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackStatusEffects", x => new { x.AttackId, x.StatusEffectId });
                    table.ForeignKey(
                        name: "FK_AttackStatusEffects_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackStatusEffects_StatusEffects_StatusEffectId",
                        column: x => x.StatusEffectId,
                        principalTable: "StatusEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStatusEffects",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusEffectId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MinDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStatusEffects", x => new { x.ItemId, x.StatusEffectId });
                    table.ForeignKey(
                        name: "FK_ItemStatusEffects_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStatusEffects_StatusEffects_StatusEffectId",
                        column: x => x.StatusEffectId,
                        principalTable: "StatusEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveCombatStatusEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusEffectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActiveCombatCombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCombatStatusEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveCombatStatusEffects_ActiveCombatCombatants_ActiveCombatCombatantId",
                        column: x => x.ActiveCombatCombatantId,
                        principalTable: "ActiveCombatCombatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveCombatStatusEffects_StatusEffects_StatusEffectId",
                        column: x => x.StatusEffectId,
                        principalTable: "StatusEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCombatCombatants_ActiveCombatId",
                table: "ActiveCombatCombatants",
                column: "ActiveCombatId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCombatCombatants_CombatantId",
                table: "ActiveCombatCombatants",
                column: "CombatantId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCombats_CharacterId",
                table: "ActiveCombats",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCombatStatusEffects_ActiveCombatCombatantId",
                table: "ActiveCombatStatusEffects",
                column: "ActiveCombatCombatantId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCombatStatusEffects_StatusEffectId",
                table: "ActiveCombatStatusEffects",
                column: "StatusEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_AttackEffects_EffectTypeId",
                table: "AttackEffects",
                column: "EffectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttackStatusEffects_StatusEffectId",
                table: "AttackStatusEffects",
                column: "StatusEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEffects_EffectTypeId",
                table: "ItemEffects",
                column: "EffectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStatusEffects_StatusEffectId",
                table: "ItemStatusEffects",
                column: "StatusEffectId");

            migrationBuilder.Sql(
                """
                INSERT INTO StatusEffects (Name)
                SELECT 'Poison'
                WHERE NOT EXISTS (
                    SELECT 1 FROM StatusEffects WHERE Name = 'Poison'
                );

                INSERT INTO EffectTypes (Name)
                SELECT 'LifeLeech'
                WHERE NOT EXISTS (
                    SELECT 1 FROM EffectTypes WHERE Name = 'LifeLeech'
                );

                INSERT INTO AttackStatusEffects
                    (AttackId, StatusEffectId, MinValue, MaxValue, MinDuration, MaxDuration)
                SELECT
                    poison.AttackId,
                    statusEffect.Id,
                    poison.MinDamage,
                    poison.MaxDamage,
                    duration.MinDamage,
                    duration.MaxDamage
                FROM AttackDamages AS poison
                INNER JOIN AttackDamages AS duration
                    ON duration.AttackId = poison.AttackId
                    AND duration.DamageTypeId = 8
                CROSS JOIN StatusEffects AS statusEffect
                WHERE poison.DamageTypeId = 5
                    AND statusEffect.Name = 'Poison';

                INSERT INTO ItemStatusEffects
                    (ItemId, StatusEffectId, MinValue, MaxValue, MinDuration, MaxDuration)
                SELECT
                    poison.ItemId,
                    statusEffect.Id,
                    poison.MinDamage,
                    poison.MaxDamage,
                    duration.MinDamage,
                    duration.MaxDamage
                FROM ItemDamages AS poison
                INNER JOIN ItemDamages AS duration
                    ON duration.ItemId = poison.ItemId
                    AND duration.DamageTypeId = 8
                CROSS JOIN StatusEffects AS statusEffect
                WHERE poison.DamageTypeId = 5
                    AND statusEffect.Name = 'Poison';

                INSERT INTO AttackEffects (AttackId, EffectTypeId, MinValue, MaxValue)
                SELECT
                    damage.AttackId,
                    effectType.Id,
                    damage.MinDamage,
                    damage.MaxDamage
                FROM AttackDamages AS damage
                CROSS JOIN EffectTypes AS effectType
                WHERE damage.DamageTypeId = 7
                    AND effectType.Name = 'LifeLeech';

                INSERT INTO ItemEffects (ItemId, EffectTypeId, MinValue, MaxValue)
                SELECT
                    damage.ItemId,
                    effectType.Id,
                    damage.MinDamage,
                    damage.MaxDamage
                FROM ItemDamages AS damage
                CROSS JOIN EffectTypes AS effectType
                WHERE damage.DamageTypeId = 7
                    AND effectType.Name = 'LifeLeech';

                DELETE FROM AttackDamages WHERE DamageTypeId IN (5, 7, 8);
                DELETE FROM ItemDamages WHERE DamageTypeId IN (5, 7, 8);
                DELETE FROM DamageTypes WHERE Id IN (5, 7, 8);
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                INSERT OR IGNORE INTO DamageTypes (Id, Name) VALUES
                    (5, 'Poison'),
                    (7, 'LifeLeech'),
                    (8, 'PoisonDuration');

                INSERT INTO AttackDamages (AttackId, DamageTypeId, MinDamage, MaxDamage)
                SELECT AttackId, 5, MinValue, MaxValue
                FROM AttackStatusEffects;

                INSERT INTO AttackDamages (AttackId, DamageTypeId, MinDamage, MaxDamage)
                SELECT AttackId, 8, MinDuration, MaxDuration
                FROM AttackStatusEffects;

                INSERT INTO ItemDamages (ItemId, DamageTypeId, MinDamage, MaxDamage)
                SELECT ItemId, 5, MinValue, MaxValue
                FROM ItemStatusEffects;

                INSERT INTO ItemDamages (ItemId, DamageTypeId, MinDamage, MaxDamage)
                SELECT ItemId, 8, MinDuration, MaxDuration
                FROM ItemStatusEffects;

                INSERT INTO AttackDamages (AttackId, DamageTypeId, MinDamage, MaxDamage)
                SELECT attackEffect.AttackId, 7, attackEffect.MinValue, attackEffect.MaxValue
                FROM AttackEffects AS attackEffect
                INNER JOIN EffectTypes AS effectType
                    ON effectType.Id = attackEffect.EffectTypeId
                WHERE effectType.Name = 'LifeLeech';

                INSERT INTO ItemDamages (ItemId, DamageTypeId, MinDamage, MaxDamage)
                SELECT itemEffect.ItemId, 7, itemEffect.MinValue, itemEffect.MaxValue
                FROM ItemEffects AS itemEffect
                INNER JOIN EffectTypes AS effectType
                    ON effectType.Id = itemEffect.EffectTypeId
                WHERE effectType.Name = 'LifeLeech';

                DELETE FROM EffectTypes
                WHERE Name = 'LifeLeech';
                """);

            migrationBuilder.DropTable(
                name: "ActiveCombatStatusEffects");

            migrationBuilder.DropTable(
                name: "AttackEffects");

            migrationBuilder.DropTable(
                name: "AttackStatusEffects");

            migrationBuilder.DropTable(
                name: "ItemEffects");

            migrationBuilder.DropTable(
                name: "ItemStatusEffects");

            migrationBuilder.DropTable(
                name: "ActiveCombatCombatants");

            migrationBuilder.DropTable(
                name: "StatusEffects");

            migrationBuilder.DropTable(
                name: "ActiveCombats");
        }
    }
}
