using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TreasuryChallenge.Configurations;
using TreasuryChallenge.Domain.Interfaces;
using TreasuryChallenge.Utils;

namespace TreasuryChallenge.Services
{
    public class TemplateFileServices : ITemplateFileServices
    {
        private readonly FileConfigurations _fileConfigurationsOptions;

        public TemplateFileServices(IOptionsMonitor<FileConfigurations> fileConfigurationsOptions)
        {
            _fileConfigurationsOptions = fileConfigurationsOptions.CurrentValue;
        }

        public async Task WriteFile(int inputValue)
        {
            if (inputValue == default)
            {
                throw new ArgumentException("It was not possible to generate the file containing the code," +
                                             "please enter a value greater than zero.");
            }

            var fileName = _fileConfigurationsOptions.FileName;
            var length = _fileConfigurationsOptions.MaxLengthContent;
            var listContent = new HashSet<string>();

            for (int i = 0; i < inputValue; i++)
            {
                listContent.Add(CodeGeneratorUtils.GetCode(length));
            }
            await File.AppendAllLinesAsync(fileName, listContent);
        }

    }
}
