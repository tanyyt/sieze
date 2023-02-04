public interface IRoot : IInit
{
    bool AddComp(IComp comp);

    void RemoveComp(IComp comp);
}
