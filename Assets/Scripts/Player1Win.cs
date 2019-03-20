using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1Win : MonoBehaviour
{
    public AudioSource BGM;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
        Invoke("Sound", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sound()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.playOnAwake = true;
        BGM.loop = false;
        BGM.clip = Resources.Load<AudioClip>("Yeah");
        BGM.volume = 0.2f;
        BGM.Play();
    }


    private void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
