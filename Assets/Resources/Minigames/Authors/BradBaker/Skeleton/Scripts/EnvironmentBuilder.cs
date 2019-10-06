using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    name: EnvironmentBuilder
    author: Brad Baker
    created: 06102019
    description:   "Randomly" build scene environment.
    inherits:   MonoBehavior
 */

public class EnvironmentBuilder : MonoBehaviour
{

    // Prefabs
    public GameObject stonePrefab;
    public GameObject stagePrefab;
    public GameObject skeletonPrefab;
    public GameObject playerPrefab;
    public GameObject circlePrefab;

    // Objects
    public Vector3 stageStart = new Vector3(1000, 340, 800);
    public Vector3 stageScale = new Vector3(2, 2, 2);
    public Vector3 circleStart = new Vector3(1000, 340.06f, 800);
    public Vector3 playerStart = new Vector3(1000, 341.7f, 800);

    // Private
    private GameObject stage;
    private GameObject circle;
    private GameObject player;
    private Renderer stageRenderer;
    private Vector3 center;
    private Vector3 start;
    private float radius;
    private const float shellRadius = 3f;

    public void Initialize()
    {
        stage = Instantiate(stagePrefab);
        stage.transform.position = stageStart;
        stage.transform.localScale = stageScale;
        stageRenderer = stage.GetComponent<Renderer>();
        center = stageRenderer.bounds.center;
        radius = stage.transform.localScale.z + shellRadius;
        start = center + new Vector3(0, 0, radius);
    }

    public GameObject GetStage()
    {
        return stage;
    }

    public GameObject BuildSummoningCircle()
    {
        circle = Instantiate(circlePrefab);
        circle.transform.position = circleStart;
        circle.transform.Rotate(new Vector3(0, -7, 0));
        return circle;
    }

    public GameObject CreatePlayer()
    {
        player = Instantiate(playerPrefab);
        player.transform.position = playerStart;
        if (circle != null)
            player.transform.parent = circle.transform;
        else
            Debug.Log("Circle was null, could not attach player!");
        return player;
    }

    // 
    public List<GameObject> CreateStones(float angle)
    {
        int numberStones = (int)(360.0f / angle);
        Vector3 lastPoint = start;
        List<GameObject> created = new List<GameObject>();
        float radAngle = angle * Mathf.Deg2Rad;
        for (int i = 0; i < numberStones; i++)
        {
            GameObject newObject = Instantiate(stonePrefab);
            lastPoint.x = center.x + Mathf.Cos(radAngle * i - Mathf.PI / 2) * radius;
            lastPoint.z = center.z + Mathf.Sin(radAngle * i - Mathf.PI / 2) * radius;
            newObject.transform.position = lastPoint;
            newObject.transform.Rotate(new Vector3(0, -(angle * i - 90), 0));

            GameObject obj2 = new GameObject();
            TextMesh text = obj2.AddComponent<TextMesh>();
            text.text = "" + i;
            text.offsetZ = 0.1f;
            text.fontSize = 12;
            text.transform.position = newObject.transform.position + new Vector3(0, 2f, 0);
            text.color = new Color(255, 255, 255);

            created.Add(newObject);
        }
        return created;
    }

}
