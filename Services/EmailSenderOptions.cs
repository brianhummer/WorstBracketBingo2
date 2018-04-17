using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorstBracketBingo.Services
{
    public class EmailSenderOptions
    {
        private string _smtpConfig { get; set; }
        public string SmtpConfig
        {
            get { return this._smtpConfig; }
            set
            {
                this._smtpConfig = value;

                // smtpConfig is in username:password@localhost:1025 format; extract the part
                var smtpConfigPartsRegEx = new Regex(@"(.*)\:(.*)@(.+)\:(.+)");
                var smtpConfigPartsMatch = smtpConfigPartsRegEx.Match(value);

                this.Username = smtpConfigPartsMatch.Groups[1].Value;
                this.Password = smtpConfigPartsMatch.Groups[2].Value;
                this.Host = smtpConfigPartsMatch.Groups[3].Value;
                this.Port = Convert.ToInt32(smtpConfigPartsMatch.Groups[4].Value);
            }
        }

        public string EmailFromName { get; set; }
        public string EmailFromAddress { get; set; }

        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Host { get; protected set; }
        public int Port { get; protected set; }
    }
}
