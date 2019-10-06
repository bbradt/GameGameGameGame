using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    name: GameController
    author: Brad Baker
    created: 06102019
    description:   Control Win/Loss behavior in the game. 
    inherits:   MonoBehavior
 */

public class GameController : MonoBehaviour
{

    public List<GameObject> tombStones;
    public GameObject environmentObject;
    private EnvironmentBuilder environmentBuilder;
    private CircleController summonCircle;
    private PlayerController player;
    private GameObject currentFacing;

    // Start is called before the first frame update
    void Start()
    {
        environmentBuilder = environmentObject.GetComponent<EnvironmentBuilder>();
        environmentBuilder.Initialize();
        summonCircle = environmentBuilder.BuildSummoningCircle().GetComponent<CircleController>();
        player = environmentBuilder.CreatePlayer().GetComponent<PlayerController>();
        tombStones = environmentBuilder.CreateStones(30);
        currentFacing = tombStones[0];
        (currentFacing.GetComponent("Halo") as Behaviour).enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        GameObject newFacing = CheckFacing();
        if (newFacing != currentFacing)
        {
            (currentFacing.GetComponent("Halo") as Behaviour).enabled = false;
            currentFacing = newFacing;
            (currentFacing.GetComponent("Halo") as Behaviour).enabled = true;
        }

    }

    GameObject CheckFacing()
    {
        int facing = 0;
        if (summonCircle.facingAngle < 0)
            facing = tombStones.Count + (summonCircle.facingAngle % tombStones.Count);
        else
            facing = (summonCircle.facingAngle % tombStones.Count);
        return tombStones[facing % tombStones.Count];
    }

}
