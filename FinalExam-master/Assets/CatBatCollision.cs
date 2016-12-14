using UnityEngine;
using System.Collections;

public class CatBatCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.gameObject.name == "EarthLow(Clone)")
            {
                AudioSource audio = GetComponent<AudioSource>();
                Object.Destroy(hit.gameObject);
                audio.Play();
                
            }
        }
    }


}
