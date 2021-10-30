using System.Threading.Tasks;

namespace TreasuryChallenge.Domain.Interfaces
{
    public interface IWriteFileController
    {
        Task WriteCodeInFile(int InputValue);
    }
}
