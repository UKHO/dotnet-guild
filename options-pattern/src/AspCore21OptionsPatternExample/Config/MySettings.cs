using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core21OptionsPatternExample.Config
{
    public class MySettings
    {
        [Required]
        public string MyString { get; set; }

        [Range(1, 10, ErrorMessage = "MyNumber must be between 1 and 10")]
        public int MyNumber { get; set; } = 19;

        public Uri MyUri { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Missing config value MyBool")]
        public bool MyBool { get; set; }

        public string MyIpAddress { get; set; }

        public string MyEnvString { get; set; }

        public string MySecretString { get; set; }

        public IEnumerable<string> Validate()
        {
            string pattern =
                @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            var regex = new Regex(pattern);
            if (string.IsNullOrEmpty(MyIpAddress) || !regex.Match(this.MyIpAddress).Success)
                yield return $"Valid IP address not supplied for {nameof(MyIpAddress)}";
        }
    }
}