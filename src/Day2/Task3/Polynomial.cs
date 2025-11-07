namespace Day2.Task3;

public class Polynomial
{
    private readonly double[] _coefficients;

    public Polynomial(params double[] coefficients)
    {
        if (coefficients == null || coefficients.Length == 0){
            throw new ArgumentException("Polynomial must have at least one coefficient.");
        }

        _coefficients = new double[coefficients.Length];
        Array.Copy(coefficients, _coefficients, coefficients.Length);
    }

    public int GetDegree => _coefficients.Length - 1;
    private double this[int i] => i >= 0 && i < _coefficients.Length ? _coefficients[i] : 0;


    public static Polynomial operator +(Polynomial left, Polynomial right)
    {
        if (left is null) 
        {
            throw new ArgumentNullException($"{nameof(left)} cant be null");
        }
        if (right is null) 
        {
            throw new ArgumentNullException($"{nameof(right)} cant be null" ); 
        }

        int MaxDegree = Math.Max(left.GetDegree, right.GetDegree);
        double[] coefficients = new double[MaxDegree + 1];

        for (int i = 0; i <= MaxDegree; i++)
            coefficients[i] = left[i] + right[i];

        return new Polynomial(coefficients);
    }

    public static Polynomial operator -(Polynomial left, Polynomial right)
    {
        if (left is null)
        {
            throw new ArgumentNullException($"{nameof(left)} cant be null");
        }
        if (right is null)
        {
            throw new ArgumentNullException($"{nameof(right)} cant be null");
        }

        int MaxDegree = Math.Max(left.GetDegree, right.GetDegree);
        double[] coefficients = new double[MaxDegree + 1];

        for (int i = 0; i <= MaxDegree; i++)
            coefficients[i] = left[i] - right[i];

        return new Polynomial(coefficients);
    }

    public static Polynomial operator *(Polynomial left, Polynomial right)
    {
        if (left is null)
        {
            throw new ArgumentNullException($"{nameof(left)} cant be null");
        }
        if (right is null)
        {
            throw new ArgumentNullException($"{nameof(right)} cant be null");
        }

        double[] coefficients = new double[left.GetDegree + right.GetDegree + 1];

        for (int i = 0; i <= left.GetDegree; i++)
        {
            for (int j = 0; j <= right.GetDegree; j++)
            {
                coefficients[i + j] += left[i] * right[j];
            }
        }

        return new Polynomial(coefficients);
    }

    public static bool operator ==(Polynomial left, Polynomial right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        if (left.GetDegree != right.GetDegree) return false;

        for (int i = 0; i <= left.GetDegree; i++)
        {
            if (left[i] != right[i])
                return false;
        }

        return true;
    }

    public static bool operator !=(Polynomial left, Polynomial right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals (this, obj)) return true;
        if (obj == null || obj.GetType() != typeof(Polynomial)) return false;

        var other = obj as Polynomial;

        if (this._coefficients.Length != other.GetDegree) return false;

        for (int i = 0; i <= other.GetDegree; i++)
        {
            if (this[i] != other[i])
                return false;
        }
        
        return true;
    }

    public override int GetHashCode()
    {
        var rnd = new Random();
        int hash = 1;
        foreach (var c in _coefficients)
            hash = hash * rnd.Next(30, 100) + c.GetHashCode();
        
        return hash;
    }

    public override string ToString()
    {
        var terms = new List<string>();
        for (int i = _coefficients.Length - 1; i >= 0; i--)
        {
            double coeff = _coefficients[i];
            if (coeff == 0) continue;

            string term = i switch
            {
                0 => $"{coeff}",
                1 => $"{coeff}x",
                _ => $"{coeff}x^{i}"
            };
            terms.Add(term);
        }
     
        return string.Join(" + ", terms);
    }
}
