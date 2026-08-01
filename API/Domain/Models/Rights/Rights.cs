namespace Domain.Models.Rights
{
    public static class Rights
    {
        public static void Check()
        {
            _ = CarGet;
            _ = CarAdminGet;
            _ = CarCreate;
            _ = CarUpdate;
            _ = CarDelete;

            _ = ParkGet;
            _ = ParkAdminGet;
            _ = ParkCreate;
            _ = ParkUpdate;
            _ = ParkDelete;

            _ = PositionGet;
            _ = PositionAdminGet;
            _ = PositionCreate;
            _ = PositionUpdate;
            _ = PositionDelete;
        }
        
        public static Right CarGet { get; } =       RightFactory.Create(1, "car").WithProperty(1, "id").AllowsGet();
        public static Right CarAdminGet { get; } =  RightFactory.Create(1, "car").AllowsGet().LevelAdmin();
        public static Right CarCreate { get; } =    RightFactory.Create(1, "car").AllowsCreate();
        public static Right CarUpdate { get; } =    RightFactory.Create(1, "car").AllowsUpdate();
        public static Right CarDelete { get; } =    RightFactory.Create(1, "car").AllowsDelete();

        public static Right ParkGet { get; } =      RightFactory.Create(2, "park").AllowsGet();
        public static Right ParkAdminGet { get; } = RightFactory.Create(2, "park").AllowsGet().LevelAdmin();
        public static Right ParkCreate { get; } =   RightFactory.Create(2, "park").AllowsCreate();
        public static Right ParkUpdate { get; } =   RightFactory.Create(2, "park").AllowsUpdate();
        public static Right ParkDelete { get; } =   RightFactory.Create(2, "park").AllowsDelete();

        public static Right PositionGet { get; } =      RightFactory.Create(3, "position").AllowsGet();
        public static Right PositionAdminGet { get; } = RightFactory.Create(3, "position").AllowsGet().LevelAdmin();
        public static Right PositionCreate { get; } =   RightFactory.Create(3, "position").AllowsCreate();
        public static Right PositionUpdate { get; } =   RightFactory.Create(3, "position").AllowsUpdate();
        public static Right PositionDelete { get; } =   RightFactory.Create(3, "position").AllowsDelete();
    }
}
