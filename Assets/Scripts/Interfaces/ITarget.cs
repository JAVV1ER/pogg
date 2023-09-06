using System;
using UnityEngine;

namespace Interfaces
{
    public interface ITarget
    {
        public Vector2 Position { get; }

        public event Action OnBotBoundsEnter;
        public event Action OnPlayerBoundsEnter;
    }
}