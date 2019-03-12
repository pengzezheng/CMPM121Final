using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    int speed = 10;
    float rotationSpeed = 500;
    float timer = 2.0f;
    // Start is called before the first frame update

    void OnGUI()
    {
        //Show score
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor=Color.black;
        style.fontSize = (int)(10f);
        GUI.Label(new Rect(0, 0, 400, 100), "Player 1 Speed: " + speed);
        GUI.Label(new Rect(0, 50, 400, 100), "Player 1 Mass: " + GetComponent<Rigidbody>().mass);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
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

        if (transform.position.y <= -1)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 2.0f;
            SceneManager.LoadScene(5);
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
            //Debug.Log("Speed is "+speed);
        }

        if (other.gameObject.tag == "MassBuff")
        {
            Destroy(other.gameObject);
            if (GetComponent<Rigidbody>().mass < 1)
            {
                GetComponent<Rigidbody>().mass += 0.1f;
            }
            //Debug.Log("Mass is " + GetComponent<Rigidbody>().mass);
        }
    }
}
