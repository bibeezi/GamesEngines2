using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvengerShipFight : MonoBehaviour
{
    Pursue pursue;
    Flee flee;
    StateMachine stateMachine;
    GameObject[] leviathans;
    GameObject pursueLeviathan;
    int whichLeviathan;
    int bullets = 10;
    public GameObject bulletPrefab;

    public class TargetLeviathan : State 
    {
        public override void Enter()
        {
            owner.GetComponent<AvengerShipFight>().flee.enabled = false;
            owner.GetComponent<AvengerShipFight>().pursue.enabled = true;

            owner.GetComponent<AvengerShipFight>().pursueLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;

            owner.GetComponent<AvengerShipFight>().pursue.target = owner.GetComponent<AvengerShipFight>().pursueLeviathan.GetComponent<Boid>();

        }

        public override void Think()
        {
            if(owner.GetComponent<AvengerShipFight>().pursueLeviathan == null)
            {
                owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");
                owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                owner.GetComponent<AvengerShipFight>().pursueLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
            }
            else if(Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().pursueLeviathan.transform.position) < 80f)
            {
                owner.GetComponent<AvengerShipFight>().stateMachine.ChangeState(new FleeLeviathan());
            }

            if(owner.GetComponent<AvengerShipFight>().bullets > 0 && Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().pursueLeviathan.transform.position) < 200f)
            {
                Instantiate(owner.GetComponent<AvengerShipFight>().bulletPrefab, owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().transform.rotation);
                owner.GetComponent<AvengerShipFight>().bullets--;
            }
        }
    }

    public class FleeLeviathan : State 
    {
        public override void Enter()
        {
            owner.GetComponent<AvengerShipFight>().flee.enabled = true;
            owner.GetComponent<AvengerShipFight>().pursue.enabled = false;

            owner.GetComponent<AvengerShipFight>().flee.target = owner.GetComponent<AvengerShipFight>().pursueLeviathan.transform.position;

            owner.GetComponent<AvengerShipFight>().bullets = 10;
        }

        public override void Think()
        {
            if(owner.GetComponent<AvengerShipFight>().pursueLeviathan == null)
            {
                owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");
                owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                owner.GetComponent<AvengerShipFight>().pursueLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
            }
            else if(Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().pursueLeviathan.transform.position) > 200f)
            {
                owner.GetComponent<AvengerShipFight>().stateMachine.ChangeState(new TargetLeviathan());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pursue = GetComponent<Pursue>();
        flee = GetComponent<Flee>();

        leviathans = GameObject.FindGameObjectsWithTag("leviathan");

        whichLeviathan = Random.Range(0, leviathans.Length);

        stateMachine = GetComponent<StateMachine>();
        stateMachine.ChangeState(new TargetLeviathan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
