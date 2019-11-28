using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.StoryManagement.TurnManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public IGameData GameData { get; set; }
    public IBaseData BaseData { get; set; }
    public ISaveLoad saveLoad;
    public ISceneManager sceneManager;
    public ITurnManager turnManager;

    public void TestContruct()
    {
        BaseData = new BaseData();
        GameData = new GameData();
        sceneManager = new GameObject().AddComponent<SceneManager>();
    }

    private void Construct()
    {
        saveLoad = new SaveLoad();
        sceneManager = new GameObject("Scene Manager").AddComponent<SceneManager>();
    }

    public void SaveGame()
    {
        saveLoad.Save(GameData);
    }

    public void LoadGame(string saveName)
    {
        GameData = saveLoad.Load(saveName);
    }

    public void LoadBaseData()
    {
        BaseData = saveLoad.LoadBaseData();
    }

    public void StartGame()
    {
        sceneManager.SetupScene(GameData, BaseData);
        sceneManager.ShowIntro(GameData, BaseData);

        TurnManager turnManager = new TurnManager(sceneManager);
        StartTurn(turnManager);
    }

    public void StartTurn(ITurnManager turnManager)
    {
        this.turnManager = turnManager;
        turnManager.EndTurn += EndTurn;
        turnManager.GetViableStories(BaseData, GameData);
        if (turnManager.ViableStories.Count == 0)
        {
            EndGame();
        }
        else
        {
            turnManager.BeginTurn(BaseData, GameData);
        }
    }

    public void EndTurn()
    {
        TurnManager turnManager = new TurnManager(sceneManager);
        StartTurn(turnManager);
    }

    public void EndGame()
    {
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        Construct();
        LoadBaseData();

        StartGame();
    }
}