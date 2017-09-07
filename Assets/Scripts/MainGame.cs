using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {


    int GameMode = 0;

    //ссылка на игровой объект змейку
    public GameObject Snake;
    //змейка создающаяся в игре   
    GameObject SnakeObj;
    //параметры направления змейки
    float XX = 0, YY = 0;

    //создаем еду
    public GameObject Eat;

    int TimeSpeed = 50;
    int Buff = 0;

    void AddEat()
    {

        Instantiate(Eat);
    }



    void CreateSnake()
    {
        //ставим змейку на поле
        SnakeObj = Instantiate(Snake) as GameObject;
        SnakeObj.name = "Snake";


        //запускаем игру
        GameMode = 1;
    }

	// Use this for initialization
	void Start () {
        //CreateSnake();

    }
	
	// Update is called once per frame
	void Update () {
		
        if (SnakeObj != null)
        {
            //обнуляем направление движения
            XX = 0;
            YY = 0;
            if (Input.GetAxis("Horizontal") > 0) XX = 1;
            if (Input.GetAxis("Horizontal") < 0) XX = -1;
            if (Input.GetAxis("Vertical") > 0) YY = 1;
            if (Input.GetAxis("Vertical") < 0) YY = -1;

            if ((XX != 0) || (YY != 0))
            {
                //получаем компонент управления змейкой
                SnakeLife S = SnakeObj.GetComponent<SnakeLife>();

                //указываем змейке куда ей двигаться
                if (XX != 0) S.DirecionHod = new Vector2(XX, 0);
                if (YY != 0) S.DirecionHod = new Vector2(0, YY);
            }
        }
        else
        {
            GameMode = 0;
        }

        if (GameMode > 0)
        {
            Buff++;

            if (Buff > TimeSpeed)
            {
                AddEat();
                Buff = 0;
            }
        }
	}

    //покажем кнопку старта
    void OnGUI()
    {
        int posaY = Screen.height / 2;
        int posaX = Screen.width / 2;

        switch (GameMode)
        {
            case 0:

                if (GUI.Button(new Rect(new Vector2(posaX - 100, posaY), new Vector2(200, 30)), "Старт игры")) CreateSnake();
                if (GUI.Button(new Rect(new Vector2(posaX - 100, posaY + 40), new Vector2(200, 30)), "Выход")) Application.Quit();
                break;
            case 1:

                //получаем компонент управления змейкой
                SnakeLife S = SnakeObj.GetComponent<SnakeLife>();

                int Score = 0;

                if (S != null) Score = S.ScoreSnake;

                //показываем очки на экране
                GUI.Label(new Rect(new Vector2(posaX, 0), new Vector2(200, 30)), "Набрано яблок" + Score);
                break;
        }
    }
}
