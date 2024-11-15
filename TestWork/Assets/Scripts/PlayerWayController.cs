using System.Collections.Generic;
using UnityEngine;

public class PlayerWayController : MonoBehaviour
{   
    private List<GameObject> _targetList = new List<GameObject>();
    public List<GameObject> TargetList { get { return _targetList; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            other.gameObject.tag = "TargetEnemy";
            _targetList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TargetEnemy")
        {   
            _targetList.Remove(other.gameObject);
        }
    }
    public void ChecTargetkList(GameObject target)
    {
        _targetList.Remove(target);
    }
}
