namespace BoardgameSimulator.MySqlDB
{
    using System.Collections.Generic;
    using Models;
    using Telerik.OpenAccess.Metadata.Fluent;

    public class ModelConfiguration : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var armyvsarmyMapping = new MappingConfiguration<ArmyVsArmyReport>();

            armyvsarmyMapping.MapType(report => new
            {
                Id = report.Id,
                Army1Id = report.Army1Id,
                UnitName1 = report.UnitName1,
                UnitQuantity1 = report.UnitQuantity1,
                Army2Id = report.Army2Id,
                UnitName2 = report.UnitName2,
                UnitQuantity2 = report.UnitQuantity2
            }).ToTable("ArmyVsArmyReport");

            armyvsarmyMapping.HasProperty(c => c.Id).IsIdentity();

            configurations.Add(armyvsarmyMapping);

            return configurations;
        }
    }
}
