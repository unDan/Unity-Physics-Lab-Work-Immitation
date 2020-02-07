using UnityEngine;
using UnityEngine.UI;

public class ChangeBody : MonoBehaviour
{
    public GameObject[] body; //скатываемое тело
    public Toggle[] toggle; //переключатель тела
    public GameObject GUIPanel; //панель полизовательского интерфейса

    const int CYLINDER = 0;
    const int EMPTY_CYLINDER = 1;
    const int BRICK_METAL = 2;
    const int BRICK_WOODEN = 3;

    public void ChangeToCylinder()
    {
        for(int i=0; i<body.Length; ++i)
        {
            if(body[i].activeInHierarchy)
            {
                body[i].SetActive(false);
                toggle[i].interactable = true;
            }
        }
        body[CYLINDER].SetActive(true);
        toggle[CYLINDER].interactable = false;
        GUIPanel.GetComponent<GUI>().body = body[CYLINDER];
    }

    public void ChangeToEmptyCylinder()
    { 
        for (int i = 0; i < body.Length; ++i)
        {
            if (body[i].activeInHierarchy)
            {
                body[i].SetActive(false);
                toggle[i].interactable = true;
            }        
        }
        body[EMPTY_CYLINDER].SetActive(true);
        toggle[EMPTY_CYLINDER].interactable = false;
        GUIPanel.GetComponent<GUI>().body = body[EMPTY_CYLINDER];
    }

    public void ChangeToWoodenBrick()
    {
        for (int i = 0; i < body.Length; ++i)
        {
            if (body[i].activeInHierarchy)
            {
                body[i].SetActive(false);
                toggle[i].interactable = true;
            }
        }
        body[BRICK_WOODEN].SetActive(true);
        toggle[BRICK_WOODEN].interactable = false;
        GUIPanel.GetComponent<GUI>().body = body[BRICK_WOODEN];

        Global.getInstance.brick_friction_koefficient = Global.getInstance.wood_wood_friction_koefficient;
        body[BRICK_WOODEN].GetComponent<Body>().updatePatameters();
    }

    public void ChangeToMetalBrick()
    {
        for (int i = 0; i < body.Length; ++i)
        {
            if (body[i].activeInHierarchy)
            {
                body[i].SetActive(false);
                toggle[i].interactable = true;
            }         
        }
        body[BRICK_METAL].SetActive(true);
        toggle[BRICK_METAL].interactable = false;
        GUIPanel.GetComponent<GUI>().body = body[BRICK_METAL];

        Global.getInstance.brick_friction_koefficient = Global.getInstance.metal_wood_friction_koefficient;
        body[BRICK_METAL].GetComponent<Body>().updatePatameters();
    }
}
