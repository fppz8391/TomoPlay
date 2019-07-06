using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotePoint : MonoBehaviour
{
    public List<Vector3> points;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform x in GetComponentInChildren<Transform>()){
            points.Add(x.position);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMove>().moveToByAnima(points[0],2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
