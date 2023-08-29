using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace player_skripts
{
   public class RacketCustomize: MonoBehaviour
   {
      private GameObject _rocketGameObject;
      private SpriteRenderer _spriteRenderer;
      public bool isNeon;
      void Start()
      {
         
         GameObject targetGameObject = gameObject;

         _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
         RacketDirector racketDirector = new RacketDirector();
         RacketBuilder racketBuilder1 = new NeonRacketBuilder();
         racketDirector.Construct(racketBuilder1);
      }

      
   }
   public abstract class RacketBuilder
   {
      public abstract void BuildSpriteColour();
      public abstract void BuildTrailColour();
   }

   public class RacketDirector
   {
      public void Construct(RacketBuilder racketBuilder)
      {
         racketBuilder.BuildSpriteColour();
         racketBuilder.BuildTrailColour();
      }
   }

   public class NeonRacketBuilder : RacketBuilder
   {
      private Racket _racket = new Racket();
       

      public override void BuildSpriteColour()
      {
         _racket.ChangeColourSprite(Color.magenta);
      }

      public override void BuildTrailColour()
      {
         throw new System.NotImplementedException();
      }
   }

   class Racket
   {
      private Color _color;
      private SpriteRenderer _spriteRenderer;

      
      /*[Tooltip("Конструктор")]
      public Rocket(GameObject rocket)
      {
         this._rocket = rocket;
         
      }*/
      
      public void ChangeColourSprite(Color color)
      {
         _spriteRenderer.color = color;
      }
   }
}

