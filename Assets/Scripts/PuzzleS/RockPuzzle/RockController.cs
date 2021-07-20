using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    [SerializeField] Transform[] rocks;
    [SerializeField] GameObject[] whatToDelete;
    [Header ("Вписать дефолтную высоту от 1 до 4")]
    [SerializeField] int[] rockLevelChecker;
    [HideInInspector] public bool ended;
    private void Update()
    {
        if (rockLevelChecker[0] == 3 && rockLevelChecker[1] == 2 && rockLevelChecker[2] == 1 && rockLevelChecker[3] == 0)
        {
            for (int i = 0; i < whatToDelete.Length; i++)
            {
                if (whatToDelete != null)
                    Destroy(whatToDelete[i]);
            }
            Debug.Log("ПОБЕДА");
            ended = true;
            Destroy(gameObject);
        }
    }
    public void ChangeRockPositions(int whatRockUp, int whatRockDown)
    {
        if (rocks[whatRockUp].position.y < -0.8f)
        {
            rockLevelChecker[whatRockUp]++;
            rocks[whatRockUp].position = new Vector3(rocks[whatRockUp].position.x, rocks[whatRockUp].position.y + 1.2f, rocks[whatRockUp].position.z);
        }
        if (rocks[whatRockDown].position.y > -4.4f)
        {
            rockLevelChecker[whatRockDown]--;
            rocks[whatRockDown].position = new Vector3(rocks[whatRockDown].position.x, rocks[whatRockDown].position.y - 1.2f, rocks[whatRockDown].position.z);
        }
    }
}
