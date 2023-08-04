﻿using System.Collections.Generic;

namespace Peereflits.Shared.Types.Phone;

public class CountryCodes : Dictionary<int, string>
{
    public CountryCodes()
    {
        this[1] = "Verenigde Staten en Canada";
        this[7] = "Rusland en Kazachstan";
        this[20] = "Egypte";
        this[27] = "Zuid-Afrika";
        this[30] = "Griekenland";
        this[31] = "Nederland";
        this[32] = "België";
        this[33] = "Frankrijk";
        this[34] = "Spanje";
        this[36] = "Hongarije";
        this[39] = "Italië";
        this[40] = "Roemenië";
        this[41] = "Zwitserland";
        this[43] = "Oostenrijk";
        this[44] = "Verenigd Koninkrijk";
        this[45] = "Denemarken";
        this[46] = "Zweden";
        this[47] = "Noorwegen";
        this[48] = "Polen";
        this[49] = "Duitsland";
        this[51] = "Peru";
        this[52] = "Mexico";
        this[53] = "Cuba";
        this[54] = "Argentinië";
        this[55] = "Brazilië";
        this[56] = "Chili";
        this[57] = "Colombia";
        this[58] = "Venezuela";
        this[60] = "Maleisië";
        this[61] = "Australië";
        this[62] = "Indonesië";
        this[63] = "Filipijnen";
        this[64] = "Nieuw-Zeeland";
        this[65] = "Singapore";
        this[66] = "Thailand";
        this[81] = "Japan";
        this[82] = "Zuid-Korea";
        this[84] = "Vietnam";
        this[86] = "China";
        this[90] = "Turkije";
        this[91] = "India";
        this[92] = "Pakistan";
        this[93] = "Afghanistan";
        this[94] = "Sri Lanka";
        this[95] = "Myanmar";
        this[98] = "Iran";
        this[211] = "Zuid-Soedan";
        this[212] = "Marokko";
        this[213] = "Algerije";
        this[216] = "Tunesië";
        this[218] = "Libië";
        this[220] = "Gambia";
        this[221] = "Senegal";
        this[222] = "Mauritanië";
        this[223] = "Mali";
        this[224] = "Guinee";
        this[225] = "Ivoorkust";
        this[226] = "Burkina Faso";
        this[227] = "Niger";
        this[228] = "Togo";
        this[229] = "Benin";
        this[230] = "Mauritius";
        this[231] = "Liberia";
        this[232] = "Sierra Leone";
        this[233] = "Ghana";
        this[234] = "Nigeria";
        this[235] = "Tsjaad";
        this[236] = "Centraal-Afrikaanse Republiek";
        this[237] = "Kameroen";
        this[238] = "Kaapverdië";
        this[239] = "Sao Tomé en Principe";
        this[240] = "Equatoriaal-Guinea";
        this[241] = "Gabon";
        this[242] = "Congo-Brazzaville";
        this[243] = "Congo-Kinshasa";
        this[244] = "Angola";
        this[245] = "Guinee-Bissau";
        this[246] = "Diego Garcia";
        this[247] = "Ascension";
        this[248] = "Seychellen";
        this[249] = "Soedan";
        this[250] = "Rwanda";
        this[251] = "Ethiopië";
        this[252] = "Somalië";
        this[253] = "Djibouti";
        this[254] = "Kenia";
        this[255] = "Tanzania";
        this[256] = "Oeganda";
        this[257] = "Burundi";
        this[258] = "Mozambique";
        this[260] = "Zambia";
        this[261] = "Madagaskar";
        this[262] = "Réunion";
        this[263] = "Zimbabwe";
        this[264] = "Namibië";
        this[265] = "Malawi";
        this[266] = "Lesotho";
        this[267] = "Botswana";
        this[268] = "Swaziland";
        this[269] = "Comoren";
        this[290] = "Sint-Helena";
        this[291] = "Eritrea";
        this[297] = "Aruba";
        this[298] = "Faeröer";
        this[299] = "Groenland";
        this[350] = "Gibraltar";
        this[351] = "Portugal";
        this[352] = "Luxemburg";
        this[353] = "Ierland";
        this[354] = "IJsland";
        this[355] = "Albanië";
        this[356] = "Malta";
        this[357] = "Cyprus";
        this[358] = "Finland";
        this[359] = "Bulgarije";
        this[370] = "Litouwen";
        this[371] = "Letland";
        this[372] = "Estland";
        this[373] = "Moldavië";
        this[374] = "Armenië";
        this[375] = "Wit-Rusland";
        this[376] = "Andorra";
        this[377] = "Monaco";
        this[378] = "San Marino";
        this[379] = "Vaticaanstad";
        this[380] = "Oekraïne";
        this[381] = "Servië";
        this[382] = "Montenegro";
        this[385] = "Kroatië";
        this[386] = "Slovenië";
        this[387] = "Bosnië en Herzegovina";
        this[388] = "ETNS";
        this[389] = "Noord-Macedonië";
        this[420] = "Tsjechië";
        this[421] = "Slowakije";
        this[423] = "Liechtenstein";
        this[500] = "Falklandeilanden";
        this[501] = "Belize";
        this[502] = "Guatemala";
        this[503] = "El Salvador";
        this[504] = "Honduras";
        this[505] = "Nicaragua";
        this[506] = "Costa Rica";
        this[507] = "Panama";
        this[508] = "Saint-Pierre en Miquelon";
        this[509] = "Haïti";
        this[590] = "Guadeloupe, Saint-Barthélemy en Saint-Martin";
        this[591] = "Bolivia";
        this[592] = "Guyana";
        this[593] = "Ecuador";
        this[594] = "Frans-Guyana";
        this[595] = "Paraguay";
        this[596] = "Martinique";
        this[597] = "Suriname";
        this[598] = "Uruguay";
        this[599] = "Curaçao en Caribisch Nederland";
        this[670] = "Oost-Timor";
        this[672] = "Australisch Antarctica";
        this[673] = "Brunei";
        this[674] = "Nauru";
        this[675] = "Papoea-Nieuw-Guinea";
        this[676] = "Tonga";
        this[677] = "Salomonseilanden";
        this[678] = "Vanuatu";
        this[679] = "Fiji";
        this[680] = "Palau";
        this[681] = "Wallis en Futuna";
        this[682] = "Cookeilanden";
        this[683] = "Niue";
        this[684] = "Amerikaans-Samoa";
        this[685] = "Samoa";
        this[686] = "Kiribati";
        this[687] = "Nieuw-Caledonië";
        this[688] = "Tuvalu";
        this[689] = "Frans-Polynesië";
        this[690] = "Tokelau";
        this[691] = "Micronesia";
        this[692] = "Marshalleilanden";
        this[800] = "Internationale gratis nummers";
        this[850] = "Noord-Korea";
        this[852] = "Hongkong";
        this[853] = "Macau";
        this[855] = "Cambodja";
        this[856] = "Laos";
        this[870] = "InmarSat satelliet-telefoon alle regio's";
        this[871] = "InmarSat satelliet-telefoon Atlantic East";
        this[872] = "InmarSat satelliet-telefoon Pacific";
        this[873] = "InmarSat satelliet-telefoon Indian";
        this[874] = "InmarSat satelliet-telefoon Atlantic West";
        this[880] = "Bangladesh";
        this[886] = "Taiwan";
        this[960] = "Maldiven";
        this[961] = "Libanon";
        this[962] = "Jordanië";
        this[963] = "Syrië";
        this[964] = "Irak";
        this[965] = "Koeweit";
        this[966] = "Saoedi-Arabië";
        this[967] = "Jemen";
        this[968] = "Oman";
        this[970] = "Palestina";
        this[971] = "Verenigde Arabische Emiraten";
        this[972] = "Israël";
        this[973] = "Bahrein";
        this[974] = "Qatar";
        this[975] = "Bhutan";
        this[976] = "Mongolië";
        this[977] = "Nepal";
        this[992] = "Tadzjikistan";
        this[993] = "Turkmenistan";
        this[994] = "Azerbeidzjan";
        this[995] = "Georgië";
        this[996] = "Kirgizië";
        this[998] = "Oezbekistan";
        this[1242] = "Bahama's";
        this[1246] = "Barbados";
        this[1264] = "Anguilla";
        this[1268] = "Antigua en Barbuda";
        this[1284] = "Britse Maagdeneilanden";
        this[1340] = "Amerikaanse Maagdeneilanden";
        this[1345] = "Kaaimaneilanden";
        this[1441] = "Bermuda";
        this[1473] = "Grenada";
        this[1649] = "Turks- en Caicoseilanden";
        this[1664] = "Montserrat";
        this[1670] = "Noordelijke Marianen";
        this[1671] = "Guam";
        this[1721] = "Sint Maarten";
        this[1758] = "Saint Lucia";
        this[1767] = "Dominica";
        this[1784] = "Saint Vincent en de Grenadines";
        this[1787] = "Puerto Rico";
        this[1809] = "Dominicaanse Republiek";
        this[1868] = "Trinidad en Tobago";
        this[1869] = "Saint Kitts en Nevis";
        this[1876] = "Jamaica";
        this[1907] = "Alaska";
        this[1939] = "Puerto Rico";
        this[2696] = "Mayotte";
        this[6723] = "Norfolk";
        this[8816] = "Iridium satelliet-telefoon";
        this[8817] = "Iridium satelliet-telefoon";
    }
}