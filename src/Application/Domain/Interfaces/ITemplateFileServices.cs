using System.Threading.Tasks;

namespace TreasuryChallenge.Domain.Interfaces
{
    public interface ITemplateFileServices
    {
        Task WriteFile(int inputValue);
    }
}
