using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour
{
    private int Operand1;
    private int Operation;
    private int Operand2;
    public string Result;

    public Text FirstOperand;
    public Text Operator;
    public Text SecondOperand;

    public int ScoreValue = 500;
    public float MoveSpeed = 1.0f;
    public GameController GameController;

    //In modalità binaria il massimo numero rappresentabile senza problemi è 64, quindi per esempio per l'addizione i massimi valori degli operandi sono 32 e 32

    private void Awake()
    {
        GameController = FindObjectOfType<GameController>();
        Operation = Random.Range(0,4);
        if (Operation == 0)
        {
            if (GameController.Mode == 1)
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(33, 10 + Time.time / 25));
                Operand2 = (int)Random.Range(0, Mathf.Min(33, 10 + Time.time / 50));
            }
            else
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(151, 10 + Time.time / 25));
                Operand2 = (int)Random.Range(0, Mathf.Min(151, 10 + Time.time / 50));
            }

            Operator.text = "+";

            Result = (Operand1 + Operand2).ToString();

            if(GameController.Mode == 1)
            {
                Result = System.Convert.ToString(Operand1 + Operand2, 2);
            }
        }
        else if(Operation == 1)
        {
            if (GameController.Mode == 1)
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(64, 10 + Time.time / 25));
                do
                {
                    Operand2 = (int)Random.Range(0, Mathf.Min(64, 10 + Time.time / 50));
                } while (Operand1 < Operand2);
            }
            else
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(101, 10 + Time.time / 25));
                do
                {
                    Operand2 = (int)Random.Range(0, Mathf.Min(101, 10 + Time.time / 25));
                } while (Operand1 < Operand2);
            }

            Operator.text = "-";

            Result = (Operand1 - Operand2).ToString();

            if (GameController.Mode == 1)
            {
                Result = System.Convert.ToString(Operand1 - Operand2, 2);
            }
        }
        else if(Operation == 2)
        {
            if (GameController.Mode == 1)
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(9, 3 + Time.time / 25));
                Operand2 = (int)Random.Range(0, Mathf.Min(9, 3 + Time.time / 50));
            }
            else
            {
                Operand1 = (int)Random.Range(0, Mathf.Min(21, 10 + Time.time / 25));
                Operand2 = (int)Random.Range(0, Mathf.Min(11, 10 + Time.time / 50));
            }

            Operator.text = "x";

            Result = (Operand1 * Operand2).ToString();

            if (GameController.Mode == 1)
            {
                Result = System.Convert.ToString(Operand1 * Operand2, 2);
            }
        }
        else
        {
            if (GameController.Mode == 1)
            {
                Operand1 = (int)Random.Range(16, Mathf.Min(64, 20 + Time.time / 25));
                do
                {
                    Operand2 = (int)Random.Range(1, Mathf.Min(64, 10 + Time.time / 25));
                } while (Operand1 < Operand2 || Operand1 % Operand2 != 0);
            }
            else
            {
                Operand1 = (int)Random.Range(32, Mathf.Min(201, 65 + Time.time / 25));
                do
                {
                    Operand2 = (int)Random.Range(1, Mathf.Min(201, 10 + Time.time / 25));
                } while (Operand1 < Operand2 || Operand1 % Operand2 != 0);
            }

            Operator.text = "%";

            Result = (Operand1 / Operand2).ToString();

            if (GameController.Mode == 1)
            {
                Result = System.Convert.ToString(Operand1 / Operand2, 2);
            }
        }
        FirstOperand.text = Operand1.ToString();
        SecondOperand.text = Operand2.ToString();

        if (GameController.Mode == 1)
        {
            FirstOperand.text = System.Convert.ToString(Operand1, 2);
            SecondOperand.text = System.Convert.ToString(Operand2, 2);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            GameController.StopGame();
        }
    }

    private void OnDestroy()
    {
        if(GameController.isPlaying) GameController.AddScore(ScoreValue);
        GameController.ClearInput();
    }

}
