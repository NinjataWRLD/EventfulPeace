using EventfulPeace.Domain.Common.TypedIds;

namespace EventfulPeace.Domain.Events;

public static class EventConstants
{
    public const int NameMaxLength = 100;
    public const int NameMinLength = 5;

    public const int DescriptionMaxLength = 1000;
    public const int DescriptionMomLength = 20;

    public static class Locations
    {
        public static readonly LocationId Blagoevgrad = LocationId.New(Guid.Parse("a77afb62-ec0c-4322-9ea7-474641d76164"));
        public static readonly LocationId Burgas = LocationId.New(Guid.Parse("b60131ca-1d56-4e4e-b43e-b68eed269473"));
        public static readonly LocationId Shumen = LocationId.New(Guid.Parse("30822e93-9470-4f10-b6ae-70a2f512228a"));
        public static readonly LocationId Dobrich = LocationId.New(Guid.Parse("f6ef9357-e048-4ee4-b7e3-82082d304b93"));
        public static readonly LocationId Gabrovo = LocationId.New(Guid.Parse("faf4e858-44ad-40bc-98f1-2e0e7b9e65f1"));
        public static readonly LocationId Kardjali = LocationId.New(Guid.Parse("2bf2c22b-325b-42e5-ae3e-23a20c69408d"));
        public static readonly LocationId Haskovo = LocationId.New(Guid.Parse("2a316f7e-0112-4815-8033-18c6cda5f3b6"));
        public static readonly LocationId Kyustendil = LocationId.New(Guid.Parse("84b77c7d-f9d4-4e85-a468-67fc3a60a124"));
        public static readonly LocationId Lovech = LocationId.New(Guid.Parse("ac80410e-d7f5-41cc-92de-649bc134c963"));
        public static readonly LocationId Montana = LocationId.New(Guid.Parse("0ff3a9fb-1c7e-4313-bf81-6bfe5c05445d"));
        public static readonly LocationId Pazardjik = LocationId.New(Guid.Parse("2885a542-2b35-4cd3-9cfa-2ebf23e80ea1"));
        public static readonly LocationId Pernik = LocationId.New(Guid.Parse("60dc9276-4645-4098-866e-0dc330829d3e"));
        public static readonly LocationId Pleven = LocationId.New(Guid.Parse("be84bfbb-2aa8-40be-a028-99ec8c07c7fa"));
        public static readonly LocationId Plovdiv = LocationId.New(Guid.Parse("233a5b44-aefd-4163-94ac-7c9d921d8129"));
        public static readonly LocationId Razgrad = LocationId.New(Guid.Parse("5f035f95-28bd-4cee-ae2d-40c921f29a1d"));
        public static readonly LocationId Ruse = LocationId.New(Guid.Parse("51e0aff1-47fa-4f3b-82a0-b41fa2851a58"));
        public static readonly LocationId Smolyan = LocationId.New(Guid.Parse("4402ee9e-8b3e-45c1-859e-c7c707be1fd1"));
        public static readonly LocationId Sliven = LocationId.New(Guid.Parse("67ef3033-def7-4211-8f09-a03243a33fff"));
        public static readonly LocationId Sofia = LocationId.New(Guid.Parse("e3c0e30b-5587-4c1a-a864-db1d66a9c3e0"));
        public static readonly LocationId StaraZagora = LocationId.New(Guid.Parse("06102732-56c9-425b-831a-cf2d8de5476c"));
        public static readonly LocationId Targovishte = LocationId.New(Guid.Parse("2d562197-83b2-472e-a5d7-8ee789b4cfc3"));
        public static readonly LocationId Varna = LocationId.New(Guid.Parse("8b921b20-b3c5-469a-b01c-4683c3a885a7"));
        public static readonly LocationId VelikoTarnovo = LocationId.New(Guid.Parse("42a6aff1-d977-4ef0-90ca-097ebeeb4eea"));
        public static readonly LocationId Vidin = LocationId.New(Guid.Parse("b54800f9-a8d7-4200-ba0a-04ea90919374"));
        public static readonly LocationId Vratsa = LocationId.New(Guid.Parse("c9c7eed3-189a-419d-8dc3-ecae6a41aa77"));
        public static readonly LocationId Yambol = LocationId.New(Guid.Parse("9da8e2be-fcd9-408e-93a7-aeda0febafef"));
    }
}
