namespace DuelGuerrier.Models;

public class Elfe : Guerrier
{
    public Elfe(string nom, int pointDeVie, int nbAttaque) : base(nom, pointDeVie, nbAttaque) { }

    public override int Attaquer()
    {
        Random deLancer = new Random();
        int degatSubit = 0;
        for (int i = 0; i < NbAttaque; i++)
        {
            degatSubit += deLancer.Next(4, 9);
        }
        return degatSubit;
    }

    public override void SubirDegat(int degatSubit)
    {
        PointDeVie -= degatSubit / 2;
        if (PointDeVie < 0) PointDeVie = 0;
    }
}
