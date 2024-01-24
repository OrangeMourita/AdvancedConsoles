using System.Text;

namespace Terminals;

public abstract class Terminal
{
    public Stream StandardInput { get; init; }
    public Stream StandardOutput { get; init; }
    public Stream StandardError { get; init; }
    
    
}
