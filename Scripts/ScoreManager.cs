using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1;
    [SerializeField] private TextMeshProUGUI player2;
    private int player1Score = 0;
    private int player2Score = 0;

    public void AddScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
            player1.text = player1Score.ToString();
        }
        else if (player == 2)
        {
            player2Score++;
            player2.text = player2Score.ToString();
        }
    }
}
