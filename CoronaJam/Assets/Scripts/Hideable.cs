using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color materialColor;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        materialColor = renderer.material.color;
    }

    public void Show()
    {
        materialColor = new Color(materialColor.r, materialColor.g, materialColor.b, 0);
    }

    public void Hide()
    {
        materialColor = new Color(materialColor.r, materialColor.g, materialColor.b, 1);
    }
}
