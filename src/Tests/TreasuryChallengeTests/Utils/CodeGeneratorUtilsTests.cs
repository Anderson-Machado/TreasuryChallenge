using System;
using TreasuryChallenge.Utils;
using Xunit;

namespace TreasuryChallengeTests.Utils
{
    public class CodeGeneratorUtilsTests
    {
        [Fact]
        [Trait("TemplateFileTests", "Deve Gerar o código com sucesso.")]
        public void ShouldGenerateTheCodeSuccessfully()
        {
            var length = 7;
            var result = CodeGeneratorUtils.GetCode(length);

            Assert.NotEmpty(result);

            Assert.Equal(7, result.Length);
        }

        [Fact]
        [Trait("CodeGeneratorUtilsTests", "Deve Gerar exceção quando informado um valor maior do que 26.")]
        public void ShouldThrownArgumentExceptionWhenEnteringASizeGreaterThan26()
        {
            var length = 29;

            Assert.Throws<ArgumentOutOfRangeException>(() => CodeGeneratorUtils.GetCode(length));

        }

        [Fact]
        [Trait("CodeGeneratorUtilsTests", "Deve Gerar exceção quando não informado o tamanho do codigo.")]
        public void ShouldThrownArgumentExceptionWhenCodeLengthIsNotEntered()
        {
            var length = 0;

            var exception = Assert.Throws<ArgumentException>(() => CodeGeneratorUtils.GetCode(length));

            Assert.Equal("The maximum size must be greater than zero, check it in appsettings.json.", exception.Message);
        }
    }
}
