using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    #region variables

    public int Barricades { get; set; }

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        Barricades = 3;
    }
}