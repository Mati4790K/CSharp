using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public Text moneyText;
    public Text livesText;
    public int startMoney = 2;

    public static int Lives;
    public int startLives = 10;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        Resources.LoadAll("Prefabs");
        Resources.LoadAll("Effects");
    }
    private void Update()
    {
        moneyText.text = "$" + Money.ToString();
        livesText.text = Lives.ToString();
    }

    public void HackMoney()
    {
        Money += 2500;
    }
}
