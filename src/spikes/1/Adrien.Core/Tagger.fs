module Adrien.Tagger

/// Tagger for generating incremental tag
type Tagger(t) =
    member val Last = t with get,set
    member t.Next() = t.Last <- t.Last + 1u; t.Last

/// Global tagger
type GlobalTagger() =
    static let T = new Tagger(0u)
    static member Next = T.Next()
    static member Reset = T.Last <- 0u

/// Instance tagger 
type InstanceTagger() =
    static let mutable t = 0 
    static member Next() = t <- t + 1; t
