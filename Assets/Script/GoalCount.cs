using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalCount : MonoBehaviour
{
    private TextMeshProUGUI noOfGoalsText;
    public int noOfGoals = 0;
    [SerializeField] GoalCounter goalCounter;
    private ScenceManager scenceManager;

    private void Start()
    {
        goalCounter = FindObjectOfType<GoalCounter>();
        noOfGoalsText = GameObject.Find("NoOfGoals").GetComponent<TextMeshProUGUI>();
        scenceManager = FindObjectOfType<ScenceManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            goalCounter.noOfGoals++;
            noOfGoalsText.text = "GOALS: " + goalCounter.noOfGoals;
            scenceManager.reload = true;
        }
        
    }

}
