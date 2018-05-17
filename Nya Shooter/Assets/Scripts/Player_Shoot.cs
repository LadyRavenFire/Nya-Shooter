using UnityEngine;
using UnityEngine.Networking;

public class Player_Shoot : NetworkBehaviour
{

    //*WARNING* NOT HARDCORE CODE!!
    private const string PLAYER_TAG = "Player";
    //END OF BAD CODE!!

    public PlayerWeapon weapon;

    [SerializeField] private Camera cam;

    [SerializeField] private LayerMask mask;


    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No camera referenced");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    void CmdPlayerShot(string _playerID, int _damage) 
    {
        Debug.Log(_playerID + " has been shot.");
       // Destroy(GameObject.Find(_ID)); HAHALOL
        PlayerManager _player = GameManager.GetPlayer(_playerID);
        _player.TakeDamage(_damage);
    }

}
