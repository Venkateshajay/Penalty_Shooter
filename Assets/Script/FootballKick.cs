using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FootballKick : MonoBehaviour
{
    [SerializeField] Transform Aimer;
    private Rigidbody footballRigidbody;
    private Vector3 targetPosition = Vector3.zero;
    [SerializeField] private Vector3 forceVector;
    [SerializeField] PowerSlider powerSlider;
    private float power;
    public bool goalMissed = false;
    public float timeAfterKick = 0f;
    private ScenceManager scenceManager;

    void Start()
    {
        footballRigidbody = GetComponent<Rigidbody>();
        scenceManager = FindObjectOfType<ScenceManager>();
    }
    private void Update()
    {
        targetPosition = new Vector3(Aimer.position.x, Aimer.position.y, 0f);
        forceVector = ForceVectorCalculator(targetPosition);
        if (powerSlider.kicked)
        {
            TimeCalculator();
        }
        if (timeAfterKick > 5f)
        {
            scenceManager.waitTime = 0f;
            scenceManager.reload = true;
        }

    }

    private Vector3 ForceVectorCalculator(Vector3 targetPosition)
    {
        Vector3 forceVector = Vector3.zero;
        forceVector.x = targetPosition.x / 2.2f;
        if(targetPosition.y <= 0)
        {
            forceVector.y = 0f;
        }
        else
        {
            forceVector.y = (targetPosition.y + 4.25f)/2.1f;
        }
        forceVector.z = 10f;
        return forceVector;
    } 

    private void PowerAdder()
    {
        if(power > 0.33 && power < 0.66)
        {
            return;
        }
        else if(power >= 0.66)
        {
            forceVector.y += (power * 2.25f);
        }
        else if(power <= 0.33)
        {
            float slow = (1f - power) * 1.5f;
            forceVector.y -= slow;
            Debug.Log(forceVector);
        }
    }

    public void Shoot()
    {
        if (!powerSlider.kicked)
        {
            powerSlider.kicked = true;
            power = powerSlider.GetSliderValue();
            PowerAdder();
            footballRigidbody.AddForce(forceVector, ForceMode.Impulse);
            //StartCoroutine(ReloadScence());
        }
    }

    /*IEnumerator ReloadScence()
    {
        yield return new WaitForSecondsRealtime(5f);
        goalMissed = true;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }*/

    private void TimeCalculator()
    {
        timeAfterKick += Time.deltaTime;
    }
}
