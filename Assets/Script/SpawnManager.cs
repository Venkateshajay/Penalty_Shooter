using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GoalCounter goal;
    private float xPosition;
    private float zPosition;

    void Start()
    {
        goal = GameObject.Find("GoalCanvas").GetComponent<GoalCounter>();
        for(int i = 0; i < goal.noOfGoals;i++)
        {
            xPosition = Random.Range(-10, 10);
            zPosition = Random.Range(16, 7);
            Instantiate(obstaclePrefab, new Vector3(xPosition, 2.5f, zPosition), transform.rotation);
        }
    }
    void Update()
    {
        
    }
}
