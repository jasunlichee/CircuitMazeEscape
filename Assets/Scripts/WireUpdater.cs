using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireUpdater : MonoBehaviour
{
    public GameObject WireArray;
    public Material lit;
    public Material unlit;
    public Material darkLight;
    public Material lightLight;
    public GameObject door;
    public AudioSource doorOpen;
    private int counter;
    private bool isOpen;

    void Start()
    {
        counter = 0;
        isOpen = false;
    }

    private void Update()
    {
        if (isAllLit())
        {
            openDoor();
        }
    }

    public void incrementCounter()
    {
        counter++;
    }

    public int getCounter()
    {
        return counter;
    }

    void updateTop(GameObject square)
    {
        int index = square.GetComponent<CubeFunction>().index;

        if (square.GetComponent<CubeFunction>().left == true && !onLeftEdge(index))
        {
            GameObject left = getSquare(index - 1);
            if (left.GetComponent<CubeFunction>().right && left.CompareTag("Unpower"))
            {
                lightUp(left);
                updateLeft(left);
            }
        }

        if (square.GetComponent<CubeFunction>().top == true && !onTopEdge(index))
        {
            GameObject top = getSquare(index + 5);
            if (top.GetComponent<CubeFunction>().bottom && top.CompareTag("Unpower"))
            {
                lightUp(top);
                updateTop(top);
            }
        }

        if (square.GetComponent<CubeFunction>().right == true && !onRightEdge(index))
        {
            GameObject right = getSquare(index + 1);
            if (right.GetComponent<CubeFunction>().left && right.CompareTag("Unpower"))
            {
                lightUp(right);
                updateRight(right);
            }
        }
    }

    void updateLeft(GameObject square)
    {
        int index = square.GetComponent<CubeFunction>().index;
        if (square.GetComponent<CubeFunction>().left == true && !onLeftEdge(index))
        {
            GameObject left = getSquare(index - 1);
            if (left.GetComponent<CubeFunction>().right && left.CompareTag("Unpower"))
            {
                lightUp(left);
                updateLeft(left);
            }
        }

        if (square.GetComponent<CubeFunction>().top == true && !onTopEdge(index))
        {
            GameObject top = getSquare(index + 5);
            if (top.GetComponent<CubeFunction>().bottom && top.CompareTag("Unpower"))
            {
                lightUp(top);
                updateTop(top);
            }
        }

        if (square.GetComponent<CubeFunction>().bottom == true && !onBottomEdge(index))
        {
            GameObject bottom = getSquare(index - 5);
            if (bottom.GetComponent<CubeFunction>().top && bottom.CompareTag("Unpower"))
            {
                lightUp(bottom);
                updateBottom(bottom);
            }
        }

    }

    void updateRight(GameObject square)
    {
        int index = square.GetComponent<CubeFunction>().index;

        if (square.GetComponent<CubeFunction>().top == true && !onTopEdge(index))
        {
            GameObject top = getSquare(index + 5);
            if (top.GetComponent<CubeFunction>().bottom && top.CompareTag("Unpower"))
            {
                lightUp(top);
                updateTop(top);
            }
        }

        if (square.GetComponent<CubeFunction>().bottom == true && !onBottomEdge(index))
        {
            GameObject bottom = getSquare(index - 5);
            if (bottom.GetComponent<CubeFunction>().top && bottom.CompareTag("Unpower"))
            {
                lightUp(bottom);
                updateBottom(bottom);
            }
        }

        if (square.GetComponent<CubeFunction>().right == true && !onRightEdge(index))
        {
            GameObject right = getSquare(index + 1);
            if (right.GetComponent<CubeFunction>().left && right.CompareTag("Unpower"))
            {
                lightUp(right);
                updateRight(right);
            }
        }
    }

    void updateBottom(GameObject square)
    {
        int index = square.GetComponent<CubeFunction>().index;

        if (square.GetComponent<CubeFunction>().bottom == true && !onBottomEdge(index))
        {
            GameObject bottom = getSquare(index - 5);
            if (bottom.GetComponent<CubeFunction>().top && bottom.CompareTag("Unpower"))
            {
                lightUp(bottom);
                updateBottom(bottom);
            }
        }

        if (square.GetComponent<CubeFunction>().right == true && !onRightEdge(index))
        {
            GameObject right = getSquare(index + 1);
            if (right.GetComponent<CubeFunction>().left && right.CompareTag("Unpower"))
            {
                lightUp(right);
                updateRight(right);
            }
        }

        if (square.GetComponent<CubeFunction>().left == true && !onLeftEdge(index))
        {
            GameObject left = getSquare(index - 1);
            if (left.GetComponent<CubeFunction>().right && left.CompareTag("Unpower"))
            {
                lightUp(left);
                updateLeft(left);
            }
        }
    }

    public void updateEverything()
    {
        foreach (Transform square in WireArray.transform)
        {
            if (square.gameObject.layer != 6)
            {
                darkenDown(square.gameObject);
            }
        }

        GameObject battery = getSquare(13);
        if (battery.GetComponent<CubeFunction>().left)
        {
            GameObject left = getSquare(12);
            if (left.GetComponent<CubeFunction>().right)
            {
                lightUp(left);
                updateLeft(left);
            }
        }

        if (battery.GetComponent<CubeFunction>().right)
        {
            GameObject right = getSquare(14);
            if (right.GetComponent<CubeFunction>().left)
            {
                lightUp(right);
                updateRight(right);
            }
        }

        if (battery.GetComponent<CubeFunction>().top)
        {
            GameObject top = getSquare(18);
            if (top.GetComponent<CubeFunction>().bottom)
            {
                lightUp(top);
                updateTop(top);
            }
        }

        if (battery.GetComponent<CubeFunction>().bottom)
        {
            GameObject bottom = getSquare(8);
            if (bottom.GetComponent<CubeFunction>().top)
            {
                lightUp(bottom);
                updateBottom(bottom);
            }
        }



    }




    GameObject getSquare(int target)
    {
        int i = 1;
        GameObject hold = WireArray.gameObject;
        foreach (Transform square in WireArray.transform)
        {
            hold = square.gameObject;
            if (i == target)
            {
                return square.gameObject;
            }
            i++;
        }

        return hold;
    }

    private bool onLeftEdge(int a)
    {
        if (a == 1 || a == 6 || a == 11 || a == 16 || a == 21)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool onTopEdge(int a)
    {
        if (a == 21 || a == 22 || a == 23 || a == 24 || a == 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool onRightEdge(int a)
    {
        if (a == 5 || a == 10 || a == 15 || a == 20 || a == 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool onBottomEdge(int a)
    {
        if (a == 1 || a == 2 || a == 3 || a == 4 || a == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void lightUp(GameObject square)
    {
        square.tag = "Power";
        foreach (Transform obj in square.transform)
        {
            if (obj.gameObject.layer == 7)
            {
                obj.GetComponent<MeshRenderer>().material = lit;
                obj.tag = "Power";
            }

            if (obj.gameObject.layer == 8)
            {
                obj.GetComponent<MeshRenderer>().material = lightLight;
                obj.tag = "Power";
            }



        }
    }

    private void darkenDown(GameObject square)
    {
        square.tag = "Unpower";
        foreach (Transform obj in square.transform)
        {
            if (obj.gameObject.layer == 7)
            {
                obj.GetComponent<MeshRenderer>().material = unlit;
                obj.tag = "Unpower";
            }

            if (obj.gameObject.layer == 8)
            {
                obj.GetComponent<MeshRenderer>().material = darkLight;
                obj.tag = "Unpower";
            }
        }
    }

    private bool isAllLit()
    {
        foreach (Transform square in WireArray.transform)
        {
            if(square.gameObject.tag != "Power")
            {
                playSound();
                return false;
            }
        }

        return true;
    }

    private void playSound()
    {
        if(isOpen == false)
        {
            isOpen = true;
            doorOpen.Play();
        }
        
    }


    private void openDoor()
    {
        door.SetActive(false);
    }
}
