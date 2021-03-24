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

        int[] numbers = { 0,0,1,1,2,2,3,3,4,4};
        numbers = suffleArray(numbers);

        for(int i =0; i < gridCols; i++) {
            for(int j = 0; j < gridRows; j++) {
                MemoryCard card;

                if (i == 0 && j == 0)
                    card = originalCard;
                else
                    card = Instantiate(originalCard) as MemoryCard;

                int index = j * gridCols + i;
                int id = numbers[index];
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

    private int[] suffleArray(int[] numbers) {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++) {
            int temp = newArray[i];
            int r = Random.Range(0, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = temp;
        }
        return newArray;
    }
}
