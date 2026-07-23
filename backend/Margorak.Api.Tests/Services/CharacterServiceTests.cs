using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Margorak.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margorak.Api.Tests.Services
{
    [TestClass]
    public class CharacterServiceTests
    {
        private Mock<ICharacterRepository> _characterRepositoryMock = null!;
        private Mock<IMapRepository> _mapRepositoryMock = null!;
        private Mock<IStartingItemService> _startingItemServiceMock = null!;
        private Mock<IItemRepository> _itemRepositoryMock = null!;
        private CharacterService _characterService = null! ;


        [TestInitialize]
        public void Setup()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
            _mapRepositoryMock = new Mock<IMapRepository>();
            _startingItemServiceMock = new Mock<IStartingItemService>();
            _itemRepositoryMock = new Mock<IItemRepository>();
            _characterService = new CharacterService(
                _characterRepositoryMock.Object,
                _mapRepositoryMock.Object,
                _startingItemServiceMock.Object,
                _itemRepositoryMock.Object);

        }

        [TestMethod]
        public async Task SaveCharacterAsync_WithValidData_TrimsNameAndSavesCharacter()
        {

            // Arrange

            var characterRace = new CharacterRace
            {
                Id = 2,
                Name = "human"
            };

            var characterClass = new CharacterClass
            {
                Id = 1,
                Name = "warrior"
            };
            var request = new CreateCharacterDto
            {
                Name = " bert",
                CharacterClassId = 1,
                CharacterRaceId = 2
            };

            _characterRepositoryMock
                .Setup(repository => repository.GetRaceByIdAsync(2))
                .ReturnsAsync(characterRace);

            _characterRepositoryMock
                .Setup(repository => repository.GetClassByIdAsync(1))
                .ReturnsAsync(characterClass);

            _startingItemServiceMock
                .Setup(service => service.GetStartingItemsAsync(characterClass.Id))
                .ReturnsAsync([]);
            // Act
            var result = await _characterService.CreateCharacterAsync(request);

            // Assert
            Assert.AreEqual("bert",result.Name,"Charactername Trim didnt work");
            Assert.AreEqual(1,result.CharacterClassId,"CharacterClassId missmatch");
            Assert.AreEqual(2,result.CharacterRaceId,"CharacterRaceId missmatch");

            _characterRepositoryMock.Verify(
                repository => repository.SaveNewCharacterAsync(result),
                Times.Once);


        }
        [TestMethod]
        public async Task SaveCharacterAsync_WithUnknownClass_DoesNotSaveCharacter()
        {
            // Arrange
            var requestNoClass = new CreateCharacterDto
            {
                Name = "bert",
                CharacterClassId = 1,
                CharacterRaceId = 2
            };

            var characterRace = new CharacterRace
            {
                Id = 2,
                Name = "human"
            };

            _characterRepositoryMock
                .Setup(repository => repository.GetRaceByIdAsync(2))
                .ReturnsAsync(characterRace);

            _characterRepositoryMock
                .Setup(repository => repository.GetClassByIdAsync(1))
                .ReturnsAsync((CharacterClass?)null);
            // Act
            await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => _characterService.CreateCharacterAsync(requestNoClass));

            // Assert
            _characterRepositoryMock.Verify(
                repository => repository.SaveNewCharacterAsync(
                    It.IsAny<Character>()),
                Times.Never);
        }

        [TestMethod]
        public async Task SaveCharacterAsync_WithUnknownRace_DoesNotSaveCharacter()
        {
            // Arrange
            var requestNoRace = new CreateCharacterDto
            {
                Name = "bert",
                CharacterClassId = 2,
                CharacterRaceId = 1
            };

            _characterRepositoryMock
                .Setup(repository => repository.GetRaceByIdAsync(1))
                .ReturnsAsync((CharacterRace?)null);

            // Act
            await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => _characterService.CreateCharacterAsync(requestNoRace));

            // Assert
            _characterRepositoryMock.Verify(
                repository => repository.SaveNewCharacterAsync(
                    It.IsAny<Character>()),
                Times.Never);
        }

        [TestMethod]

        public async Task LoadCharacterAsync_WithExistingCharacter_ReturnsCompleteCharacter()
        {
            // Arrange
            var character = new Character
            {
                Id = 1,
                Name = "Bert",
                Gender = "Male",

                CharacterRaceId = 2,
                CharacterRace = new CharacterRace
                {
                    Id = 2,
                    Name = "Human"
                },

                CharacterClassId = 1,
                CharacterClass = new CharacterClass
                {
                    Id = 1,
                    Name = "Warrior"
                },

                Level = 5,
                Experience = 450,
                StatusPoints = 3,

                Strength = 15,
                Dexterity = 11,
                Vitality = 14,
                Intelligence = 8,

                CurrentHp = 80,
                MaxHp = 100,
                CurrentMp = 20,
                MaxMp = 30,

                Gold = 250,

                CurrentMapId = 1,
                LocX = 10,
                LocY = 15,

                Version = 1,

                OwnedItems = [],
                CharacterEquipment = []
            };

            _characterRepositoryMock
                .Setup(repository => repository.GetCompleteCharacterAsync(1))
                .ReturnsAsync(character);
            _itemRepositoryMock
                .Setup(repository => repository.GetInventoryItemsByCharacterIdAsync(1))
                .ReturnsAsync([]);

            // Act
            var result = await _characterService.LoadCharacterAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(character.Id, result.Character.Id);
            Assert.AreEqual(character.Name, result.Character.Name);
            Assert.AreEqual(character.CharacterRace.Id, result.Character.CharacterRace.Id);
            Assert.AreEqual(character.CharacterClass.Id, result.Character.CharacterClass.Id);
            Assert.AreEqual(0, result.InventoryItems.Count);
            Assert.AreEqual(0, result.EquippedItems.Length);
        }

        [TestMethod]
        public async Task LoadCharacterAsync_WithoutExistingCharacter_ReturnsNull()
        {
            // Arrange
            _characterRepositoryMock
                .Setup(repository => repository.GetCompleteCharacterAsync(2))
                .ReturnsAsync((Character?)null);
            _itemRepositoryMock
                .Setup(repository => repository.GetInventoryItemsByCharacterIdAsync(2))
                .ReturnsAsync((List<OwnedItem>?)null);

            // Act
            var result = await _characterService.LoadCharacterAsync(2);

            // Assert
            Assert.IsNull(result);
        }

    }
}
