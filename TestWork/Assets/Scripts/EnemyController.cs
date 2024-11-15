using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Material _damageMaterial;
    private float _partSize = 0.1f;
    public void TakeDamage()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = _damageMaterial;
        StartCoroutine(DestroyWithExplosionDelay());
    }

    private void CreateExplosionPart(int x, int y, int z)
    {
        GameObject explosionPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
        explosionPart.tag = "ExplosionPart";
        explosionPart.transform.localPosition = transform.localPosition + new Vector3(_partSize * x, _partSize * y, _partSize * z);
        explosionPart.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        MeshRenderer meshRenderer = explosionPart.GetComponent<MeshRenderer>();
        meshRenderer.material = _damageMaterial;
        explosionPart.AddComponent<Rigidbody>().mass = 0.1f;
        Rigidbody explosionPartRb = explosionPart.GetComponent<Rigidbody>();
        explosionPartRb.AddExplosionForce(30, transform.position, 1);
    }

    IEnumerator DestroyWithExplosionDelay()
    {
        
        yield return new WaitForSeconds(0.4f);
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    CreateExplosionPart(x, y, z);
                }
            }
        }
        Destroy(gameObject);
    }
}
