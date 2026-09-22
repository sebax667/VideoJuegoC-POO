using System;

public class Personaje
{
    public string nombre;
    public int vida;
    public int nivel;
    public int ataque;

    // Constructor 1: sin parámetros
    public Personaje()
    {
        this.nombre = "Mario";
        this.vida = 100;
        this.nivel = 1;
        this.ataque = 12;
    }

    // Constructor 2: recibe solo nombre
    public Personaje(string nombre)
    {
        this.nombre = nombre;
        this.vida = 100;
        this.nivel = 1;
        this.ataque = 18;
    }

    // Constructor 3: recibe nombre, vida, nivel y ataque
    public Personaje(string nombre, int vida, int nivel, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.nivel = nivel;
        this.ataque = ataque;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Nombre: {this.nombre}");
        Console.WriteLine($"Vida: {this.vida}");
        Console.WriteLine($"Nivel: {this.nivel}");
        Console.WriteLine($"Ataque: {this.ataque}");
        Console.WriteLine("--------------------------------------------------");
    }

    public void RecibirDanio(int cantidad)
    {
        this.vida = this.vida - cantidad;

        if (this.vida < 0)
        {
            this.vida = 0;
        }

        Console.WriteLine($"{this.nombre} recibe {cantidad} puntos de daño. Vida restante: {this.vida}");
    }

    public void Curar(int cantidad)
    {
        this.vida = this.vida + cantidad;
        Console.WriteLine($"{this.nombre} usa una poción y recupera {cantidad} puntos de vida.");
    }

    public void SubirNivel()
    {
        this.nivel = this.nivel + 1;
        this.ataque = this.ataque + 5;
        Console.WriteLine($"{this.nombre} ha subido al nivel {this.nivel}. Su ataque aumenta a {this.ataque}.");
    }

    public void Atacar(Personaje enemigo)
    {
        Console.WriteLine($"{this.nombre} lanza un ataque poderoso contra {enemigo.nombre}.");
        enemigo.RecibirDanio(this.ataque);
        Console.WriteLine($"El ataque causa {this.ataque} de daño.");
    }

    public int ObtenerVida()
    {
        return this.vida;
    }

    public bool EstaVivo()
    {
        return this.vida > 0;
    }
}

public class Program
{
    public static void Main()
    {
        // Instancias con los 3 constructores diferentes
        Personaje kratos = new Personaje("Kratos", 150, 6, 35);
        Personaje masterChief = new Personaje("Master Chief");
        Personaje mario = new Personaje();

        Console.WriteLine("=== ESTADO INICIAL ===");
        kratos.MostrarInformacion();
        masterChief.MostrarInformacion();
        mario.MostrarInformacion();
        Console.WriteLine();

        Console.WriteLine("=== COMBATE ===");

        // 1. Un personaje ataca a otro
        kratos.Atacar(masterChief);

        // 2. Un personaje recibe daño
        masterChief.RecibirDanio(12);

        // 3. Un personaje usa Curar
        mario.Curar(25);

        // 4. Un personaje usa SubirNivel
        mario.SubirNivel();

        Console.WriteLine();

        Console.WriteLine("=== ESTADO FINAL ===");
        kratos.MostrarInformacion();
        masterChief.MostrarInformacion();
        mario.MostrarInformacion();
        Console.WriteLine();

        Console.WriteLine("=== COMPROBACION DE VIDA ===");
        Console.WriteLine($"Kratos esta vivo: {kratos.EstaVivo()}");
        Console.WriteLine($"Master Chief esta vivo: {masterChief.EstaVivo()}");
        Console.WriteLine($"Mario esta vivo: {mario.EstaVivo()}");
    }
}