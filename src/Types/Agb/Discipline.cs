namespace Peereflits.Shared.Types.Agb;

/// <summary>
/// <para>De AGB-code (Algemeen GegevensBeheer) is een uniek codenummer van Nederlandse zorgaanbieders of zorgverleningsinstanties. De AGB-code is op grond van de WMG (Wet Marktordening Gezondheidszorg) sinds 1 januari 2016 verplicht voor alle formele zorgverleners.</para> 
/// <para>De gegevens die bij de AGB-codes horen worden geregistreerd in een openbaar register, dat wordt bijgehouden door Vektis in Zeist. In het AGB-register staat alle noodzakelijke (zorg)informatie om declareren en het afsluiten van contracten tussen zorgverzekeraars en zorgaanbieders mogelijk te maken. Ook is deze informatie de basis voor zorgzoekers en zorgvinders voor verzekerden en patiënten. In alle administratieve processen binnen het zorgveld wordt deze AGB-code gebruikt als identificerende sleutel.</para>
/// <para>Een AGB-code telt acht cijfers, waarbij de eerste twee cijfers het type zorgaanbieder aanduiden:</para>
/// <see cref="https://nl.wikipedia.org/wiki/AGB-code"/>
/// </summary>
public enum Discipline
{
    /// <summary>
    ///     Niet opgegeven
    /// </summary>
    NotSet = 0,

    /// <summary>
    ///     huisartsen
    /// </summary>
    Huisartsen = 1,

    /// <summary>
    ///     apothekers
    /// </summary>
    Apothekers = 2,

    /// <summary>
    ///     medisch specialisten
    /// </summary>
    MedischSpecialisten = 3,

    /// <summary>
    ///     fysiotherapeuten
    /// </summary>
    Fysiotherapeuten = 4,

    /// <summary>
    ///     logopedisten
    /// </summary>
    Logopedisten = 5,

    /// <summary>
    ///     ziekenhuizen
    /// </summary>
    Ziekenhuizen = 6,

    /// <summary>
    ///     oefentherapeuten
    /// </summary>
    Oefentherapeuten = 7,

    /// <summary>
    ///     verloskundigen
    /// </summary>
    Verloskundigen = 8,

    /// <summary>
    ///     tandarts-specialisten (mondziekten en kaakchirurgie)
    /// </summary>
    TandartsSpecialistenMondziektenKaakchirurgie = 11,

    /// <summary>
    ///     tandartsen
    /// </summary>
    Tandartsen = 12,

    /// <summary>
    ///     tandarts-specialisten (dento-maxillaire orthopedie)
    /// </summary>
    TandartsSpecialistenDentoMaxillaireOrthopedie = 13,

    /// <summary>
    ///     bedrijfsartsen
    /// </summary>
    Bedrijfsartsen = 14,

    /// <summary>
    ///     rechtspersonen
    /// </summary>
    Rechtspersonen = 17,

    /// <summary>
    ///     dialysecentra
    /// </summary>
    Dialysecentra = 18,

    /// <summary>
    ///     audiologische centra
    /// </summary>
    AudiologischeCentra = 19,

    /// <summary>
    ///     radiotherapeutische centra
    /// </summary>
    RadiotherapeutischeCentra = 20,

    /// <summary>
    ///     dienstenstructuren (ANW-diensten)
    /// </summary>
    Dienstenstructuren = 21,

    /// <summary>
    ///     zelfstandige behandelcentra
    /// </summary>
    ZelfstandigeBehandelcentra = 22,

    /// <summary>
    ///     instellingen voor revalidatiedagbehandeling
    /// </summary>
    InstellingenRevalidatiedagbehandeling = 23,

    /// <summary>
    ///     diëtisten
    /// </summary>
    Dietisten = 24,

    /// <summary>
    ///     instellingen voor psychiatrische deeltijdbehandeling
    /// </summary>
    InstellingenPsychiatrischeDeeltijdbehandeling = 25,

    /// <summary>
    ///     podotherapeuten
    /// </summary>
    Podotherapeuten = 26,

    /// <summary>
    ///     instellingen voor verstandelijk gehandicapten
    /// </summary>
    InstellingenVerstandelijkGehandicapten = 30,

    /// <summary>
    ///     bloedbanken
    /// </summary>
    Bloedbanken = 31,

    /// <summary>
    ///     GGD
    /// </summary>
    GGD = 32,

    /// <summary>
    ///     kraamcentra
    /// </summary>
    Kraamcentra = 33,

    /// <summary>
    ///     trombosediensten
    /// </summary>
    Trombosediensten = 34,

    /// <summary>
    ///     instellingen voor visueel gehandicapten
    /// </summary>
    InstellingenVisueelGehandicapten = 35,

    /// <summary>
    ///     ambulancediensten
    /// </summary>
    Ambulancediensten = 36,

    /// <summary>
    ///     gezondheidscentra
    /// </summary>
    Gezondheidscentra = 37,

    /// <summary>
    ///     tandheelkundige centra
    /// </summary>
    TandheelkundigeCentra = 38,

    /// <summary>
    ///     instellingen voor jeugdtandverzorging
    /// </summary>
    InstellingenJeugdtandverzorging = 39,

    /// <summary>
    ///     instellingen voor auditief gehandicapten
    /// </summary>
    InstellingenAuditiefGehandicapten = 40,

