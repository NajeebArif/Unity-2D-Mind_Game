using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;


    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startingPosition = originalCard.transform.position;

        for(int i =0; i < gridCols; i++) {
            for(int j = 0; j < gridRows; j++) {
                MemoryCard card;
                if (i == 0 && j == 0)
                    card = originalCard;
                else
                    card = Instantiate(originalCard) as MemoryCard;
                int id = Random.Range(0, sprites.Length);
                originalCard.setCard(id, sprites[id]);
                float posX = (offsetX * i) + startingPosition.x;
                float posY = -(offsetY * j) + startingPosition.y;
                card.transform.position = new Vector3(posX, posY, startingPosition.z);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
