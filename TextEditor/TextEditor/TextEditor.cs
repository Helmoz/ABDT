namespace TextEditor
{
    public class TextEditor
    {
        private UndoRedoStack CommandStack { get; set; } = new UndoRedoStack();

        public void MoveCursorTo(int row, int col)
        {
            CommandStack.Do(new MoveCursorTo(row, col));
        }

        public void InsertChar(char c)
        {
            CommandStack.Do(new InsertChar(c));
        }
        
        public void DeleteChar(char c)
        {
            CommandStack.Do(new DeleteChar(c));
        }

        public void Undo()
        {
            CommandStack.Undo();
        }
        
        public void Redo()
        {
            CommandStack.Redo();
        }
    }
}