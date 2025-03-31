using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{

    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos=camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos=new Vector2(mousePos.x, mousePos.y);
        this.transform.position=mousePos;
        

        Debug.Log("mousePos: " + mousePos);
    }
}
