using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManager.Tests;

[TestFixture]
public class PlayerManagerTests
{
    private Mock<IPlayerMapper> _playerMapperMock = null!;
    private PlayersManagerLib.PlayerManager _playerManager = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _playerMapperMock = new Mock<IPlayerMapper>();
        _playerManager = new PlayersManagerLib.PlayerManager(_playerMapperMock.Object);
    }

    [Test]
    public void RegisterNewPlayer_WhenPlayerNameDoesNotExist_ReturnsRegisteredPlayer()
    {
        var newPlayer = new Player
        {
            Name = "Virat Kohli",
            Age = 35,
            Country = "India",
            NoOfMatches = 500
        };

        _playerMapperMock
            .Setup(mapper => mapper.IsPlayerNameExistsInDb(newPlayer.Name))
            .Returns(false);

        _playerMapperMock
            .Setup(mapper => mapper.AddPlayer(It.IsAny<Player>()))
            .Returns((Player player) => player);

        var registeredPlayer = _playerManager.RegisterNewPlayer(newPlayer);

        _playerMapperMock.Verify(
            mapper => mapper.IsPlayerNameExistsInDb(newPlayer.Name),
            Times.Once);

        _playerMapperMock.Verify(
            mapper => mapper.AddPlayer(It.IsAny<Player>()),
            Times.Once);

        Assert.That(registeredPlayer.Name, Is.EqualTo("Virat Kohli"));
        Assert.That(registeredPlayer.Age, Is.EqualTo(35));
        Assert.That(registeredPlayer.Country, Is.EqualTo("India"));
        Assert.That(registeredPlayer.NoOfMatches, Is.EqualTo(500));
    }
}