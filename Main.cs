namespace SandBox
{   
    public class Program
    {

        public class Human
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Relation> Relations { get; set; } = new List<Relation>();
        }

        public class Relation
        {
            public Human Node1 { get; set; }
            public Human Node2 { get; set; }
            public RelationType RelationType { get; set; }
        }

        public enum RelationType
        {
            HusbandWife = 1,
            FatherDaughter = 2,
            MotherDaughter = 3,
            FatherSon = 4,
            MotherSon = 5,
            GrandfatherGrandson = 6,
            GrandfatherGranddaughter = 7,
            GrandmotherGrandson = 8,
            GrandmotherGranddaughter = 9,
        }

        public static void Main(string[] arrayOfServersNames)
        {
            Human andrei = new Human { Id = 1, Name = "Andrei" };
            Human alena = new Human { Id = 2, Name = "Alena" };

            Relation andreiAlenaRelation = new Relation { Node1 = andrei, Node2 = alena, RelationType = RelationType.HusbandWife };
            
            andrei.Relations.Add(andreiAlenaRelation);
            alena.Relations.Add(andreiAlenaRelation);

            Human anna = new Human { Id = 3, Name = "Anna" };
            
            Relation alenaAnnaRelation = new Relation { Node1 = alena, Node2 = anna, RelationType = RelationType.MotherDaughter };
            
            alena.Relations.Add(alenaAnnaRelation);
            anna.Relations.Add(alenaAnnaRelation);

            Relation andreiAnnaRelation = new Relation { Node1 = andrei, Node2 = anna, RelationType = RelationType.FatherDaughter };

            andrei.Relations.Add(andreiAnnaRelation);
            anna.Relations.Add(andreiAnnaRelation);

            Human grandfaterOfAndrei = new Human { Id = 4, Name = "Andrei's Grandfather" };

            Relation andreiGrandfatherRelation = new Relation { Node1 = andrei, Node2 = grandfaterOfAndrei, RelationType = RelationType.FatherSon };

            andrei.Relations.Add(andreiGrandfatherRelation);
            grandfaterOfAndrei.Relations.Add(andreiGrandfatherRelation);

            Relation annaGrandfatherRelation = new Relation { Node1 = anna, Node2 = grandfaterOfAndrei, RelationType = RelationType.GrandfatherGranddaughter };
            anna.Relations.Add(annaGrandfatherRelation);
            grandfaterOfAndrei.Relations.Add(annaGrandfatherRelation);

            foreach (var relation in andrei.Relations)
            {
                Console.WriteLine($"Human: {andrei.Name}, Relation: {relation.Node1.Name} - {relation.Node2.Name}, Type: {relation.RelationType}");
            }

            foreach (var relation in alena.Relations)
            {
                Console.WriteLine($"Human: {alena.Name}, Relation: {relation.Node1.Name} - {relation.Node2.Name}, Type: {relation.RelationType}");
            }

            foreach (var relation in anna.Relations)
            {
                Console.WriteLine($"Human: {anna.Name}, Relation: {relation.Node1.Name} - {relation.Node2.Name}, Type: {relation.RelationType}");
            }

            foreach (var relation in grandfaterOfAndrei.Relations)
            {
                Console.WriteLine($"Human: {grandfaterOfAndrei.Name}, Relation: {relation.Node1.Name} - {relation.Node2.Name}, Type: {relation.RelationType}");
            }
        }
    }
}