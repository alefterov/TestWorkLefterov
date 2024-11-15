using UnityEngine;

public class MainAreaController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ExplosionPart")
        {
            Destroy(collision.gameObject);
        }
    }
}
