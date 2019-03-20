using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public AudioSource res;

    // Start is called before the first frame update
    void Start()
    {
        res = gameObject.AddComponent<AudioSource>();
        res.playOnAwake = false;
        res.loop = false;
        res.clip = Resources.Load<AudioClip>("Collision");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Vector3 direction = transform.position - collision.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(direction.x*1000, 0, direction.z*1000);
            res.Play();
        }
    }
}
