namespace DuelGuerrier.Models;

public class Guerrier
{
    protected string _nom;
    protected int _pointDeVie;
    protected int _nbAttaque;

    public string Nom { get { return _nom; } set { _nom = value; } }
    public int PointDeVie { get { return _pointDeVie; } set { _pointDeVie = value; } }
    public int NbAttaque { get { return _nbAttaque; } set { _nbAttaque = value; } }

    public Guerrier(string nom, int pointDeVie, int nbAttaque)
    {
        _nom = nom;
        _pointDeVie = pointDeVie;
        _nbAttaque = nbAttaque;
    }

    public void AfficherInfos()
    {
        Console.WriteLine($"Nom : {Nom} ; PV = {PointDeVie} ; Nombres d'attaques = {NbAttaque}");
    }

    public virtual int Attaquer()
    {
        Random deLancer = new Random();
        int degatSubit = 0;
        for (int i = 0; i < NbAttaque; i++)
        {
            degatSubit += deLancer.Next(1, 7);
        }
        return degatSubit;
    }

    public virtual void SubirDegat(int degatSubit)
    {
        PointDeVie -= degatSubit;
        if (PointDeVie < 0) PointDeVie = 0;
    }
}
