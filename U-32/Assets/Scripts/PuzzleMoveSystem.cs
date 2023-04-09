using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoveSystem : MonoBehaviour
{
    public GameObject correctPos;
    private bool moving;
    private bool finish;

    private Vector3 resetPos;


    void Start()
    {
        resetPos = this.transform.localPosition;
    }

    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, this.gameObject.transform.localPosition.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
        }
    }



    private void OnMouseUp()
    {
        moving = false;

        if (Vector3.Distance(this.transform.position, correctPos.transform.position) <= 0.5f)
        {
            this.transform.position = new Vector3(correctPos.transform.position.x, correctPos.transform.position.y, correctPos.transform.position.z);
            finish = true;
            PuzzleWin.instance.AddPoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);
        }
    }




}
