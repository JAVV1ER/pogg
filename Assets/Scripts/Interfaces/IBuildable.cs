using UnityEngine;

namespace Interfaces
{
    public interface IBuildable
    {
        void StartBuild(Skins currentSkin,GameObject _playerPrefab,Transform _playerPlaceholderTransform);
    }
}