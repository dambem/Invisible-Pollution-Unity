namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using Mapbox.Unity.MeshGeneration.Factories.TerrainStrategies;
	using Mapbox.Unity.Map;
    using System.Security.Cryptography.X509Certificates;

    public class SpawnOnGlobeExample : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		[Geocode]
		public string[] _locations;
		string location1 =
		string location2 =
		string location3 = 
		GameObject instance1;
		GameObject instance2;
		GameObject instance3;
		GameObject button1;
		GameObject button2;
		GameObject button3;
		[SerializeField]
		float _spawnScale = 100f;


		[SerializeField]
		GameObject _markerPrefab;

		void Start()
		{

				instance1 = Instantiate(_markerPrefab);
				var location = Conversions.StringToLatLon(locationString);
				var earthRadius = ((IGlobeTerrainLayer)_map.Terrain).EarthRadius;
				instance.transform.position = Conversions.GeoToWorldGlobePosition(location, earthRadius);
				instance.transform.localScale = Vector3.one * _spawnScale;
				instance.transform.SetParent(transform);
		}
		void Update()
        {

        }
	}
}