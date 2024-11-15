using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerSphere;
    [SerializeField] private GameObject _gates;
    private bool _isGatesOpen = false; 
    public void FinishLevel()
    {
        Rigidbody rb = _playerSphere.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(
            transform.position.x, 
            transform.position.y + 250,
            transform.position.z + 200
            ));
    }

    public void FixedUpdate()
    {
        if(!_isGatesOpen)
        {
            if (Vector3.Distance(_gates.transform.position, _playerSphere.transform.position) < 5)
            {
                _isGatesOpen = true;
                GatesControlller gatesControlller = _gates.GetComponent<GatesControlller>();
                gatesControlller.OpenGates();
            }
        }
        
    }
}
