using System;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var textEditor = new TextEditor();
            textEditor.MoveCursorTo(1, 2);
            textEditor.MoveCursorTo(1, 3);
            textEditor.InsertChar('a');
            textEditor.InsertChar('b');
            textEditor.InsertChar('d');
            textEditor.InsertChar('t');
            textEditor.Undo();
            textEditor.Undo();
            textEditor.Undo();
            textEditor.Redo();
            textEditor.Redo();
            textEditor.DeleteChar('d');
        }
    }
}