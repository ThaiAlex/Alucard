public interface IInteractable
{
    // Telmuun 24

    void Interact(); // Vad som h�nder n�r spelaren interagerar (t.ex. �ppna kista)

    bool CanInteract(); // Returnerar true/false om spelaren f�r interagera just nu
}
