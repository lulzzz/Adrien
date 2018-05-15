module Graph
(* From https://www.cs.cornell.edu/courses/cs3110/2013sp/lectures/lec21-graphs/lec21.html *)

(* A signature for directed graphs.*)

type graph  (* A directed graph consisting of a set of vertices
             * V and directed edges E with integer weights. *)
type vertex (* A vertex, or node, of the graph *)
type edge   (* A edge of the graph *)

(* Creates an empty graph. *)
val create : unit -> graph

(* Returns the id of the specified vertex. *)
val vertex_id : vertex -> int

(* Compares two vertices, returning 0 if their ids are equal, -1 if
 * the first has a smaller id, and +1 if first has a larger id.
 * Suitable for comparators in sets and maps. *)
val compare : vertex -> vertex -> int

(* For an edge return (src, dst, w) where src is the source vertex of
 * the edge, dst is the destination vertex, and w is the edge
 * weight. *)
val edge_info : edge -> vertex * vertex * int

(* True if the given graph is empty (has no vertices).
 * Run time O(1). *)
val is_empty : graph -> bool

(* A list of all vertices in the graph, without duplicates, in the order
 * they were added.Run time: O(|V|). *)
val vertices : graph -> vertex list

(* A list of all vertices in the graph, without duplicates, in the order
 * they were added.Run time: O(1). *)
val num_vertices : graph -> int

(* A list of all edges in the graph, without duplicates.
 * Run time: O(|V|+|E|). *)
val edges : graph -> edge list

(* A list of the edges leaving the vertex v.
 * Run time: linear in the length of the result. *)
val outgoing : vertex -> edge list

(* A list of the edges coming in to the vertex v.
 * Run time: linear in the length of the result. *)
val incoming : vertex -> edge list

(* The number of incoming edges for the specified vertex.
 * Run time: O(1). *)
val in_degree : vertex -> int

(* The number of outgoing edges for the specified vertex. 
 * Run time: O(1). *)
val out_degree : vertex -> int

(* Adds a new isolated vertex (a vertex with no incident
 * edges) to the specified graph, and returns that vertex. 
 * Run time: O(1). *)
val add_vertex : graph -> vertex

(* Removes the specified vertex from the specified graph,
 * along with all incident edges; that is, all edges that
 * have the vertex as a source or destination. 
 * Run time: O(|E|). 
 * Note that the total time for removing all |V| vertices in the 
 * graph is also O(|E|) and not O(|V||E|). *)
val remove_vertex : graph -> vertex -> unit

(* add_edge (src, dst, w) adds an edge from src vertex to dst
 * vertex with weight w. 
 * Run time: O(1). *)
val add_edge : vertex * vertex * int -> unit

(* remove_edge (src, dst) removes the edge from src vertex to
 * dst vertex, and has no effect if the edge does not exist. 
 * Run time: O(|E|). *)
val remove_edge : vertex * vertex -> unit

(* Creates and returns a copy of the graph. 
 * Run time: O(|V|+|E|). *)
val copy : graph -> graph
