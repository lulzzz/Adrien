(* Based on Steven Horsfield's code at https://stevehorsfield.wordpress.com/2009/07/27/f-a-data-structure-for-modelling-directional-graphs/ *)

module Graph

  (* In this module, a graph is represented by an adjacency
     list.

     This module is not intended to be a high performance
     implementation.

     This module can represent a directed or undirected
     graph depending on the method of handling edges.
     The default behaviour results in a directed graph.
  *)

  type VertexData<'V> =
    int (* identifier *) *
    'V (* vertex data *)

  type EdgeData<'E> =
    int (* identifier *) *
    int (* priority *) *
    int (* vertex target *) *
    'E (* edge data *)

  (* The graph uses adjacency list notation *)
  type Adjacency<'E> = EdgeData<'E> list

  (* The Vertex type represents the internal structure
     of the graph *)
  type Vertex<'V, 'E> = VertexData<'V> * Adjacency<'E>

  (* A Graph is a Vertex list.  The nextNode allows for
     consistent addressing of nodes *)
  type Graph<'V, 'E> =
    int (* nextNode identifier *) *
    Vertex<'V, 'E> list

  (* Empty graph construction *)
  val empty: Graph<_,_>

  (* Helper methods for getting the data from a Vertex *)
  val vertexId : Vertex<_,_> -> int
  val vertexData : Vertex<'V,_> -> 'V
  (* Helper methods for getting the data from an Edge *)
  val edgeId : EdgeData<_> -> int
  val edgePriority : EdgeData<_> -> int
  val edgeTarget : EdgeData<_> -> int
  val edgeData : EdgeData<'E> -> 'E

  (* Getting a vertex from a graph by id *)
  val getVertex : int -> Graph<'V,'E> -> Vertex<'V,'E>
  (* Getting all edges from a graph by a vertex id *)
  val getEdges : int -> Graph<'V,'E> -> Adjacency<'E>

  (* Add a new vertex *)
  val addVertex : 'V -> Graph<'V,'E> -> 
      int (*new id*) * Graph<'V,'E>

  (* Add a new edge.  Edges include a priority value *)
  val addEdge :
    int (*priority*) ->
    int (*source vertex*) ->
    int (*target vertex*) ->
    'E (*edge data*) ->
    Graph<'V,'E> ->
    int (*new id*) * Graph<'V,'E>

  (* The edges aren't sorted by default so this function
     sorts them by priority *)
  val sortEdges : Adjacency<'E> -> Adjacency<'E>

  (* Removes an edge from a graph by id *)
  val removeEdge : int -> Graph<'V,'E> -> Graph<'V,'E>

  (* Removes a vertex from a graph by id and removes
     any related edges *)
  val removeVertex : int -> Graph<'V,'E> -> Graph<'V,'E>