using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    

    //Скорость нашей пули
    public float Speed;
    //Время, через которое наша пуля
    //уйдет в пул объектов
    public float TimeToDisable;
    //Каждый раз, когда наша пуля активируется
    Vector3 direction;

    IEnumerator SetDisabled(float TimeToDisable)
    {
        //Данный скрип приостановит свое исполнение на 
        //TimeToDisable секунд, а потом продолжит работу
        yield return new WaitForSeconds(TimeToDisable);
        Destroy(gameObject);
    }

    private void Awake()
    {
        StartCoroutine(SetDisabled(TimeToDisable));
    }
    public void Set_Direction(Vector3 direction)
    {
        this.direction = direction;
    }
    void Update()
    {
        if (direction != null)
            transform.position += direction * Speed * Time.deltaTime;        
    }
}

