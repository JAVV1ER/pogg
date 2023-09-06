using DefaultNamespace;
using UnityEngine;

public class RacketBuilder
{
    private GameObject _prefab;
    private Transform _parent;
    private Color? _color;
    private float? _width;

    public RacketBuilder(GameObject prefab)
    {
        _prefab = prefab;
    }
   
    public RacketBuilder SetColor(Color color)
    {
        _color = color;
        return this;
    }
    public RacketBuilder SetWidth(float width)
    {
        _width = width;
        return this;
    }

    public RacketBuilder SetParent(Transform parent)
    {
        _parent = parent;
        return this;
    }
   
   
    public GameObject Build()
    {
        CheckDefaults();
      
        var racket = Object.Instantiate(_prefab, _parent);
      
        Renderer renderer = racket.GetComponent<SpriteRenderer>();
        renderer.material.color = _color.Value;

        var scale = racket.transform.localScale;
        scale.x = _width.Value;
        racket.transform.localScale = scale;
      
        return racket;
    }

    private void CheckDefaults()
    {
        if (_width == null) _width = Defaults.Instance.RacketWidth;
        if (_color == null) _color = Defaults.Instance.RacketColor;
    }
}