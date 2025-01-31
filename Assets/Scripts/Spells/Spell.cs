﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    //Spell in spellbook
    public float manaCost;
    public SpellType spellType;
    public float cooldown;

    [SerializeField] private AudioClip _onCast;

    public GameObject projectile;

    public const string path = "Prefabs/Magic/Spells/";

    bool onCooldown = false;
    Image spellImage;

    private void Start()
    {
        spellImage = GetComponent<Image>();
    }

    public virtual void Cast(Vector3 firePoint, float angle)
    {   

        if (onCooldown)
            return;     

        Instantiate(projectile, firePoint, Quaternion.Euler(0,Engine.current.player.transform.GetChild(0).rotation.eulerAngles.y, angle));
        SoundRecorder.Play_Effect(_onCast);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        float _endTime = Time.time + cooldown;
        onCooldown = true;
        do
        {
            spellImage.fillAmount = 1 - ((_endTime - Time.time) / cooldown);
            yield return null;
        }
        while (spellImage.fillAmount < 1);
        onCooldown = false;
    }
}

public enum SpellType { Wind, Fire, Ice, Levitation }

