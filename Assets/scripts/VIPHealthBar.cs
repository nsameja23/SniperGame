using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIPHealthBar : MonoBehaviour
{
    public float vipBaseHealth;
    public float vipCurrentHealth;
    public bool isVIPDead;

    public Image[] healthbarImageList;
    public Image healthbar;

    // Use this for initialization
    void Start()
    {
        vipBaseHealth = 100;
        vipCurrentHealth = vipBaseHealth;
        isVIPDead = false;

        healthbarImageList = this.GetComponentsInChildren<Image>();
        FindHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    void FindHealthBar()
    {
        foreach (Image image in healthbarImageList)
        {
            if (image.tag == "AdjustableHealthBar" && healthbar == null)
            {
                healthbar = image;
                return;
            }
        }
    }

    void UpdateHealthBar()
    {
        healthbar.fillAmount = vipCurrentHealth / vipBaseHealth;
    }

    #region Accessors

    public float VipHealth
    {
        get
        {
            return vipCurrentHealth;
        }
    }

    #endregion
}
