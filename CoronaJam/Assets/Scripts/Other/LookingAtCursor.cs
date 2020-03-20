using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCursor : MonoBehaviour
{
    [SerializeField] private Camera currentCamera;
    private SpriteRenderer renderer;
    private float angleToRotInDegree;
    private float initScaleY;
    public bool canMoveWeapon = true;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        angleToRotInDegree = transform.rotation.z;
        initScaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMoveWeapon)
            LookAtCursor();
    }

    private void LookAtCursor()
    {
        Vector3 cursorPos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorPosInObjectSpace = cursorPos - transform.position;
        
        if (cursorPosInObjectSpace.x != 0)
        {
            angleToRotInDegree = Mathf.Atan2(cursorPosInObjectSpace.y, cursorPosInObjectSpace.x) * Mathf.Rad2Deg - 180;
            transform.localScale = new Vector3(transform.localScale.x , initScaleY * -Mathf.Sign(cursorPosInObjectSpace.x), transform.localScale.z);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleToRotInDegree);
    }

    public void setCamera(Camera camera)
    {
        currentCamera = camera;
    }
}
