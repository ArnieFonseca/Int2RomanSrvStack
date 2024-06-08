using ServiceStack;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int2Roman.ServiceModel;

/// <summary>
/// Int2Roman Data Transfers Object
/// </summary>
[Route("/calculate/roman")]
public class Int2RomanDTO : IReturn<Int2RomanDTOResponse>
{
    public int Number { get; set; }
}
/// <summary>
/// Int2Roman Data Transfers Object Response
/// </summary>
public class Int2RomanDTOResponse
{
    public string Result { get; set; }
    public ResponseStatus ResponseStatus { get; set; } //Exception gets serialized here
}
