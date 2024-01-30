

public interface IStatusMove 
{

    string Name { get; }
    void Effect(ICombatActions attacker, ICombatActions defender);
}
