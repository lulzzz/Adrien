#load "/home/nbuser/library/Paket.fsx"

Paket.Package ["Adrien.Base"; "Adrien"]

#r @"/home/nbuser/library/packages/Adrien.Base/lib/net452/Adrien.Base.dll"   
#r @"/home/nbuser/library/packages/Adrien/lib/net452/Adrien.dll"

open Adrien.Expression
open Adrien.Tree