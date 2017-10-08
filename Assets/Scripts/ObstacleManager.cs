using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    
    //Obstacles
    private GameObject tree;

    //Object Pools
    private int objIndex = 0;
    private List<GameObject> trees;
    private int numObs = 40;

    //Time and Level Manager
    private float totalTime;
    private float obstacleFreq = 10;
    private int level = 1;
    private float levelTime = 20;
    private float lastObstacle = 0;


    //Obstacle Position Activation Restraints
    private GameObject ground;
    private Vector3 groundSize;
    private Vector3 groundPos;
    private float zEnd;
    private float zStart;
    private float xStart;
    private float y = 1.5f;



    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Ground");
        groundSize = ground.GetComponent<Renderer>().bounds.size;
        groundPos = ground.transform.position;
        zEnd = groundPos[2] + (groundSize[2] /2);
        zStart = groundPos[2] - (groundSize[2] / 2);
        xStart = groundPos[0] + (groundSize[0] / 2) + 2;


        tree = Resources.Load<GameObject>("Prefabs/Tree");

        trees = new List<GameObject>();
        for (int i = 0; i < numObs; i++)
        {
            GameObject obj = (GameObject)Instantiate(tree);
            obj.SetActive(false);
            trees.Add(obj);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        totalTime += Time.deltaTime;
        lastObstacle += Time.deltaTime;
        if (totalTime > levelTime * level)
        {
            level += 1;
            obstacleFreq += 10;
        }
        if (lastObstacle >= (levelTime / obstacleFreq))
        {
            Obstacle();
            lastObstacle = 0;
        }

    }

    void Obstacle()
    {
        if (objIndex == numObs)
        {
            objIndex = 0;
        }
        float zPos = Random.Range(zStart, zEnd);
        trees[objIndex].transform.position = new Vector3(xStart, y, zPos);
        trees[objIndex].SetActive(true);
        objIndex += 1;

    }

}
