namespace EncounterHelper
{
    public abstract class IEncounterParticipant
    {
        public abstract string Name { get; set; }
        public abstract int AC { get; set; }
        public abstract int CurrentHitsPoints { get; set; }
        public abstract int Initiative { get; set; }

        public abstract string GetDetails();
    }
}