using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject shot;
    private Transform playerpos;

    private void Start()
    {
       playerpos = GetComponent<Transform>();
    }
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, playerpos.position, Quaternion.identity);
        }
	}
}
