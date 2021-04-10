using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShootingSpells : MonoBehaviour
{
    [SerializeField] GameObject SpellPrefab;
    public List<GameObject> ObjectPool;
    [SerializeField] const int TIME_BTW_SHOTS = 2;
    float timeBtwShots = TIME_BTW_SHOTS;
    [SerializeField] ActionWithSpellBook SpellBook;
    [SerializeField] int spellNum;
    [SerializeField] float manaCost;
    [SerializeField] ManaCounter MC;
    private void Start()
    {
        
        //Создаем новый список, так как List - 
        //ссылка на динамический массив
        ObjectPool = new List<GameObject>();
    } 
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && (SpellBook.Spells[spellNum]) && !(EventSystem.current.IsPointerOverGameObject()) && MC.currentMana>=manaCost)
            {
                MC.SpellShot(manaCost);
                //diff - будет смещением нашего нажатия от объекта
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                //номализация приводит каждое значение в промежуток
                //от -1 до 1
                diff.Normalize();
                //по нормализованному виду мы находим угол, так как в diff
                //находится вектор, который можно перенести на тригонометрическую окружность
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                //и прсиваиваем наш угол персонажу
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
                //Показывает, нашли ли мы выключенный объект в нашем массиве
                bool freeBullet = false;
                //Теперь необходимо проверить, есть ли выключенный объект в нашем пуле
                for (int i = 0; i < ObjectPool.Count; i++)
                {
                    //Смотрим, активен ли объект в игровом пространстве
                    if (!ObjectPool[i].activeInHierarchy)
                    {
                        //Если объект не активен
                        //То мы задаем ему все нужные параметры
                        //Позицию
                        ObjectPool[i].transform.position = transform.position;
                        //Поворот
                        ObjectPool[i].transform.rotation = transform.rotation;
                        //И опять его включаем
                        ObjectPool[i].SetActive(true);
                        //Ставим объект найденным, чтоб опять не создавать лишний
                        freeBullet = true;
                        break;
                    }
                }
                //если свободный объект не был найден, то нужно создать еще один
                if (!freeBullet)
                {
                    //Создаем объект с нужными значениями и заносим его в пул
                    var newSpell = Instantiate(SpellPrefab, transform.position, transform.rotation);
                    ObjectPool.Add(newSpell);
                }
                timeBtwShots = TIME_BTW_SHOTS;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

