using System.Collections.Generic;

class TextCaretaker
{
    private Stack<TextMemento> m_backStack;

    public void SaveString(TextMemento memento)
    {
        m_backStack.Push(memento);
    }

    public void GoBack(TextPrompter prompter)
    {
        prompter.ApplyMemento(m_backStack.Pop());
    }
}
