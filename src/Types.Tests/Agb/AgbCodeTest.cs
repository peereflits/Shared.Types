using Peereflits.Shared.Types.Agb;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Agb;

public class AgbCodeTest
{
    [Theory]
    [InlineData(AgbCode.MinValue - 1)]
    [InlineData(AgbCode.MaxValue + 1)]
    [InlineData(9000000)]  // Invalide discipline nr
    [InlineData(10000000)] // Invalide discipline nr
    [InlineData(15000000)] // Invalide discipline nr
    [InlineData(16000000)] // Invalide discipline nr
    [InlineData(27000000)] // Invalide discipline nr
    [InlineData(28000000)] // Invalide discipline nr
    [InlineData(29000000)] // Invalide discipline nr
    [InlineData(55000000)] // Invalide discipline nr
    [InlineData(59000000)] // Invalide discipline nr
    [InlineData(62000000)] // Invalide discipline nr
    [InlineData(63000000)] // Invalide discipline nr
    [InlineData(64000000)] // Invalide discipline nr
    [InlineData(68000000)] // Invalide discipline nr
    [InlineData(69000000)] // Invalide discipline nr
    [InlineData(71000000)] // Invalide discipline nr
    [InlineData(77000000)] // Invalide discipline nr
    [InlineData(80000000)] // Invalide discipline nr
    [InlineData(81000000)] // Invalide discipline nr
    [InlineData(82000000)] // Invalide discipline nr
    [InlineData(83000000)] // Invalide discipline nr
    [InlineData(86000000)] // Invalide discipline nr
    [InlineData(92000000)] // Invalide discipline nr
    [InlineData(95000000)] // Invalide discipline nr
    [InlineData(97000000)] // Invalide discipline nr
    [InlineData(99000000)] // Invalide discipline nr
    public void WhenCodeIsInvalid_ItShouldReturnFalse(int agbCode)
    {
        AgbCode result = agbCode;

        Assert.False(result.IsValid);
        Assert.Equal(Discipline.NotSet, result.Discipline);
    }

    [Theory]
    [InlineData(1000000, Discipline.Huisartsen)]
    [InlineData(2000000, Discipline.Apothekers)]
    [InlineData(3000000, Discipline.MedischSpecialisten)]
    [InlineData(4000000, Discipline.Fysiotherapeuten)]
    [InlineData(5000000, Discipline.Logopedisten)]
    [InlineData(6000000, Discipline.Ziekenhuizen)]
    [InlineData(7000000, Discipline.Oefentherapeuten)]
    [InlineData(8000000, Discipline.Verloskundigen)]
    [InlineData(11000000, Discipline.TandartsSpecialistenMondziektenKaakchirurgie)]
    [InlineData(12000000, Discipline.Tandartsen)]
    [InlineData(13000000, Discipline.TandartsSpecialistenDentoMaxillaireOrthopedie)]
    [InlineData(14000000, Discipline.Bedrijfsartsen)]
    [InlineData(17000000, Discipline.Rechtspersonen)]
    [InlineData(18000000, Discipline.Dialysecentra)]
    [InlineData(19000000, Discipline.AudiologischeCentra)]
    [InlineData(20000000, Discipline.RadiotherapeutischeCentra)]
    [InlineData(21000000, Discipline.Dienstenstructuren)]
    [InlineData(22000000, Discipline.ZelfstandigeBehandelcentra)]
    [InlineData(23000000, Discipline.InstellingenRevalidatiedagbehandeling)]
    [InlineData(24000000, Discipline.Dietisten)]
    [InlineData(25000000, Discipline.InstellingenPsychiatrischeDeeltijdbehandeling)]
    [InlineData(26000000, Discipline.Podotherapeuten)]
    [InlineData(30000000, Discipline.InstellingenVerstandelijkGehandicapten)]
    [InlineData(31000000, Discipline.Bloedbanken)]
    [InlineData(32000000, Discipline.GGD)]
    [InlineData(33000000, Discipline.Kraamcentra)]
    [InlineData(34000000, Discipline.Trombosediensten)]
    [InlineData(35000000, Discipline.InstellingenVisueelGehandicapten)]
    [InlineData(36000000, Discipline.Ambulancediensten)]
    [InlineData(37000000, Discipline.Gezondheidscentra)]
    [InlineData(38000000, Discipline.TandheelkundigeCentra)]
    [InlineData(39000000, Discipline.InstellingenJeugdtandverzorging)]
    [InlineData(40000000, Discipline.InstellingenAuditiefGehandicapten)]
    [InlineData(41000000, Discipline.ZZPers)]
    [InlineData(42000000, Discipline.Verzorgingshuizen)]
    [InlineData(43000000, Discipline.BeheerstichtingenVerzorgingstehuizen)]
    [InlineData(44000000, Discipline.Optometristen)]
    [InlineData(45000000, Discipline.VerpleeginrichtingenSomatischeZiekten)]
    [InlineData(46000000, Discipline.VerpleeginrichtingenGeriatrischePatienten)]
    [InlineData(47000000, Discipline.GecombineerdeVerpleeginrichtingen)]
    [InlineData(48000000, Discipline.OverigeInstellingen)]
    [InlineData(49000000, Discipline.Abortusklinieken)]
    [InlineData(50000000, Discipline.Laboratoria)]
    [InlineData(51000000, Discipline.KlinischGenetischeCentra)]
    [InlineData(52000000, Discipline.Eurotransplant)]
    [InlineData(53000000, Discipline.DiverseSamenwerkingsverbanden)]
    [InlineData(54000000, Discipline.GGZInstellingen)]
    [InlineData(56000000, Discipline.ConsultatiebureausAlcoholDrugs)]
    [InlineData(57000000, Discipline.PhysicianAssistant)]
    [InlineData(58000000, Discipline.CentralePostAmbulancediensten)]
    [InlineData(60000000, Discipline.InstellingenDagverplegingOuderen)]
    [InlineData(61000000, Discipline.BeheerstichtingenDagverblijven)]
    [InlineData(65000000, Discipline.GezinsvervangendeTehuizen)]
    [InlineData(66000000, Discipline.KoepelsBeheerstichtingen)]
    [InlineData(67000000, Discipline.Netwerkorganisaties)]
    [InlineData(70000000, Discipline.Kinderdagverblijven)]
    [InlineData(72000000, Discipline.RIBW)]
    [InlineData(73000000, Discipline.GecombineerdeWLZ)]
    [InlineData(74000000, Discipline.Arbodiensten)]
    [InlineData(75000000, Discipline.Thuiszorginstellingen)]
    [InlineData(76000000, Discipline.LeveranciersHulpmiddelen)]
    [InlineData(78000000, Discipline.SociaalPedagogischeDiensten)]
    [InlineData(79000000, Discipline.Riagg)]
    [InlineData(84000000, Discipline.OverigeArtsen)]
    [InlineData(85000000, Discipline.TaxiVervoerders)]
    [InlineData(87000000, Discipline.Mondhygienisten)]
    [InlineData(88000000, Discipline.Ergotherapeuten)]
    [InlineData(89000000, Discipline.Schoonheidsspecialisten)]
    [InlineData(90000000, Discipline.OverigeTherapeuten)]
    [InlineData(91000000, Discipline.Verpleegkundigen)]
    [InlineData(93000000, Discipline.Tandtechnici)]
    [InlineData(94000000, Discipline.PsychologischZorgverleners)]
    [InlineData(96000000, Discipline.Pedicuren)]
    [InlineData(98000000, Discipline.Declaranten)]
    public void WhenCodeHasKnownDiscipline_ItShouldReturnTheCorrectDiscipline(int code, Discipline expected)
    {
        AgbCode result = code;

        Assert.True(result.IsValid);
        Assert.Equal(expected, result.Discipline);
        Assert.Equal(0, result.SequenceNumber);
    }

