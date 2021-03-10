using UnityEngine;
using System.Collections;

public class PlayerRocket : MonoBehaviour {

    #region Public Properties
    public ParticleSystem rocket;
	public PlayerMovement player;
	//public RectTransform rocketFuel;
	public float rocketSpeed = 10f;
    public float rocketTimeRegen = 5F;
    public int rocketRegenAmount = 2;

    public static int currentBoosts = 6;
	public int boostMax = 6;
    #endregion

    #region Private Properties
    private float _cachedY;
	private float _minXValue;
	private float _maxXValue;
	private float _coolDown;
    private bool _regenAllowed = true;
    #endregion

    //starting with some UI values
    void Start () {
        //ParticleSystem.EmissionModule em = rocket.emission;
        //em.enabled = true;
		//rocket.maxParticles = 10;

		//_cachedY = rocketFuel.position.y;
		//_maxXValue = rocketFuel.position.x;
		//_minXValue = rocketFuel.position.x - rocketFuel.rect.width;
		currentBoosts = boostMax;
	}

    void Update()
    {
        HandleRocketFuel();

        if (_regenAllowed)
            StartCoroutine(RegenerateBoost());
    }

    //regen
    IEnumerator RegenerateBoost()
    {
        _regenAllowed = false;
        yield return new WaitForSeconds(rocketTimeRegen);
        AddBoosts(rocketRegenAmount);
        _regenAllowed = true;
    }

    //fire rockets
    public void Fire(GravityBody body)
    {

        if (body.Grounded == 1)
        //if (currentBoosts > 0)
        {
            currentBoosts = 0;
            rocket.maxParticles = 200;

            player.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity + (player.GetComponent<Rigidbody>().transform.up * rocketSpeed);

            HandleRocketFuel();
        }
        else
        {
            rocket.maxParticles = 10;
            currentBoosts = 1;
        }
        //Debug.Log(body.Grounded);
    }

    //stop rockets
    public void Stop()
    {
        rocket.maxParticles = 10;
    }

    //add boosts
    public void AddBoosts(int boost)
    {
        if (boost < boostMax)
        {
            int validateBoost = currentBoosts + boost;
            if (validateBoost > boostMax)
            {
                currentBoosts = boostMax;
            }
            else
            {
                currentBoosts = currentBoosts + boost;
            }
        }
        else
        {
            currentBoosts = boostMax;
        }
    }

    //UI Handling
    private void HandleRocketFuel()
    {
        float currentXValue = MapRocketValues(currentBoosts, 0, boostMax, _minXValue, _maxXValue);
        //rocketFuel.position = new Vector3(currentXValue, _cachedY);
    }

    private float MapRocketValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
