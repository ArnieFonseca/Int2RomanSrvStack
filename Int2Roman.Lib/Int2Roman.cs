

using LanguageExt;

using Microsoft.CodeAnalysis;

using System.Data;
namespace Int2Roman.Lib;

using MapperContainer = (uint pn, Mapper ub, Mapper lb, Mapper plb, Option<Mapper> exactNumber);

/// <summary>
/// Interface concrete implementation
/// This Method convert and Integer into the corresponding Roman equivalence
/// </summary>

public class IntToRoman : IInt2Roman
{

    /// <summary>
    /// Interface concrete implementation.
    /// This Method convert and Integer into the corresponding Roman equivalence
    /// </summary>
    /// <param name="num">Positive non zeros value</param>
    /// <returns>String representation on Roman Number notation</returns>
    string IInt2Roman.ConvertToRoman(uint num) =>
      ConvertToRomanHelper(num, string.Empty);

    private const string ERROR_CONVERSION_MSG = "Error - Unable to convert to Roman Number";

    /// <summary>
    /// Maps a non zero integer to a Roman Number notation
    /// </summary>
    private static readonly IEnumerable<Mapper> mapper =
        new List<Mapper>()
        {
            new() {Number=1, Roman="I"},
            new() {Number=5, Roman="V"},
            new() {Number=10, Roman="X"},
            new() {Number=50, Roman="L"},
            new() {Number=100, Roman="C"},
            new() {Number=500, Roman="D"},
            new() {Number=1_000, Roman="M"},
            new() {Number=5_000, Roman="V\u0305"},
            new() {Number=10_000, Roman="X\u0305" },
            new() {Number=50_000, Roman="L\u0305" },
            new() {Number=100_000, Roman="C\u0305" },
            new() {Number=500_000, Roman="D\u0305" },
            new() {Number=1_000_000, Roman="M\u0305" }
        };

    /// <summary>
    /// Calculates the Upper Boundary of a non zero Integer
    /// (e.g., given 80 it produces 100 as Upper Bound)
    /// </summary>
    private static readonly Func<uint, Mapper> GetUpperBound = pn =>
        mapper.First(m => m.Number >= pn);
    /// <summary>
    /// Calculates the Lower Boundary of a non zero Integer
    /// (e.g., given 80 it produces 50 as Upper Bound)
    /// </summary>
    private static readonly Func<uint, Mapper> GetLowerBound = (uint pn) =>
        mapper.Last(m => m.Number <= pn);
    /// <summary>
    /// Calculates the Previous Lower Boundary of a non zero Integer
    /// (e.g., given 80 it produces 10 as Upper Bound). In the even the previous does exist
    /// then the first element of the mapper is is returned    ///
    /// </summary>
    private static readonly Func<uint, Mapper> GetPrevLowerBound = (uint pn) =>
            mapper.LastOrDefault(m => m.Number < GetLowerBound(pn).Number) ?? mapper.First();
    /// <summary>
    /// Calculates the case of 4, 9, 40, 90 ... for any other number it will return NULL
    /// (e.g., given 4 it produces IV, given 9 it produces IX, given 90 it produces XC)
    /// </summary>
    private static readonly Func<uint, Option<Mapper>> GetExact = (uint pn) =>
            mapper.FirstOrDefault(m => m.Number == GetUpperBound(pn).Number - pn);
    /// <summary>
    /// Retrieve the leftmost decimal portion of the input number
    /// (e.g., given 537 it will return 500, given 37 it returns 30, given 7 it return 7)
    /// </summary>
    /// <param name="num">Non zero Integer</param>
    /// <returns>The highest decimal positional representation in the input</returns>
    private static uint GetProcessingNumber(uint num)
    {
        double pn = (double)num;                    // Convert to double

        double a = Math.Floor(Math.Log10(num));     // Get the exponent
        double b = Math.Pow(10, a);                 // Get the decimal multiplier
        uint c = (uint)(pn / b);                    // Get the first digit

        return (uint)(b * c);                       // Returns the processing number
    }
    /// <summary>
    /// Recursive Helper function to Convert a non zero Integer
    /// into its corresponding Roman Number notation
    /// (e.g., given 537 it returns DXXXVII
    /// </summary>
    /// <param name="num"></param>
    /// <param name="romanNumber"></param>
    /// <returns></returns>
    private static string ConvertToRomanHelper(uint num, string romanNumber)
    {
        if (num == 0)                           // Base case therefore returns Roman Number
        {
            return romanNumber;
        }
        else
        {
            uint pn = GetProcessingNumber(num);
            Mapper ub = GetUpperBound(pn);
            Mapper lb = GetLowerBound(pn);
            Mapper plb = GetPrevLowerBound(pn);
            Option<Mapper> exactNumber = GetExact(pn);            

            MapperContainer mc = (pn, ub, lb, plb, exactNumber);

            string rst = TranslateToRomanNumber(mc);
            return ConvertToRomanHelper(num - pn, romanNumber + rst);
        }
    }
    /// <summary>
    /// Helper function to translate a number to a roman number equivalence.
    /// It uses a pattern matching for the conversion
    /// </summary>
    /// <param name="mc">Mapper Container </param>
    /// <returns>String in Roman Number format</returns>
    private static string TranslateToRomanNumber(MapperContainer mc) =>

        mc.pn switch
        {
            // case 1: Processing number exists in the mapping
            var _ when mc.pn == mc.ub.Number
                => mc.ub.Roman,
            // case 2: The processing number is either 4,9,40,90 ...
            var _ when mc.exactNumber.IsSome
                => mc.exactNumber.Match(r => r.Roman, string.Empty) + mc.ub.Roman,
            // case 3: The processing number is a repeating patter for 1,2,3,10,20,30 ...
            var _ when mc.pn < mc.ub.Number - mc.lb.Number
                => string.Concat(Enumerable.Repeat(mc.lb.Roman, RepeatLower(mc, mc.pn))),
            // case 4: The processing number is a repeating patter for 6,7,8,60,70,80 ...
            var _ when mc.pn > mc.ub.Number - mc.lb.Number
                => mc.lb.Roman + string.Concat(Enumerable.Repeat(mc.plb.Roman, RepeatUpper(mc, mc.pn))),
            // default: Catch up
            _ => ERROR_CONVERSION_MSG,
        };

    /// <summary>
    /// Helper function for the repeating number of 1,2,3,20,30 ...
    /// </summary>
    /// <param name="mc">Mapper Container</param>
    /// <param name="pn">Processing Number</param>
    /// <returns></returns>
    private static int RepeatLower(MapperContainer mc, uint pn) =>
        (int)(pn / mc.lb.Number);
    /// <summary>
    /// Helper function for the repeating number of 6,7,8,60,70,80 ...
    /// </summary>
    /// <param name="mc">Mapper Container</param>
    /// <param name="pn">Processing Number</param>
    /// <returns></returns>
    private static int RepeatUpper(MapperContainer mc, uint pn) =>
        (int)((pn - mc.lb.Number) / mc.plb.Number);

    void IDisposable.Dispose()
    {
        //throw new NotImplementedException();
    }
}