using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public int money = 0;
    public const int MAX_COUNT = 7;
    public Text moneyText;
    public Text prompt;

    void Start()
    {
        
    }

    void Update()
    {
		moneyText.text = money.ToString();
    }

    public void Add(int amount)
    {
        money += amount;
    }
}
