using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedSearchAndDestroy : MonoBehaviour {
	private NavMeshAgent agent;
	private Vector3 player;
	private UnityEngine.GameObject manager;
	
	void Start() {
		agent = GetComponent<NavMeshAgent>();
        manager = UnityEngine.GameObject.Find("Game Controller");
	}

	void Update() {
		player = FindClosestPlayer().transform.position;
		agent.destination = player;
	}

    UnityEngine.GameObject FindClosestPlayer() {
        // Find all game objects tagged as Player
        UnityEngine.GameObject[] targets;
		targets = UnityEngine.GameObject.FindGameObjectsWithTag("Player");
        UnityEngine.GameObject closestPlayer = null;
		var distance = Mathf.Infinity;
		Vector3 position = transform.position;

		// Iterate through them and find the closest one
		foreach(UnityEngine.GameObject target in targets)  {
			var difference = (target.transform.position - position);
		var curDistance = difference.sqrMagnitude;
			if(curDistance < distance) {
				closestPlayer = target;
				distance = curDistance;
			}
		}

		return closestPlayer;
	}
}