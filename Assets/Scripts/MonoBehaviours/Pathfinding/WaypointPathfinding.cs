using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPathfinding : MonoBehaviour {
    public List<Waypoint> waypoints = new List<Waypoint> ();
    public Waypoint startWaypoint;
    public Waypoint currentWaypoint;
    public List<PathSegment> path = new List<PathSegment> ();
    public EnemyState enemyState;
    public IEnumerator traversePath;
    Rigidbody2D rigidbody;
    public float range;

    void Awake()
    {
        traversePath = TraversePath();
        enemyState = GetComponent<EnemyState>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        FindPath(transform.position, new Vector2(-3.55f, -0.29f));
    }

    public List<PathSegment> FindPath(Vector2 current, Vector2 destination)
    {
        Debug.Log("Started");
        path = new List<PathSegment>();
        StopCoroutine(traversePath);
        currentWaypoint = startWaypoint;
        int c = 0;
        //initial hCost for current will be from currentWaypoint to destination
        //float hCostCurrent = Vector2.Distance(currentWaypoint.location, destination);
        float hCostNext;
        float hCostPrev;
        do
        {
            if (currentWaypoint.next != null)
                hCostNext = Vector2.Distance(destination, currentWaypoint.next.location);
            else
                hCostNext = int.MaxValue;

            if (currentWaypoint.previous != null)
                hCostPrev = Vector2.Distance(destination, currentWaypoint.previous.location);
            else
                hCostPrev = int.MaxValue;


            if (true)
                if (hCostNext < hCostPrev )
                {
                    if (currentWaypoint.next != null)
                    {
                        PathSegment pathSegment = new PathSegment();
                        pathSegment.initPathSegment(currentWaypoint.location, currentWaypoint.next.location, true);
                        path.Add(pathSegment);
                        currentWaypoint = currentWaypoint.next;
                        //hCostCurrent = hCostNext;
                        Debug.Log("Previous added");
                    }
                }
                else
                {
                    if (currentWaypoint.previous != null)
                    {
                        PathSegment pathSegment = new PathSegment();
                        pathSegment.initPathSegment(currentWaypoint.location, currentWaypoint.previous.location, true);
                        path.Add(pathSegment);
                        currentWaypoint = currentWaypoint.previous;
                        //hCostCurrent = hCostPrev;
                        Debug.Log("Added");
                    }
                }
            else
            {
                Debug.Log("What");
            }
            c++;
        } while (enemyState.getState() == State.patrolling);
        return path;
        //if more than one waypoint is contained then start traversing the path
        if (path.Count != 1)
        {
            StartCoroutine(traversePath);
        }
    }

    IEnumerator TraversePath()
    {
        //as long as the enemy is not in sight
        foreach (PathSegment path in path)
        {
            //as long as the enemy is not patrolling and the target is within a certain range
            while (Vector2.Distance(transform.position, path.next) > range && enemyState.getState() != State.patrolling) 
            {
                //moving it slowly each frame
                rigidbody.MovePosition((path.next - new Vector2(transform.position.x, transform.position.y) * enemyState.walkSpeed * Time.deltaTime + new Vector2(transform.position.x, transform.position.y)));
                yield return null;
            }
            if (Vector2.Distance(transform.position, path.next) <= range)
            {
                Debug.Log("Waypoint Reached");
                rigidbody.AddForce(Vector2.up);
            }
        }
        yield return null;
    }
}
public class PathSegment
{
    public Vector2 current;
    public Vector2 next;
    public bool jump;

    public void initPathSegment(Vector2 current, Vector2 next, bool jump = false)
    {
        this.current = current;
        this.next = next;
        this.jump = jump;
    }
}

