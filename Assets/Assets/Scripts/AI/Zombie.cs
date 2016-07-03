using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    public Animator AniControl;
    private GameObject _player;
    private NavMeshAgent _Agent;
    private string animation = "StandingDown";
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.updateRotation = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        _Agent.SetDestination(_player.transform.position);

        if (Mathf.Abs(_Agent.velocity.x) > (Mathf.Abs(_Agent.velocity.z)))
        {
            if(_Agent.velocity.x < 0)
            {
                animation = "MovingLeft";
            }
            else
            {
                animation = "MovingRight";
            }
        }
        else
        {
            if (_Agent.velocity.z < 0)
            {
                animation = "MovingDown";
            }
            else
            {
                animation = "MovingUp";
            }
        }
        AniControl.Play(animation);
	}
}
