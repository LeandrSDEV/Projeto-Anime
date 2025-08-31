using Moq;
using ProjetoAnime.Application.Commands;
using ProjetoAnime.Application.Commands.UpdateAnime;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;

public class UpdateAnimeCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldUpdateAnime_WhenAnimeExists()
    {
        // Arrange
        var existingAnime = new Anime { Id = 1, Nome = "Old Name", Diretor = "Old Diretor", Resumo = "Old resumo" };
        var updatedAnime = new Anime { Id = 1, Nome = "New Name", Diretor = "New Diretor", Resumo = "New resumo" };

        var mockRepo = new Mock<IAnimeRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingAnime);
        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Anime>())).ReturnsAsync(updatedAnime);

        var handler = new UpdateAnimeCommandHandler(mockRepo.Object);
        var command = new UpdateAnimeCommand
        {
            Id = 1,
            Nome = "New Name",
            Diretor = "New Diretor",
            Resumo = "New resumo"
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedAnime.Nome, result.Nome);
        mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Anime>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowKeyNotFoundException_WhenAnimeDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IAnimeRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Anime?)null);

        var handler = new UpdateAnimeCommandHandler(mockRepo.Object);
        var command = new UpdateAnimeCommand
        {
            Id = 1,
            Nome = "New Name",
            Diretor = "New Diretor",
            Resumo = "New resumo"
        };

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Anime>()), Times.Never);
    }
}
