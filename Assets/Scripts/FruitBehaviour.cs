using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    Rigidbody fruitRB;
    
    Vector3 direction;

    float strength;
    int speed = 150;

    int randomSpinIndex;
    int randomSpinIndex2;
    int randomSpinIndex3;
    int randomFPIndex;

    Vector3[] spinRotation;
    Vector3[] focalPoints;

    // Start is called before the first frame update
    void Start()
    {
        spinRotation = new Vector3[] {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        focalPoints = new Vector3[] {new Vector3(-5, 10, 0), new Vector3(0, 10, 0), new Vector3(5, 10, 0)};

        randomSpinIndex = Random.Range(0, 2);
        randomSpinIndex2 = Random.Range(2, 4);
        randomSpinIndex2 = Random.Range(4, 6);
        randomFPIndex = Random.Range(0, focalPoints.Length);

        fruitRB = GetComponent<Rigidbody>();
        direction = (focalPoints[randomFPIndex] - this.transform.position).normalized;
       
        FruitThrow();
    }
    
    void FruitThrow()
    {
        strength = Random.Range(12, 16);
        fruitRB.AddForce(direction * strength, ForceMode.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinRotation[randomSpinIndex] * Time.deltaTime * speed);
        transform.Rotate(spinRotation[randomSpinIndex2] * Time.deltaTime * speed);
        transform.Rotate(spinRotation[randomSpinIndex3] * Time.deltaTime * speed);

        if (this.transform.position.y < -10)
        {
            GameManager.lives--;
            Destroy(this.gameObject);
        }
    }
}
