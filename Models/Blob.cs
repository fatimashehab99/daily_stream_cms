namespace daily_stream_cms.Models
{
    public class Blob
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string? Type { get; set; }

        public double? Size { get; set; }

        public string? Ext { get; set; }

        public string Name { get; set; }

        public string Directory { get; set; }

    }
}
