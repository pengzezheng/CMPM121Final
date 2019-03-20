using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleEvent : MonoBehaviour
{
    //Scene arena1 = SceneManager.GetSceneByName("Arena1");
    int randomNumber;
    public AudioSource BGM;
    public Button btn;
        // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);

        BGM = gameObject.AddComponent<AudioSource>();
        BGM.playOnAwake = true;
        BGM.loop = false;
        BGM.clip = Resources.Load<AudioClip>("Title");
        BGM.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        randomNumber = Random.Range(1, 4);
        SceneManager.LoadScene(randomNumber);
    }
}
