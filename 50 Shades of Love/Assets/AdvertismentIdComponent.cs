using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertismentIdComponent : MonoBehaviour {

	private void Start()
	{
		Application.RequestAdvertisingIdentifierAsync (
			(string advertisingId, bool trackingEnabled, string error) =>
			{ Debug.Log ("advertisingId " + advertisingId + " " + trackingEnabled + " " + error); }
		);
	}
}
