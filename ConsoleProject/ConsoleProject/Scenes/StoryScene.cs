

public class StoryScene : Scene
{
    private MenuList _storyMenu;
    
    public StoryScene()
    {
        Init();
    }

    public void Init()
    {
        _storyMenu = new MenuList();
        _storyMenu.Add("마을로 가기", GoTown);
        _storyMenu.Add("타이틀로 가기", GoTitle);
        _storyMenu.Add("게임 종료", GameQuit);
    }
    
    public override void Enter()
    {
        Debug.Log("-----스토리 씬 진입-----");
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _storyMenu.SelectUp();
        } 
        
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _storyMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _storyMenu.Select();
        }
    }

    public override void Render()
    {
        TellStory();
        _storyMenu.Render(8, 5);
    }

    public override void Exit()
    {
        Debug.Log("-----스토리 씬 퇴장-----");
    }
    
    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }
    
    public void GoTown()
    {
        SceneManager.Change("Town");
    }
    
    public void GoTitle()
    {
        SceneManager.Change("Title");
    }

    public void TellStory()
    {
        "당신은...".Print();
    }
}