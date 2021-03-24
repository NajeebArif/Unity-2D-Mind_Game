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
    [SerializeField] private TextMesh scoreLabel;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int _score;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 startingPosition = originalCard.transform.position;

        int[] numbers = { 0,0,1,1,2,2,3,3};
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
                card.setCard(id, sprites[id]);

                float posX = (offsetX * i) + startingPosition.x;
                float posY = -(offsetY * j) + startingPosition.y;
                card.transform.position = new Vector3(posX, posY, startingPosition.z);
            }
        }

    }

    public bool canReveal {
        get { return _secondRevealed == null; }
    }

    public void cardRevealed(MemoryCard card) {
        if (_firstRevealed == null) {
            _firstRevealed = card;
        } else {
            _secondRevealed = card;
            StartCoroutine(checkMatch());
        }
    }
    private IEnumerator checkMatch() {
        if(_firstRevealed.id == _secondRevealed.id) {
            _score++;
            scoreLabel.text = "Score: " + _score;
        } else {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.unReveal();
            _secondRevealed.unReveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
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
