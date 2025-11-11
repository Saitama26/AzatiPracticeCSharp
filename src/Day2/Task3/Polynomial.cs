namespace Day2.Task3;
public class Polynomial : IEquatable<Polynomial>, ICloneable, IComparable<Polynomial>
{
    private readonly double[] _coefficients;
    private int GetDegree => _coefficients.Length - 1;
    private double this[int i] => i >= 0 && i < _coefficients.Length ? _coefficients[i] : 0;

    public Polynomial(params double[] coefficients)
    {
        if (coefficients == null || coefficients.Length == 0)
        {
            throw new ArgumentException("Polynomial must have at least one coefficient.");
        }

        _coefficients = new double[coefficients.Length];
        Array.Copy(coefficients, _coefficients, coefficients.Length);
    }

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

        var MaxDegree = Math.Max(left.GetDegree, right.GetDegree);
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

        var MaxDegree = Math.Max(left.GetDegree, right.GetDegree);
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

        return left.Equals(right);
    }

    public static bool operator !=(Polynomial left, Polynomial right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Polynomial);
        
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var c in _coefficients)
                hash = hash * 31 + c.GetHashCode();
            return hash;
        }
    }

    public override string ToString()
    {
        var terms = new List<string>();
        for (int i = _coefficients.Length - 1; i >= 0; i--)
        {
            var coeff = _coefficients[i];
            if (coeff == 0) continue;

            var term = i switch
            {
                0 => $"{coeff}",
                1 => $"{coeff}x",
                _ => $"{coeff}x^{i}"
            };
            terms.Add(term);
        }
     
        return string.Join(" + ", terms);
    }

    public bool Equals(Polynomial? other)
    {
        if (other == null) return false;
        
        if (_coefficients.Length - 1 != other.GetDegree) return false;

        for (int i = 0; i <= other.GetDegree; i++)
        {
            if (this[i] != other[i])
                return false;
        }

        return true;
    }

    public object Clone()
    {
        return new Polynomial((double[])_coefficients.Clone());
    }

    public int CompareTo(Polynomial? other)
    {
        if (other == null) return 1; 

        if (GetDegree != other.GetDegree)
            return GetDegree.CompareTo(other.GetDegree);

        for (int i = GetDegree; i >= 0; i--)
        {
            int cmp = _coefficients[i].CompareTo(other[i]);
            if (cmp != 0)
                return cmp;
        }

        return 0;
    }
}