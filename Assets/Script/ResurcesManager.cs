using UnityEngine;

public class ResurcesManager : MonoBehaviour
{

    private static ResurcesManager Singleton;

    [SerializeField, Range(2, 100)]
    private uint StakSize;
    private  ObjectPool ObjectsPool;
    // Start is called before the first frame update
    void Start()
    {
        if (!Singleton) Singleton = this;

        if (ObjectsPool == null)
        {
            ObjectsPool = new ObjectPool(StakSize, "Stein", "Client");
        }

        DontDestroyOnLoad(Singleton);
    }

    public static GameObject Get(int Type)
    {
        return Singleton.ObjectsPool.Get(Type);
    }
    public static bool ActiveClient()
    {
        return Singleton.ObjectsPool.AnyActiveClient();
    }
}
