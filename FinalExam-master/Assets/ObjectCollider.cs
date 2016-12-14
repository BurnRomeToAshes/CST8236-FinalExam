using UnityEngine;
using System.Collections;

public class ObjectCollider : MonoBehaviour {

    bool firstTime;

	// Use this for initialization
	void Start () {
        firstTime = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (!firstTime)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f);
            foreach (Collider hit in colliders)
            {
                MeshCollider ms = hit.GetComponent<MeshCollider>();
                if (ms != null && hit.gameObject.name != "Cat" && hit.gameObject.name != "GoalZone")
                {
                    AudioSource audio = GetComponent<AudioSource>();                   
                    audio.Play();
                    Object.Destroy(this.gameObject);
                    return;
                }
                // Trees are box colliders
                BoxCollider bc = hit.GetComponent<BoxCollider>();

                if (bc != null && hit.gameObject.name.Contains("Pine"))
                {
                    AudioSource audio = GetComponent<AudioSource>();                   
                    audio.Play();
                    Object.Destroy(this.gameObject);
                    return;
                }
            }
        } else
        {
            firstTime = false;
        }
    }

}
