using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AvengerShipFight : MonoBehaviour
{
    Seek seek;
    Flee flee;
    StateMachine stateMachine;
    GameObject[] leviathans;
    public GameObject seekLeviathan;
    int whichLeviathan;
    int bullets = 20;
    public GameObject bulletPrefab;
    public LayerMask leviathanMask;


    public class TargetLeviathan : State 
    {
        public override void Enter()
        {
            owner.GetComponent<AvengerShipFight>().flee.enabled = false;
            owner.GetComponent<AvengerShipFight>().seek.enabled = true;

            owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");

            if(owner.GetComponent<AvengerShipFight>().leviathans.Length > 0)
            {
                owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                owner.GetComponent<AvengerShipFight>().seekLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
                owner.GetComponent<AvengerShipFight>().seek.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;   
            }
        }

        public override void Think()
        {
            if(owner.GetComponent<AvengerShipFight>().seekLeviathan == null)
            {
                owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");
                
                if(owner.GetComponent<AvengerShipFight>().leviathans.Length > 0)
                {
                    owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                    owner.GetComponent<AvengerShipFight>().seekLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
                    owner.GetComponent<AvengerShipFight>().seek.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;
                }
            }
            else if(Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().seek.target) < 80f)
            {
                owner.GetComponent<AvengerShipFight>().stateMachine.ChangeState(new FleeLeviathan());
            }
            else
            {
                owner.GetComponent<AvengerShipFight>().seek.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;
            }

            Collider[] visibleLeviathans = Physics.OverlapSphere(owner.GetComponent<AvengerShipFight>().transform.position, 500f, owner.GetComponent<AvengerShipFight>().leviathanMask);

            if(visibleLeviathans.Length > 0)
            {
                Vector3 closestLeviathan = Vector3.zero;

                for(int i = 0; i < visibleLeviathans.Length; i++)
                {
                    if(closestLeviathan == Vector3.zero)
                    {
                        closestLeviathan = visibleLeviathans[i].gameObject.transform.position;
                        owner.GetComponent<AvengerShipFight>().seek.target = closestLeviathan;
                    }
                    else if(Vector3.Distance(owner.transform.position, visibleLeviathans[i].gameObject.transform.position) < Vector3.Distance(owner.transform.position, closestLeviathan))
                    {
                        closestLeviathan = visibleLeviathans[i].gameObject.transform.position;
                        owner.GetComponent<AvengerShipFight>().seek.target = closestLeviathan;
                    }

                    if(owner.GetComponent<AvengerShipFight>().seekLeviathan == null)
                    {
                        owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");
                        owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                        owner.GetComponent<AvengerShipFight>().seekLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
                        owner.GetComponent<AvengerShipFight>().seek.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;
                    }
                    else if(Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position) < 200f)
                    {
                        Vector3 dirToLeviathan = (visibleLeviathans[i].gameObject.transform.position - owner.GetComponent<AvengerShipFight>().transform.position).normalized;
                        if(Vector3.Angle(owner.GetComponent<AvengerShipFight>().transform.forward, dirToLeviathan) < 90f)
                        {
                            if(owner.GetComponent<AvengerShipFight>().bullets > 0)
                            {
                                Instantiate(owner.GetComponent<AvengerShipFight>().bulletPrefab, owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().transform.rotation);
                                owner.GetComponent<AvengerShipFight>().bullets--;
                            }
                        }
                    }
                }
            }

            
        }
    }

    public class FleeLeviathan : State 
    {
        public override void Enter()
        {
            owner.GetComponent<AvengerShipFight>().flee.enabled = true;
            owner.GetComponent<AvengerShipFight>().seek.enabled = false;

            owner.GetComponent<AvengerShipFight>().flee.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;

            owner.GetComponent<AvengerShipFight>().bullets = 10;
        }

        public override void Think()
        {
            if(owner.GetComponent<AvengerShipFight>().seekLeviathan == null)
            {
                owner.GetComponent<AvengerShipFight>().leviathans = GameObject.FindGameObjectsWithTag("leviathan");
                
                if(owner.GetComponent<AvengerShipFight>().leviathans.Length > 0)
                {
                    owner.GetComponent<AvengerShipFight>().whichLeviathan = Random.Range(0, owner.GetComponent<AvengerShipFight>().leviathans.Length);
                    owner.GetComponent<AvengerShipFight>().seekLeviathan = owner.GetComponent<AvengerShipFight>().leviathans[owner.GetComponent<AvengerShipFight>().whichLeviathan].transform.GetChild(0).gameObject;
                    owner.GetComponent<AvengerShipFight>().seek.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;
                }
            }
            else if(Vector3.Distance(owner.GetComponent<AvengerShipFight>().transform.position, owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position) > 100f)
            {
                owner.GetComponent<AvengerShipFight>().stateMachine.ChangeState(new TargetLeviathan());
            }
            else
            {
                owner.GetComponent<AvengerShipFight>().flee.target = owner.GetComponent<AvengerShipFight>().seekLeviathan.transform.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        seek = GetComponent<Seek>();
        flee = GetComponent<Flee>();

        leviathans = GameObject.FindGameObjectsWithTag("leviathan");

        stateMachine = GetComponent<StateMachine>();
        stateMachine.ChangeState(new TargetLeviathan());
    }

    // Update is called once per frame
    void Update()
    {
        leviathans = GameObject.FindGameObjectsWithTag("leviathan");

        if(leviathans.Length == 0)
        {
            int avengerShipICount = GameObject.FindGameObjectsWithTag("avengershipI").Length;
            int avengerShipIICount = GameObject.FindGameObjectsWithTag("avengershipII").Length;

            PlayerPrefs.SetInt("avengerShipICount", avengerShipICount);
            PlayerPrefs.SetInt("avengerShipIICount", avengerShipIICount);
            
            SceneManager.LoadScene(sceneName: "13SanctuaryII");
        }
    }
}
