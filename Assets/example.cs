using UnityEngine;
using System.Collections;

public class example : MonoBehaviour
{
	public float updateInterval = 0.5F;
	private double lastInterval;
	private int frames = 0;
	private float fps;
	void Start()
	{
		Application.targetFrameRate = 2;
		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
	}
	void OnGUI()
	{
		GUILayout.Label(" " + fps.ToString("f6"));
	}
	void Update()
	{
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval)
		{
			fps = (float)(frames / (timeNow - lastInterval));
			frames = 0;
			lastInterval = timeNow;
		}
	}
}