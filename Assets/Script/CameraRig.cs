using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public GameObject Character;
    public Camera obj;
   // public float speed = 5f;
    public Transform WaypointParent;
    private int Count = 0;
    private Transform PathPoints;
    private Vector3 from;
    private Vector3 to;

    void Start()
    {
        Instantiate(Character, transform.position, Quaternion.Euler(0,180,0));
        PathPoints = WaypointParent.GetChild(Count);
        for (int i = 0; i < WaypointParent.childCount; i++)
        {
            from = WaypointParent.GetChild(i).position;
            int increment = (i + 1) % WaypointParent.childCount;
            to = WaypointParent.GetChild(increment).position;
            /*Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);*/
        }
    }
    private void OnDrawGizmos()
    {
        /*for (int i = 0; i < WaypointParent.childCount; i ++)
        {
             from = WaypointParent.GetChild(i).position;
             int increment = (i + 1) % WaypointParent.childCount;
             to = WaypointParent.GetChild(increment).position;
           
        }*/
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawLine(from, to);
    }

    void Update()
    { 
        cameraLerp();
    }

    void cameraLerp()
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position,PathPoints.transform.position,0.5f*Time.deltaTime);
        var distance = Vector3.Distance(obj.transform.position,PathPoints.transform.position);
        if(distance < 0.1f)
        {
            Count++;
            Count = Count % WaypointParent.childCount;
            PathPoints = WaypointParent.GetChild(Count);
        }

    }

   /* void ModelRotate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isrot = !isrot;
        }
        DollyCamera(isrot);
       
    }
    void DollyCamera(bool rot)
    {
       
        if (rot)
        {
            int number = Random.Range(0,Camerapos.Length);
            Transform pos = Camerapos[number];
            obj.transform.position = Vector3.Lerp(obj.transform.position,pos.position,speed *Time.deltaTime);
            obj.fieldOfView = 30f;
           
        }
        else
        {
            Vector3 pos = new Vector3(0,1,-2);
            obj.transform.position = Vector3.Lerp(obj.transform.position, pos, speed * Time.deltaTime);
            obj.fieldOfView = 60f;
        }

    }
    void increment()
    {
        for (int i = 0; i < Camerapos.Length; i ++)
        {
            OriginalPos = Camerapos[i].position;
            move = true;

        }
    }
    void movetimer()
    {
        if (move)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, OriginalPos, 0.2f * Time.deltaTime);
        }
    }
    void Timerusing()
    {
        timer += Time.deltaTime;
         float ti = Mathf.Round(timer);
         int nu = Random.Range(0,Camerapos.Length);

         if (time < timer )
         {
             int numbe = Random.Range(0, Camerapos.Length);
             Transform posi = Camerapos[numbe];
             if (obj.transform.position != Camerapos[numbe].position)
             {
                 obj.transform.position = Vector3.Lerp(obj.transform.position, posi.position, 0.2f * Time.deltaTime);
                 obj.transform.position = Vector3.Lerp(obj.transform.position, Camerapos[0].position, 0.2f * Time.deltaTime);
                 if (obj.transform.position == Camerapos[0].position)
                 {
                     obj.transform.position = Vector3.Lerp(obj.transform.position, Camerapos[1].position, 0.2f * Time.deltaTime);
                 }
             }



         }

        if (time < timer)
        {
           

            for (int i = 0; i < listpos.Length; i ++ )
            {
                GameObject name = listpos[i];
                obj.transform.position = Vector3.Lerp(obj.transform.position, name.transform.position, 0.2f * Time.deltaTime);
            }

        }

          for ( int i = 0; i < Camerapos.Length; i ++)
           {
           current = parent.transform.childCount;

           Vector3 j = Camerapos[i].position ;

               obj.transform.position = Vector3.Lerp(obj.transform.position, j, 0.2f * Time.deltaTime);

           }

       if (Camerapos.Length > current)
           current++;
       current = (current + 1) % Camerapos.Length;
       if (current > Camerapos.Length)
           current = 0;
        



         time = 0.01f;
    }
    void Pathfinding()
    {
       // timer += Time.deltaTime;
        if (transform.position != Camerapos[current].position)
        {
            Vector3 positioN = Vector3.Lerp(transform.position, Camerapos[current].position, 0.2f * Time.deltaTime);
            obj.GetComponent<Rigidbody>().MovePosition(positioN);


        }
        else
        {
            current = (current + 1) % Camerapos.Length;
        }
    }*/
}
