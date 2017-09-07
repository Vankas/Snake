using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLife : MonoBehaviour {

    //количество собранныйх яблок
    public int ScoreSnake = 0;
    //скорость задержки до следующего движения змейки
    int TimeSpeed = 10;
    //накопление времени скорости
    int Buff = 0;
    //хвост змеи 1 часть
    public GameObject SnakeBody;
    //тело змеи
    List<GameObject> BodySnake = new List<GameObject>();
    //направление движения змейки
    public Vector2 DirecionHod;
    //растояние движения
    float SpeedMove = 3;

    public
        void AddChank()
    {
        Vector3 Position = transform.position;
        //если хвост существует то добавляем к нему
        if (BodySnake.Count > 0)
        {
            //получаем позицию головы и задаем ее хвосту
            Position = BodySnake[BodySnake.Count - 1].transform.position;
        }
        Position.y+=0.5f;
        //создаем новый блок хвоста
        GameObject Body = Instantiate(SnakeBody, Position, Quaternion.identity) as GameObject;

        //добавляем к хвосту блок
        BodySnake.Add(Body);

    }   

    void SnakeStap()
    {
        if ((DirecionHod.x != 0) || (DirecionHod.y != 0))
        {
            //получаем текущую позицию головы змейки
            Rigidbody ComponentRig = GetComponent<Rigidbody>();
            //задаем новую позицию головы
            ComponentRig.velocity = new Vector3(DirecionHod.x * SpeedMove, DirecionHod.y * SpeedMove, 0);

            //если хвост существует то двигаем и его
            if (BodySnake.Count > 0)
            {
                //задаем 1 части хвоста положение головы
                BodySnake[0].transform.position = transform.position;

                //двигаем хвост к голове
                for (int BodyIndex = BodySnake.Count - 1; BodyIndex > 0; BodyIndex--)
                    BodySnake[BodyIndex].transform.position = BodySnake[BodyIndex - 1].transform.position;

            }
        }


    }

    public void SnakeDestroy()
    {
        //останавливаем движение
        DirecionHod = new Vector2(0, 0);
        //убиваем хвост
        foreach (GameObject o in BodySnake) DestroyObject(o.gameObject);
        //убиваем змею
        DestroyObject(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        //уберем мусор из хвоста
        BodySnake.Clear();

        for (int I = 0; I < 3; I++) AddChank();

	}
	
	// Update is called once per frame
	void Update () {

        Buff++;
        if (Buff > TimeSpeed)
        {
        
            SnakeStap();
            Buff = 0;
        }
	}
}
