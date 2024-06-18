using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _offsetColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? _baseColor : _offsetColor;
    }
}
