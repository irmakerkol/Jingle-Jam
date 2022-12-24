using UnityEngine;

public class House : MonoBehaviour
{
    public enum HouseType
    {
        Good,
        Bad
    }

    public HouseType type;
    [SerializeField] Sprite[] houseSprites;
    private SpriteRenderer houseSpriteRenderer;
    [SerializeField] GameObject goodChimney, badChimney;


    private void Awake()
    {
        houseSpriteRenderer = GetComponent<SpriteRenderer>();

        //Decide good or bad
        int randChimney = Random.Range(1, 11);

        if (randChimney <= 5)
        {
            type = HouseType.Good;
            goodChimney.SetActive(true);
            badChimney.SetActive(false);
        }
        else 
        {
            type = HouseType.Bad;
            goodChimney.SetActive(false);
            badChimney.SetActive(true);
        }


        //Decide house image
        houseSpriteRenderer.sprite = houseSprites[Random.Range(0, houseSprites.Length)];


    }

}

