using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.CoreModule

public class scen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextLevel(int _sceneNumber)
    {
        sceneManager.LoadScene(_sceneNumber)
)
    }
}
