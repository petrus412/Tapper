using System.Collections.Generic;
using System;
using UnityEngine;

public enum EGUIType { None =-1,MainMenu,SettingsMenus}

public class UIManager : MonoBehaviour
{

    private static UIManager singleton;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;
    private Dictionary<EGUIType,GameObject> data;
    // Start is called before the first frame update
    private void Start()
    {
        Inizialization();
    }
    private void Inizialization()
    {
        if (!singleton) singleton = this;

        try
        {
            MainMenu.SetActive(false);
            SettingsMenu.SetActive(false);

            data = new Dictionary<EGUIType, GameObject>();
           // data.Add(EGUIType)
        }
        catch (SystemException ex)
        {
            Debug.LogAssertion(ex.Message);
        }
    }

    public static void ShowMenu(EGUIType type)
    {
        singleton.data[type].SetActive(true);
    }

    public static void Hide(EGUIType type) 
    {
        singleton.data[type].SetActive(false);
    }
}
