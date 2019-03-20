using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    int speed = 5;
    float rotationSpeed = 500;
    float timer = 2.0f;
    private Animator anima;
    public AudioSource sp;
    public AudioSource ma;
    GameObject part1;
    public Text spd;
    public Text mas;

    // Start is called before the first frame update

    void Start()
    {
        anima = GetComponent<Animator>();

        sp = gameObject.AddComponent<AudioSource>();
        sp.playOnAwake = false;
        sp.loop = false;
        sp.clip = Resources.Load<AudioClip>("Speed");

        ma = gameObject.AddComponent<AudioSource>();
        ma.playOnAwake = false;
        ma.loop = false;
        ma.clip = Resources.Load<AudioClip>("Mass");

        part1 = GameObject.Find("Particle System1");
        part1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            anima.SetBool("Walk", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anima.SetBool("Bwalk", true);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        else
        {
            anima.SetBool("Walk", false);
            anima.SetBool("Bwalk", false);
        }
        //Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * -rotationSpeed);
        }

        if (transform.position.y <= -0.5f)
        {
            part1.transform.position = transform.position;
            part1.SetActive(true);
        }

        if (transform.position.y <= -1)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 2.0f;
            SceneManager.LoadScene(5);
        }

        spd.text = speed.ToString();
        mas.text = GetComponent<Rigidbody>().mass.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedBuff")
        {
            sp.Play();
            Destroy(other.gameObject);
            if (speed < 12)
            {
                speed += 1;
            }

        }

        if (other.gameObject.tag == "MassBuff")
        {
            ma.Play();
            Destroy(other.gameObject);
            if (GetComponent<Rigidbody>().mass < 1)
            {
                GetComponent<Rigidbody>().mass += 0.1f;
            }
        }
    }   
}
