using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour{
    public float speed;

    //Do Physics here, happens at a set interval
    private void FixedUpdate()
    {
        //Causes the ship to rotate with the mouse
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z); // prevents weird squish effect when rotating

        //Allows player to move forward or backwards using only an up or down key
        float input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);
    }
}

