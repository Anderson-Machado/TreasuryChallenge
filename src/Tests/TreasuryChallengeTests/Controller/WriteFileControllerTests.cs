using Moq;
using System;
using System.Threading.Tasks;
using TreasuryChallenge.Controller;
using TreasuryChallenge.Domain.Interfaces;
using Xunit;

namespace TreasuryChallengeTests.Controller
{
    public class WriteFileControllerTests
    {
        private readonly WriteFileController _writeFileController;
        private readonly Mock<ITemplateFileServices> _mockTemplateFile;

        public WriteFileControllerTests()
        {
            _mockTemplateFile = new Mock<ITemplateFileServices>();
            
            _writeFileController = new WriteFileController(_mockTemplateFile.Object);
        }

        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar o arquivo com sucesso.")]
        public async Task ShouldGenerateTheFileSuccessfully()
        {
            _mockTemplateFile.Setup(x => x.WriteFile(It.IsAny<int>())).Returns(Task.CompletedTask);
            var result = _writeFileController.WriteCodeInFile(10);
            await result;

            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

    }
}
