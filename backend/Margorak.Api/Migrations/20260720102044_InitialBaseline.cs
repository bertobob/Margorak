using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AttackSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackRating = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackRange = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StrengthMod = table.Column<double>(type: "REAL", nullable: false),
                    DexterityMod = table.Column<double>(type: "REAL", nullable: false),
                    VitalityMod = table.Column<double>(type: "REAL", nullable: false),
                    IntelligenceMod = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CombatantRaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantRaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpRequiered = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "MapInteractionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapInteractionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SightRange = table.Column<int>(type: "INTEGER", nullable: false),
                    ClickRange = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequirementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResistanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResistanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerrainTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerrainTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combatants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CombatantRaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpValue = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseHp = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldLootMin = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldLootMax = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combatants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combatants_CombatantRaces_CombatantRaceId",
                        column: x => x.CombatantRaceId,
                        principalTable: "CombatantRaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackDamages",
                columns: table => new
                {
                    AttackId = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDamage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackDamages", x => new { x.AttackId, x.DamageTypeId });
                    table.ForeignKey(
                        name: "FK_AttackDamages_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackDamages_DamageTypes_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ItemCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackRating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterRaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Vitality = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHp = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxHp = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentMp = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxMp = table.Column<int>(type: "INTEGER", nullable: false),
                    Gold = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentMapId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocY = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterClasses_CharacterClassId",
                        column: x => x.CharacterClassId,
                        principalTable: "CharacterClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterRaces_CharacterRaceId",
                        column: x => x.CharacterRaceId,
                        principalTable: "CharacterRaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Maps_CurrentMapId",
                        column: x => x.CurrentMapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocY = table.Column<int>(type: "INTEGER", nullable: false),
                    MapInteractionCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapInteractions_MapInteractionCategories_MapInteractionCategoryId",
                        column: x => x.MapInteractionCategoryId,
                        principalTable: "MapInteractionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapInteractions_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terrains",
                columns: table => new
                {
                    TerrainId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TerrainTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    Accessible = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrains", x => x.TerrainId);
                    table.ForeignKey(
                        name: "FK_Terrains_TerrainTypes_TerrainTypeId",
                        column: x => x.TerrainTypeId,
                        principalTable: "TerrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CombatantAttacks",
                columns: table => new
                {
                    CombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackCount = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantAttacks", x => new { x.CombatantId, x.AttackId });
                    table.ForeignKey(
                        name: "FK_CombatantAttacks_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombatantAttacks_Combatants_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CombatantHabitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    MapId = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrainTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocX1 = table.Column<int>(type: "INTEGER", nullable: false),
                    LocY1 = table.Column<int>(type: "INTEGER", nullable: false),
                    LocX2 = table.Column<int>(type: "INTEGER", nullable: false),
                    LocY2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Probability = table.Column<int>(type: "INTEGER", nullable: false),
                    AmbushProbability = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantHabitats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CombatantHabitats_Combatants_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombatantHabitats_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombatantHabitats_TerrainTypes_TerrainTypeId",
                        column: x => x.TerrainTypeId,
                        principalTable: "TerrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CombatantResistances",
                columns: table => new
                {
                    CombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResistanceTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantResistances", x => new { x.CombatantId, x.ResistanceTypeId });
                    table.ForeignKey(
                        name: "FK_CombatantResistances_Combatants_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombatantResistances_ResistanceTypes_ResistanceTypeId",
                        column: x => x.ResistanceTypeId,
                        principalTable: "ResistanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorStats",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmorValue = table.Column<int>(type: "INTEGER", nullable: false),
                    EvasionValue = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipSlotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorStats", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ArmorStats_EquipSlots_EquipSlotId",
                        column: x => x.EquipSlotId,
                        principalTable: "EquipSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorStats_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CombatantLoots",
                columns: table => new
                {
                    CombatantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Probability = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatantLoots", x => new { x.CombatantId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CombatantLoots_Combatants_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombatantLoots_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableEffects",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinValue = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxValue = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableEffects", x => new { x.ItemId, x.EffectTypeId });
                    table.ForeignKey(
                        name: "FK_ConsumableEffects_EffectTypes_EffectTypeId",
                        column: x => x.EffectTypeId,
                        principalTable: "EffectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumableEffects_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    BonusTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBonuses_BonusTypes_BonusTypeId",
                        column: x => x.BonusTypeId,
                        principalTable: "BonusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemBonuses_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDamages",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MinDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDamage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDamages", x => new { x.ItemId, x.DamageTypeId });
                    table.ForeignKey(
                        name: "FK_ItemDamages_DamageTypes_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDamages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemRequirements",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequirementTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequirements", x => new { x.ItemId, x.RequirementTypeId });
                    table.ForeignKey(
                        name: "FK_ItemRequirements_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequirements_RequirementTypes_RequirementTypeId",
                        column: x => x.RequirementTypeId,
                        principalTable: "RequirementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemResistances",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResistanceTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemResistances", x => new { x.ItemId, x.ResistanceTypeId });
                    table.ForeignKey(
                        name: "FK_ItemResistances_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemResistances_ResistanceTypes_ResistanceTypeId",
                        column: x => x.ResistanceTypeId,
                        principalTable: "ResistanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponStats",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackRange = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponStats", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_WeaponStats_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedItems_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MapInteractionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopInteractions_MapInteractions_MapInteractionId",
                        column: x => x.MapInteractionId,
                        principalTable: "MapInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeleporterInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapInteractionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DestinationMapId = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationLocX = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationLocY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleporterInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeleporterInteractions_MapInteractions_MapInteractionId",
                        column: x => x.MapInteractionId,
                        principalTable: "MapInteractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeleporterInteractions_Maps_DestinationMapId",
                        column: x => x.DestinationMapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapTiles",
                columns: table => new
                {
                    MapTileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapId = table.Column<int>(type: "INTEGER", nullable: false),
                    XCoord = table.Column<int>(type: "INTEGER", nullable: false),
                    YCoord = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrainId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTiles", x => x.MapTileId);
                    table.ForeignKey(
                        name: "FK_MapTiles_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapTiles_Terrains_TerrainId",
                        column: x => x.TerrainId,
                        principalTable: "Terrains",
                        principalColumn: "TerrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEquipment",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipSlotId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnedItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEquipment", x => new { x.CharacterId, x.EquipSlotId });
                    table.ForeignKey(
                        name: "FK_CharacterEquipment_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEquipment_EquipSlots_EquipSlotId",
                        column: x => x.EquipSlotId,
                        principalTable: "EquipSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEquipment_OwnedItems_OwnedItemId",
                        column: x => x.OwnedItemId,
                        principalTable: "OwnedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmorStats_EquipSlotId",
                table: "ArmorStats",
                column: "EquipSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_AttackDamages_DamageTypeId",
                table: "AttackDamages",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEquipment_EquipSlotId",
                table: "CharacterEquipment",
                column: "EquipSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEquipment_OwnedItemId",
                table: "CharacterEquipment",
                column: "OwnedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterClassId",
                table: "Characters",
                column: "CharacterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterRaceId",
                table: "Characters",
                column: "CharacterRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CurrentMapId",
                table: "Characters",
                column: "CurrentMapId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantAttacks_AttackId",
                table: "CombatantAttacks",
                column: "AttackId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantHabitats_CombatantId",
                table: "CombatantHabitats",
                column: "CombatantId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantHabitats_MapId",
                table: "CombatantHabitats",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantHabitats_TerrainTypeId",
                table: "CombatantHabitats",
                column: "TerrainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantLoots_ItemId",
                table: "CombatantLoots",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatantResistances_ResistanceTypeId",
                table: "CombatantResistances",
                column: "ResistanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Combatants_CombatantRaceId",
                table: "Combatants",
                column: "CombatantRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableEffects_EffectTypeId",
                table: "ConsumableEffects",
                column: "EffectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBonuses_BonusTypeId",
                table: "ItemBonuses",
                column: "BonusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBonuses_ItemId",
                table: "ItemBonuses",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDamages_DamageTypeId",
                table: "ItemDamages",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequirements_RequirementTypeId",
                table: "ItemRequirements",
                column: "RequirementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemResistances_ResistanceTypeId",
                table: "ItemResistances",
                column: "ResistanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MapInteractions_MapId",
                table: "MapInteractions",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_MapInteractions_MapInteractionCategoryId",
                table: "MapInteractions",
                column: "MapInteractionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MapTiles_MapId",
                table: "MapTiles",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_MapTiles_TerrainId",
                table: "MapTiles",
                column: "TerrainId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedItems_CharacterId",
                table: "OwnedItems",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedItems_ItemId",
                table: "OwnedItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopInteractions_MapInteractionId",
                table: "ShopInteractions",
                column: "MapInteractionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeleporterInteractions_DestinationMapId",
                table: "TeleporterInteractions",
                column: "DestinationMapId");

            migrationBuilder.CreateIndex(
                name: "IX_TeleporterInteractions_MapInteractionId",
                table: "TeleporterInteractions",
                column: "MapInteractionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terrains_TerrainTypeId",
                table: "Terrains",
                column: "TerrainTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorStats");

            migrationBuilder.DropTable(
                name: "AttackDamages");

            migrationBuilder.DropTable(
                name: "CharacterEquipment");

            migrationBuilder.DropTable(
                name: "CombatantAttacks");

            migrationBuilder.DropTable(
                name: "CombatantHabitats");

            migrationBuilder.DropTable(
                name: "CombatantLoots");

            migrationBuilder.DropTable(
                name: "CombatantResistances");

            migrationBuilder.DropTable(
                name: "ConsumableEffects");

            migrationBuilder.DropTable(
                name: "ItemBonuses");

            migrationBuilder.DropTable(
                name: "ItemDamages");

            migrationBuilder.DropTable(
                name: "ItemRequirements");

            migrationBuilder.DropTable(
                name: "ItemResistances");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "MapTiles");

            migrationBuilder.DropTable(
                name: "ShopInteractions");

            migrationBuilder.DropTable(
                name: "TeleporterInteractions");

            migrationBuilder.DropTable(
                name: "WeaponStats");

            migrationBuilder.DropTable(
                name: "EquipSlots");

            migrationBuilder.DropTable(
                name: "OwnedItems");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "Combatants");

            migrationBuilder.DropTable(
                name: "EffectTypes");

            migrationBuilder.DropTable(
                name: "BonusTypes");

            migrationBuilder.DropTable(
                name: "DamageTypes");

            migrationBuilder.DropTable(
                name: "RequirementTypes");

            migrationBuilder.DropTable(
                name: "ResistanceTypes");

            migrationBuilder.DropTable(
                name: "Terrains");

            migrationBuilder.DropTable(
                name: "MapInteractions");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "CombatantRaces");

            migrationBuilder.DropTable(
                name: "TerrainTypes");

            migrationBuilder.DropTable(
                name: "MapInteractionCategories");

            migrationBuilder.DropTable(
                name: "CharacterClasses");

            migrationBuilder.DropTable(
                name: "CharacterRaces");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
