using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement
{
    public interface ISaveLoad
    {
        void Save(IGameData gameData);
        IGameData Load(string saveName);
        BaseData LoadBaseData();
    }
}
