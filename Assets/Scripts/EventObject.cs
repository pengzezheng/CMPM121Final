using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RespawnObject1", 1, 15);   
        InvokeRepeating("RespawnObject2", 1, 15);   
        InvokeRepeating("RespawnObject3", 1, 15);   
        InvokeRepeating("RespawnObject4", 1, 15);   
        InvokeRepeating("RespawnItem1", 1, 15);   
        InvokeRepeating("RespawnItem2", 1, 15);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnObject1()
    {

        GameObject sphere=GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        sphere.transform.localScale = new Vector3(3,3,3);
        sphere.AddComponent<Rigidbody>();
        sphere.AddComponent<Clean>(); 
        //sphere.GetComponent<Rigidbody>().mass = 1;
    }

    void RespawnObject2()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        cylinder.transform.localScale = new Vector3(2, 2, 2);
        cylinder.transform.Rotate(90,0,0);
        cylinder.AddComponent<Rigidbody>();
        cylinder.AddComponent<Clean>();
    }

    void RespawnObject3()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        capsule.transform.localScale = new Vector3(2, 2, 2);
        capsule.transform.Rotate(0, 0, 90);
        capsule.AddComponent<Rigidbody>();
        capsule.AddComponent<Clean>();
    }

    void RespawnObject4()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(Random.Range(-20, 20), 3, Random.Range(-20, 20));
        cube.transform.localScale = new Vector3(2, 2, 2);
        cube.transform.Rotate(0, 0, 90);
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<Clean>();
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
}
