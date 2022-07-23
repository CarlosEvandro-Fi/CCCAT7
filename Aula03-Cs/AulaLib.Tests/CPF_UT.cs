namespace AulaLib.Tests;

public class CPF_UT
{
    [Fact]
    public void Instanciar_Um_CPF_Apenas_Se_Valido()
    {
        CPF c1 = new("613.744.654-96");
        CPF c2 = new("61374465496");
        CPF c3 = "613.744.654-96";
        CPF c4 = c3;

        Assert.True(c1.Equals(c2));
        Assert.True(c3.Equals(c4));
        Assert.True(ReferenceEquals(c3, c4)); // *** Por que é um Record Class
        Assert.Equal("61374465496", c1.ToString());
        Assert.Equal("613.744.654-96", c1.ToDisplayPattern());

        Assert.Throws<Exception>(() => { CPF c6 = new(null!); });
        Assert.Throws<Exception>(() => { CPF c5 = new(""); });
        Assert.Throws<Exception>(() => { CPF c6 = new("1234567890"); });
        Assert.Throws<Exception>(() => { CPF c6 = new("12345678901"); });
        Assert.Throws<Exception>(() => { CPF c6 = new("1234567890A"); });
        Assert.Throws<Exception>(() => { CPF c6 = new("123456789012"); });
    }

    [Theory]
    [InlineData("64.120.235-50")]
    [InlineData("0564.120.235-50")]
    [InlineData("00000000000")]
    [InlineData("11111111111")]
    [InlineData("22222222222")]
    [InlineData("33333333333")]
    [InlineData("44444444444")]
    [InlineData("55555555555")]
    [InlineData("66666666666")]
    [InlineData("77777777777")]
    [InlineData("88888888888")]
    [InlineData("99999999999")]
    public void Teste_De_CPF_Invalidos(String cpf)
    {
        Assert.False(CPF.IsValid(cpf));
    }

    [Theory]
    [InlineData("564.120.235-50")]
    [InlineData("052.675.131-21")]
    [InlineData("805.412.605-02")]
    [InlineData("203.855.240-13")]
    [InlineData("588.308.416-84")]
    [InlineData("043.100.230-45")]
    [InlineData("355.318.208-36")]
    [InlineData("625.711.668-67")]
    [InlineData("174.610.847-98")]
    [InlineData("666.241.617-79")]
    public void Teste_De_CPF_Validos(String cpf)
    {
        Assert.True(CPF.IsValid(cpf));
        CPF c = cpf;
        Assert.Equal(c.ToDisplayPattern(), cpf);
    }

    [Fact]
    public void Teste_Do_Gerador_De_CPF()
    {
        for (int i = 0; i < 100; i++)
        {
            String cpf = CPF.Tools.Generate();
            CPF c = cpf;
            Assert.Equal(c.ToString(), cpf);
        }
    }
}
