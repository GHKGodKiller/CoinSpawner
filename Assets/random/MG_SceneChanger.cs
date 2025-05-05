using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG_SceneChanger : MonoBehaviour
{
    public void SceneLoader(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
}
