using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        int id = Random.Range(0, sprites.Length);
        originalCard.setCard(id, sprites[id]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
