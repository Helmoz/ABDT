namespace TextEditor
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }
}