using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();
        if (S != null)
        {
            S.SnakeDestroy();
        }

    }
}
