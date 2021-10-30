using System;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Interfaces;

namespace TreasuryChallenge.Controller
{
    public class WriteFileController : IWriteFileController
    {
        private readonly ITemplateFileServices _templateFile;

        public WriteFileController(ITemplateFileServices templateFile)
        {
            _templateFile = templateFile;
        }

        public async Task WriteCodeInFile(int inputValue)
        {
            try
            {
                await _templateFile.WriteFile(inputValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error to generete File: {ex.Message}");
            }
        }
    }
}
