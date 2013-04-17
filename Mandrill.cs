using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mandrill
{
    public class MailEvent
    {
        [JsonProperty(PropertyName = "ts")]
        public string TimeStamp { get; set; }

        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "msg")]
        public Message Msg { get; set; }
    }

    public class Message
    {
        [JsonProperty(PropertyName = "raw_msg")]
        public string RawMessage { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public Header Header { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }

        [JsonProperty(PropertyName = "from_email")]
        public string FromEmail { get; set; }

        [JsonProperty(PropertyName = "from_name")]
        public string FromName { get; set; }

        // Not sure why Mandrill sends an array of arrays here...
        [JsonProperty(PropertyName = "to")]
        public string[][] To { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public string Sender { get; set; }

        [JsonProperty(PropertyName = "dkim")]
        public DKIM DKIM { get; set; }

        [JsonProperty(PropertyName = "spf")]
        public SPF SPF { get; set; }

        [JsonProperty(PropertyName = "spam_report")]
        public SpamReport SpamReport { get; set; }
    }

    [JsonDictionary()]
    public class Header : Dictionary<string, object>
    {
        // Need to find a nicer way of doing this... Dictionary<string, object> is kinda dumb
    }

    public class SpamReport
    {
        [JsonProperty(PropertyName = "score")]
        public decimal Score { get; set; }

        [JsonProperty(PropertyName = "matched_rules")]
        public SpamRule[] MatchedRules { get; set; }
    }

    public class SpamRule
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "score")]
        public decimal Score { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public class DKIM
    {
        [JsonProperty(PropertyName = "signed")]
        public bool Signed { get; set; }

        [JsonProperty(PropertyName = "valid")]
        public bool Valid { get; set; }
    }

    public class SPF
    {
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; set; }
    }
}