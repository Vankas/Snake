using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    int TimeDeath = 500;
    int Buff = 0;

    // Use this for initialization
    void Start () {

        float XX = Random.Range(-8, 8);
        float YY = Random.Range(-8, 8);

        this.transform.position = new Vector3(XX, YY, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //убиваем яблоко если время истекло
        Buff++;
        if (Buff > TimeDeath) DestroyObject(this.gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {
            S.AddChank();

            S.ScoreSnake++;

            DestroyObject(this.gameObject);
        }
    }

}
