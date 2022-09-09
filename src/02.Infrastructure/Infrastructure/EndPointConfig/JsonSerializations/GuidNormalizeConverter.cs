namespace Infrastructure.EndPointConfig.JsonSerializations;

internal class GuidNormalizeConverter : JsonConverter<Guid>
{
    public override Guid Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return new Guid(reader.GetString()!);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Guid value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("N"));
    }
}

internal class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader,
        Type typeToConvert, JsonSerializerOptions options)
    {
        var splitTimeSpan = reader.GetString()
            !.Split(":");

        return new TimeSpan(int.Parse(splitTimeSpan[0])
            , int.Parse(splitTimeSpan[1])
            , 0);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeSpan value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("hh\\:mm\\:ss"));
    }
}