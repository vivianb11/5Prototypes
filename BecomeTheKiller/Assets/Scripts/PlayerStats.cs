using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class PlayerStats : MonoBehaviour
{
    
    [Header("Energy Stats")]
    [Space]
    public int energy = 5;
    public int maxEnergy = 10;

    public TextMeshProUGUI energyAmount;
    public Slider energyAmountSlider;

    private bool energyIsRunning = false;

    [Header("Life Stats")]
    [Space]
    public int hp;
    public int maxHp = 5;

    public TextMeshProUGUI hpAmount;
    public Slider hpAmountSlider;

    private bool hpIsRunning = false;

    private void Awake()
    {
        energyAmountSlider.maxValue = maxEnergy;
        hpAmountSlider.maxValue = maxHp;
        hpAmountSlider.value = 1;
    }

    private void Update()
    {
        ApplyValues();

        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeHp(-1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeHp(1);
        }
    }

    #region Energy Functions
    public bool EnoughEnergy(int energyRequiered)
    {
        if (energy < energyRequiered)
        {
            return false;
        }
        else
        {
            ChangeEnergy(- energyRequiered);
            return true;
        }
    }

    public void ChangeEnergy(int amount)
    {
        int finalResault = Mathf.Clamp(energy + amount, 0 , maxEnergy);

        if (!energyIsRunning)
        {
            energyIsRunning = true;

            StartCoroutine(EnergyChangeAnimation(finalResault));
        }
    }

    IEnumerator EnergyChangeAnimation(int finalResault)
    {

        Tween bar;

        while (finalResault != energy)
        {
            if (finalResault < energy)
            {
                energy -= 1;

                bar = energyAmountSlider.gameObject.transform.DOShakeScale(0.1f);
                yield return new WaitForSeconds(0.1f);
                bar.Kill();
            }
            else if (finalResault > energy)
            {
                energy += 1;

                bar = energyAmountSlider.gameObject.transform.DOShakeScale(0.1f);
                yield return new WaitForSeconds(0.1f);
                bar.Kill();
            }
        }
        energyIsRunning = false;
        yield return null;
    }

    #endregion

    #region Hp Functions
    public bool IsHpBelow(int value)
    {
        if (hp <= value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeHp(int amount)
    {
        int finalResault = Mathf.Clamp(hp + amount, 0, maxHp);

        if (!hpIsRunning)
        {
            hpIsRunning = true;

            StartCoroutine(HpChangeAnimation(amount, finalResault));
        }
    }

    IEnumerator HpChangeAnimation(int amount, int finalResault)
    {
        amount = (amount < 0) ? -1 * amount : amount;
        
        while (finalResault != hp)
        {
            if (finalResault < hp)
            {
                hp -= 1;

                yield return new WaitForSeconds(1 / amount);
                
            }
            else if (finalResault > hp)
            {
                hp += 1;
                
                yield return new WaitForSeconds(1 / amount);
            }
        }
        hpIsRunning = false;
        yield return null;
    }
    #endregion

    void ApplyValues()
    {
        if (energyAmountSlider.value != energy)
        {
            energyAmountSlider.value = energy;
            energyAmount.text = energy + " / " + maxEnergy;
        }

        if (energyAmountSlider.maxValue != maxEnergy)
        {
            energyAmountSlider.maxValue = maxEnergy;
        }

        if (hpAmountSlider.value != hp)
        {
            hpAmountSlider.value = hp;
            hpAmount.text = hp + " / " + maxHp;
        }

        if (hpAmountSlider.maxValue != maxHp)
        {
            hpAmountSlider.maxValue = maxHp;
        }
    }
}
