using System.Runtime.CompilerServices;

namespace VirtualCard.Interfaces
{
    public interface ILogger
    {
        void Write(string label, string msg );
    }
}
