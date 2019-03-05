using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Win : MonoBehaviour
{

    void OnGUI()
    {
        //Position
        if (GUI.Button(new Rect(350, 200, 100, 50), "Play Again!"))
        {
            SceneManager.LoadScene(0);
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
