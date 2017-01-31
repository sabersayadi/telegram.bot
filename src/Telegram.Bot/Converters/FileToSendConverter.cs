using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters
{
    internal class FileToSendConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var fts = (FileToSend)value;
            switch (fts.Type)
            {
                case FileType.Id:
                    writer.WriteValue(fts.FileId);
                   // ''''cfghgvhvhjvjbhjbh
                    break;
                case FileType.Url:
                    writer.WriteValue(fts.Url);
                    break;
                default:
                    throw new NotSupportedException("File Type not supported");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Uri uri;

            var value = reader.ReadAsString();

            if (Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out uri))
            {
                return new FileToSend(uri);
            }
            else
            {
                return new FileToSend(value);
            }
        }

        public override bool CanConvert(Type objectType)
            => (typeof(FileToSend) == objectType);

    }
}
