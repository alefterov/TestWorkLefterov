using System.Collections;
using UnityEngine;

public class GatesControlller : MonoBehaviour
{
    [SerializeField] private GameObject _leftGate;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerStrikeBall")
        {
            Destroy(other.gameObject);
        }
    }

    public void OpenGates()
    {
        StartCoroutine(OpenGatesCoroutine());
    }
    IEnumerator OpenGatesCoroutine()
    {
        yield return new WaitForSeconds(0.05f);
        if(_leftGate.transform.position.x <= 1)
        {
            _leftGate.transform.position = new Vector3(
                    _leftGate.transform.position.x + 0.05f,
                    _leftGate.transform.position.y,
                    _leftGate.transform.position.z
                );
            StartCoroutine(OpenGatesCoroutine());
        }
    }
}
