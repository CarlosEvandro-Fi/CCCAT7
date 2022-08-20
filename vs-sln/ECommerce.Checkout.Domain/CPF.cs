namespace ECommerce.Checkout.Domain;

/// <summary>
/// Cadastro de Pessoa Física.
/// </summary>
/// <param name="Value">Valor do CPF.</param>
public sealed record class CPF([DisallowNull] String Value)
{
    /// <summary>
    /// Valor do CPF.
    /// </summary>
    private String Value { get; } = IsValid(Value) ? OnlyNumbers(Value) : throw new Exception($"CPF Inválido! Valor Informado: {Value}");

    /// <summary>
    /// Se é um CPF Válido.
    /// </summary>
    /// <param name="Value">CPF.</param>
    /// <returns>True = Válido</returns>
    public static Boolean IsValid(String Value) => CPF_IS_VALID(Value);

    /// <summary>
    /// Retorna os Números do CPF.
    /// </summary>
    /// <param name="Value">CPF.</param>
    /// <returns>Números de 0 a 9.</returns>
    public static String OnlyNumbers(String s) => s is null ? "" : Regex.Replace(s, @"[^\d]", "");

    /// <summary>
    /// CPF no Formato: 00.000.000/0000-00
    /// </summary>
    /// <returns>00.000.000/0000-00</returns>
    public String ToDisplayPattern() => $"{Value.Substring(0, 3)}.{Value.Substring(3, 3)}.{Value.Substring(6, 3)}-{Value.Substring(9)}";

    /// <summary>
    /// CPF no Formato: 00000000000000
    /// </summary>
    /// <returns>00000000000000</returns>
    public override String ToString() => Value;

    public static implicit operator CPF(String s) => new(s);

    public static implicit operator String(CPF c) => c.Value;

    #region "IS VALID"

    private static Boolean CPF_IS_VALID(String CPF)
    {
        CPF = OnlyNumbers(CPF);

        if (!Regex.Match(CPF, "[0-9]{11}").Success) return false;

        if (CPF.All(character => character == CPF[0])) return false;

        Int32 verificadorCalculado1 = CPF_VERIFICADOR_1(CPF);
        Int32 verificadorCalculado2 = CPF_VERIFICADOR_2(CPF);

        Int32 verificador1 = Convert.ToInt32(CPF.Substring(CPF.Length - 2, 1));
        Int32 verificador2 = Convert.ToInt32(CPF.Substring(CPF.Length - 1, 1));

        return verificadorCalculado1 == verificador1 && verificadorCalculado2 == verificador2;
    }

    private static Int32 CPF_VERIFICADOR_1(String CPF)
    {
        Int32 soma = 0;
        for (Int32 i = 0, j = 10; i <= 8; i++, j--)
        {
            soma += Convert.ToInt32(CPF.Substring(i, 1)) * j;
        }

        if ((soma % 11) < 2)
            return 0;
        else
            return (11 - (soma % 11));
    }

    private static Int32 CPF_VERIFICADOR_2(String CPF)
    {
        Int32 soma = 0;
        for (Int32 i = 0, j = 11; i <= 9; i++, j--)
        {
            soma += Convert.ToInt32(CPF.Substring(i, 1)) * j;
        }

        if ((soma % 11) < 2)
            return 0;
        else
            return (11 - (soma % 11));
    }

    #endregion

    public static class Tools
    {
        /// <summary>
        /// Gera um CPF Fictício.
        /// </summary>
        /// <returns>CPF Fictício.</returns>
        public static String Generate()
        {
            var builder = new System.Text.StringBuilder();
            for (Int32 i = 0; i < 9; i++)
            {
                builder.Append(Random.Shared.Next(0, 9));
            }
            builder.Append(CPF_VERIFICADOR_1(builder.ToString()));
            builder.Append(CPF_VERIFICADOR_2(builder.ToString()));
            return builder.ToString();
        }
    }
}
