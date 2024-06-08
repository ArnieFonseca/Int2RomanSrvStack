
namespace Int2Roman.Lib;
/// <summary>
/// Convert to Roman Interface
/// </summary>
public interface IInt2Roman:IDisposable
{
    /// <summary>
    /// This Method convert and Integer into the corresponding Roman equivalence
    /// </summary>
    /// <param name="num">Positive non zeros value</param>
    /// <returns>String representation on Roman Number notation</returns>
    string ConvertToRoman(uint num);
}
 
