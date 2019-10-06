using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float anglePerRotation = 30;

    public int facingAngle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            gameObject.transform.Rotate(0, anglePerRotation, 0, Space.Self);
            facingAngle -= 1;
            Debug.Log("Now facing " + facingAngle);
        }
        else if (Input.GetKeyDown("right"))
        {
            gameObject.transform.Rotate(0, -anglePerRotation, 0, Space.Self);
            facingAngle += 1;
            Debug.Log("Now facing " + facingAngle);
        }
    }
}