    [Fact]
    public void WhenCodeIsImplicitlyConstructed_ItShouldReturnTheCorrectCode()
    {
        AgbCode result = 1020300;

        Assert.True(result.IsValid);
        Assert.Equal(Discipline.Huisartsen, result.Discipline);
        Assert.Equal(20300, result.SequenceNumber);
        Assert.Equal("01020300", result.ToString());
        Assert.True(result.IsPraktijk);
        Assert.False(result.IsInstelling);
    }

    [Fact]
    public void WhenCodeIsImplicitlyCast_ItShouldReturnTheCorrectValue()
    {
        const int huisArts = 1020300;
        var result = new AgbCode(huisArts);

        Assert.Equal(huisArts, (int)result);
    }

    [Fact]
    public void WhenEnsureIsValidWhileCodeIsInvalid_ItShouldThrow()
    {
        var code = new AgbCode(1);
        Assert.Throws<InvalidAgbException>(() => code.EnsureIsValid());
    }

    [Fact]
    public void WhenCodeIsInvalid_ItShouldBeConfigured()
    {
        var result = new AgbCode(1);

        Assert.False(result.IsValid);
        Assert.Equal(Discipline.NotSet, result.Discipline);
        Assert.Equal(1, result.SequenceNumber);
        Assert.Equal("00000001", result.ToString());
        Assert.False(result.IsPraktijk);
        Assert.False(result.IsInstelling);
    }

    [Theory]
    [InlineData(1000000)]
    [InlineData(3000000)]
    [InlineData(4000000)]
    [InlineData(5000000)]
    [InlineData(7000000)]
    [InlineData(24000000)]
    [InlineData(37000000)]
    [InlineData(88000000)]
    [InlineData(90000000)]
    [InlineData(91000000)]
    [InlineData(94000000)]
    [InlineData(96000000)]
    public void WhenCodeIsPraktijk_ItShouldReturnTrue(int code)
    {
        AgbCode result = code;
        Assert.True(result.IsPraktijk);
        Assert.False(result.IsInstelling);
    }

    [Theory]
    [InlineData(6000000)]
    [InlineData(19000000)]
    [InlineData(22000000)]
    [InlineData(30000000)]
    [InlineData(33000000)]
    [InlineData(35000000)]
    [InlineData(40000000)]
    [InlineData(41000000)]
    [InlineData(42000000)]
    [InlineData(43000000)]
    [InlineData(45000000)]
    [InlineData(46000000)]
    [InlineData(47000000)]
    [InlineData(48000000)]
    [InlineData(53000000)]
    [InlineData(54000000)]
    [InlineData(60000000)]
    [InlineData(61000000)]
    [InlineData(65000000)]
    [InlineData(66000000)]
    [InlineData(70000000)]
    [InlineData(72000000)]
    [InlineData(73000000)]
    [InlineData(75000000)]
    [InlineData(78000000)]
    [InlineData(79000000)]
    public void WhenCodeIsInstelling_ItShouldReturnTrue(int code)
    {
        AgbCode result = code;

        Assert.True(result.IsInstelling);
        Assert.False(result.IsPraktijk);
    }
}