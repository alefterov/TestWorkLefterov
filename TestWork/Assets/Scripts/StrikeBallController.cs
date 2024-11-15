using UnityEngine;

public class StrikeBallController : MonoBehaviour
{
    [SerializeField] private GameObject _forseAreaPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TargetEnemy")
        {
            GameObject forseArea = Instantiate(_forseAreaPrefab, transform.position, Quaternion.identity);
            forseArea.transform.localScale = transform.localScale * 3;
            Destroy(gameObject);
        }
    }
}
