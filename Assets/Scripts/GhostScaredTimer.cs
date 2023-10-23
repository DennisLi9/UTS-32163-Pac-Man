using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GhostScaredTimer : MonoBehaviour
{
    public TextMeshProUGUI scaredTimerText;
    private float scaredTime;
    private bool isScared = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScared && scaredTime > 0)
        {
            scaredTime -= Time.deltaTime;
            scaredTimerText.text = Mathf.Ceil(scaredTime).ToString();
        }
        else if (scaredTime <= 0)
        {
            isScared = false;
            scaredTimerText.gameObject.SetActive(false);  // Hide the timer
        }
    }
    
    public void StartScaredTimer(float duration)
    {
        isScared = true;
        scaredTime = duration;
        scaredTimerText.gameObject.SetActive(true);  // Show the timer
    }
}