    /// <summary>
    ///     ZZP’ers in wijkverpleging / PGB-aanbieders / beheerstichtingen
    /// </summary>
    ZZPers = 41,

    /// <summary>
    ///     verzorgingshuizen
    /// </summary>
    Verzorgingshuizen = 42,

    /// <summary>
    ///     beheerstichtingen verzorgingstehuizen
    /// </summary>
    BeheerstichtingenVerzorgingstehuizen = 43,

    /// <summary>
    ///     optometristen
    /// </summary>
    Optometristen = 44,

    /// <summary>
    ///     verpleeginrichtingen voor somatische ziekten
    /// </summary>
    VerpleeginrichtingenSomatischeZiekten = 45,

    /// <summary>
    ///     verpleeginrichtingen voor psycho-geriatrische patiënten
    /// </summary>
    VerpleeginrichtingenGeriatrischePatienten = 46,

    /// <summary>
    ///     gecombineerde verpleeginrichtingen
    /// </summary>
    GecombineerdeVerpleeginrichtingen = 47,

    /// <summary>
    ///     overige instellingen
    /// </summary>
    OverigeInstellingen = 48,

    /// <summary>
    ///     abortusklinieken
    /// </summary>
    Abortusklinieken = 49,

    /// <summary>
    ///     laboratoria (huisartsenlaboratorium / gemeenschappelijk laboratorium / gemeenschappelijke apotheek + laboratorium
    /// </summary>
    Laboratoria = 50,

    /// <summary>
    ///     klinisch-genetische centra
    /// </summary>
    KlinischGenetischeCentra = 51,

    /// <summary>
    ///     Eurotransplant
    /// </summary>
    Eurotransplant = 52,

    /// <summary>
    ///     diverse samenwerkingsverbanden
    /// </summary>
    DiverseSamenwerkingsverbanden = 53,

    /// <summary>
    ///     GGZ-instellingen (PUK/PAAZ)
    /// </summary>
    GGZInstellingen = 54,

    /// <summary>
    ///     consultatiebureaus voor alcohol en drugs (CAD)
    /// </summary>
    ConsultatiebureausAlcoholDrugs = 56,

    /// <summary>
    ///     physician assistant
    /// </summary>
    PhysicianAssistant = 57,

    /// <summary>
    ///     centrale post ambulancediensten (CPA)
    /// </summary>
    CentralePostAmbulancediensten = 58,

    /// <summary>
    ///     instellingen voor dagverpleging voor ouderen
    /// </summary>
    InstellingenDagverplegingOuderen = 60,

    /// <summary>
    ///     beheerstichtingen dagverblijven
    /// </summary>
    BeheerstichtingenDagverblijven = 61,

    /// <summary>
    ///     gezinsvervangende tehuizen
    /// </summary>
    GezinsvervangendeTehuizen = 65,

    /// <summary>
    ///     koepels en beheerstichtingen WLZ
    /// </summary>
    KoepelsBeheerstichtingen = 66,

    /// <summary>
    ///     netwerkorganisaties
    /// </summary>
    Netwerkorganisaties = 67,

    /// <summary>
    ///     kinderdagverblijven
    /// </summary>
    Kinderdagverblijven = 70,

    /// <summary>
    ///     RIBW
    /// </summary>
    RIBW = 72,

    /// <summary>
    ///     WLZ gecombineerd
    /// </summary>
    GecombineerdeWLZ = 73,

    /// <summary>
    ///     arbodiensten
    /// </summary>
    Arbodiensten = 74,

    /// <summary>
    ///     thuiszorginstellingen
    /// </summary>
    Thuiszorginstellingen = 75,

    /// <summary>
    ///     leveranciers hulpmiddelen
    /// </summary>
    LeveranciersHulpmiddelen = 76,

    /// <summary>
    ///     sociaal-pedagogische diensten
    /// </summary>
    SociaalPedagogischeDiensten = 78,

    /// <summary>
    ///     Riagg
    /// </summary>
    Riagg = 79,

    /// <summary>
    ///     overige artsen
    /// </summary>
    OverigeArtsen = 84,

    /// <summary>
    ///     taxivervoerders
    /// </summary>
    TaxiVervoerders = 85,

    /// <summary>
    ///     mondhygiënisten
    /// </summary>
    Mondhygienisten = 87,

    /// <summary>
    ///     ergotherapeuten
    /// </summary>
    Ergotherapeuten = 88,

    /// <summary>
    ///     schoonheidsspecialisten
    /// </summary>
    Schoonheidsspecialisten = 89,

    /// <summary>
    ///     overige therapeuten en complementair en aanvullende zorg
    /// </summary>
    OverigeTherapeuten = 90,

    /// <summary>
    ///     verpleegkundigen
    /// </summary>
    Verpleegkundigen = 91,

    /// <summary>
    ///     tandtechnici / tandprothetici
    /// </summary>
    Tandtechnici = 93,

    /// <summary>
    ///     psychologisch zorgverleners
    /// </summary>
    PsychologischZorgverleners = 94,

    /// <summary>
    ///     pedicuren
    /// </summary>
    Pedicuren = 96,

    /// <summary>
    ///     declaranten / servicebureaus / zorgverzekeraars
    /// </summary>
    Declaranten = 98
}