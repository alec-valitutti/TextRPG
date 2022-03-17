namespace TextRPG.Interfaces
{
    public interface IUserInput
    {
        bool GetInput(Player player);
        bool GetConditional(Player player);
    }
}