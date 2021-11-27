using UnityEngine;

public class ResurcesManager : MonoBehaviour
{

    private static ResurcesManager Singleton;

    [SerializeField, Range(2, 100)]
    private uint StakSize;
    private  ObjectPool BoccalePool;
    // Start is called before the first frame update
    void Start()
    {
        if (!Singleton) Singleton = this;

        if (BoccalePool==null)
        {
            BoccalePool = new ObjectPool(StakSize, "Stein", "Client");
        }

        DontDestroyOnLoad(Singleton);
    }

    public static GameObject Get(int Type)
    {
        return Singleton.BoccalePool.Get(Type);
    }
}
