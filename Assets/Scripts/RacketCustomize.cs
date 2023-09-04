using System;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class RacketCustomize : IRacketCustomize//: MonoBehaviour
{
   

   
   [SerializeField]
   //private GameObject _playerControllerPrefab;
   
   //private Transform _playerPlaceholderTransform;

   //public Transform PlayerPlaceholderTransform { set => _playerPlaceholderTransform = value; }
   
   
   public void StartBuild(Skins currentSkin,GameObject _playerPrefab,Transform _playerPlaceholderTransform)
   {
      var racketBuilder = new RacketBuilder();
      switch(currentSkin)
      { 
            
         case Skins.Neon:
            var neonRacket = racketBuilder
               .WithRootPrefab(_playerPrefab)
               .WithPlaceholder(_playerPlaceholderTransform)
               .WithColor(Color.magenta)
               .WithWidth(.1f)
               .Build();
            Debug.Log(neonRacket);
            break;
         case Skins.Classic:
            var classicRacket = racketBuilder
               .WithRootPrefab(_playerPrefab)
               .WithPlaceholder(_playerPlaceholderTransform)
               .WithColor(Color.white)
               .WithWidth(.2f)
               .Build();
            Debug.Log(classicRacket);
            break;
      }
   }
   
}
public class RacketBuilder
{
   private GameObject _prefab;
   private Transform _transform;
   private Color _color;
   private float _width;
   public RacketBuilder WithRootPrefab(GameObject prefab)
   {
      _prefab = prefab;
      return this;
   }
   public RacketBuilder WithColor(Color color)
   {
      _color = color;
      return this;
   }
   public RacketBuilder WithWidth(float width)
   {
      _width = width;
      return this;
   }

   public RacketBuilder WithPlaceholder(Transform transform)
   {
      _transform = transform;
      return this;
   }
   
   
   public GameObject Build()
   {
      var createdRacket = Object.Instantiate(_prefab, _transform);
      var createdPlayerController = createdRacket.GetComponent<PlayerController>();
      
      createdPlayerController.SetColor(_color);
      createdPlayerController.SetWidth(_width);

      return createdRacket;
   }
}

public enum Skins
{
   Neon,
   Classic
}