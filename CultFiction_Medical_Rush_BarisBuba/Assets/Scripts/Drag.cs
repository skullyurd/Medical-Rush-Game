using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    [SerializeField] private Rigidbody thisRB;

    void OnMouseDrag()
    {
        thisRB.useGravity = false;


        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.25f);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;
    }

    void OnMouseUp()
    {
        thisRB.useGravity = true;
    }

}
