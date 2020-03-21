using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorPill { BLUE, RED}

public class Pill
{
    public ColorPill color;
    public float effectTime;
    public float effectMultiplier;

    public Pill(ColorPill color, float effectTime, float effectMultiplier)
    {
        this.color = color;
        this.effectTime = effectTime;
        this.effectMultiplier = effectMultiplier;
    }

    public void UsePill(PlayerController player)
    {
        if(color == ColorPill.BLUE){


            IEnumerator coroutine = player.SlowEnemies(effectMultiplier, effectTime);
            player.StartCoroutine(coroutine);

        }else if(color == ColorPill.RED)
        {
            IEnumerator coroutine = player.UpgradeDamage(effectMultiplier, effectTime);
            player.StartCoroutine(coroutine);
        }

    }
}

public class PillPick : MonoBehaviour, IPickable
{

    private enum EffectType { Slow, Damage }

    [SerializeField] private ColorPill color;
    [SerializeField] private float effectTimeInSeconds;
    [SerializeField] private float effectMultiplier;
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
        if(player.setPill(new Pill(color, effectTimeInSeconds, effectMultiplier)))
            Destroy(gameObject);
    }

}
