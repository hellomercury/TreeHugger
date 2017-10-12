using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    
    //Obstacles Prefabs
    private GameObject tree;
    private GameObject rock;
    private GameObject stump;

    //Object Pool
    private int numObs = 30;
    private List<GameObject> obstacles;

    //Time and Level Manager
    private float totalTime;
    private float obstacleFreq = 10;
    private int level = 1;
    private float levelTime = 10;
    private float lastObstacle = 0;


    //Obstacle Position Activation Restraints
    private GameObject ground;
    private Vector3 groundSize;
    private Vector3 groundPos;
    private float zEnd;
    private float zStart;
    private float xStart;



    // Use this for initialization
    void Start () {
        // Find Bounds for Platform
        ground = GameObject.Find("Ground");
        groundSize = ground.GetComponent<Renderer>().bounds.size;
        groundPos = ground.transform.position;
        zEnd = groundPos[2] + (groundSize[2] /2) - 1;
        zStart = groundPos[2] - (groundSize[2] / 2) + 1;
        xStart = groundPos[0] + (groundSize[0] / 2) + 2;

        //Instantiate List
        obstacles = new List<GameObject>();

        //Get the Prefabs
        tree = Resources.Load<GameObject>("Prefabs/Tree");
        rock = Resources.Load<GameObject>("Prefabs/rockM");
        stump = Resources.Load<GameObject>("Prefabs/Stump");

        //Put Prefbas into a list for random fill
        List<GameObject> prefabs = new List<GameObject> { tree, rock, stump };

        
        //Randomly Fill List With Game Objects
        for (int i = 0; i < numObs; i++)
        {
            int objChoice = Random.Range(0, 3); //Random Range for Integers is exlusive
            GameObject obj = (GameObject)Instantiate(prefabs[objChoice]);
            obj.SetActive(false);
            obstacles.Add(obj);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        totalTime += Time.deltaTime;
        lastObstacle += Time.deltaTime;
        if (totalTime > levelTime * level)
        {
            level += 1;
            obstacleFreq += 5;
        }
        if (lastObstacle >= (levelTime / obstacleFreq))
        {
            if (Random.Range(0, 11) % 2 == 0) //Adds an extra element of randomness to generation
            {
                Obstacle();
                lastObstacle = 0;
            }
        }

    }

    // Send Obstacle
    void Obstacle()
    {
        int objIndex = Random.Range(0, numObs); //Randomly selects obstacle
        if (obstacles[objIndex].activeSelf == false)
        {
            float zPos = Random.Range(zStart, zEnd);
            obstacles[objIndex].transform.position = new Vector3(xStart, obstacles[objIndex].transform.position.y, zPos);
            obstacles[objIndex].SetActive(true);
        }

    }

}
