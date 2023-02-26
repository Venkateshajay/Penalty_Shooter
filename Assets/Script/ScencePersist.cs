using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScencePersist : MonoBehaviour
{
    private FootballKick football;
    // Start is called before the first frame update
    void Start()
    {
        football = FindObjectOfType<FootballKick>();
    }

    void Update()
    {
        if (football.goalMissed)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {

        int numGameSession = FindObjectsOfType<ScencePersist>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
