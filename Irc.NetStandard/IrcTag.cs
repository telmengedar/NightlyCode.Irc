using System.Text;

namespace NightlyCode.IRC {

    /// <summary>
    /// attribute in <see cref="IrcMessage"/>
    /// </summary>
    public class IrcTag {

        /// <summary>
        /// creates a new <see cref="IrcTag"/>
        /// </summary>
        /// <param name="vendor">vendor of attribute</param>
        /// <param name="key">attribute key</param>
        /// <param name="value">attribute value</param>
        public IrcTag(string vendor, string key, string value)
            : this(key, value)
        {
            Vendor = vendor;
        }

        /// <summary>
        /// creates a new <see cref="IrcTag"/>
        /// </summary>
        /// <param name="key">attribute key</param>
        /// <param name="value">attribute value</param>
        public IrcTag(string key, string value) {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// key vendor (optional)
        /// </summary>
        public string Vendor { get; }

        /// <summary>
        /// key name
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// attribute value (optional)
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString() {
            StringBuilder sb = string.IsNullOrEmpty(Vendor) ? new StringBuilder(Key) : new StringBuilder(Vendor).Append("/").Append(Key);
            if(!string.IsNullOrEmpty(Value)) {
                sb.Append('=');
                foreach(char character in Value) {
                    switch(character) {
                        case ';':
                            sb.Append("\\:");
                            break;
                        case ' ':
                            sb.Append("\\s");
                            break;
                        case '\\':
                            sb.Append("\\\\");
                            break;
                        case '\r':
                            sb.Append("\\r");
                            break;
                        case '\n':
                            sb.Append("\\n");
                            break;
                        default:
                            sb.Append(character);
                            break;
                    }
                }
            }
            return sb.ToString();
        }
    }
}