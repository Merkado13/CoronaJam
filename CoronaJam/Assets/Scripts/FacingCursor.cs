using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCursor : MonoBehaviour
{
    
    private SpriteRenderer renderer;
    [SerializeField] private Vector3 cursorPos;
    [SerializeField] private Camera curentCamera;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        faceToCursor();
    }

    private void faceToCursor(){
        cursorPos = curentCamera.ScreenToWorldPoint(Input.mousePosition);
        float xOffset = cursorPos.x - transform.position.x;
        renderer.flipX = xOffset >= 0;
    }
}
