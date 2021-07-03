using UnityEngine;
using UnityEngine.EventSystems;
public class ShootingSpells : MonoBehaviour
{
    [SerializeField] GameObject SpellPrefab;
    [SerializeField] int spellNum;
    [SerializeField] float manaCost;
    [SerializeField] Transform firePoint;


    ActionWithSpellBook spellBook;
    ManaCounter mana;
    PlayerController pc;

    const int TIME_BTW_SHOTS = 2;
    float timeBtwShots = TIME_BTW_SHOTS;

    public void Initialise(ActionWithSpellBook spellBook, ManaCounter mana)
    {
        this.spellBook = spellBook;
        this.mana = mana;
    }

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && (spellBook.Spells[spellNum]) && !(EventSystem.current.IsPointerOverGameObject()) && mana.currentMana>=manaCost)
            {
                mana.SpellShot(manaCost);
                //diff - будет смещением нашего нажатия от объекта
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
                //номализация приводит каждое значение в промежуток
                //от -1 до 1
                diff.Normalize();
                if(diff.x<0 && pc.faceRight)
                {
                    pc.Flip();
                }
                else if(diff.x>=0 && !pc.faceRight)
                {
                    pc.Flip();
                }               
                //по нормализованному виду мы находим угол, так как в diff
                //находится вектор, который можно перенести на тригонометрическую окружность
                //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                //и прсиваиваем наш угол персонажу
                //firePoint.rotation = Quaternion.Euler(0f, 0f, rot_z);
                Instantiate(SpellPrefab, firePoint).GetComponent<Spell>().Set_Direction(new Vector3(diff.x, diff.y));
                spellBook.UseSpell();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

