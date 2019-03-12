using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    int speed = 10;
    float rotationSpeed = 500;
    float timer = 2.0f;
    // Start is called before the first frame update

    void OnGUI()
    {
        //Show score
        GUIStyle style = GUI.skin.GetStyle("label");
        style.fontSize = (int)(10f);
        GUI.Label(new Rect(700, 0, 400, 100), "Player 2 Speed: " + speed);
        GUI.Label(new Rect(700, 50, 400, 100), "Player 2 Mass: " + GetComponent<Rigidbody>().mass);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        //Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * -rotationSpeed);
        }

        if (transform.position.y <= -1)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 2.0f;
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedBuff")
        {
            Destroy(other.gameObject);
            if (speed < 20)
            {
                speed += 1;
            }
        }

        if (other.gameObject.tag == "MassBuff")
        {
            Destroy(other.gameObject);
            if (GetComponent<Rigidbody>().mass < 1)
            {
                GetComponent<Rigidbody>().mass += 0.1f;
            }
        }
    }
}
