using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace IdentityServer4SpaClient.DataModels.Helpers
{
    public class MessageResult: Dictionary<string, string>
    {
        public string MessageKey { get; set; }

        public MessageResult(string messageKey)
        {
            MessageKey = messageKey;
        }   

        public string ToJson()
        {
            dynamic messageResultObject = new ExpandoObject();

            var messageArgumentsObject = new ExpandoObject() as IDictionary<string, object>;

            foreach (string argKey in Keys)
            {
                messageArgumentsObject.Add(argKey, this[argKey]);
            }

            messageResultObject.messageKey = MessageKey;
            messageResultObject.messageArguments = messageArgumentsObject;

            return JsonConvert.SerializeObject(messageResultObject);
        }
    }
}