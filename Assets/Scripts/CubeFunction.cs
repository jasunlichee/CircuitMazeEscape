using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFunction : MonoBehaviour
{

    public GameObject cube;
    public int index;
    public GameObject updater;
    public AudioSource click;

    public bool left = false;
    public bool right = false;
    public bool top = false;
    public bool bottom = false;
    private int angle = 0;

    public int type; //0 = lightbulb, 1 = straight, 2 = T, 3 = corner


    [SerializeField] private Vector3 rotation;

    Quaternion target = Quaternion.Euler(0, 90, 0);

    Quaternion current = Quaternion.Euler(-90, 0, 90);


    private void Start()
    {
        left = false;
        right = false;
        top = false;
        bottom = false;
        angle = 0;
        updateBools(type);

        GameObject parent = this.transform.parent.gameObject;


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == cube)
                {
                    click.Play();
                    current *= target;
                    if (angle == 270)
                    {
                        angle = 0;
                    }
                    else
                    {
                        angle += 90;
                    }
                    updateBools(type);
                    updater.GetComponent<WireUpdater>().updateEverything();
                    updater.GetComponent<WireUpdater>().incrementCounter();
                }
            }

        }

        cube.transform.rotation = Quaternion.Slerp(cube.transform.rotation, current, 0.1f);
    }

    public void updateBools(int a)
    {
        if (a == 0)
        {
            updateLight();
        }
        else if (a == 1)
        {
            updateStraight();
        }
        else if (a == 2)
        {
            updateT();
        }
        else if (a == 3)
        {
            updateCorner();
        }
    }

    private void updateLight()
    {
        if (angle == 0)
        {
            top = false;
            bottom = true;
            left = false;
            right = false;
        }
        else if (angle == 90)
        {
            top = false;
            bottom = false;
            left = true;
            right = false;
        }
        else if (angle == 180)
        {
            top = true;
            bottom = false;
            left = false;
            right = false;
        }
        else if (angle == 270)
        {
            top = false;
            bottom = false;
            left = false;
            right = true;
        }
    }

    private void updateStraight()
    {
        if (angle == 0)
        {
            top = true;
            bottom = true;
            left = false;
            right = false;
        }
        else if (angle == 90)
        {
            top = false;
            bottom = false;
            left = true;
            right = true;
        }
        else if (angle == 180)
        {
            top = true;
            bottom = true;
            left = false;
            right = false;
        }
        else if (angle == 270)
        {
            top = false;
            bottom = false;
            left = true;
            right = true;
        }
    }

    private void updateT()
    {
        if (angle == 0)
        {
            top = false;
            bottom = true;
            left = true;
            right = true;
        }
        else if (angle == 90)
        {
            top = true;
            bottom = true;
            left = true;
            right = false;
        }
        else if (angle == 180)
        {
            top = true;
            bottom = false;
            left = true;
            right = true;
        }
        else if (angle == 270)
        {
            top = true;
            bottom = true;
            left = false;
            right = true;
        }
    }

    private void updateCorner()
    {
        if (angle == 0)
        {
            top = false;
            bottom = true;
            left = true;
            right = false;
        }
        else if (angle == 90)
        {
            top = true;
            bottom = false;
            left = true;
            right = false;
        }
        else if (angle == 180)
        {
            top = true;
            bottom = false;
            left = false;
            right = true;
        }
        else if (angle == 270)
        {
            top = false;
            bottom = true;
            left = false;
            right = true;
        }
    }

}
