using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceOBJ : MonoBehaviour
{

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;
    private List<GameObject> placedPrefabList = new List<GameObject>();

    [SerializeField]
    private int maxPrefabSpawnCount = 0;
    private int placedPrefabCount;

    [SerializeField]
    private GameObject PlaceablePrefab;
    public GameObject Cube;

    float waitTime = 5f;

    //Vector2 ballPosition;   
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    //public Animator anim; 

    //void Start()
    //{
       // anim.GetComponent<Animator>();
    //}
    
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryToGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)//(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            Debug.Log(touchPosition.x);

            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryToGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);

            Destroy(spawnedObject, waitTime);
            //spawnedObject = Instantiate(Cube, hitPose.position, hitPose.rotation);
            //BoxCollider boxCollider = Cube.AddComponent<BoxCollider>();
            //anim.Play("bioFilmGrow");
            //if (placedPrefabCount < maxPrefabSpawnCount)
            //{
            //spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
            //placedPrefabList.add(spawnedObject);
            //placedPrefabCount++;
            //SpawnedPrefab(hitPose);
            // }
            //if (spawnedObject == null)
            //{
            //spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
            //placedPrefabList.add(spawnedObject);
            //placedPrefabCount++;
            //SpawnedPrefab(hitPose);
            //} else
            //{
            //spawnedObject.transform.position = hitPos.position;
            //spawnedObject.transform.rotation = hitPos.rotation;

            //}
        }
    }

    public void SetPrefabType (GameObject prefabType)
    {
        PlaceablePrefab = prefabType;

    }

    private void SpawnedPrefab(Pose hitPose)
    {
        spawnedObject = Instantiate(PlaceablePrefab, hitPose.position, hitPose.rotation);
        placedPrefabList.Add(spawnedObject);
        placedPrefabCount++;
    }
  
}
