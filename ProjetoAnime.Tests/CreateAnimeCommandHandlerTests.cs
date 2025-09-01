using Moq;
using ProjetoAnime.Application.Interfaces;
using ProjetoAnime.Application.Queries;
using ProjetoAnime.Core.Entidade;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class CreateAnimeCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddAnimeAndReturnAnime()
    {
        // Arrange
        var mockRepo = new Mock<IAnimeRepository>();
        var animeToAdd = new Anime { Id = 1, Nome = "Naruto", Diretor = "Masashi", Resumo = "Resumo" };

        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Anime>()))
            .ReturnsAsync(animeToAdd);

        var handler = new CreateAnimeCommandHandler(mockRepo.Object);
        var command = new CreateAnimeCommand
        {
            Nome = "Naruto",
            Diretor = "Masashi",
            Resumo = "Resumo"
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(animeToAdd.Id, result.Id);
        Assert.Equal(animeToAdd.Nome, result.Nome);
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Anime>()), Times.Once);
    }
}
