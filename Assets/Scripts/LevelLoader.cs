using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("PacManScene_1");
    }

    public void LoadLevel2()
    {
        // For now, do nothing
        Debug.Log("Level 2 button pressed");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
