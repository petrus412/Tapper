using UnityEngine.Events;
using UnityEngine;

public class ResurcesManager : MonoBehaviour
{

    private static ResurcesManager Singleton;

    [SerializeField, Range(2, 100)]
    private uint StakSize;
    private  ObjectPool ObjectsPool;
    public UnityEvent NewScore;
    int Points;
    // Start is called before the first frame update
    void Awake()
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
    public static void IncrementPoints(int Value)
    {
        Singleton.Points += Value;
        Singleton.NewScore?.Invoke();
    }
    public static UnityEvent GetEvent()
    {
        return Singleton.NewScore;
    }
    public static int GetPoints()
    {
        return Singleton.Points;
    }
}
