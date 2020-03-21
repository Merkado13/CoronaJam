using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LiquidSoap
{
    private float cleanAmount;

    public LiquidSoap(float cleanAmount)
    {
        this.cleanAmount = cleanAmount;
    }

    public void UseLiquidSoap(PlayerController player)
    {

        player.setCleaness(player.getCleaness() + cleanAmount);

    }
}

public class LiquidSoapPick : MonoBehaviour, IPickable
{

    [SerializeField] private float cleanAmount;

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
        if(player.setLiquidSoap(new LiquidSoap(cleanAmount)))
            Destroy(gameObject);
    }
}
