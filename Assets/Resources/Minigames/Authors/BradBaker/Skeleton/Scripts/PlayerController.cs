using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SkeletonController
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
