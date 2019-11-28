using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement;
using UnityEngine;

public class SaveLoad : ISaveLoad
{
    public void Save(IGameData gameData)
    {
        //TODO
    }

    public IGameData Load(string saveGame)
    {
        //placeholder
        return new GameData();
    }

    public BaseData LoadBaseData()
    {
        //placeholder
        return new BaseData();
    }
}