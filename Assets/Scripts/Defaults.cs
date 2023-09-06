using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Defaults: MonoBehaviour
    {
        private static Defaults _instance;
        public static Defaults Instance => _instance ?? throw new ArgumentNullException("Объект Defaults был null");
        
        [SerializeField] 
        private float _racketWidth;
        [SerializeField]
        private Color _racketColor;

        public float RacketWidth => _racketWidth;
        public Color RacketColor => _racketColor;

        private void Awake()
        {
            if (_instance == null) _instance = this;
        }
    }
}