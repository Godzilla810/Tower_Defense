using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI roundsText;

    // public TextMeshProUGUI countdownText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStatus.Money.ToString();
        livesText.text = PlayerStatus.Lives.ToString() + "LIVES";
        roundsText.text = PlayerStatus.Rounds.ToString();
    }
}
