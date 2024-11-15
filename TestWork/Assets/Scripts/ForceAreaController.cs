using System.Collections;
using UnityEngine;

public class ForceAreaController : MonoBehaviour
{   
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "TargetEnemy")
        {
            EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();
            enemyController.TakeDamage();
            _particleSystem.transform.localScale = transform.localScale;
            ParticleSystem particleSystem = _particleSystem.GetComponent<ParticleSystem>();
            var main = particleSystem.main;
            main.startSizeX = _particleSystem.transform.localScale.x * 3;
            main.startSizeY = _particleSystem.transform.localScale.x * 3;
            main.startSizeZ = _particleSystem.transform.localScale.x * 3;
            _particleSystem.Play();
            
        }
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
