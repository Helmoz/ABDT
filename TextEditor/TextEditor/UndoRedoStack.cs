using System.Collections.Generic;

namespace TextEditor
{
    public class UndoRedoStack
    {
        private Stack<ICommand> UndoStack { get; }
        private Stack<ICommand> RedoStack { get; }

        public UndoRedoStack()
        {
            UndoStack = new Stack<ICommand>();
            RedoStack = new Stack<ICommand>();
        }

        public void Do(ICommand cmd)
        {
            cmd.Do();
            UndoStack.Push(cmd);
            RedoStack.Clear();
        }
        
        public void Undo()
        {
            if (UndoStack.Count <= 0)
                return;
            var cmd = UndoStack.Pop();
            cmd.Undo();
            RedoStack.Push(cmd);
        }
        
        public void Redo()
        {
            if (RedoStack.Count <= 0)
                return;
            var cmd = RedoStack.Pop();
            cmd.Do();
            UndoStack.Push(cmd);
        }
    }
}