using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorStateMachineUtil;

public class Enemy_FSM : MonoBehaviour
{
    #region variables

    public GameObject[] Windows { get; set; }

    private Rigidbody2D rigidbody;

    #endregion variables

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #region FSM_SearchWindow

    [StateEnterMethod("Base.Search window")]
    public void EnterSearchWindow()
    {
        print("Busco ventana");
        //rigidbody.velocity = new Vector2(-1, 0);
    }

    #endregion FSM_SearchWindow
}