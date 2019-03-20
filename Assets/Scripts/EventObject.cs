using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource res;

    // Start is called before the first frame update
    void Start()
    {
        //BGM
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.playOnAwake = true;
        BGM.loop = true;
        BGM.clip = Resources.Load<AudioClip>("BGM");
        BGM.Play();

        //Object Respawn
        res = gameObject.AddComponent<AudioSource>();
        res.playOnAwake = false;
        res.loop = false;
        res.clip = Resources.Load<AudioClip>("Respawn");

        InvokeRepeating("RespawnObject1", 2, 15);   
        InvokeRepeating("RespawnObject2", 2, 15);   
        InvokeRepeating("RespawnObject3", 2, 15);   
        InvokeRepeating("RespawnObject4", 2, 15);   
        InvokeRepeating("RespawnItem1", 2, 15);   
        InvokeRepeating("RespawnItem2", 2, 15);   
        InvokeRepeating("RespawnSound", 1, 15);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnObject1()
    {

        GameObject sphere=GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        sphere.transform.localScale = new Vector3(4,4,4);
        sphere.AddComponent<Rigidbody>();
        sphere.AddComponent<Clean>();
        sphere.GetComponent<MeshRenderer>().material.mainTexture= Resources.Load("Metal1") as Texture;
        //sphere.GetComponent<Rigidbody>().mass = 1;


    }

    void RespawnObject2()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        cylinder.transform.localScale = new Vector3(3, 3, 3);
        cylinder.transform.Rotate(90,0,0);
        cylinder.AddComponent<Rigidbody>();
        cylinder.AddComponent<Clean>();
        cylinder.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Metal2") as Texture;
    }

    void RespawnObject3()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        capsule.transform.localScale = new Vector3(3, 3, 3);
        capsule.transform.Rotate(0, 0, 90);
        capsule.AddComponent<Rigidbody>();
        capsule.AddComponent<Clean>();
        capsule.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Metal3") as Texture;
    }

    void RespawnObject4()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        cube.transform.localScale = new Vector3(3, 3, 3);
        cube.transform.Rotate(0, 0, 90);
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<Clean>();
        cube.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load("Metal4") as Texture;
    }


    void RespawnItem1()
    {
        GameObject foo = Instantiate((GameObject)Resources.Load("BeveledStar"));
        foo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        foo.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        foo.tag = "SpeedBuff";
        foo.AddComponent<BoxCollider>();
        foo.GetComponent<Renderer>().material.color=Color.yellow;
        foo.GetComponent<Collider>().isTrigger = true;
        foo.GetComponent<BoxCollider>().center = new Vector3(0,0,-1);
    }

    void RespawnItem2()
    {
        GameObject foo = Instantiate((GameObject)Resources.Load("Heart"));
        foo.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        foo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        foo.tag = "MassBuff";
        foo.AddComponent<BoxCollider>();
        foo.GetComponent<Renderer>().material.color = Color.red;
        foo.GetComponent<Collider>().isTrigger = true;
        foo.GetComponent<BoxCollider>().center = new Vector3(0, 0, -1);
    }

    void RespawnSound()
    {
        res.Play();
    }
}
