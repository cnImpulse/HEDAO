using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class CmdMgr : Singleton<CmdMgr>
    {
        private Stack<Command> UndoStack = new Stack<Command>();
        private Stack<Command> RedoStack = new Stack<Command>();

        public void Execute(Command command)
        {
            command.Redo();
            UndoStack.Push(command);
            RedoStack.Clear(); // 清空恢复栈，因为新的操作使得之前的恢复操作无效
        }

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                Command command = UndoStack.Pop();
                command.Undo();
                RedoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                Command command = RedoStack.Pop();
                command.Redo();
                UndoStack.Push(command);
            }
        }
    }
}
