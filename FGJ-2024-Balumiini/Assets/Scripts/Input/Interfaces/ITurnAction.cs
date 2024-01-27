
// Define an Action interface
public interface ITurnAction
{
    void Execute();
    bool IsDone { get; set; }
}
