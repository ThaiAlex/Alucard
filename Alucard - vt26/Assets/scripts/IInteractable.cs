public interface IInteractable
{
    // Telmuun 24

    void Interact(); // Vad som händer när spelaren interagerar (t.ex. öppna kista)

    bool CanInteract(); // Returnerar true/false om spelaren får interagera just nu
}
