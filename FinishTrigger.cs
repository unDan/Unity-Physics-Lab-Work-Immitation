using UnityEngine;


public class FinishTrigger : MonoBehaviour
{
    private string bodyName;
    
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Cylinder")
            bodyName = "Сплошной цилиндр";
        else if (other.tag == "EmptyCylinder")
            bodyName = "Полый цилиндр";
        else if (other.tag == "BrickMetal")
            bodyName = "Брусок (металл)";
        else if (other.tag == "BrickWooden")
            bodyName = "Брусок (дерево)";

        if (other.tag == "Cylinder" || other.tag == "EmptyCylinder" || other.tag == "BrickMetal" || other.tag == "BrickWooden")
        {
            Global.getInstance.inMove = false;
            GameObject.FindGameObjectWithTag("GUI").GetComponent<GUI>().inaccuracyAdding();
        }
    }

}
