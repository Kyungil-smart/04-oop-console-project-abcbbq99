

public class LogScene : Scene
{
    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.ChangePrevScene();
        }
    }

    public override void Render()
    {
        Debug.Render();
    }

    public override void Enter()
    {
        Debug.Log("-----로그창 진입-----");
    }

    public override void Exit()
    {
        Debug.Log("-----로그창 퇴장-----");
    }
}