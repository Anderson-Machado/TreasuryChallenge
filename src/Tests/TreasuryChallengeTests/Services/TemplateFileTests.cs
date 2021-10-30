using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using TreasuryChallenge.Configurations;
using TreasuryChallenge.Services;
using Xunit;

namespace TreasuryChallengeTests.Services
{
    public class TemplateFileTests
    {

        private readonly Mock<IOptionsMonitor<FileConfigurations>> _mockOptions;
        private readonly Mock<TemplateFileServices> _mockTemplateFile;

        public TemplateFileTests()
        {
            _mockOptions = new Mock<IOptionsMonitor<FileConfigurations>>();
            _mockTemplateFile = new Mock<TemplateFileServices>(_mockOptions.Object);
        }

        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar o arquivo com sucesso.")]
        public async Task ShouldGenerateTheFileSuccessfully()
        {
            var fileConfigurationsOptions = new FileConfigurations() { FileName = "TestUnit.txt", MaxLengthContent = 7 };
            _mockOptions.Setup(x => x.CurrentValue).Returns(fileConfigurationsOptions);

            var result = _mockTemplateFile.Object.WriteFile(10);
            await result;

            Assert.NotNull(result);
            Assert.True(result.IsCompleted);
        }

        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar exceção quando não informado o nome do arquivo.")]
        public async Task ShouldThrownArgumentExceptionWhenNotInformedOfTheFileName()
        {
            var fileConfigurationsOptions = new FileConfigurations() { FileName = "", MaxLengthContent = 7 };

            _mockOptions.Setup(x => x.CurrentValue).Returns(fileConfigurationsOptions);

            await Assert.ThrowsAsync<ArgumentException>(async () => await _mockTemplateFile.Object.WriteFile(10));

        }

        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar exceção quando não informado o tamanho do codigo a ser gerado no arquivo.")]
        public async Task ShouldThrownArgumentExceptionWhenCodeLengthIsNotEntered()
        {
            var fileConfigurationsOptions = new FileConfigurations() { FileName = "TestUnit.txt", MaxLengthContent = 0 };

            _mockOptions.Setup(x => x.CurrentValue).Returns(fileConfigurationsOptions);

            await Assert.ThrowsAsync<ArgumentException>(async () => await _mockTemplateFile.Object.WriteFile(10));

        }

        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar exceção quando não informado a quantidade de código desejado.")]
        public async Task ShouldThrownArgumentExceptionWhenNotInformingTheAmountOfCode()
        {
            var fileConfigurationsOptions = new FileConfigurations() { FileName = "TestUnit.txt", MaxLengthContent = 7 };

            _mockOptions.Setup(x => x.CurrentValue).Returns(fileConfigurationsOptions);

            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await _mockTemplateFile.Object.WriteFile(0));

            Assert.Equal("It was not possible to generate the file containing the code," +
                                             "please enter a value greater than zero.", exception.Message);

        }

    }
}
