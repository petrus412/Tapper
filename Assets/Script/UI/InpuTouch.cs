using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class InpuTouch : MonoBehaviour
{
    int id;
    float Timer;
    bool Start;
    public UnityEvent Fire, Versare,Fail;
    public UnityEvent<int> Move;
    public UnityEvent<Vector3> Dir;
    int LaneId=-1;
    Vector2 StartPosition;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            foreach (Touch i in Input.touches)
            {
                if (i.position.x > Screen.width / 2 && i.phase==TouchPhase.Began&&!Start)
                {                
                    StartTimer();
                    id = i.fingerId;
                }
                else if(i.position.x < Screen.width / 2 && i.phase == TouchPhase.Began)
                {
                    StartPosition = i.position;
                    print(StartPosition);
                    LaneId = i.fingerId;
                }
                if( i.fingerId==LaneId&&Mathf.Abs((i.position - StartPosition).x)>30)
                {
                    Vector3 Direction = new Vector3(((i.position - StartPosition).x), 0, 0);
                    Dir?.Invoke(Direction.normalized);
                }
                if(Start&&i.phase==TouchPhase.Ended&&id==i.fingerId)
                {
                    EndTimer();
                }
                else if(i.phase==TouchPhase.Ended&&LaneId==i.fingerId)
                {
                    if(i.position.y>StartPosition.y&& Mathf.Abs(i.position.y - StartPosition.y)>300)
                    {
                        Move?.Invoke(1);
                    }
                    else
                    {
                       Move?.Invoke(-1);
                    }
                }
                if(i.fingerId == LaneId&&i.phase==TouchPhase.Ended)
                {
                    LaneId = -1;
                }
            }
        }
        
        if(Start)
        {
            Timer += Time.deltaTime;
        }
   
    }
    private void StartTimer()
    {
        Versare?.Invoke();
        Start = true;
    }
    private void EndTimer()
    {
        Start = false;
        if(Timer>=0.3f)
        {
            Fire?.Invoke();
        }
        else
        {
            Fail?.Invoke();
        }
        Timer = 0;
    }
}
