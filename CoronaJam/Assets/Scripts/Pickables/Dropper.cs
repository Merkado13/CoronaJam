using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [System.Serializable]
    public class Droppable{
        GameObject drop;
        float ratio;
    }

    [SerializeField] Droppable[] drops;

    private void Drop()
    {

    }

    void OnDestroy()
    {
        Drop();
    }
}
