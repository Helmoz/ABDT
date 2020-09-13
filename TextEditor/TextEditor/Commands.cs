using System;

namespace TextEditor
{
    public class MoveCursorTo : ICommand
    {
        private int Column { get; }

        private int Row { get; }
        
        public MoveCursorTo(int row, int col)
        {
            Row = row;
            Column = col;
        }
        
        public void Do()
        {
            Console.WriteLine($"Moved cursor to ({Row},{Column})");
        }
        
        public void Undo()
        {
            Console.WriteLine($"Moved cursor back");
        }
    }

    public class InsertChar : ICommand
    {
        private char InputChar { get; }
        
        public InsertChar(char input)
        {
            InputChar = input;
        }
        public void Do()
        {
            Console.WriteLine($"Inserted char {InputChar}");
        }

        public void Undo()
        {
            Console.WriteLine($"Undo InsertChar");
        }
    }
    
    public class DeleteChar : ICommand
    {
        private char InputChar { get; }
        
        public DeleteChar(char input)
        {
            InputChar = input;
        }
        
        public void Do()
        {
            Console.WriteLine($"Deleted char {InputChar}");
        }

        public void Undo()
        {
            Console.WriteLine($"Undo DeleteChar");
        }
    }
    
    
} 