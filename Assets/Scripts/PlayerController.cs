using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject[] fruits;
    GameObject bomb;
    public GameObject splitFruit;
    public Vector3 playerPosition;
    public AudioSource audioSource;
    public AudioClip sliceSound;

    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit");

        for (int i = 0; i < Input.touchCount; i++)
        {
            
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                playerPosition = touchPosition;
                GameObject nearestFruitToTouchPosition = FindNearestFruitToTouchPosition(touchPosition);

                if (nearestFruitToTouchPosition != null && Time.timeScale == 1)
                {
                    audioSource.PlayOneShot(sliceSound);
                    if(nearestFruitToTouchPosition.name != "Bomb(Clone)")
                    {
                        
                        Destroy(nearestFruitToTouchPosition);
                        Instantiate(splitFruit, nearestFruitToTouchPosition.transform.position, nearestFruitToTouchPosition.transform.rotation);

                        GameManager.score++;
                    }else if(nearestFruitToTouchPosition.name == "Bomb(Clone)")
                    {
                      
                        Destroy(nearestFruitToTouchPosition);
                        GameManager.lives--;
                    }


                }

            }
        }

    }

    private GameObject FindNearestFruitToTouchPosition(Vector3 touchPosition)
    {
        GameObject nearest = null;
        float distance = .75f;

        for (int i = 0; i < fruits.Length; i++)
        {
            Transform fruitPos = fruits[i].transform;
            float candidateDistance = Vector3.Distance(touchPosition, fruitPos.position);
            if (candidateDistance < distance)
            {
                nearest = fruits[i].gameObject;
                //distance = candidateDistance;
            }
        }

        return nearest;
    }
}
