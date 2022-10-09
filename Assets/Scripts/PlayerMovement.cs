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
    private Coroutine _jumping;
    private Coroutine _gettingShieldBonus;
    private Rigidbody _rigidbody;
    private bool _isJumping=false;
    private bool _isSideJump=false;
    private bool _onGround=true;
    private float _startJumpForce;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private void Start()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        _startJumpForce = _jumpForce;
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
            _player.GetChangingPosition(transform);
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
            _player.GetChangingPosition(transform);
        }
        
        if (Input.GetKey(KeyCode.UpArrow)&&_onGround&&Time.timeScale>0.1f)
        {
            Jump();
        }

    }

    private void Jump()
    {
        if (_jumping==null)
        {
            _jumping= StartCoroutine(Jumping());
        }
    }

    private IEnumerator Jumping()
    {
        if (_isSideJump)
        {
            _player.SideFlip();
        }
        else
        {
            if (_jumpForce < _bonusJumpForce)
            {
                _player.ChampionFlip();
            }
            else
            {
                _player.BonusFlip();
            }
        }

        Vector3 destination = transform.position + Vector3.up * _jumpForce+Vector3.forward*_jumpForce;
        _onGround = false;
        _rigidbody.isKinematic = true;
        while (transform.position.z<destination.z)
        {
            transform.position = Vector3.MoveTowards(transform.position,destination,_upSpeed*Time.deltaTime);
            yield return null;
        }
        _rigidbody.isKinematic = false;
        _jumping = null;
    }

    public void SetJumpForce(float time)
    {
        StartCoroutine(JumpForcing(time));
    }

    private IEnumerator JumpForcing(float time)
    {
        _upSpeed *= 3;
        yield return new WaitForSeconds(time);
        _upSpeed /= 3;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle)|| other.TryGetComponent(out BigObstacles bigObstacles))
        {
            if (_isSideJump)
            {
                Jump();
            }
            else
            {
                _player.Fall();
                _speed = 0;

            }
        }
        if (other.TryGetComponent(out Diamond diamond))
        {
            diamond.gameObject.SetActive(false);
            _player.TakeDiamond(diamond.CrystalsCount);
        }
        if (other.TryGetComponent(out Finish finish))
        {
            _player.FinishGame();
        }  
        if (other.TryGetComponent(out HourGlassBonus hourGlass))
        {
            hourGlass.StartHourGlass(_player);
        }
        if (other.TryGetComponent(out ShieldJumpBonus sideJumpBonus))
        {
            if (_gettingShieldBonus==null)
            {
                _gettingShieldBonus=StartCoroutine(GetSideJumpBonus(sideJumpBonus.LifeTime));
            }
            sideJumpBonus.gameObject.SetActive(false);
        }
        
        if (other.TryGetComponent(out Hint hint))
        {
            hint.StartHint();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _player.Fall();
            _speed = 0;
        }
        
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            _onGround = true;
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

    private IEnumerator GetJumpBonus(float bonusLifeTime)
    {
        _player.GetJumpBonus();
        _jumpForce = _bonusJumpForce;
        yield return new WaitForSeconds(bonusLifeTime);
        _jumpForce = _startJumpForce;
    }
    
    private IEnumerator GetSideJumpBonus(float bonusLifeTime)
    {
        _player.GetShieldJumpBonus();
        _isSideJump = true;
        yield return new WaitForSeconds(bonusLifeTime);
        _isSideJump = false;
    }
}
