using MediatR;
using Moq;
using ProjetoAnime.Application.Commands;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Core.Entidade;
using DeleteAnimeCommand = ProjetoAnime.Application.Commands.DeleteAnimeCommand;

public class DeleteAnimeCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldDeleteAnime_WhenAnimeExists()
    {
        // Arrange
        var existingAnime = new Anime { Id = 1, Nome = "Anime To Delete", Diretor = "Director", Resumo = "Resumo" };

        var mockRepo = new Mock<IAnimeRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingAnime);
        mockRepo.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

        var handler = new DeleteAnimeCommandHandler(mockRepo.Object);
        var command = new DeleteAnimeCommand { Id = 1 };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);
        mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowKeyNotFoundException_WhenAnimeDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IAnimeRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Anime?)null);

        var handler = new DeleteAnimeCommandHandler(mockRepo.Object);
        var command = new DeleteAnimeCommand { Id = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.DeleteAsync(1), Times.Never);
    }
}
