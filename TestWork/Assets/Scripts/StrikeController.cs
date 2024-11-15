using System.Collections;
using UnityEngine;

public class StrikeController : MonoBehaviour
{
    [SerializeField] private GameObject _strikeBallPrefab;
    [SerializeField] private GameObject _strikeSpown;
    [SerializeField] private GameObject _playerWay;
    [SerializeField] private GameObject _gameController;
    [SerializeField] private float _strikePower;

    private GameObject _strikeBall;
    private GameObject _strikeTarget;
    GameController gameController;
    PlayerWayController playerWayController;
    private float _minDistance;
    private float _targetCountIndex;
    private bool _isFirstStrike = true;
    PlayerController playerController;
    public void Awake()
    {
        playerController = GetComponent<PlayerController>();
        gameController = _gameController.GetComponent<GameController>();
        playerWayController = _playerWay.GetComponent<PlayerWayController>();
    }

    public void GrowStrike()
    {
        if (_isFirstStrike)
        {
            _targetCountIndex = playerWayController.TargetList.Count;
            _isFirstStrike = false;
        }

        if (playerWayController.TargetList.Count > 0)
        {
            _strikeBall = Instantiate(_strikeBallPrefab, _strikeSpown.transform.position, Quaternion.identity);

            StartCoroutine(GrowStrikeBall(_strikeBall));
        }
    }
    public void Strike()
    {
        if (playerWayController.TargetList.Count > 0)
        {
            _minDistance = Vector3.Distance(transform.position, new Vector3(0, 0, 1000));

            foreach (GameObject target in playerWayController.TargetList)
            {
                if (target != null)
                {
                    if (Vector3.Distance(transform.position, target.transform.position) < _minDistance)
                    {
                        _minDistance = Vector3.Distance(transform.position, target.transform.position);
                        _strikeTarget = target;
                    }
                }
            }

            StopAllCoroutines();
            transform.localScale = new Vector3(
               transform.localScale.x - 0.1f / _targetCountIndex * 0.8f,
               transform.localScale.y - 0.1f / _targetCountIndex * 0.8f,
               transform.localScale.z - 0.1f / _targetCountIndex * 0.8f
               );
            if(_strikeTarget != null)
            {
                Vector3 strikeVector = new Vector3(
                (_strikeTarget.transform.position.x - _strikeSpown.transform.position.x) * _strikePower,
                _strikeTarget.transform.position.y,
                (_strikeTarget.transform.position.z - _strikeSpown.transform.position.z) * _strikePower
                );
                _strikeBall.GetComponent<Rigidbody>().AddForce(strikeVector);
                playerWayController.ChecTargetkList(_strikeTarget);
                if (playerWayController.TargetList.Count == 0)
                {
                    playerController.FinishLevel();
                }
            }
            
           
        }
    }
    IEnumerator GrowStrikeBall(GameObject strikeBall)
    {
        yield return new WaitForSeconds(0.04f);
        strikeBall.transform.localScale = new Vector3(
           strikeBall.transform.localScale.x + 0.01f,
           strikeBall.transform.localScale.y + 0.01f,
           strikeBall.transform.localScale.z + 0.01f
           );
        transform.localScale = new Vector3(
            transform.localScale.x - 0.1f / _targetCountIndex * 0.8f,
            transform.localScale.y - 0.1f / _targetCountIndex * 0.8f,
            transform.localScale.z - 0.1f / _targetCountIndex * 0.8f
            );
        _playerWay.transform.localScale = new Vector3(
            transform.localScale.x - 0.008f,
            0.1f,
            16
            );
        if (transform.localScale.x <= 0.2f)
        {
            StopAllCoroutines();
            gameController.GameOver();
        }
        else
        {
            StartCoroutine(GrowStrikeBall(strikeBall));
        }

    }
}
