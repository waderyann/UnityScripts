using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRandomly : MonoBehaviour
{
    float timeForNewPath = 1;
    
    public float amountOfAgents;
    public float speed = 10.0f;
    bool inCoroutine = false;
    public GameObject Player;
    public Transform Target;


    // Start is called before the first frame update
    void Start()
    {
    }

    float getRandomValue()
    {
        return Random.Range(-5, 5);
    }


    IEnumerator DoSomething()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoroutine = false;
        //GetNewPath();
    }

    void GetNewPath()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(getRandomValue(), getRandomValue(), getRandomValue());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine)
        {
            StartCoroutine(DoSomething());
        }

        //GetNewPath();

        if(Input.GetKeyDown(KeyCode.X))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            //this.transform.LookAt(Target.transform.position);
        }

        transform.LookAt(Target.transform.position);
        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }
}
