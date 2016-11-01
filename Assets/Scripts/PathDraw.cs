using UnityEngine;
using System.Collections;

public class PathDraw : MonoBehaviour {

/*	
    LineRenderer line;
    NavMeshAgent agent;
    Transform target;


	void Start () {
        line = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Finish").transform;
	}

    void GetPath() {
        line.SetPosition(0, transform.position);
        agent.SetDestination(target.position);

        yield WaitForEndOfFrame();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
*/

    void Start() {
        DrawPath();
    }

    void DrawPath() {

        var nav = GetComponent<NavMeshAgent>();
        if(nav == null || nav.path == null) {
            return;
        }

        var line = this.GetComponent<LineRenderer>();
        if( line == null ) {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material( Shader.Find( "Sprites/Default" ) ) { color = Color.yellow };
            line.SetWidth( 0.5f, 0.5f );
            line.SetColors( Color.yellow, Color.yellow );
        }

        var path = nav.path;

        line.SetVertexCount( path.corners.Length );

        for( int i = 0; i < path.corners.Length; i++ ) {
            line.SetPosition( i, path.corners[ i ] );
        }

    }

    void Update() {
        DrawPath();
        /*
        for (int i = 0; i < path.corners.Length - 1; i++) {
             Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
         }

*/
    }
}
