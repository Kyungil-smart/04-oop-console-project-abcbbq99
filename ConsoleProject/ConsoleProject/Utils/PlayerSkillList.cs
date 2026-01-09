

public class PlayerSkillList
{
    private List<(Skill skill, Action action)> _skills;
    private int _currentIndex;
    public int CurrentIndex { get => _currentIndex; }
    private Ractangle _outline;
    private int _maxLength;

    public PlayerSkillList(params (Skill, Action)[] menuTexts)
    {
        if (menuTexts.Length == 0)
        {
            _skills = new List<(Skill, Action)>();
        }
        else
        {
            _skills = menuTexts.ToList();
        }

        for (int i = 0; i < _skills.Count; i++)
        {
            int textWidth = _skills[i].skill.Name.GetTextWidth();
            
            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }
        }

        _outline = new Ractangle(width: _maxLength + 4, height: _skills.Count + 2);
    }

    public void Reset()
    {
        _currentIndex = 0;
    }

    public void Select()
    {
        if (_skills.Count == 0) return;
        
        _skills[_currentIndex].action?.Invoke();
        
        if(_skills.Count == 0) _currentIndex = 0;
        else if (_currentIndex >= _skills.Count) _currentIndex = _skills.Count - 1;
    }

    public void Add(Skill skill, Action action)
    {
        _skills.Add((skill, action));
        
        int textWidth = skill.Name.GetTextWidth();
        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _outline.Width = _maxLength + 6;
        _outline.Height++;
    }

    public void Remove()
    {
        _skills.RemoveAt(_currentIndex);

        int max = 0;
        
        foreach ((Skill skill, Action action) in _skills)
        {
            int textWidth = skill.Name.GetTextWidth();

            if (max < textWidth) max = textWidth;
        }
        
        if(_maxLength != max) _maxLength = max;
        
        _outline.Width = _maxLength + 6;
        _outline.Height--;
    }

    public void SelectUp()
    {
        _currentIndex--;

        if (_currentIndex < 0) 
            _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;
        
        if(_currentIndex >= _skills.Count) 
            _currentIndex = _skills.Count - 1;
    }

    public void Render(int x, int y)
    {
        _outline.X = x;
        _outline.Y = y;
        _outline.Draw();
        
        for(int i = 0; i < _skills.Count; i++)
        {
            y++;
            Console.SetCursorPosition(x + 1, y);
            
            if (i == _currentIndex)
            {
                "->".Print(ConsoleColor.Green);
                _skills[i].skill.Name.Print(ConsoleColor.Green);
                continue;
            }
            else
            {
                Console.Write("  ");
                _skills[i].skill.Name.Print();
            }
        }
    }
}