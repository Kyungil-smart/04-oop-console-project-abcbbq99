
public class BattleScene : Scene
{
    public PlayerCharacter _player { get;}
    public BattleList _battleList { get;}
    public PlayerSkill _skillList { get;}
    
    public BattleScene()
    {
        Init();
    }

    public void Init()
    {
        
    }
    
    
    public override void Enter()
    {
        _player.IsActiveControl = false;
        _battleList.IsActive = true;
        _skillList.IsActive = false;
        Debug.Log("-----전투창 진입-----");
    }
    
    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _battleList.SelectUp();
            _skillList.SelectUp();
        } 
        
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _battleList.SelectDown();
            _skillList.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _battleList.Select();
            _skillList.Select();
        }

        if (!_battleList.IsActive)
        {
            SceneManager.ChangePrevScene();
            _player.IsActiveControl = true;
        }
    }

    public override void Render()
    {
        _battleList.Render();
        _skillList.Render();
    }

    public override void Exit()
    {
        Debug.Log("-----전투창 퇴장-----");
    }
}