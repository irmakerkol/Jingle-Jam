using TMPro;
using UnityEngine;

public class GetPlayerPrefs : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    private int getHitByRock;
    private void Start()
    {
        getHitByRock = PlayerPrefs.GetInt("HitByRock");
        Text.text = "SANTA GOT HIT BY JAMANCA  " + getHitByRock + " TIMES";


    }
}
