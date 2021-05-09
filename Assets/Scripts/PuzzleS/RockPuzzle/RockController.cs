using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] Transform[] rocks;
    private void Update()
    {
        if (rocks[0].position.y == -1.5 && rocks[1].position.y == -2 && rocks[2].position.y == -2.5 && rocks[3].position.y == -3 )
        {
            Debug.Log("ПОБЕДА");
            Destroy(gameObject);
        }
    }
    public void ChangeRockPositions(int whatRockUp, int whatRockDown)
    {
        if (rocks[whatRockUp].position.y < -1.5)
        {
            rocks[whatRockUp].position = new Vector3(rocks[whatRockUp].position.x, rocks[whatRockUp].position.y + 0.5f, rocks[whatRockUp].position.z);
        }
        if (rocks[whatRockDown].position.y > -3)
        {
            rocks[whatRockDown].position = new Vector3(rocks[whatRockDown].position.x, rocks[whatRockDown].position.y - 0.5f, rocks[whatRockDown].position.z);
        }
    }
}
