using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Castle.Core.Logging;
using FluentAssertions;
using Moksnes.CurrencyConverter.Shared;
using Xunit;

namespace Moksnes.CurrencyConverter.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void GivenJson_WhenDeserialize_ShouldDeserializeRates()
        {
            var jsonString =
                "{\"motd\":{\"msg\":\"If you or your company use this project or like what we doing, please consider backing us so we can continue maintaining and evolving this project.\",\"url\":\"https://exchangerate.host/#/donate\"},\"success\":true,\"base\":\"SEK\",\"date\":\"2021-11-24\",\"rates\":{\"AED\":0.406264,\"AFN\":10.417296,\"ALL\":11.935563,\"AMD\":52.731556,\"ANG\":0.199475,\"AOA\":64.702429,\"ARS\":11.123967,\"AUD\":0.15347,\"AWG\":0.199112,\"AZN\":0.188084,\"BAM\":0.192533,\"BBD\":0.221312,\"BDT\":9.490164,\"BGN\":0.19257,\"BHD\":0.041729,\"BIF\":220.34265,\"BMD\":0.110577,\"BND\":0.151357,\"BOB\":0.764023,\"BRL\":0.616323,\"BSD\":0.1106,\"BTC\":0.000002,\"BTN\":8.231373,\"BWP\":1.294849,\"BYN\":0.278005,\"BZD\":0.223036,\"CAD\":0.140384,\"CDF\":221.376062,\"CHF\":0.103302,\"CLF\":0.003269,\"CLP\":89.997243,\"CNH\":0.707068,\"CNY\":0.706996,\"COP\":434.131127,\"CRC\":70.817593,\"CUC\":0.110597,\"CUP\":2.848013,\"CVE\":10.855658,\"CZK\":2.509552,\"DJF\":19.696691,\"DKK\":0.731534,\"DOP\":6.264479,\"DZD\":15.384659,\"EGP\":1.738189,\"ERN\":1.659105,\"ETB\":5.327833,\"EUR\":0.098377,\"FJD\":0.233779,\"FKP\":0.082738,\"GBP\":0.082801,\"GEL\":0.344004,\"GGP\":0.082766,\"GHS\":0.678002,\"GIP\":0.082798,\"GMD\":5.790102,\"GNF\":1055.628967,\"GTQ\":0.855941,\"GYD\":23.141096,\"HKD\":0.861993,\"HNL\":2.66847,\"HRK\":0.740285,\"HTG\":10.956038,\"HUF\":36.38987,\"IDR\":1578.103445,\"ILS\":0.346797,\"IMP\":0.082767,\"INR\":8.239314,\"IQD\":161.42436,\"IRR\":4674.333296,\"ISK\":14.518857,\"JEP\":0.082761,\"JMD\":17.221861,\"JOD\":0.078492,\"JPY\":12.718546,\"KES\":12.409629,\"KGS\":9.377451,\"KHR\":449.981064,\"KMF\":48.427315,\"KPW\":99.542177,\"KRW\":131.472515,\"KWD\":0.033613,\"KYD\":0.092217,\"KZT\":48.023905,\"LAK\":1193.776684,\"LBP\":167.30937,\"LKR\":22.43213,\"LRD\":15.807862,\"LSL\":1.751302,\"LYD\":0.509071,\"MAD\":1.02226,\"MDL\":1.959983,\"MGA\":441.035749,\"MKD\":6.063237,\"MMK\":196.716269,\"MNT\":316.129819,\"MOP\":0.888204,\"MRO\":39.485078,\"MRU\":4.01073,\"MUR\":4.810106,\"MVR\":1.708866,\"MWK\":90.325946,\"MXN\":2.350338,\"MYR\":0.465601,\"MZN\":7.061183,\"NAD\":1.754251,\"NGN\":45.473118,\"NIO\":3.897948,\"NOK\":0.986193,\"NPR\":13.17014,\"NZD\":0.16027,\"OMR\":0.042685,\"PAB\":0.110598,\"PEN\":0.443723,\"PGK\":0.391499,\"PHP\":5.593682,\"PKR\":19.392408,\"PLN\":0.462615,\"PYG\":756.623486,\"QAR\":0.402778,\"RON\":0.486965,\"RSD\":11.565721,\"RUB\":8.21782,\"RWF\":114.529258,\"SAR\":0.41497,\"SBD\":0.890636,\"SCR\":1.473292,\"SDG\":48.388615,\"SEK\":1,\"SGD\":0.151172,\"SHP\":0.082817,\"SLL\":1216.687083,\"SOS\":64.002355,\"SRD\":2.380574,\"SSP\":14.407095,\"STD\":2343.530854,\"STN\":2.454849,\"SVC\":0.968228,\"SYP\":277.888573,\"SZL\":1.751477,\"THB\":3.690628,\"TJS\":1.249735,\"TMT\":0.387243,\"TND\":0.319902,\"TOP\":0.250212,\"TRY\":1.41948,\"TTD\":0.752161,\"TWD\":3.074355,\"TZS\":254.385561,\"UAH\":2.975587,\"UGX\":394.988757,\"USD\":0.110618,\"UYU\":4.87094,\"UZS\":1191.066076,\"VES\":0.502027,\"VND\":2508.32917,\"VUV\":12.361976,\"WST\":0.283931,\"XAF\":64.521175,\"XAG\":0.004789,\"XAU\":0.000145,\"XCD\":0.298957,\"XDR\":0.079172,\"XOF\":64.521121,\"XPD\":0.000136,\"XPF\":11.737775,\"XPT\":0.000186,\"YER\":27.678268,\"ZAR\":1.754855,\"ZMW\":1.952853,\"ZWL\":35.614013}}";
            var result = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonString, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = false,
            });
            result.Rates.Should().NotBeEmpty();
        }
    }
}