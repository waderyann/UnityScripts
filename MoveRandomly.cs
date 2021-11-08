using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeForNewPath;
    public int newtarget;
    public float speed;
    public Vector3 Target;
    bool inCoroutine = false;
    NavMeshAgent navMeshAgent;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 3, z);
        return pos;
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
        navMeshAgent.SetDestination(getNewRandomPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoroutine)
        {
            StartCoroutine(DoSomething());
        }
    }
}
