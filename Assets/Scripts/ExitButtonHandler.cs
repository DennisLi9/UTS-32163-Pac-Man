using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartScene"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
