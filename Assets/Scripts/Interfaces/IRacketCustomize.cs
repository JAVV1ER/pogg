using UnityEngine;

namespace Interfaces
{
    public interface IRacketCustomize
    {
        
        void StartBuild(Skins currentSkin,GameObject _playerPrefab,Transform _playerPlaceholderTransform);
    }
}