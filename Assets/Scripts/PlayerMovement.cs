using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _upSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _bonusJumpForce;
    [SerializeField] private float _bonusJumpTime;
    [SerializeField] private Line _leftLine;
    [SerializeField] private Line _centralLine;
    [SerializeField] private Line _rightLine;

    private Player _player;
    private Coroutine _movingToLine;
    private Rigidbody _rigidbody;
    private bool _isJumping=false;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward*_speed*Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x>_rightLine.transform.position.x&& transform.position.x >_centralLine .transform.position.x)
            {
                MoveToLine(_centralLine.transform);
            }
            else
            {
                MoveToLine(_rightLine.transform);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x<_leftLine.transform.position.x&& transform.position.x <_centralLine .transform.position.x)
            {
                MoveToLine(_centralLine.transform);
            }
            else
            {
                MoveToLine(_leftLine.transform);
            }
        }
        
        if (Input.GetKey(KeyCode.UpArrow)&&_isJumping==false)
        {
            Jump();
        }

    }

    private void Jump()
    {
        StartCoroutine(Jumping());
    }

    private IEnumerator Jumping()
    {
        if (_jumpForce<_bonusJumpForce)
        {
            _player.ChampionFlip();
        }
        else
        {
            _player.BonusFlip();
        }
        Vector3 destination = transform.position + Vector3.up * _jumpForce+Vector3.forward*_jumpForce;
        _isJumping = true;
        _rigidbody.isKinematic = true;
        while (transform.position.z<destination.z)
        {
            transform.position = Vector3.MoveTowards(transform.position,destination,_upSpeed*Time.deltaTime);
            yield return null;
        }
        _rigidbody.isKinematic = false;
        _isJumping = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _player.Fall();
        }
        if (other.TryGetComponent(out BigObstacles bigObstacles))
        {
            _player.Fall();
        }
        if (other.TryGetComponent(out Diamond diamond))
        {
            diamond.gameObject.SetActive(false);
            _player.TakeDiamond(diamond.Points);
        }
        if (other.TryGetComponent(out Finish finish))
        {
            _player.FinishGame();
        }
        if (other.TryGetComponent(out BonusJump bonusJump))
        {
            StartCoroutine(GettingJumpBonus());
            bonusJump.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _player.Fall();
        }
    }

    private void MoveToLine(Transform line)
    {
        if (_movingToLine!=null)
        {
            StopCoroutine(_movingToLine);
            _movingToLine = StartCoroutine(MovingToLine(line));

        }
        else
        {
            _movingToLine = StartCoroutine(MovingToLine(line));
        }
    }

    private IEnumerator MovingToLine(Transform line)
    {
        while (transform.position.x!=line.position.x)
        {
            Vector3 newPosition = new Vector3(line.position.x,transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position,newPosition,_sideSpeed*Time.deltaTime);
            transform.LookAt(newPosition+Vector3.forward);
            yield return null;
        }
        transform.LookAt(transform.position+Vector3.forward);
    }

    private IEnumerator GettingJumpBonus()
    {
        _player.GetJumpBonus();
        float startForce = _jumpForce;
        _jumpForce=_bonusJumpForce;
        Debug.Log(_jumpForce);
        yield return new WaitForSeconds(_bonusJumpTime);
        _jumpForce=startForce;
        Debug.Log(_jumpForce);
    }
}
