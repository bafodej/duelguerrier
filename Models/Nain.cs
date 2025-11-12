namespace DuelGuerrier.Models;

public class Nain : Guerrier
{
    private bool _armureLourde;

    public bool ArmureLourde { get { return _armureLourde; } set { _armureLourde = value; } }

    public Nain(string nom, int pointDeVie, int nbAttaque, bool armureLourde) : base(nom, pointDeVie, nbAttaque)
    {
        _armureLourde = armureLourde;
    }

    public override void SubirDegat(int degatSubit)
    {
        PointDeVie -= degatSubit / 2;
        if (PointDeVie < 0) PointDeVie = 0;
    }
}
