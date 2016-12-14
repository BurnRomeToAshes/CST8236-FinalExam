using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private float h;
    private float v;

    void Update()
    {
        Vector3 back = transform.TransformDirection(Vector3.back);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += forward * 0.1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += back * 0.1f;
        }
   
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate(GameObject.FindGameObjectWithTag("Bullet"), transform.position, Quaternion.identity) as GameObject;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(forward * 10.0f, ForceMode.Impulse);
        }


        h = 0.1f * Input.GetAxis ("Mouse Y");
        v = 0.1f * Input.GetAxis ("Mouse X");
        transform.Translate(v,h,0);     
    }
}
