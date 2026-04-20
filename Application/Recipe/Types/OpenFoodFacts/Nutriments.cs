using MongoDB.Bson.Serialization.Attributes;

namespace BackendServer.Application.Recipe.Types.OpenFoodFacts;

[BsonIgnoreExtraElements]
public class Nutriments
{
    [BsonElement("added-sugars")] public double? AddedSugars { get; set; }

    [BsonElement("added-sugars_100g")]
    public double? AddedSugars100g { get; set; }

    [BsonElement("added-sugars_modifier")]
    public string? AddedSugarsModifier { get; set; }

    [BsonElement("added-sugars_unit")]
    public string? AddedSugarsUnit { get; set; }

    [BsonElement("added-sugars_value")]
    public double? AddedSugarsValue { get; set; }

    [BsonElement("carbohydrates")] public double? Carbohydrates { get; set; }

    [BsonElement("carbohydrates_100g")]
    public double? Carbohydrates100g { get; set; }

    [BsonElement("carbohydrates_unit")]
    public string? CarbohydratesUnit { get; set; }

    [BsonElement("carbohydrates_value")]
    public double? CarbohydratesValue { get; set; }

    [BsonElement("energy")] public double? Energy { get; set; }
    [BsonElement("energy-kcal")] public double? EnergyKcal { get; set; }
    [BsonElement("energy-kcal_100g")] public double? EnergyKcal100g { get; set; }
    [BsonElement("energy-kcal_unit")] public string? EnergyKcalUnit { get; set; }

    [BsonElement("energy-kcal_value")]
    public double? EnergyKcalValue { get; set; }

    [BsonElement("energy-kj")] public double? EnergyKj { get; set; }
    [BsonElement("energy-kj_100g")] public double? EnergyKj100g { get; set; }

    [BsonElement("energy-kj_modifier")]
    public string? EnergyKjModifier { get; set; }

    [BsonElement("energy-kj_unit")] public string? EnergyKjUnit { get; set; }
    [BsonElement("energy-kj_value")] public double? EnergyKjValue { get; set; }

    [BsonElement("energy_100g")] public double? Energy100g { get; set; }
    [BsonElement("energy_modifier")] public string? EnergyModifier { get; set; }
    [BsonElement("energy_unit")] public string? EnergyUnit { get; set; }
    [BsonElement("energy_value")] public double? EnergyValue { get; set; }

    [BsonElement("fat")] public double? Fat { get; set; }
    [BsonElement("fat_100g")] public double? Fat100g { get; set; }
    [BsonElement("fat_unit")] public string? FatUnit { get; set; }
    [BsonElement("fat_value")] public double? FatValue { get; set; }

    [BsonElement("fruits-vegetables-legumes-estimate-from-ingredients_100g")]
    public double? FruitsVegetablesLegumesEstimateFromIngredients100g { get; set; }

    [BsonElement("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
    public double? FruitsVegetablesNutsEstimateFromIngredients100g { get; set; }

    [BsonElement("nova-group")] public int? NovaGroup { get; set; }
    [BsonElement("nova-group_100g")] public int? NovaGroup100g { get; set; }

    [BsonElement("nova-group_serving")]
    public int? NovaGroupServing { get; set; }

    [BsonElement("nova-group_unit")] public string? NovaGroupUnit { get; set; }
    [BsonElement("nova-group_value")] public int? NovaGroupValue { get; set; }

    [BsonElement("proteins")] public double? Proteins { get; set; }
    [BsonElement("proteins_100g")] public double? Proteins100g { get; set; }
    [BsonElement("proteins_unit")] public string? ProteinsUnit { get; set; }
    [BsonElement("proteins_value")] public double? ProteinsValue { get; set; }

    [BsonElement("salt")] public double? Salt { get; set; }
    [BsonElement("salt_100g")] public double? Salt100g { get; set; }
    [BsonElement("salt_unit")] public string? SaltUnit { get; set; }
    [BsonElement("salt_value")] public double? SaltValue { get; set; }

    [BsonElement("sodium")] public double? Sodium { get; set; }
    [BsonElement("sodium_100g")] public double? Sodium100g { get; set; }
    [BsonElement("sodium_unit")] public string? SodiumUnit { get; set; }
    [BsonElement("sodium_value")] public double? SodiumValue { get; set; }

    [BsonElement("sugars")] public double? Sugars { get; set; }
    [BsonElement("sugars_100g")] public double? Sugars100g { get; set; }
    [BsonElement("sugars_unit")] public string? SugarsUnit { get; set; }
    [BsonElement("sugars_value")] public double? SugarsValue { get; set; }
}