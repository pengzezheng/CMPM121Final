using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleEvent : MonoBehaviour
{
    //Scene arena1 = SceneManager.GetSceneByName("Arena1");
    int randomNumber;

    void OnGUI()
    {
        //Position
        if (GUI.Button(new Rect(350, 200, 100, 50), "Start!"))
        {
            randomNumber = Random.Range(1, 4);
            SceneManager.LoadScene(randomNumber);
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
