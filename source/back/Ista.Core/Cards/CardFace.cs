namespace Ista.Domain.Cards
{
    public class Face
    {
        public string Text { get; init; }

        public static Face FromText(string text) => new Face() { Text = text };
    }
}
