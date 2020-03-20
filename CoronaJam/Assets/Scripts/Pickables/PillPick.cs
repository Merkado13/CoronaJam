using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorPill { BLUE, RED}

public class Pill
{
    public ColorPill color;

    public Pill(ColorPill color)
    {
        this.color = color;
    }

    public void UsePill(PlayerController player)
    {
        if(color == ColorPill.BLUE){


        }else if(color == ColorPill.RED)
        {

        }

    }
}

public class PillPick : MonoBehaviour, IPickable
{

    [SerializeField] private ColorPill color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pick(PlayerController player)
    {
        player.setPill(new Pill(color));
        Destroy(gameObject);
    }

}
