using Newtonsoft.Json;
using Steam.Api.Clients.StoreApi.Responses.Enums;
using Steam.Api.Clients.StoreApi.Responses.JsonConverters;

namespace Steam.Api.Clients.StoreApi.Responses
{
    [JsonConverter(typeof(TestConverter))]
    public class SteamApp
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("steam_appid")]
        //public int SteamAppId { get; set; }

        //[JsonProperty("required_age")]
        //public int RequiredAge { get; set; }

        //[JsonProperty("is_free")]
        //public bool IsFree { get; set; }

        //[JsonProperty("detailed_description")]
        //public string DetailedDescription { get; set; }

        //[JsonProperty("about_the_game")]
        //public string AboutTheGame { get; set; }

        //[JsonProperty("short_description")]
        //public string ShortDescription { get; set; }

        //[JsonProperty("supported_languages")]
        //public string SupportedLanguages { get; set; }

        //[JsonProperty("header_image")]
        //public string HeaderImage { get; set; }

        //[JsonProperty("website")]
        //public string Website { get; set; }

        //[JsonProperty("pc_requirements", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(RequirementsJsonConverter))]
        //public Requirements PcRequirements { get; set; }

        //[JsonProperty("mac_requirements", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(RequirementsJsonConverter))]
        //public Requirements MacRequirements { get; set; }

        //[JsonProperty("linux_requirements", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(RequirementsJsonConverter))]
        //public Requirements LinuxRequirements { get; set; }

        //[JsonProperty("legal_notice")]
        //public string LegalNotice { get; set; }

        //[JsonProperty("developers")]
        //public string[] Developers { get; set; }

        //[JsonProperty("publishers")]
        //public string[] Publishers { get; set; }

        //[JsonProperty("price_overview")]
        //public PriceOverview PriceOverview { get; set; }

        //[JsonProperty("packages")]
        //public long[] Packages { get; set; }

        //[JsonProperty("package_groups")]
        //public PackageGroup[] PackageGroups { get; set; }

        //[JsonProperty("platforms")]
        //public Platforms Platforms { get; set; }

        //[JsonProperty("categories")]
        //public Category[] Categories { get; set; }

        //[JsonProperty("genres")]
        //public Genre[] Genres { get; set; }

        //[JsonProperty("screenshots")]
        //public Screenshot[] Screenshots { get; set; }

        //[JsonProperty("movies")]
        //public Movie[] Movies { get; set; }

        //[JsonProperty("recommendations")]
        //public Recommendations Recommendations { get; set; }

        //[JsonProperty("achievements")]
        //public Achievements Achievements { get; set; }

        //[JsonProperty("release_date")]
        //public ReleaseDate ReleaseDate { get; set; }

        //[JsonProperty("support_info")]
        //public SupportInfo SupportInfo { get; set; }

        //[JsonProperty("background")]
        //public string Background { get; set; }

        //[JsonProperty("controller_support", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ControllerSupportJsonConverter))]
        //public ControllerSupportEnum? ControllerSupport { get; set; }

        //[JsonProperty("dlc")]
        //public int[] DLC { get; set; }

        //[JsonProperty("reviews")]
        //public string Reviews { get; set; }
    }

    //public class Requirements
    //{
    //    [JsonProperty("minimum", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Minimum { get; set; }

    //    [JsonProperty("recommended", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Recommended { get; set; }

    //    public Requirements()
    //    {
    //    }
    //}

    //public class PriceOverview
    //{
    //    [JsonProperty("currency")]
    //    public string Currency { get; set; }

    //    [JsonProperty("initial")]
    //    [JsonConverter(typeof(SteamPriceJsonConverter))]
    //    public double Initial { get; set; }

    //    [JsonProperty("final")]
    //    [JsonConverter(typeof(SteamPriceJsonConverter))]
    //    public double Final { get; set; }

    //    [JsonProperty("discount_percent")]
    //    public int DiscountPercent { get; set; }

    //    [JsonProperty("individual", NullValueHandling = NullValueHandling.Ignore)]
    //    [JsonConverter(typeof(SteamPriceJsonConverter))]
    //    public double Individual { get; set; }

    //    public PriceOverview()
    //    {
    //    }
    //}

    //public class PackageGroup
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("title")]
    //    public string Title { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    [JsonProperty("selection_text")]
    //    public string SelectionText { get; set; }

    //    [JsonProperty("save_text")]
    //    public string SaveText { get; set; }

    //    [JsonProperty("display_type")]
    //    public long DisplayType { get; set; }

    //    [JsonProperty("is_recurring_subscription")]
    //    public string IsRecurringSubscription { get; set; }

    //    [JsonProperty("subs")]
    //    public Sub[] Subs { get; set; }

    //    public PackageGroup()
    //    {
    //    }
    //}

    //public class Sub
    //{
    //    [JsonProperty("packageid")]
    //    public int Packageid { get; set; }

    //    [JsonProperty("percent_savings_text")]
    //    public string PercentSavingsText { get; set; }

    //    [JsonProperty("percent_savings")]
    //    public int PercentSavings { get; set; }

    //    [JsonProperty("option_text")]
    //    public string OptionText { get; set; }

    //    [JsonProperty("option_description")]
    //    public string OptionDescription { get; set; }

    //    [JsonProperty("can_get_free_license")]
    //    public string CanGetFreeLicense { get; set; }

    //    [JsonProperty("is_free_license")]
    //    public bool IsFreeLicense { get; set; }

    //    [JsonProperty("price_in_cents_with_discount")]
    //    public long PriceInCentsWithDiscount { get; set; }

    //    public Sub()
    //    {
    //    }
    //}

    //public class Platforms
    //{
    //    [JsonProperty("windows")]
    //    public bool Windows { get; set; }

    //    [JsonProperty("mac")]
    //    public bool Mac { get; set; }

    //    [JsonProperty("linux")]
    //    public bool Linux { get; set; }

    //    public Platforms()
    //    {
    //    }
    //}

    //public class Category
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    public Category()
    //    {
    //    }
    //}

    //public class Genre
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("description")]
    //    public string Description { get; set; }

    //    public Genre()
    //    {
    //    }
    //}

    //public class Movie
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("thumbnail")]
    //    public string Thumbnail { get; set; }

    //    [JsonProperty("webm")]
    //    public IReadOnlyDictionary<string, string> Webm { get; set; } = new Dictionary<string, string>();

    //    [JsonProperty("highlight")]
    //    public bool Highlight { get; set; }

    //    public Movie()
    //    {
    //    }
    //}

    //public class Recommendations
    //{
    //    [JsonProperty("total")]
    //    public long Total { get; set; }

    //    public Recommendations()
    //    {
    //    }
    //}

    //public class Achievements
    //{
    //    [JsonProperty("total")]
    //    public long Total { get; set; }

    //    [JsonProperty("highlighted")]
    //    public Highlighted[] Highlighted { get; set; }

    //    public Achievements()
    //    {
    //    }
    //}

    //public class Highlighted
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("path")]
    //    public string Path { get; set; }

    //    public Highlighted()
    //    {
    //    }
    //}

    //public class ReleaseDate
    //{
    //    [JsonProperty("coming_soon")]
    //    public bool ComingSoon { get; set; }

    //    [JsonProperty("date")]
    //    public string Date { get; set; }

    //    public ReleaseDate()
    //    {
    //    }
    //}

    //public class SupportInfo
    //{
    //    [JsonProperty("url")]
    //    public string Url { get; set; }

    //    [JsonProperty("email")]
    //    public string Email { get; set; }

    //    public SupportInfo()
    //    {
    //    }
    //}

    //public class Screenshot
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("path_thumbnail")]
    //    public string PathThumbnail { get; set; }

    //    [JsonProperty("path_full")]
    //    public string PathFull { get; set; }

    //    public Screenshot()
    //    {
    //    }
    //}
}
