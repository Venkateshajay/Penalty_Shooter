using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public float waitTime = 2f;
    public bool reload = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (reload && waitTime == 2f)
        {
            StartCoroutine(ReloadScence());
        }
        if(reload && waitTime == 0f)
        {
            Destroy(GameObject.Find("ScencePersist"));
            StartCoroutine(ReloadScence());
        }
    }

    IEnumerator ReloadScence()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
