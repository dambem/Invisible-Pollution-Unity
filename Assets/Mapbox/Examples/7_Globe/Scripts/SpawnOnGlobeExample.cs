namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using Mapbox.Unity.MeshGeneration.Factories.TerrainStrategies;
	using Mapbox.Unity.Map;
    using System.Security.Cryptography.X509Certificates;
    using System.Runtime.InteropServices;
	using Leap.Unity;
	using Leap.Unity.Interaction;
    using System.Diagnostics;

    public class SpawnOnGlobeExample : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;
		public GameObject _objectToRotate;

		[SerializeField]
		[Geocode]

		
		GameObject instance1;
		GameObject instance2;
		GameObject instance3;

		float lat1 = 53.3825f;
		float lon1 = -1.47194f;
		float xPos1;
		float zPos1;
		float yPos1;
		float lat2;
		float lon2;
		float xPos2;
		float zPos2;
		float yPos2;
		float lat3;
		float lon3;
		float xPos3;
		float zPos3;
		float yPos3;
		string location1 = "53.3825, -1.47194";
		string location2 = "34.0544, -118.2439";
		string location3 = "28.66667, 77.21667";
		public GameObject buttons;
		public GameObject button1;
		public GameObject button2;
		public GameObject button3;

		public GameObject UIToHide;
		public GameObject UIToShow;

		public GameObject slider1;
		public GameObject slider2;
		public GameObject slider3;
		[SerializeField]
		float _spawnScale = 100f;
		public float speed = 0.01f;

		bool pressed1 = false;
		bool pressed2 = false;
		bool pressed3 = false;
		[SerializeField]
		GameObject _markerPrefab;


		void Start()
		{
			var earthRadius = ((IGlobeTerrainLayer)_map.Terrain).EarthRadius;

			float lat1 = 53.3825f;
			float lon1 = -1.47194f;
			float xPos1 = (100f) * Mathf.Cos(lat1) * Mathf.Cos(lon1);
			UnityEngine.Debug.Log(xPos1);
			float zPos1 = (100f) * Mathf.Cos(lat1) * Mathf.Sin(lon1);
			float yPos1 = (100f) * Mathf.Sin(lat1);
			float lat2 = 34.0544f;
			float lon2 = -118.2439f;
			float xPos2 = (100f) * Mathf.Cos(lat1) * Mathf.Cos(lon1);
			float zPos2 = (100f) * Mathf.Cos(lat1) * Mathf.Sin(lon1);
			float yPos2 = (100f) * Mathf.Sin(lat1);
			float lat3 = 28.66667f;
			float lon3 = 77.21667f;
			float xPos3 = (100f) * Mathf.Cos(lat1) * Mathf.Cos(lon1);
			float zPos3 = (100f) * Mathf.Cos(lat1) * Mathf.Sin(lon1);
			float yPos3 = (100f) * Mathf.Sin(lat1);
			instance1 = Instantiate(_markerPrefab);
			var location1L = Conversions.StringToLatLon(location1);
			instance1.transform.position = Conversions.GeoToWorldGlobePosition(location1L, earthRadius);
            instance1.transform.localScale = Vector3.one * _spawnScale;
            instance1.transform.SetParent(transform);

			instance2 = Instantiate(_markerPrefab);
			var location2L = Conversions.StringToLatLon(location2);
			instance2.transform.position = Conversions.GeoToWorldGlobePosition(location2L, earthRadius);
			instance2.transform.localScale = Vector3.one * _spawnScale;
			instance2.transform.SetParent(transform);

			instance3 = Instantiate(_markerPrefab);
			var location3L = Conversions.StringToLatLon(location3);
			instance3.transform.position = Conversions.GeoToWorldGlobePosition(location3L, earthRadius);
			instance3.transform.localScale = Vector3.one * _spawnScale;
			instance3.transform.SetParent(transform);


		}
		void makePress1()
		{
			pressed1 = true;
		}
		void makePress2()
		{
			pressed2 = true;
		}
		void makePress3()
		{
			pressed3 = true;
		}
		void Update()
        {
			var interactionBehaviour1 = button1.GetComponent<InteractionButton>();
			var interactionBehaviour2 = button2.GetComponent<InteractionButton>();
			var interactionBehaviour3 = button3.GetComponent<InteractionButton>();
			interactionBehaviour1.OnPress += makePress1;
			interactionBehaviour2.OnPress += makePress2;
			interactionBehaviour3.OnPress += makePress3;
			if (pressed1)
			{
				UIToHide.SetActive(false);
				UIToShow.SetActive(true);
				//buttons.SetActive(false);
				float singleStep = speed * Time.deltaTime;

				_objectToRotate.transform.Rotate(xPos1, yPos1, zPos1, Space.World);

				//slider1.SetActive(true);
			}
			if (pressed2)
			{
				UIToHide.SetActive(false);
				UIToShow.SetActive(true);
				//buttons.SetActive(false);
				float singleStep = speed * Time.deltaTime;
				_objectToRotate.transform.Rotate(xPos1, yPos1, zPos1, Space.World);

				//slider2.SetActive(true);
			}
			if (pressed3)
			{
				UIToHide.SetActive(false);
				UIToShow.SetActive(true);
				//buttons.SetActive(false);
				float singleStep = speed * Time.deltaTime;
				_objectToRotate.transform.Rotate(xPos1, yPos1, zPos1, Space.World);

				//slider3.SetActive(true);
			}

		}
	}
}