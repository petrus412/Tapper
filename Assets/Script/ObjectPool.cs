using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    private List<GameObject> _ObjectList;
    private List<GameObject> _ClientList;
    private string _AssetPath;
    private string _ClientAssetPath;
    private uint ListSize;

    public ObjectPool(uint Size,string AssetPath,string ClientAssetPath)
    {
        ListSize = Size;
        _AssetPath = AssetPath;
        _ClientAssetPath = ClientAssetPath;
        _ObjectList = new List<GameObject>();
        _ClientList = new List<GameObject>();

        for (uint i=0; i < ListSize; i++)
        {
            var Item = Object.Instantiate(Resources.Load<GameObject>(_AssetPath));
            Item.SetActive(false);
            var Client = Object.Instantiate(Resources.Load<GameObject>(_ClientAssetPath));
            Client.SetActive(false);
            _ObjectList.Add(Item);
            _ClientList.Add(Client);
        }
    }

    public GameObject Get(int Type)
    {
        GameObject Result = GetFirstAvailabe(Type,out var HasSucced);
        if (HasSucced)
        {
            return Result;
        }
        else 
        {
            ExpandList(Type);
            return Get(Type); 
        }
    }
    private GameObject GetFirstAvailabe(int Type,out bool Success)
    {

        foreach (var element in Type==0?_ObjectList:_ClientList)
        {
            if (!element.activeSelf)
            {
                Success = true;
                return element;
            }
        }
        Success = false;
        return null;
    }
    private void ExpandList(int Type)
    {
        for (uint i = 0; i < ListSize; i++)
        {
            var Item = Object.Instantiate(Resources.Load<GameObject>(Type == 0 ? _AssetPath:_ClientAssetPath));
            Item.SetActive(false);
            (Type == 0 ? _ObjectList : _ClientList).Add(Item);
        }
    }
}
