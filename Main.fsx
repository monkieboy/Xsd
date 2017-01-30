#load """References.fsx"""
open FSharp.Data
open System.Xml.Serialization
open System.IO

[<Literal>]
let RequestSample = __SOURCE_DIRECTORY__ + "/Req.xml"
type Request = XmlProvider<RequestSample>
let xsd = __SOURCE_DIRECTORY__ + "/Req.xsd" |> File.ReadAllText
let validate xml =
  let validator = XsdValidator()
  validator.Validate(xml, xsd)

let run () = validate RequestSample

run()