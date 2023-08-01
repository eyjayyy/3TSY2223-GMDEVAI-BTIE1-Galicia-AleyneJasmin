using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject baddie;
    public GameObject goodie;
    GameObject[] agents;

    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Spawn object for agents to flee from
    void SpawnBaddie()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Instantiate(baddie, hit.point, baddie.transform.rotation);
            foreach(GameObject a in agents)
            {
                a.GetComponent<AIController>().DetectNewBaddie(hit.point);
            }
        }
    }

    // Spawn object for agents to flock to
    void SpawnGoodie()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Instantiate(goodie, hit.point, goodie.transform.rotation);
            foreach(GameObject a in agents)
            {
                a.GetComponent<AIController>().DetectNewGoodie(hit.point);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBaddie();
        }

        else if (Input.GetMouseButtonDown(1))
        {
            SpawnGoodie();
        }
    }
}
