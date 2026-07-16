using Margorak.Api.Mapper;
using Margorak.Api.Models;

namespace Margorak.Api.Tests.Mapper
{
    [TestClass]
    public sealed class TerrainTypeMapperTests
    {
        [TestMethod]
        public void ToDto_WithTerrainType_MapsIdAndName()
        {
            // Arrange
            var terrainType = new TerrainType
            {
                Id = 1,
                Name = "Wald"
            };

            // Act
            var result = TerrainTypeMapper.ToDto(terrainType);

            // Assert
            Assert.AreEqual(terrainType.Id, result.Id);
            Assert.AreEqual(terrainType.Name, result.Name);
        }
    }
}
