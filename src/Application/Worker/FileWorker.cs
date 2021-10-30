using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Interfaces;

namespace TreasuryChallenge.Worker
{
    [ExcludeFromCodeCoverage]
    public class FileWorker : BackgroundService
    {

        private readonly IWriteFileController _writeFileController;

        public FileWorker(IWriteFileController writeFileController)
        {
            _writeFileController = writeFileController;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Tell me the number of lines do you need and press enter.");

            var inputValue = int.Parse(Console.ReadLine());
            var stopwatch = Stopwatch.StartNew();

            await _writeFileController.WriteCodeInFile(inputValue);

            stopwatch.Stop();
            Console.WriteLine($"A file with {inputValue} lines was generated in {stopwatch.ElapsedMilliseconds}ms.");
        }
    }
}
