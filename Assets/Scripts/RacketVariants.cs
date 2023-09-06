using UnityEngine;

public abstract class RacketVariants
{
   public static GameObject NeonRacket(GameObject playerPrefab, Transform playerPlaceholderTransform)
   {
      return new RacketBuilder(playerPrefab)
         .SetParent(playerPlaceholderTransform)
         .SetColor(Color.magenta)
         .SetWidth(.1f)
         .Build();
   }
   
   public static GameObject ClassicRacket(GameObject playerPrefab, Transform playerPlaceholderTransform)
   {
      return new RacketBuilder(playerPrefab)
         .SetParent(playerPlaceholderTransform)
         .SetColor(Color.white)
         .SetWidth(.2f)
         .Build();
   }
}

public enum Skins
{
   Neon,
   Classic
}