using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private float waitTime;
	[SerializeField] private GameObject[] obstaclePrefabs; // hard prefab in slot 1 | easy prefab in slot 0
	private float tempTime;
	private int currentIndex;
	private static readonly int[] difficultConfigs = new int[5]
	{
		0, 0, 0, 1, 1,
	};

	void Start(){
		tempTime = waitTime - Time.deltaTime;
	}

	void LateUpdate () {
		if(GameManager.Instance.GameState()){
			tempTime += Time.deltaTime;
			if(tempTime > waitTime){
				// Wait for some time, create an obstacle, then set wait time to 0 and start again
				tempTime = 0;
				GameObject o = obstaclePrefabs[difficultConfigs[currentIndex]];
				GameObject pipeClone = Instantiate(o, transform.position, transform.rotation);
				
				// reset
				currentIndex++;
				if (currentIndex >= difficultConfigs.Length)
				{
					currentIndex = 0;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.transform.parent != null){
			Destroy(col.gameObject.transform.parent.gameObject);
		}else{
			Destroy(col.gameObject);
		}
	}

}
