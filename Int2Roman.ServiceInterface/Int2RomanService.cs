using ServiceStack;
using Int2Roman.ServiceModel;
using Int2Roman.Lib;

namespace Int2Roman.ServiceInterface;

public class Int2RomanService : Service 
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IInt2Roman int2Roman;

    /// <summary>
    /// Constructor with dependency Injection
    /// </summary>    
    public Int2RomanService(IInt2Roman int2Roman)
    {
        this.int2Roman = int2Roman; 
    }
    /// <summary>
    /// The DTO is validated and when it fails errors are sent via Response Status
    /// otherwise the convert roman number is sent via the DTO Response
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Int2RomanDTOResponse Post(Int2RomanDTO request)
    {
        // Validate DTO
         ResponseStatus rs = Int2RomanDTOValidator.ValidateDTO(request);

        if(rs.IsError())                // When any errors send back the message
        {
            // Send back Response Status
            return new Int2RomanDTOResponse { ResponseStatus = rs };
        }


        // Convert the input number
        string romanNumber = int2Roman.ConvertToRoman((uint)request.Number);

        // Send back the answer on the DTO Response
        return new Int2RomanDTOResponse { Result = romanNumber };
         
    }
}
