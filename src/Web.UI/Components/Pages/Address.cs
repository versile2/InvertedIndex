namespace Web.UI.Components.Pages
{
    public class Address
    {
        public string street_line { get; set; } = string.Empty;
        public string secondary { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public int entries { get; set; } = 0;
        public string source { get; set; } = string.Empty;
        public string source_formatted
        {
            get
            {
                if (source == "MANUAL") return "MANUAL";
                if (entries > 0) return "SMARTY";
                if (string.IsNullOrEmpty(source)) return "UNKNOWN";
                else return (source ?? "UNKNOWN").ToUpper();
            }
        }
        // Return Formatted Address
        public string address
        {
            get
            {
                string formatted = "";
                try
                {
                    string street = street_line;
                    // Add secondary address if it exists
                    if (!string.IsNullOrEmpty(secondary)) street += " " + secondary;

                    // Check if address contains multiple entries
                    if (entries > 1) formatted = $"{street} ({entries}) {city}, {state} {zipcode}".Trim();
                    else formatted = $"{street} {city}, {state} {zipcode}".Trim();

                    // If an invalid address, return empty string
                    if (formatted.Trim() == ",") formatted = "";

                    // If formatted address ends with "," remove it
                    if (formatted.EndsWith(",")) formatted = formatted.Substring(0, formatted.Length - 1).Trim();

                    // If Source is Manual, Return Formatted Message
                    if (source == "MANUAL") return "MANUAL ENTRY: " + formatted;

                    if (formatted.Trim().Length == 1) return formatted;
                    else return formatted;
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
