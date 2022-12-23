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
    [SerializeField] Sprite[] chimneySprites;
    private SpriteRenderer houseSpriteRenderer;
    [SerializeField] SpriteRenderer chimneySpriteRenderer;

    private void Awake()
    {
        houseSpriteRenderer = GetComponent<SpriteRenderer>();

        //Decide good or bad
        int randChimney = Random.Range(1, 11);

        if (randChimney <= 6)
            type = HouseType.Good;
        else
            type = HouseType.Bad;

        chimneySpriteRenderer.sprite = type == HouseType.Good ? chimneySprites[0] : chimneySprites[1];

        //Decide house image
        houseSpriteRenderer.sprite = houseSprites[Random.Range(0, houseSprites.Length)];


    }

}

