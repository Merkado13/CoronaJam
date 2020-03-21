using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    #region variables

    public int Barricades { get; set; }

    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Barricades = 3;

        UpdateSprite();
    }

    public void UpdateSprite()
    {
        switch(Barricades) {
            case 0:
                spriteRenderer.sprite = sprites[0];
                break;

            case 1:
                spriteRenderer.sprite = sprites[1];
                break;

            case 2:
                spriteRenderer.sprite = sprites[2];
                break;

            case 3:
                spriteRenderer.sprite = sprites[3];
                break;
        }
    }
}